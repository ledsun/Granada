using System;
using System.Collections.Generic;
using Granada.Redirect;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GranadaTest
{
    [TestClass]
    public class DictionaryQueryParamsExtentionsTest
    {
        [TestMethod]
        public void クエリストリングを生成します()
        {
            var q = new Dictionary<string, string>();
            q["hoge"] = "fuga";
            q["hoge1"] = "fuga";
            Assert.AreEqual<string>("hoge=fuga&hoge1=fuga", q.MakeQueryString());
        }

        [TestMethod]
        public void 同じKeyを指定したら上書きします()
        {
            var q = new Dictionary<string, string>();
            q["hoge"] = "fuga";
            q["hoge"] = "fuga1";
            Assert.AreEqual<string>("hoge=fuga1", q.MakeQueryString());
        }

        [TestMethod]
        public void パラメータをURLエンコードします()
        {
            var q = new Dictionary<string, string>();
            q["hoge"] = "fuga?";
            Assert.AreEqual<string>("hoge=fuga%3f" ,q.MakeQueryString());
        }
    }
}
