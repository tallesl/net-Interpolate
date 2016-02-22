namespace InterpolateLibrary.Console
{
    using System;
    using System.Diagnostics;

    class Program
    {
        const int Iterations = 50000;
        static void Main(string[] args)
        {
            string format = "{foo} is a {bar} is a {baz} is a {qux:#.#} is a really big {fizzle}";
            var o = new { foo = 123, bar = true, baz = "this is a test", qux = 123.45, fizzle = DateTime.Now };

            MeasureFormatTime("Hanselformat", () => format.HanselmanFormat(o));
            MeasureFormatTime("OskarFormat", () => format.OskarFormat(o));
            MeasureFormatTime("JamesFormat", () => format.JamesFormat(o));
            MeasureFormatTime("HenriFormat", () => format.HenriFormat(o));
            MeasureFormatTime("HaackFormat", () => format.HaackFormat(o));

            Console.ReadLine();
        }

        static void MeasureFormatTime(string name, Action formatAction)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < Iterations; i++)
            {
                formatAction();
            }
            stopwatch.Stop();
            Console.WriteLine(name + " took " + ((double)stopwatch.ElapsedMilliseconds / (double)Iterations) + " ms");
        }
    }
}
