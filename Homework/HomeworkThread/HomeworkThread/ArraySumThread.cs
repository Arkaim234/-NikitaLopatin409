namespace HomeworkThread
{
    class ArraySumThread
    {
        private int[] arr;
        private int sum;
        private object lockObject = new object();
        
        public void Randomaizer(int n)
        {
            int[] arr = new int[n];
            Random random = new Random();
            for (int i = 0; i < n-1; i++)
            {
                arr[i] = random.Next(0,10);
            }
        }

        public void Calculate(int m)
        {
            int part = arr.Length / m;
            Task[] threads = new Task[m];
            for (int i = 0; i < m;i++)
            {
                int start = i * part;
                int end = (i == m - 1) ?arr.Length:start + part;
                threads[i] = Task.Run(() =>
                {
                    int partsum = 0;
                    for (int j = start; j < end; j++)
                    {
                        partsum += arr[j];
                    }
                    lock (lockObject)
                    {
                        sum += partsum;
                    }
                });
            }
            Task.WaitAll(threads);
        }

        public void PrintSum()
        {
            Console.WriteLine(sum);
        }
    }
}
