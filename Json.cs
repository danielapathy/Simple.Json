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

        public static string Get(string value)
        {
            throw new NotImplementedException();
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
