using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NUnit.Framework;

namespace Granada.Redirect
{
    class QueryParams : Dictionary<string, string>
    {
        /// <summary>
        /// 設定したパラメータからクエリストリング文字列を作ります。
        /// 次の形式で文字列を返します。key1=val1&amp;key2=val2
        /// valにURLで使えない文字列が入っていた場合、そのままResponse.Redirectに入れるとURLエンコードされます。
        //  valの値はすべてURLエンコードして返します。
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

        [TestFixture]
        public class Test
        {
            [Test]
            public void クエリストリングを生成します()
            {
                var q = new QueryParams();
                q["hoge"] = "fuga";
                Assert.That(q.QueryString, Is.EqualTo("hoge=fuga"));
            }

            [Test]
            public void 同じKeyを指定したら上書きします()
            {
                var q = new QueryParams();
                q["hoge"] = "fuga";
                q["hoge"] = "fuga1";
                Assert.That(q.QueryString, Is.EqualTo("hoge=fuga1"));
            }

            [Test]
            public void パラメータをURLエンコードします()
            {
                var q = new QueryParams();
                q["hoge"] = "fuga?";
                Assert.That(q.QueryString, Is.EqualTo("hoge=fuga%3f"));
            }
        }
    }

    [TestFixture]
    public class Test
    {
        [Test]
        public void クエリパラメータの追加()
        {
            var n = new NextPage("index.html?aaa");
            n.AddQuery("hoge", "fuga");
            n.AddQuery("hoge1", "fuga?");

            Assert.That(n.ToString(), Is.EqualTo("index.html?aaa&hoge=fuga&hoge1=fuga%3f"));
            Assert.That((string)n, Is.EqualTo("index.html?aaa&hoge=fuga&hoge1=fuga%3f"));
        }
    }
}
