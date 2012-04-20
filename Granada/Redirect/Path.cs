using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

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
}
