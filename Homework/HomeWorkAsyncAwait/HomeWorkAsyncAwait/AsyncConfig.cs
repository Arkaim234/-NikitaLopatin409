using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkAsyncAwait
{

    internal class AsyncConfig
    {    
        public interface ILoading
        {
            public Task<MyService> LoadConfigFromFileAsync(string path);
        }
        public class MyService
        {
        }

        class AsyncInicilization
        {
            private MyService? service = null;
            private bool InicilizationService;
            private Task<MyService?> serviceTask;
            private readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1);

            public AsyncInicilization(string path, ILoading service)
            {
                    serviceTask = service.LoadConfigFromFileAsync(path);
            }

            public async Task<MyService> GetService(string path)
            {
                await semaphoreSlim.WaitAsync();

                try
                {
                    if (serviceTask.Exception != null)
                    {
                        throw serviceTask.Exception.InnerException
                               ?? new InvalidOperationException("Ошибка при инициализации сервиса.");
                    }

                    if (!InicilizationService)
                    {
                        service = await serviceTask.ConfigureAwait(false);
                        InicilizationService = true;
                    }

                    return service
                           ?? throw new InvalidOperationException("Сервис не был инициализирован.");
                }
                finally
                {
                    semaphoreSlim.Release();
                }
            }
        }

    }
}
