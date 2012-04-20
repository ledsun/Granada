using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Granada.Redirect
{
    /// <summary>
    /// クエリストリング生成用辞書
    /// </summary>
    class QueryParams : Dictionary<string, string>
    {
        /// <summary>
        /// 設定したパラメータからクエリストリング文字列を作ります。
        /// 次の形式で文字列を返します。key1=val1&amp;key2=val2
        /// valにURLで使えない文字列が入っていた場合、そのままResponse.Redirectに入れるとURLエンコードされます。
        /// valの値はすべてURLエンコードして返します。
        /// </summary>
        public string QueryString
        {
            get
            {
                var s = "";
                foreach (string key in Keys)
                {
                    if (!string.IsNullOrEmpty(s))
                        s += "&";
                    s += key + "=" + HttpUtility.UrlEncode(this[key]);
                }
                return s;
            }
        }
    }
}
