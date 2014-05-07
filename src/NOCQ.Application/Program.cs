using System;
using System.Dynamic;
using NOCQ.Plugins.Email;
using System.Collections.Generic;

namespace NOCQ.Application
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var settings = new EmailSettings ();
			settings.Host = "imap.gmail.com";
			settings.IsSsl = true;
			settings.Frequency = 20;
			settings.Username = "gwyrox@gmail.com";


			Console.WriteLine ("Password: ");
			settings.Password = Console.ReadLine ();
			settings.Port = 993;
			settings.Folder = "INBOX";

			var rule = new ParseRule ();
			rule.Name = "Nagios";
			rule.Enabled = true;
			rule.From = "gwyrox@gmail.com";
			rule.Source = "Nagios";
			rule.System = "(?<=Host: ).*";
			rule.Service = "(?<=Service: ).*";
			rule.Data = "(?<=Additional Info:[\\n]*).*";
			rule.Severity = "P3";
			rule.Runbook = "http://google.com";

			settings.ParseRules = new List<ParseRule> { rule };

			var email = new ImapInput (settings);
			email.Execute (null,null);
		}
	}
}
