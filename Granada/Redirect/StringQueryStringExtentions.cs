using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Granada.Redirect
{
    static class StringQueryStringExtentions
    {
        public static string AddQueryString(this string _path, string val)
        {
            return Bond(_path) + val;
        }

        /// <summary>
        /// URLにクエリストリングを結合するため接続子を返します。
        /// </summary>
        /// <returns></returns>
        private static string Bond(string _path)
        {
            return !_path.Contains("?") ? _path + "?"
                : !_path.EndsWith("&") ? _path + "&"
                : _path;
        }
    }
}
