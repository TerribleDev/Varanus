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
		private string host { get; set; }
		private string q { get; set; }
		private string port {get;set;}
		private int timeout { get; set;}
        public RedisDatabase(){}

		public static void SaveAlert(Alert alert, RedisSettings setting)
		{
			using (var redis = new RedisClient(setting.Hostname,
				setting.Port,
				setting.Timeout
			))
			{
                

				redis.LPush(setting.InputQueue, JsonConvert.SerializeObject(alert));

			}

		}

		public static Alert GetNextAlert(RedisSettings setting)
		{

			using (var redis = new RedisClient(setting.Hostname,
				setting.Port,
				setting.Timeout
			))
			{
				var ts = redis.RPop(setting.OutputQueue);

				return JsonConvert.DeserializeObject<Alert>(ts);

			}
		}
		
    }
}

