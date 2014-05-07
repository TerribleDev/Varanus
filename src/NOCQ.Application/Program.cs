using System;
using System.Dynamic;
using NOCQ.Settings;
using NOCQ.Plugins.Email;
using System.Collections.Generic;
using System.Linq;

namespace NOCQ.Application
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// Parse the settings file
			var json = System.IO.File.ReadAllText ("settings.json");
			var settings = SettingsParser.Parse (json);

			// Load the settings for the email plugin
			var email = settings.InputPlugins.Single (x => x.Name == "Email");
			var emailSettings = email.Settings;

			//.Create and start an email plugin instance
			var emailPlugin = new ImapInput(emailSettings);
			emailPlugin.Execute(null,null);

			Console.ReadKey ();
		}
	}
}
