using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Json
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Creating a json string */
            string json = Json.Get("name", "John \"Test\" Doe", "Age", 35, "Location", new object[] { "Address", "90 Manor Station Street, Zanesville, OH 43701" });
            Console.WriteLine("New String: " + json);

            /* Reading a json string */
            object[] name = Json.Get("{\"first\":\"John\",\"last\":\"Doe\"}");
            Console.WriteLine("Name: " + name[1]);

            Console.ReadLine();
        } 
    }
}
