using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FileOrganizer
{
    class Program
    {
        /// <summary>
        /// 从文件名中提取所有汉字（连续的汉字块会合并）
        /// </summary>
        private static string ExtractChinese(string fileName)
        {
            // \p{IsCJKUnifiedIdeographs} 匹配 Unicode 汉字
            var matches = Regex.Matches(fileName, @"\p{IsCJKUnifiedIdeographs}+");
            // 把所有匹配的汉字块拼接成一个字符串
            return string.Concat(matches.Cast<Match>().Select(m => m.Value));
        }

        /// <summary>
        /// 为文件夹名添加后缀，避免同名冲突
        /// </summary>
        private static string GetUniqueFolderPath(string baseFolderName)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), baseFolderName);
            int index = 1;
            while (Directory.Exists(folderPath))
            {
                string newName = $"{baseFolderName}({index})";
                folderPath = Path.Combine(Directory.GetCurrentDirectory(), newName);
                index++;
            }
            return folderPath;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== 文件整理工具 ===\n");

            while (true)
            {
                // 1. 读取当前目录所有文件并按名称排序
                string[] allFiles = Directory.GetFiles(".", "*.*", SearchOption.TopDirectoryOnly)
                                             .OrderBy(f => Path.GetFileName(f))
                                             .ToArray();

                if (allFiles.Length == 0)
                {
                    Console.WriteLine("当前目录已无文件，程序结束。");
                    break;
                }

                // 取第一个文件（已排序）
                string firstFilePath = allFiles[0];
                string firstFileName = Path.GetFileName(firstFilePath);

                // 2. 提取文件名中的汉字
                string chineseKey = ExtractChinese(firstFileName);
                if (string.IsNullOrEmpty(chineseKey))
                {
                    Console.WriteLine($"文件 [{firstFileName}] 中未检测到汉字，跳过本次处理。");
                    // 直接删除该文件（或移动到回收站），这里选择直接跳过
                    // 若想删除可取消注释下一行
                    // File.Delete(firstFilePath);
                    continue;
                }

                // 3. 模糊查找包含该汉字的所有文件
                var matchedFiles = allFiles
                    .Where(f => Path.GetFileName(f).Contains(chineseKey))
                    .ToList();

                // 打印匹配结果
                Console.WriteLine($"\n使用关键词【{chineseKey}】共找到 {matchedFiles.Count} 个文件：");
                foreach (var f in matchedFiles)
                {
                    Console.WriteLine(Path.GetFileName(f));
                }

                // 4. 以第一个文件的「完整文件名（不带扩展名）」作为文件夹名
                string folderBaseName = Path.GetFileNameWithoutExtension(firstFileName);
                string folderPath = GetUniqueFolderPath(folderBaseName);
                Directory.CreateDirectory(folderPath);
                Console.WriteLine($"\n已创建文件夹：{folderPath}");

                // 询问用户是否移动
                Console.Write("\n是否将以上文件移动到该文件夹？(y/n, 默认 n)：");
                string answer = Console.ReadLine()?.Trim().ToLower() ?? "n";

                if (answer != "y")
                {
                    // 用户取消 → 删除刚创建的空文件夹并退出
                    Directory.Delete(folderPath, false);
                    Console.WriteLine("操作已取消，程序退出。");
                    break;
                }

                // 5. 移动文件
                foreach (var src in matchedFiles)
                {
                    string fileName = Path.GetFileName(src);
                    string dest = Path.Combine(folderPath, fileName);

                    // 若目标已存在（极少见），自动重命名
                    dest = GetUniqueFilePath(dest);
                    File.Move(src, dest);
                    Console.WriteLine($"已移动：{fileName} → {folderPath}");
                }

                Console.WriteLine("\n移动完成，准备处理下一批文件...\n");
                // 循环会重新读取目录，继续处理剩余文件
            }

            Console.WriteLine("\n按任意键退出...");
            Console.ReadKey();
        }

        /// <summary>
        /// 为目标文件路径添加后缀，避免同名冲突
        /// </summary>
        private static string GetUniqueFilePath(string filePath)
        {
            string dir = Path.GetDirectoryName(filePath);
            string name = Path.GetFileNameWithoutExtension(filePath);
            string ext = Path.GetExtension(filePath);
            int index = 1;
            while (File.Exists(filePath))
            {
                string newName = $"{name}({index}){ext}";
                filePath = Path.Combine(dir, newName);
                index++;
            }
            return filePath;
        }
    }
}