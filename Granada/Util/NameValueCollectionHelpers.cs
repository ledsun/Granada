using System;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Granada.Util
{
    public static class NameValueCollectionHelpers
    {
        public static T GetValue<T>(this NameValueCollection collection, string key)
        {
            return GetValue(collection, key, default(T));
        }

        public static T GetValue<T>(this NameValueCollection collection, string key, T defaultValue)
        {
            var value = collection[key];

            if (value == null)
                return defaultValue;

            var converter = TypeDescriptor.GetConverter(typeof(T));

            if (converter == null || !converter.CanConvertFrom(value.GetType()))
                return defaultValue;

            return (T)converter.ConvertFrom(value);
        }
    }
}