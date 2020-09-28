using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread_MergeSort
{
    class MergeSort
    {
        static async Task Main(string[] args)
        {
            int[] data = BigList.data;

            var sw = new Stopwatch();
            sw.Start();

            int middle = data.Length / 2 - 1;

            //var thread1 = new Thread(() => MergeSortRecursive(ref data, 0, middle));
            //var thread2 = new Thread(() => MergeSortRecursive(ref data, middle + 1, data.Length - 1));

            //thread1.Start();
            //thread2.Start();

            //thread1.Join();
            //thread2.Join();

            var listOfTasks = new List<Task>();

            var task1 = Task.Run(() => MergeSortRecursive(ref data, 0, middle));
            var task2 = Task.Run(() => MergeSortRecursive(ref data, middle + 1, data.Length - 1));
            var task3 = Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(1000);
                    Console.WriteLine("Sorting numbers, Please wait");
                }
            });

            listOfTasks.Add(task1);
            listOfTasks.Add(task2);
            listOfTasks.Add(task3);

            await Task.WhenAll(task1, task2);

            Merge(ref data, 0, middle, data.Length - 1);

            // MergeSortRecursive(ref data, 0, data.Length - 1); //this just runs mergesort synchronosly 

            sw.Stop();
            Console.WriteLine($"Numbers are sorted. Time that was required is {sw.Elapsed}");

            // Console.WriteLine(string.Join(", ", data));
            File.WriteAllLines("../../../mergeSort.txt", data.Select(x => x.ToString()));

        }
        public static void MergeSortRecursive(ref int[] data, int left, int right)
        {
            if (left < right)
            {
                int m = left + (right - left) / 2;

                MergeSortRecursive(ref data, left, m);
                MergeSortRecursive(ref data, m + 1, right);

                Thread.Sleep(1); // this slows the proccess down so we can see the difference between executing on 1 thread or 2 threads. 

                Merge(ref data, left, m, right);
            }
        }

        private static void Merge(ref int[] data, int left, int mid, int right)
        {
            int i, j, k;
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] L = new int[n1];
            int[] R = new int[n2];

            for (i = 0; i < n1; i++)
                L[i] = data[left + i];

            for (j = 0; j < n2; j++)
                R[j] = data[mid + 1 + j];

            i = 0;
            j = 0;
            k = left;

            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    data[k] = L[i];
                    i++;
                }
                else
                {
                    data[k] = R[j];
                    j++;
                }

                k++;
            }

            while (i < n1)
            {
                data[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                data[k] = R[j];
                j++;
                k++;
            }
        }
    }
}
