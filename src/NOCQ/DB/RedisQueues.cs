using System;
using System.Configuration;

namespace NOCQ
{
	public struct RedisQueues
    {
		public static string Input = ConfigurationManager.AppSettings["DBQueueInput"];
		public static string Output = ConfigurationManager.AppSettings["DBQueueOutput"];
    }
}

