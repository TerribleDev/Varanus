using System;
using System.Dynamic;
using System.Linq;
using NOCQ.Plugins.Email;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NOCQ.Extensability;
namespace NOCQ.Application
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var s = RedisDatabase.GetNextAlert("127.0.0.1", RedisQueues.Input, 6379, 3000);

			// process s
			var importPlugs = CatalogRepository.GetImportPlugins();

			importPlugs.ToList().ForEach(x => 
				{
					Task.Factory.StartNew(x.Value.Run, TaskCreationOptions.LongRunning);
					Console.WriteLine(x.Value.Name);
				});

			//RedisDatabase.SaveAlert(, "127.0.0.1", RedisQueues.Output, 6379, 3000);

			Console.ReadLine();
		
		}
	}
}
