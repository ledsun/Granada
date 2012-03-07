namespace Ledsun.Granada.Session
{
    /// <summary>
    /// セッション操作用のクラス
    /// どこからでも操作できるように各セッションキーへの操作クラスをstatic変数で持ちます。
    /// 使用例
    ///  SesiionHelper.Hoge.Set("hoge");
    ///  if(SesiionHelper.Hoge.IsExist)
    ///      string hoge = SessionHelper.Hoge;
    /// </summary>
    public static class SessionHelper
    {
        /// <summary>
        /// just for example.
        /// </summary>
        public static SessionWrapper<string> Hoge = new SessionWrapper<string>("Hoge");
    }
}