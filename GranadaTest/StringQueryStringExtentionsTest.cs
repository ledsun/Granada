using System;
using Granada.Redirect;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GranadaTest
{
    [TestClass]
    public class StringQueryStringExtentionsTest
    {
        [TestMethod]
        public void ファイル名で終わるURLにクエリ文字列を追加するとはてなで結合します()
        {
            Assert.AreEqual<string>("index.html?hoge=fuga", "index.html".AppendQueryString("hoge=fuga"));
        }

        [TestMethod]
        public void クエリ文字列付のURLにクエリ文字列を追加するとあんどで結合します()
        {
            Assert.AreEqual<string>("index.html?hoge&hoge=fuga", "index.html?hoge".AppendQueryString( "hoge=fuga"));

            Assert.AreEqual<string>("index.html?hoge&hoge=fuga", "index.html?hoge&".AppendQueryString("hoge=fuga"));
        }

        [TestMethod]
        public void クエリ文字列の前にファイル名で終わるURLを結合します()
        {
            Assert.AreEqual<string>("index.html?hoge=fuga", "hoge=fuga".InsertPath("index.html"));
        }
    }
}
