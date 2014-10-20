using System;

namespace NOCQ.Settings
{
	public class RedisSettings
	{
		public string Hostname {get;set;}
		public int Port {get;set;}
		public int Timeout{get;set;}
		public string InputQueue{get;set;}
		public string OutputQueue{get;set;}
	}
}

