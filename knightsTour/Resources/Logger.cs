using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace knightsTour.Resources
{
    public class Logger
    {
        private FileStream stream;

        public Logger(string fileName)
        {
            stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Write, 4096, useAsync: true); ;
        }

        public async void WriteToFileAsync(string content)
        {
            var bytes = Encoding.UTF8.GetBytes(content);
            await stream.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}
