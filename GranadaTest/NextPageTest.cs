using System;
using Granada.Redirect;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GranadaTest
{
    [TestClass]
    public class NextPageTest
    {
        [TestMethod]
        public void クエリパラメータなし()
        {
            var n = new NextPage("index.html");

            Assert.AreEqual<string>("index.html", n.ToString());
        }

        [TestMethod]
        public void クエリパラメータの追加()
        {
            var n = new NextPage("index.html?aaa");
            n.AddQuery("hoge", "fuga");
            n.AddQuery("hoge1", "fuga?");

            Assert.AreEqual<string>("index.html?aaa&hoge=fuga&hoge1=fuga%3f", n.ToString());
            Assert.AreEqual<string>("index.html?aaa&hoge=fuga&hoge1=fuga%3f", n);
        }
    }
}
