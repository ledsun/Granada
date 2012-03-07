using System.Web;

namespace Ledsun.Granada.Session
{
    /// <summary>
    /// 型指定してセッションにアクセスします。
    /// 使用例
    ///  var wrapper = new SessionWrapper{string}("hoge");
    ///  wrapper.Set("hogehoge");
    ///  if(wrapper.IsExist)
    ///      string hoge = wrapper;
    /// </summary>
    /// <typeparam name="U">セッションに保存する値の型</typeparam>
    public class SessionWrapper<U>
    {
        /// <summary>
        /// セッションに保存するときのキー
        /// </summary>
        private string Key { get; set; }

        /// <summary>
        /// コンストラクタで型とキーを指定します。
        /// </summary>
        /// <param name="key"></param>
        public SessionWrapper(string key)
        {
            Key = key;
        }

        /// <summary>
        /// セッションに値を保存します。
        /// </summary>
        /// <param name="value">nullを入れたら値を削除します。</param>
        public void Set(U value)
        {
            if (value == null)
            {
                HttpContext.Current.Session.Remove(Key);
            }
            else
            {
                HttpContext.Current.Session[Key] = value;
            }
        }

        /// <summary>
        /// セッションに値があればtrueを返します。
        /// </summary>
        public bool IsExist
        {
            get
            {
                return HttpContext.Current.Session[Key] != null;
            }
        }

        /// <summary>
        /// セッションから値を取り出します。
        /// 指定型への暗黙変換を実装しているので以下のような記述が可能です。
        /// string hoge = new SessionWrapper{string}("hoge");
        /// </summary>
        /// <param name="wrapper"></param>
        /// <returns></returns>
        public static implicit operator U(SessionWrapper<U> wrapper)
        {
            if (!wrapper.IsExist)
            {
                throw new SessionNullException(wrapper.Key);
            }

            return (U)HttpContext.Current.Session[wrapper.Key];
        }
    }
}