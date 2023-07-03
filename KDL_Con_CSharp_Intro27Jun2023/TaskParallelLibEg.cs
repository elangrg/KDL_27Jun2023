using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDL_Con_CSharp_Intro27Jun2023
{
    internal class TaskParallelLibEg
    {

        static void Main(string[] args)
        {

            DemoFor();
            Console.Clear();
            DemoForEach();
            Console.Clear();
            DemoInvoke();
            Console.Clear();


            DemoTask();
            Console.Clear();
            DemoTaskResult();
            Console.Clear();
            DemoContinuation();
            Console.Clear();
            DemoContinuationWhenAll();
            Console.Clear();
            DemoContinuationWhenAny();
            Console.Clear();




            Console.WriteLine("in Main Row");
            Console.ReadKey();



        }


        static void ParallelFor()
        {

            //  Action<int,double > fptr = display;

            //  fptr(123, 1234);

            //  Func<int, double, string> fptr2 = displayone;

            //string rst=  fptr2(123, 244.44);


            Stopwatch sw = Stopwatch.StartNew();
            Parallel.For(0, 100, (index) => {
                ProcessData(index);
            });
            long elapsed = sw.ElapsedMilliseconds;
            Console.WriteLine("Parallel for: {0} milliseconds", elapsed);
        }


        static void DemoFor()
        {
            SequentialFor();
            ParallelFor();
        }
        static int[] LoadData(int size)
        {
            int[] data = new int[size];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;
            }
            return data;
        }
        static void DemoForEach()
        {
            int[] data = LoadData(100);
            SequentialForEach(data);
            ParallelForEach(data);
        }
        static void ProcessData(int index)
        {
            // Simulate some data processing here
            for (long i = 0; i < 3000000 + index * 1000; i++)
            {
                ProcessItem(ref i);
            }
        }
        static void DataCalculation(int index)
        {
            // Simulate some data processing here
            for (long i = 0; i < 3000000 / (index + 1); i++)
            {
                ProcessItem(ref i);
            }
        }
        static void ProcessItem(ref long value)
        {
            value += 1;
            value -= 1;
        }

        static void DemoInvoke()
        {
            DemoInvoke_Sequential();
            DemoInvoke_Parallel();
        }


        //
        // Brainiac Techie Eg No 16-1
        //
        static void SequentialFor()
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int index = 0; index < 100; index++)
            {
                ProcessData(index);
            }
            long elapsed = sw.ElapsedMilliseconds;
            Console.WriteLine("Sequential for: {0} milliseconds", elapsed);
        }

        static void SequentialForEach(int[] data)
        {
            Stopwatch sw = Stopwatch.StartNew();
            foreach (int value in data)
            {
                ProcessData(value);
            }
            long elapsed = sw.ElapsedMilliseconds;
            Console.WriteLine("Sequential foreach: {0} milliseconds", elapsed);
        }

        static void ParallelForEach(int[] data)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Parallel.ForEach(data, (value) => {
                ProcessData(value);
            });
            long elapsed = sw.ElapsedMilliseconds;
            Console.WriteLine("Parallel foreach: {0} milliseconds", elapsed);
        }

        //
        // Brainiac Techie Eg No 16-3
        //
        static int Operation(int index)
        {
            DataCalculation(index);
            Console.WriteLine("Operation {0}", index);
            return index * 10;
        }
        static void DemoInvoke_Sequential()
        {
            Console.WriteLine("=== Sequential calls ===");
            Operation(1);
            Operation(2);
            Operation(3);
            Operation(4);
        }
        static void DemoInvoke_Parallel()
        {

            Console.WriteLine("=== Parallel.Invoke calls ===");
            Parallel.Invoke(
                () => Operation(1),
                () => Operation(2),
                () => Operation(3),
                () => Operation(4));
        }


        //
        // Brainiac Techie Eg No 16-4
        //
        static void DemoTask()
        {
            Console.WriteLine("=== Task calls ===");



            Task t1 = Task.Factory.StartNew(() => { Operation(1); });


            Task t5 = GetTask();
            t5.Start();

            Task t2 = Task.Factory.StartNew(delegate { Operation(2); });

            Task t3 = Task.Factory.StartNew(delegate { Operation(3); });
            Task t4 = Task.Factory.StartNew(delegate { Operation(4); });
            Task.WaitAll(new Task[] { t1, t2, t3, t4 });

            Console.WriteLine("after ...");
            Console.ReadKey();

        }


        static Task GetTask()
        {

            return new Task(() => { Console.WriteLine("Hello "); });


        }


        //
        // Brainiac Techie Eg No 16-5
        //
        static void DemoTaskResult()
        {

            Console.WriteLine("=== Task<TResult> calls ===");
            var f1 = Task.Factory.StartNew(() => Operation(1));
            var f2 = Task.Factory.StartNew(() => Operation(2));
            var f3 = Task.Factory.StartNew(() => Operation(3));
            var f4 = Task.Factory.StartNew(() => Operation(4));

            Task.WaitAll(new Task[] { f1, f2, f3, f4 });
            int result = f1.Result + f2.Result + f3.Result + f4.Result;
            Console.WriteLine("Task result is {0}", result);
        }



        //
        // Brainiac Techie Eg No 16-6
        //
        static void DemoContinuation()
        {

            Console.WriteLine("=== Task calls ===");
            Task tLast = Task.Factory.StartNew(() => { Operation(1); })
                .ContinueWith((prevTask) => {

                    Console.WriteLine(prevTask.Status);
                    Operation(2);
                })
                .ContinueWith((prevTask) => { Operation(3); })
                .ContinueWith((prevTask) => { Operation(4); });
            tLast.Wait();
        }

        //
        // Brainiac Techie Eg No 16-7
        //
        static void DemoContinuationWhenAll()
        {
            Console.WriteLine("=== Task calls ===");
            Task t1 = Task.Factory.StartNew(() => { Operation(1); });
            Task t2 = Task.Factory.StartNew(() => { Operation(2); });
            Task t3 = Task.Factory.StartNew(() => { Operation(3); });
            Task tLast = Task.Factory.ContinueWhenAll(
                new Task[] { t1, t2, t3 },
                (prevTasks) => {
                    Console.WriteLine("----");
                    Operation(4);
                });

            tLast.Wait();
        }

        //
        // No Brainiac Techie Eg No in the book
        //
        static void DemoContinuationWhenAny()
        {
            Console.WriteLine("=== Task calls ===");
            Task t1 = Task.Factory.StartNew(() => { Operation(1); });
            Task t2 = Task.Factory.StartNew(() => { Operation(2); });
            Task t3 = Task.Factory.StartNew(() => { Operation(3); });
            Console.WriteLine("Task ID t1={0}, t2={1}, t3={2}", t1.Id, t2.Id, t3.Id);
            Task tLast = Task.Factory.ContinueWhenAny(
                new Task[] { t1, t2, t3 },
                (prevTask) => {
                    Console.WriteLine("-- waited task={0}", prevTask.Id);
                    Operation(4);
                });

            tLast.Wait();
        }

        //
        // Brainiac Techie Eg No 16-8
        //
    }
}
