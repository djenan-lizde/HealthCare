using System;
using System.Collections.Generic;
using System.Linq;

namespace ePregledi.Models.Extensions
{
    public static class Globals
    {
        public static Dictionary<int, string> ToPairList<T>(Type type)
        {
            Dictionary<int, string> x = new Dictionary<int, string>();

            var values = Enum.GetValues(type).Cast<T>().ToList();
            var keys = Enum.GetValues(type).Cast<int>().ToList();

            for (int i = 0; i < values.Count; i++)
            {
                var key = keys[i];
                var val = values[i].ToString();

                x.Add(key, val);
            }

            return x;
        }
    }
}
