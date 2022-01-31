using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Simple.Json
{
    public static class Json
    {
        public static List<object> presets = new List<object>();
        private static object[] presetsArray;
        private static Type objType = new object[] { }.GetType();

        public static void AddPresetKey(object name, object value)
        {
            presets.Add(name);
            presets.Add(value);
            presetsArray = presets.ToArray();
        }

        public static string Escape(string value)
        {
            return HttpUtility.JavaScriptStringEncode(value);
        }

        public static string Convert(object value, int i)
        {
            string key = string.Empty;
            if (i % 2 == 0)
            {
                key += "\"" + Escape(value.ToString()) + "\":";
            }
            else if (i % 2 == 1)
            {
                if (value.GetType() == typeof(int))
                {
                    key += value.ToString();
                }
                else
                {
                    key += "\"" + Escape(value.ToString()) + "\"";
                }

            }
            return key;
        }

        public static object[] Get(string value)
        {
            value = value.Trim().Substring(1, value.Length - 2);
            string[] values = value.Split(',');
            object[] json = new object[values.Length * 2];
            int mod = 0;

            for(int i = 0; i < values.Length; i++)
            {
                string[] key = values[i].Split(':');
                json[i + mod] = key[0].Substring(1, key[0].Length - 2);
                if(key[1][0] == '"')
                {
                    json[i + mod + 1] = key[1].Substring(1, key[1].Length - 2);
                } else if(key[1][0] == '{')
                {
                    Console.WriteLine(key[1]);
                } else
                {
                    json[i + mod + 1] = int.Parse(key[1]);
                }

                mod += 1;
            }

            return json;
        }

        public static string Construct(object value, int index)
        {
            string json = string.Empty;

            if (value.GetType() == objType)
            {
                json += Get(value as object[]);
            }
            else
            {
                json += Convert(value, index);
                if (index % 2 == 1)
                {
                    json += ",";
                }
            }

            return json;
        }

        public static string Get(params object[] values)
        {
            string json = string.Empty;

            for (int i = 0; i < values.Length; i++)
            {
                json += Construct(values[i], i);
            }

            if(presetsArray != null)
            {
                json += ",";
                for (int i = 0; i < presetsArray.Length; i++)
                {
                    json += Construct(presetsArray[i], i);
                }
            }

            if (json.EndsWith(","))
            {
                json = json.Substring(0, json.Length - 1);
            }

            return "{" + json + "}";
        }
    }
}
