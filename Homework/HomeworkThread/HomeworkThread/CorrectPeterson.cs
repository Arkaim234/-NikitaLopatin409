using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkThread
{
    internal class CorrectPeterson
    {
        private volatile bool[] flag = new bool[2]; 
        private volatile int victim; 

        public void Enter(int threadId)
        {
            int otherThread = 1 - threadId; 
            flag[threadId] = true; 
            victim = threadId; 

            while (flag[otherThread] && victim == threadId)
            {
                Thread.Yield(); 
            }
        }

        public void Exit(int threadId)
        {
            flag[threadId] = false; 
        }
    }
}
