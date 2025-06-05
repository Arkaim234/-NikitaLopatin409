using System;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkAsyncAwait
{
    internal class Parser
    {
        private readonly string[] http;

        public Parser(string[] Http)
        {
            http = Http;
        }

        public async Task<string[]> Parse()
        {
            if (http == null || http.Length == 0)
                return Array.Empty<string>();

            using var httpClient = new HttpClient();

            try
            {
                var tasks = http
                    .Where(url => !string.IsNullOrWhiteSpace(url))
                    .Select(url => httpClient.GetStringAsync(url));

                string[] results = await Task.WhenAll(tasks);
                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return Array.Empty<string>();
            }
        }
    }
}