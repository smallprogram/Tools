using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System;
using System.IO;
using System.DirectoryServices.ActiveDirectory;

namespace FilesRanameTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_getpath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件所在文件夹";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show(this, "文件夹路径不能为空", "提示");
                    return;
                }
                tb_path.Text = dialog.SelectedPath;
            }
        }

        private void btn_starRename_Click(object sender, EventArgs e)
        {
            Ui_Star();

            if (tb_path.Text.Length == 0)
            {
                MessageBox.Show(this, "文件夹路径不能为空", "提示");
                Ui_Stop();
                return;
            }

            if (tb_exname.Text == "")
            {
                MessageBox.Show(this, "文件扩展名不能为空", "提示");
                Ui_Stop();
                return;
            }
            tb_exname.Text = tb_exname.Text.Replace(".", "");

            if (tb_renameRule.Text.IndexOf('$') == -1)
            {
                MessageBox.Show(this, "重命名规则没有包含$符号", "提示");
                Ui_Stop();
                return;
            }

            if (tb_renameRule.Text.Count(s => (s == '$')) > 1)
            {
                MessageBox.Show(this, "重命名规则包含多个$符号", "提示");
                Ui_Stop();
                return;
            }

            if (tb_oldnameRule.Text.Count(s => (s == '$')) > 1)
            {
                MessageBox.Show(this, "原文件名规则包含多个$符号", "提示");
                Ui_Stop();
                return;
            }

            bool isHaveOldnameRule = true;
            if (tb_oldnameRule.Text.IndexOf('$') == -1 || tb_oldnameRule.Text == "")
            {
                isHaveOldnameRule = false;
            }



            DirectoryInfo folder = new DirectoryInfo(tb_path.Text.Trim());

            var files = folder.GetFiles("*." + tb_exname.Text);

            if (files.Length <= 0)
            {
                MessageBox.Show(this, $"所选路径下，没有扩展名为{tb_exname.Text}的文件", "提示");
                Ui_Stop();
                return;
            }

            rtb_log.Text = "";
            rtb_log.Text += $"{tb_path.Text}文件夹下共有{files.Length}个{tb_exname.Text}文件!\r\n";
            rtb_log.Text += $"开始按照命名规则批量重命名文件！\r\n";
            if (isHaveOldnameRule)
            {
                foreach (FileInfo file in files)
                {
                    string NewName = "";
                    int fileIndex = tb_oldnameRule.Text.IndexOf("$");
                    string Oldnumber = "";
                    if (fileIndex == 0)
                    {
                        char char1 = tb_oldnameRule.Text[fileIndex + 1];
                        Oldnumber = file.Name.Substring(0, file.Name.IndexOf(char1));
                    }
                    else
                    {
                        if (fileIndex == tb_oldnameRule.Text.Length - 1)
                        {
                            char char1 = tb_oldnameRule.Text[fileIndex - 1];
                            Oldnumber = file.Name.Substring(file.Name.IndexOf(char1) + 1);
                        }
                        else
                        {
                            char char1 = tb_oldnameRule.Text[fileIndex - 1];
                            char char2 = tb_oldnameRule.Text[fileIndex + 1];
                            Oldnumber = file.Name.Substring(file.Name.IndexOf(char1) + 1, file.Name.IndexOf(char2) - (file.Name.IndexOf(char1) + 1));
                        }
                    }

                    int oldNumberInt = 0;
                    try
                    {
                        oldNumberInt = Int32.Parse(Oldnumber);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, $"获取原始序号出错，有可能原始序号不能转换为数字，详细信息：\r\n {ex.Message}", "提示");
                        Ui_Stop();
                        return;
                    }

                    int totalNumberLength = files.Length.ToString().Length;
                    int currentNumberLength = oldNumberInt.ToString().Length;

                    string NewNumber = "";
                    for (int i = 0; i < totalNumberLength - currentNumberLength; i++)
                    {
                        NewNumber += "0";
                    }
                    NewNumber += oldNumberInt.ToString();

                    NewName = tb_renameRule.Text.Replace("$", NewNumber);
                    string OldName = file.Name;
                    if (file.Exists)
                    {
                        // Move file with a new name. Hence renamed.  
                        file.MoveTo(@$"{file.DirectoryName}\{NewName}.{tb_exname.Text}");
                    }




                    rtb_log.Text += $"已将文件 {OldName} 重命名为 {NewName}.{tb_exname.Text} \r\n";
                }
                rtb_log.Text += $"重命名完毕！ \r\n";
            }
            else
            {
                string NewName = "";
                for (int f = 0; f < files.Length; f++)
                {
                    int totalNumberLength = files.Length.ToString().Length;

                    string NewNumber = "";
                    for (int i = 1; i <= totalNumberLength - f.ToString().Length; i++)
                    {
                        NewNumber += "0";
                    }
                    NewNumber += f.ToString();

                    NewName = tb_renameRule.Text.Replace("$", NewNumber);
                    string OldName = files[f].Name;
                    if (files[f].Exists)
                    {
                        // Move file with a new name. Hence renamed.  
                        files[f].MoveTo(@$"{files[f].DirectoryName}\{NewName}.{tb_exname.Text}");
                    }

                    rtb_log.Text += $"已将文件 {OldName} 重命名为 {NewName}.{tb_exname.Text} \r\n";
                }
                rtb_log.Text += $"重命名完毕！ \r\n";
            }

            
            Ui_Stop();
        }


        private void Ui_Star()
        {
            tb_exname.ReadOnly = true;
            tb_renameRule.ReadOnly = true;
            tb_oldnameRule.ReadOnly = true;
            btn_getpath.Enabled = false;
            btn_starRename.Enabled = false;
            btn_starRename.Text = "正在批量重命名...";
        }

        private void Ui_Stop()
        {
            tb_exname.ReadOnly = false;
            tb_renameRule.ReadOnly = false;
            tb_oldnameRule.ReadOnly = false;
            btn_getpath.Enabled = true;
            btn_starRename.Enabled = true;
            btn_starRename.Text = "批量重命名";
        }
    }
}