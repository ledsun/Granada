using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Granada.Redirect
{
    class Path
    {
        private readonly string _path;

        public Path(string val)
        {
            _path = val;
        }

        public string AddQueryString(string val)
        {
            return Bond + val;
        }

        /// <summary>
        /// もらったURLの後ろにクエリストリングをつけるために、接続子を追加します。
        /// </summary>
        /// <returns></returns>
        private string Bond
        {
            get
            {
                return !_path.Contains("?") ? _path + "?"
                    : !_path.EndsWith("&") ? _path + "&"
                    : _path;
            }
        }
    }
}
