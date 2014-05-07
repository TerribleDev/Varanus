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

		public static async Task SaveAlert(Alert alert, string q)
		{
			using (var redis = new RedisClientAsync(q,
				Convert.ToInt32(ConfigurationManager.AppSettings["Port"]),
				Convert.ToInt32(ConfigurationManager.AppSettings["Timeout"])
			))
			{
				await redis.LPush(q, alert);

			}

		}

		public static async Task<Alert> GetNextAlert(string q)
		{

			using (var redis = new RedisClientAsync(q,
				Convert.ToInt32(ConfigurationManager.AppSettings["Port"]),
				Convert.ToInt32(ConfigurationManager.AppSettings["Timeout"])
			))
			{
				var ts = await redis.RPop(q);

				return await JsonConvert.DeserializeObjectAsync<Alert>(ts);

			}
		}
		
    }
}

