using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkAsyncAwait
{
    public interface IProgress
    {
        public void Log(long total, long current);
    }

    public class Progress : IProgress
    {
        public void Log(long total, long current)
        {
            Console.WriteLine(current * 100 / total);
        }
    }

    public class Reader
    {
        private readonly string _filePath;
        private readonly IProgress _progress;

        public Reader(string path, IProgress tracker)
        {
            _filePath = path;
            _progress = tracker;
        }

        public async Task<string> GetFileContent()
        {
            var file = new FileInfo(_filePath);
            long total = file.Length;
            long current = 0;

            var buffer = new char[4096];
            var content = new StringBuilder();

            using (var reader = new StreamReader(_filePath))
            {
                int read;
                while ((read = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    current += read;
                    content.Append(buffer, 0, read);
                    _progress.Log(total, current);
                }
            }

            return content.ToString();
        }
    }
}
