using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        // 已知的解密密钥 其实无所谓
        byte[] decryptionKey = Encoding.UTF8.GetBytes("72Fhskjglp8qjpqx"); // 16, 24, or 32 bytes long

        while (true)
        {
            // 获取用户输入的加密密钥（十六进制字符串）
            Console.WriteLine("Enter the encrypted key (hexadecimal string) or '0' to exit:");
            string encryptedKeyHex = Console.ReadLine();

            // 检查用户是否输入了退出标志
            if (encryptedKeyHex == "0")
            {
                break;
            }

            try
            {
                // 尝试将输入的十六进制字符串转换为字节数组
                byte[] encryptedKey = StringToByteArray(encryptedKeyHex);

                // 检查数据长度是否为16字节的倍数
                if (encryptedKey.Length % 16 != 0)
                {
                    throw new ArgumentException("The length of the encrypted key must be a multiple of 16 bytes.");
                }

                // 创建AES解密器
                using (Aes aes = Aes.Create())
                {
                    aes.Key = decryptionKey;
                    aes.Mode = CipherMode.ECB; // 使用ECB模式
                    aes.Padding = PaddingMode.None; // ECB模式下不需要填充

                    // 创建解密器对象
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, null); // 不使用IV

                    // 解密
                    byte[] decryptedKey = decryptor.TransformFinalBlock(encryptedKey, 0, encryptedKey.Length);

                    // 输出解密后的密钥
                    Console.WriteLine("Decrypted Video Key: " + Encoding.UTF8.GetString(decryptedKey).TrimEnd('\0'));
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid hexadecimal string. Please try again.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (CryptographicException)
            {
                Console.WriteLine("Error during decryption. Please ensure the input and key are correct.");
            }
        }
    }

    // 辅助函数：将十六进制字符串转换为字节数组
    static byte[] StringToByteArray(string hex)
    {
        int length = hex.Length;
        byte[] bytes = new byte[length / 2];
        for (int i = 0; i < length; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        }
        return bytes;
    }
}