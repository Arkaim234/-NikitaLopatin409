using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WpfDeadLockusing
{
    public static class DeadLock
    {
        public static async Task<string[]> ParseAsync(string[] urls)
        {
            using var httpClient = new HttpClient();

            try
            {
                var tasks = urls
                    .Where(url => !string.IsNullOrWhiteSpace(url))
                    .Select(url => httpClient.GetStringAsync(url));//< - тут нормик

                return await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return Array.Empty<string>();
            }
        }

        public static string[] ParseSync(string[] urls)
        {
            //НЕПРАВИЛЬНО: Блокируем поток и ждем результата
            return ParseAsync(urls).Result;
        }
    }
}