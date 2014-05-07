using System;
using System.Dynamic;
using System.Linq;
using NOCQ.Plugins.Email;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NOCQ.Application
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var list = new List<Alert>();
			for (var i = 0; i < 3000; i++)
			{
				var al = new Alert()
				{Data = "data" + Guid.NewGuid(), Runbook = "runbook", Service = "service",
					Severity = "sev",
					Source = "Source",
					System = "System",
					TimeStamp = new DateTime(2011,1,1)
				};
				list.Add(al);
			}
			list.ForEach(al => RedisDatabase.SaveAlert(al, "127.0.0.1", RedisQueues.Input, 6379, 3000));
			for (var i = 0; i < 3000; i++)
			{
				var s = RedisDatabase.GetNextAlert("127.0.0.1", RedisQueues.Input, 6379, 3000);
				Console.WriteLine(s.Data);
			}

			Console.ReadLine();
		
		}
	}
}
