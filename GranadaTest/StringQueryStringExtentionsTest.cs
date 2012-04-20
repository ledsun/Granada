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
            Assert.AreEqual<string>("index.html?hoge=fuga", "index.html".AddQueryString("hoge=fuga"));
        }

        [TestMethod]
        public void クエリ文字列付のURLにクエリ文字列を追加するとあんどで結合します()
        {
            Assert.AreEqual<string>("index.html?hoge&hoge=fuga", "index.html?hoge".AddQueryString( "hoge=fuga"));

            Assert.AreEqual<string>("index.html?hoge&hoge=fuga", "index.html?hoge&".AddQueryString("hoge=fuga"));
        }
    }
}
