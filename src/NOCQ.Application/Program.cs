using System;
using System.Dynamic;
using NOCQ.Plugins.Email;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NOCQ.Application
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var al = new Alert()
			{Data = "data", Runbook = "runbook", Service = "service",
				Severity = "sev",
				Source = "Source",
				System = "System",
				TimeStamp = new DateTime(2011,1,1)
			};

			RedisDatabase.SaveAlert(al, "127.0.0.1", RedisQueues.Input, 6379, 3000);
			var s = RedisDatabase.GetNextAlert("127.0.0.1", RedisQueues.Input, 6379, 3000);
			Console.WriteLine(s.Data);
			Console.ReadLine();
		
		}
	}
}
