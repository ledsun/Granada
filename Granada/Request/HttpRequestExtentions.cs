using System;
using System.Web;
using Granada.Util;

namespace Granada.Request
{
    /// <summary>
    /// HttpRequest����QueryString�̒l���^�ϊ����Ď擾���܂��B
    /// </summary>
    public static class HttpRequestExtentions
    {
        public static bool HasQueryString(this HttpRequest request, string key)
        {
            return !string.IsNullOrEmpty(request.QueryString[key]);
        }

        public static T GetQueryStringValue<T>(this HttpRequest request, string key)
        {
            return request.QueryString.GetValue<T>(key);
        }

        public static T GetQueryStringValue<T>(this HttpRequest request, string key, T defaultValue)
        {
            return request.QueryString.GetValue(key, defaultValue);
        }

        public static T GetFormValue<T>(this HttpRequest request, string key)
        {
            return request.Form.GetValue<T>(key);
        }

        public static T GetFormValue<T>(this HttpRequest request, string key, T defaultValue)
        {
            return request.Form.GetValue(key, defaultValue);
        }
    }
}