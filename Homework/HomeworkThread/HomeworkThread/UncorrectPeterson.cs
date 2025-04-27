using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkThread
{
    internal class UncorrectPeterson
    {
        private bool[] flag = new bool[2]; // Нет volatile → возможна невидимость изменений
        private int victim;

        public void Enter(int threadId)
        {
            int otherThread = 1 - threadId;
            flag[threadId] = true; // Может быть не сразу видно другому потоку
            victim = threadId; // Возможна race condition

            // Ожидание без памяти (может зациклиться)
            while (flag[otherThread] && victim == threadId)
            {
                // Нет Thread.Yield() → возможна активная блокировка
            }
        }

        public void Exit(int threadId)
        {
            flag[threadId] = false; // Может быть не сразу видно
        }
    }
}
