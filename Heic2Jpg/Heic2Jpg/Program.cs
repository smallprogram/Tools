// See https://aka.ms/new-console-template for more information
using ImageMagick;

var files = Directory.GetFiles("./input/");

await Parallel.ForEachAsync(files, async (fileName, _) => await ConvertFile(fileName));


static async Task ConvertFile(string fileName)
{
    string ext = Path.GetExtension(fileName).ToLowerInvariant();
    if (ext == ".heic")
    {
        Console.WriteLine($"发现 {Path.GetFileName(fileName)}. 转换为JPG...");
        await ConvertHEIC(MagickFormat.Jpg, fileName, "./output");
    }
    else
    {
        Console.WriteLine($"{Path.GetFileName(fileName)} 不是 .HEIC... 跳过该文件");
    }
}

static async Task ConvertHEIC(MagickFormat convertToFormat, string fileName, string outputPath)
{
    try
    {
        using var image = new MagickImage(fileName);
        image.Format = convertToFormat;
        await image.WriteAsync($"{outputPath}/{Path.GetFileNameWithoutExtension(fileName)}.jpg");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"不能写入路径: {Path.GetFileName(fileName)}. 错误信息: {ex.Message}");
    }
}
