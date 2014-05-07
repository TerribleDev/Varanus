using System;
using ctstone.Redis;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;
namespace NOCQ
{
    public class RedisDataase
    {
		public RedisDataase(){}

		public static async Task SaveAlert(IAlert alert)
		{
			using (var redis = new RedisClientAsync(ConfigurationManager.AppSettings["DBQueueKey"],
				Convert.ToInt32(ConfigurationManager.AppSettings["Port"]),
				Convert.ToInt32(ConfigurationManager.AppSettings["Timeout"])
			))
			{
				await redis.LPush(ConfigurationManager.AppSettings["DBQueueKey"], alert);

			}

		}

		public static async Task<Alert> GetNextAlert()
		{
			using (var redis = new RedisClientAsync(ConfigurationManager.AppSettings["DBQueueKey"],
				Convert.ToInt32(ConfigurationManager.AppSettings["Port"]),
				Convert.ToInt32(ConfigurationManager.AppSettings["Timeout"])
			))
			{
				var ts = await redis.RPop(ConfigurationManager.AppSettings["DBQueueKey"]);

				return JsonConvert.DeserializeObject<Alert>(ts);

			}
		}
		
    }
}

