using System;
using System.Threading;

namespace AsyncAwait.Task1.CancellationTokens
{
    static class Calculator
    {
        // todo: change this method to support cancellation token
        public static long Calculate(int n, CancellationToken token)
        {
            if (n < 0)
                throw new ArgumentException("Число должно быть больше нуля");

            long sum = 0;

            for (int i = 0; i < n; i++)
            {
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();

                // i + 1 is to allow 2147483647 (Max(Int32)) 
                sum = sum + (i + 1);
                Thread.Sleep(10);
            }

            return sum;
        }
    }
}
