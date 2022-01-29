using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Json
{
    class Program
    {
        static void Debug()
        {
            /* Creating a json string */
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                string json = Json.Get("name", "John \"Test\" Doe", "Age", 35, "Location", new object[] { "Address", "90 Manor Station Street, Zanesville, OH 43701" });
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Creating 100,000 Simple.Json strings: " + elapsedMs + "ms");

            /* Reading a json string */
            watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                object[] name = Json.Get("{\"first\":\"John\",\"last\":\"Doe\"}");
            }
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Reading 100,000 Simple.Json strings: " + elapsedMs + "ms");

            Console.ReadLine();
        }

        static void Normal()
        {
            /* Creating a json string */
            string json = Json.Get("name", "John \"Test\" Doe", "Age", 35, "Location", new object[] { "Address", "90 Manor Station Street, Zanesville, OH 43701" });
            Console.WriteLine("New String: " + json);

            /* Reading a json string */
            object[] name = Json.Get("{\"first\":\"John\",\"last\":\"Doe\"}");
            Console.WriteLine("Name: " + name[1]);

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Debug();
        } 
    }
}
