using System;
using System.Timers;
using AE.Net.Mail;
using System.Collections.Generic;
using System.Linq;

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
		List<ParseRule> parseRules{ get; set; }

		public ImapInput (dynamic settings)
		{
			var sets = settings as EmailSettings;

			if (sets.GetType().GetProperty("Username") == null
                || sets.GetType().GetProperty("Password") == null
                || sets.GetType().GetProperty("Host") == null
                || sets.GetType().GetProperty("Folder") == null)
				throw new ArgumentException ("You are missing a required setting.");

			parseRules = sets.ParseRules.Where (x => x.Enabled).ToList();

			loginName = sets.Username;
			password = sets.Password;
			server = sets.Host;
			folderPath = sets.Folder;

			timer = new Timer (sets.Frequency);
			timer.Elapsed += Execute;
		}

		public void Execute(object sender, ElapsedEventArgs args)
		{
			using(var imap = new ImapClient(server, loginName, password, ImapClient.AuthMethods.Login, port, ssl)) {
				var msgs = imap.SearchMessages(
					SearchCondition.Undeleted().And( 
						SearchCondition.SentSince(new DateTime(2000, 1, 1))
					));

				foreach (var msg in msgs) 
				{
					var realMsg = msg.Value;

					Console.WriteLine ("FROM:" + realMsg.From);

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