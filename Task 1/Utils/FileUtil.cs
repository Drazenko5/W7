using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Utils
{
    public class FileUtil
    {

        private static readonly int BUFFER_LENGTH = 1024;

        public static async void CopyFileAsync(string sourcePath, string destinationPath)
        {

            if (!File.Exists(sourcePath))
                throw new FileNotFoundException("File not exists", sourcePath);

            using (FileStream inputStream = File.OpenRead(sourcePath))
            {
                if (!inputStream.CanRead)
                    throw new UnauthorizedAccessException("Doesn't have permission for read source file");

                using (FileStream outputStream = File.Create(destinationPath))
                {
                    byte[] buffer = new byte[BUFFER_LENGTH];
                    int readCount = 0;
                    while ((readCount = await inputStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await outputStream.WriteAsync(buffer, 0, readCount);
                    }
                    Console.WriteLine("File successfully copied");
                }
            }

        }
    }
}