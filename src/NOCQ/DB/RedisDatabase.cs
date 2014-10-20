using System;
using ctstone.Redis;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;
using NOCQ.Settings;


namespace NOCQ
{
    public sealed class RedisDatabase
    {
		public RedisSettings Settings { get; private set;}
		public RedisDatabase(RedisSettings settings)
		{
			if (settings == null)
				throw new ArgumentNullException ("settings");

			Settings = settings;
		}

		public void SaveAlert(Alert alert)
		{
			using (var redis = new RedisClient(Settings.Hostname,
				Settings.Port,
				Settings.Timeout
			))
			{
                

				redis.LPush(Settings.InputQueue, JsonConvert.SerializeObject(alert));

			}

		}

		public Alert GetNextAlert()
		{

			using (var redis = new RedisClient(Settings.Hostname,
				Settings.Port,
				Settings.Timeout
			))
			{
				var ts = redis.RPop(Settings.OutputQueue);

				return JsonConvert.DeserializeObject<Alert>(ts);

			}
		}
		
    }
}

