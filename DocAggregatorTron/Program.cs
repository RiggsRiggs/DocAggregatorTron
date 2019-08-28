using System;
using System.Diagnostics;
using DocAggregatorTron;

namespace Sandbox
{
    public class DocAggregatorTron
    {
        static void Main()
        {
            // this is a .NET class which is part of the diagnostics namespace
            // useful when you want to see how long something takes to complete for example.
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var processor = GetProcessor();

            processor.DoSomeWork();

            stopWatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            var ts = stopWatch.Elapsed;

            var elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";
            Console.WriteLine("RunTime " + elapsedTime);
            Console.WriteLine("the end - press any key to exit");
            Console.ReadKey();
        }

        private static IProcessor GetProcessor()
        {
            //var yesOrNo = true;
            //
            IProcessor processor;
            //
            //if (yesOrNo == true)
            //{
            //    processor = new TomAggregator();
            //}
            //else
            //{
            //    processor = new OtherAggregator();
            //}

            processor = new TomAggregator();


            return processor;
        }
    }
}
