using HomeWorkAsyncAwait;
using System;
using System.Threading.Tasks;

namespace AsyncTasks
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                // Путь к файлу — замените на реальный путь на вашем компьютере
                string filePath = @"C:\Games\shellsort_result.txt";

                // Создаем трекер прогресса
                IProgress progress = new Progress();

                // Создаем Reader
                var reader = new Reader(filePath, progress);

                // Читаем файл асинхронно
                Console.WriteLine("Начинаем чтение файла...");
                string content = await reader.DownloadFile();

                // Выводим результат
                Console.WriteLine("Файл успешно прочитан. Содержимое:");
                Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
                Console.WriteLine(ex.GetType());
            }
        }
    }
}