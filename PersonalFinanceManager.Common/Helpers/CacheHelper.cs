using System;
using System.Runtime.Caching;

namespace PersonalFinanceManager.Common.Helpers
{
    public static class CacheHelper
    {
        private static readonly MemoryCache _cache = MemoryCache.Default;

        public static T GetOrSet<T>(string key, Func<T> getItemCallback, int expirationMinutes = 5)
        {
            if (_cache.Contains(key))
            {
                return (T)_cache.Get(key);
            }

            T item = getItemCallback();
            if (item != null)
            {
                var policy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(expirationMinutes)
                };
                _cache.Set(key, item, policy);
            }
            return item;
        }

        public static void Remove(string key)
        {
            if (_cache.Contains(key))
            {
                _cache.Remove(key);
            }
        }

        public static void Clear()
        {
            // MemoryCache doesn't have a direct Clear method.
            // In a production scenario, you would dispose and re-instantiate, or use a CancellationChangeToken.
            // For simplicity in this demo wrapper, we won't fully clear without tracking keys.
        }
    }
}
