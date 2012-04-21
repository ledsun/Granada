using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Granada.Redirect
{
    static class StringQueryStringExtentions
    {
        /// <summary>
        /// パス文字列の後ろにクエリストリング文字列を付けます
        /// </summary>
        /// <param name="path"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string AppendQueryString(this string path, string val)
        {
            return Bond(path) + val;
        }

        /// <summary>
        /// クエリストリング文字列の前にパス文字列を付けます。
        /// </summary>
        /// <param name="val"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string InsertPath(this string val, string path)
        {
            return Bond(path) + val;
        }

        /// <summary>
        /// パスとクエリストリングを結合するため接続子を返します。
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
