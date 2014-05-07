using System;

namespace NOCQ.Settings
{
	public class RedisSettings
	{
		public string hostname {get;set;}
		public string port {get;set;}
		public string timeout{get;set;}
		public string inputQueue{get;set;}
		public string outputQueue{get;set;}
	}
}

