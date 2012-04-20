using System;
using Granada.Redirect;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GranadaTest
{
    [TestClass]
    public class QueryParamsTest
    {
        [TestMethod]
        public void クエリストリングを生成します()
        {
            var q = new QueryParams();
            q["hoge"] = "fuga";
            Assert.AreEqual<string>("hoge=fuga", q.QueryString);
        }

        [TestMethod]
        public void 同じKeyを指定したら上書きします()
        {
            var q = new QueryParams();
            q["hoge"] = "fuga";
            q["hoge"] = "fuga1";
            Assert.AreEqual<string>("hoge=fuga1", q.QueryString);
        }

        [TestMethod]
        public void パラメータをURLエンコードします()
        {
            var q = new QueryParams();
            q["hoge"] = "fuga?";
            Assert.AreEqual<string>("hoge=fuga%3f" ,q.QueryString);
        }
    }
}
