using System;
using System.Timers;
using AE.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NOCQ.Plugins.Email
{
	public class ImapInput
	{
		 string loginName { get; set; }
		 string password { get; set; }
		 string server { get; set; }
		 string folderPath { get; set; }
		 Timer timer { get; set; }
		 int port { get; set; }
		 bool ssl { get; set; }
		 DateTime lastRun { get; set; }
		List<IParseRule> parseRules{ get; set; }

		public ImapInput (dynamic settings)
		{
			var sets = settings as EmailSettings;

			if (sets.GetType().GetProperty("Username") == null
                || sets.GetType().GetProperty("Password") == null
                || sets.GetType().GetProperty("Host") == null
                || sets.GetType().GetProperty("Folder") == null)
				throw new ArgumentException ("You are missing a required setting.");

			if (sets.ParseRules != null) {
				parseRules = sets.ParseRules.Where (x => x.Enabled).ToList ();
			}

			loginName = sets.Username;
			password = sets.Password;
			server = sets.Host;
			folderPath = sets.Folder;
			port = sets.Port;

			timer = new Timer (sets.Frequency);
			timer.Elapsed += Execute;
		}

		public void Execute(object sender, ElapsedEventArgs args)
		{
			using(var imap = new ImapClient(server, loginName, password, ImapClient.AuthMethods.Login, 993, true)) {
				var msgs = imap.SearchMessages(
					SearchCondition.Undeleted().And( 
						SearchCondition.SentSince(new DateTime(2014, 5, 7))
					));

				foreach (var msg in msgs) 
				{
					var realMsg = msg.Value;

					var rule = parseRules.Where (x => x.From.Equals (realMsg.From.Address, StringComparison.CurrentCultureIgnoreCase));
					//"fuc".Com
					if (rule.Any ()) 
					{
						var thisRule = rule.First ();

						var source = thisRule.Source;

						var sysRegex = new Regex(thisRule.System);
						var servRegex = new Regex(thisRule.Service);

						var sysMatch = sysRegex.Match(realMsg.Body);
						var servMatch = servRegex.Match(realMsg.Body);

						if (sysMatch.Success && servMatch.Success) {
							Console.WriteLine ("Source: " + source);
							Console.WriteLine("System: " + sysMatch.Value);
							Console.WriteLine ("Service: " + servMatch.Value);
						}



						//Console.WriteLine (system);
					}
				}
			}
		}

		public void Run()
		{
			Console.WriteLine ("Start");
			timer.Start ();
		}

		public void Stop()
		{
			Console.WriteLine ("Stop");
			timer.Stop ();
		}
	}
}