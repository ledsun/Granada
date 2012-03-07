using System;

namespace Ledsun.Granada.Session
{
    /// <summary>
    /// セッション未設定の場合に使用。
    /// </summary>
    public class SessionNullException : ApplicationException
    {
        public readonly string SessionKey = "";

        public SessionNullException(string sessionKey)
            : base("セッションが未設定です。 sessionKey : " + sessionKey)
        {
            SessionKey = sessionKey;
        }
    }
}