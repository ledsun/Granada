using System.Collections.Generic;
using System.Web;
using NUnit.Framework;

namespace Ledsun.Granada.Redirect
{
    /// <summary>
    /// クエリストリング付URLへ遷移するためのクラス
    /// 使用例
    ///  var n = New NextPage("http://example.com/index.html")
    ///  n.AddQuery(key, val).Go()
    /// 結果
    ///  Response.Redirect(http://example.com/index.html?key=val)
    /// </summary>
    public class NextPage
    {
        /// <summary>
        /// 生成するURLのPATH
        /// </summary>
        private readonly Path _path;

        /// <summary>
        /// クエリストリングにするkey-valの組み合わせ
        /// </summary>
        private readonly QueryParams _params = new QueryParams();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">パス文字列。http://example.com/index.htmlや~/index.htmlや./index.htmlと指定できます。</param>
        public NextPage(string path)
        {
            _path = new Path(path);
        }

        /// <summary>
        /// keyを指定して値を設定します。
        ///  同じkeyに二回設定したら上書きされます。
        ///  メソッドチェーンにするため自分自身を返したいのでインデクサとしては実装しません。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns>メソッドチェーン対応で自分自身を返します。</returns>
        public NextPage AddQuery(string key, string val)
        {
            _params[key] = val;
            return this;
        }

        /// <summary>
        /// keyを指定して値を設定します。
        ///  同じkeyに二回設定したら上書きされます。
        ///  メソッドチェーンにするため自分自身を返したいのでインデクサとしては実装しません。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns>メソッドチェーン対応で自分自身を返します。</returns>
        public NextPage AddQuery(string key, bool val)
        {
            _params[key] = val ? "true" : "false";
            return this;
        }

        /// <summary>
        /// リクエストURLのクエリストリングから指定したkeyの値を取ってきて設定します。
        /// </summary>
        /// <param name="key">値をコピーしたいクエリストリングのkey</param>
        /// <returns>メソッドチェーン対応で自分自身を返します。</returns>
        public NextPage AddQueryFromRequest(string key)
        {
            _params[key] = HttpContext.Current.Request.QueryString[key];
            return this;
        }

        /// <summary>
        /// コンストラクタで指定したパスにクエリストリングを付けた文字列を作成します。
        /// </summary>
        /// <returns>次のような文字列を返します。入力時のパス部分は変更しません。http://example.com/index.html?key1=val1&amp;key2=val2</returns>
        public override string ToString()
        {
            return _path.AddQueryString(_params.QueryString);
        }

        /// <summary>
        /// 文字列型への暗黙のユーザー定義型変換演算子
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static implicit operator string(NextPage val)
        {
            return val.ToString();
        }

        /// <summary>
        /// 指定したURLへ遷移します。
        /// </summary>
        public void Go()
        {
            HttpContext.Current.Response.Redirect(ToString());
        }

        private class Path
        {
            private readonly string _path;

            public Path(string val)
            {
                _path = val;
            }

            public string AddQueryString(string val)
            {
                return AddBond + val;
            }

            /// <summary>
            /// もらったURLの後ろにクエリストリングをつけるために、接続子を追加します。
            /// </summary>
            /// <returns></returns>
            private string AddBond
            {
                get
                {
                    return !_path.Contains("?") ? _path + "?"
                        : !_path.EndsWith("&") ? _path + "&"
                        : _path;
                }
            }

            [TestFixture]
            public class Test
            {
                [Test]
                public void ファイルにクエリ文字列を追加します()
                {
                    var p = new Path("index.html");
                    Assert.That(p.AddQueryString("hoge=fuga"), Is.EqualTo("index.html?hoge=fuga"));
                }

                [Test]
                public void クエリ文字列付のURLにクエリ文字列を追加します()
                {
                    var p1 = new Path("index.html?hoge");
                    Assert.That(p1.AddQueryString("hoge=fuga"), Is.EqualTo("index.html?hoge&hoge=fuga"));

                    var p2 = new Path("index.html?hoge&");
                    Assert.That(p2.AddQueryString("hoge=fuga"), Is.EqualTo("index.html?hoge&hoge=fuga"));
                }
            }
        }

        private class QueryParams : Dictionary<string, string>
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
}
