using System.Web;

namespace Granada.Redirect
{
    /// <summary>
    /// クエリストリング付URLへ遷移するためのクラス
    /// 使用例
    ///  var n = New NextPage("http://example.com/index.html");
    ///  n.AddQuery(key, val).Go();
    /// 結果
    ///  Response.Redirect(http://example.com/index.html?key=val);
    /// </summary>
    public class NextPage
    {
        /// <summary>
        /// 生成するURLのPATH
        /// </summary>
        private readonly string _path;

        /// <summary>
        /// クエリストリングとして付加するkey-valの組み合わせ
        /// </summary>
        private readonly QueryParams _params = new QueryParams();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">パス文字列。http://example.com/index.htmlや~/index.htmlや./index.htmlと指定できます。</param>
        public NextPage(string path)
        {
            _path = path;
        }

        #region AddQueryメソッド
        /// <summary>
        /// keyを指定して値を設定します。
        ///  同じkeyに二回設定したら上書きされます。
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
        /// keyを指定して値を設定します。
        ///  同じkeyに二回設定したら上書きされます。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns>メソッドチェーン対応で自分自身を返します。</returns>
        public NextPage AddQuery(string key, int val)
        {
            _params[key] = val.ToString();
            return this;
        }

        /// <summary>
        /// keyを指定して値を設定します。
        ///  同じkeyに二回設定したら上書きされます。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns>メソッドチェーン対応で自分自身を返します。</returns>
        public NextPage AddQuery(string key, uint val)
        {
            _params[key] = val.ToString();
            return this;
        }
        #endregion

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
        /// 指定したURLへ遷移します。
        /// </summary>
        public void Go()
        {
            HttpContext.Current.Response.Redirect(ToString());
        }

        #region 文字列化
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
        #endregion
    }
}
