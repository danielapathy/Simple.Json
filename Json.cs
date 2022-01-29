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
        public static Dictionary<string, string> presets = new Dictionary<string, string>();

        public static void AddPresetKey(string name, string value)
        {
            presets.Add(name, value);
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

        public static string Get(params object[] values)
        {
            string json = string.Empty;
            for(int i = 0; i < values.Length; i++)
            {
                if(values[i].GetType() == new object[] { }.GetType())
                {
                    json += Get(values[i] as object[]);
                } else
                {
                    json += Convert(values[i], i);
                    if (i % 2 == 1)
                    {
                        json += ",";
                    }
                }
            }

            if(json.EndsWith(","))
            {
                json = json.Substring(0, json.Length - 1);
            }

            return "{" + json + "}";
        }
    }
}
