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
            Json.AddPresetKey("token", "0cbc6611f5540b");
            string json = Json.Get("name", "John \"Test\" Doe", "Age", 35, "Location", new object[] { "Address", "90 Manor Station Street, Zanesville, OH 43701" });
            Console.WriteLine("New String: " + json);
            Console.ReadLine();
        } 
    }
}
