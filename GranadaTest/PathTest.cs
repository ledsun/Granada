using System;
using Granada.Redirect;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GranadaTest
{
    [TestClass]
    public class PathTest
    {
        [TestMethod]
        public void ファイルにクエリ文字列を追加します()
        {
            var p = new Path("index.html");
            Assert.AreEqual<string>("index.html?hoge=fuga", p.AddQueryString("hoge=fuga"));
        }

        [TestMethod]
        public void クエリ文字列付のURLにクエリ文字列を追加します()
        {
            var p1 = new Path("index.html?hoge");
            Assert.AreEqual<string>("index.html?hoge&hoge=fuga", p1.AddQueryString("hoge=fuga"));

            var p2 = new Path("index.html?hoge&");
            Assert.AreEqual<string>("index.html?hoge&hoge=fuga", p2.AddQueryString("hoge=fuga"));
        }
    }
}
