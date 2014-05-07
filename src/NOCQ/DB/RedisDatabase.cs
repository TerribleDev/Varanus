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

        public static void SaveAlert(Alert alert, string host, string q, int port, int timeout)
		{
            using (var redis = new RedisClient(host,
                port,
                timeout
			))
			{
                

                redis.LPush(q, JsonConvert.SerializeObject(alert));

			}

		}

        public static Alert GetNextAlert(string host, string q, int port, int timeout )
		{

            using (var redis = new RedisClient(host,
                port,
                timeout
			))
			{
				var ts = redis.RPop(q);

				return JsonConvert.DeserializeObject<Alert>(ts);

			}
		}
		
    }
}

