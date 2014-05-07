using System;
using ctstone.Redis;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;
namespace NOCQ
{
    public class RedisDatabase
    {
        public RedisDatabase(){}

        public static void SaveAlert(Alert alert, string host, string q)
		{
            using (var redis = new RedisClient(host,
				Convert.ToInt32(ConfigurationManager.AppSettings["Port"]),
                Convert.ToInt32(ConfigurationManager.AppSettings["Timeout"])
			))
			{
                

                redis.LPush(q, JsonConvert.SerializeObject(alert));

			}

		}

        public static Alert GetNextAlert(string host, string q )
		{

            using (var redis = new RedisClient(host,
				Convert.ToInt32(ConfigurationManager.AppSettings["Port"]),
				Convert.ToInt32(ConfigurationManager.AppSettings["Timeout"])
			))
			{
				var ts = redis.RPop(q);

				return JsonConvert.DeserializeObject<Alert>(ts);

			}
		}
		
    }
}

