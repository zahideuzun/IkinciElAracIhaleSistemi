using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.App.Helper
{

	public class CacheHelper
	{
		public static T GetOrSet<T>(string key, Func<T> getItemCallback, DateTimeOffset absoluteExpiration)
		{
			var cache = MemoryCache.Default;
			var item = cache.Get(key);

			if (item == null)
			{
				item = getItemCallback();
				cache.Set(key, item, absoluteExpiration);
			}

			return (T)item;
		}
	}
}
