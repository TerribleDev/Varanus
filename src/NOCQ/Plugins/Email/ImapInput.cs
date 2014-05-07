using System;
using System.Timers;
using AE.Net.Mail;
using System.Collections.Generic;

namespace NOCQ.Plugins.Email
{
	public class ImapInput
	{
		private string loginName { get; set; }
		private string password { get; set; }
		private string server { get; set; }
		private string folderPath { get; set; }
		private Timer timer { get; set; }
		private int port { get; set; }
		private bool ssl { get; set; }
		private DateTime lastRun { get; set; }
		private List<ParseRule> parseRules{ get; set; }

		public ImapInput (dynamic settings)
		{
			var sets = settings as EmailSettings;

			if (sets.Username == null
				|| sets.Password == null
				|| sets.Host == null
				|| sets.Folder == null
			    || sets.Frequency == null
			    || sets.Port == null
			    || sets.IsSsl == null)
				throw new ArgumentException ("You are missing a required setting.");

			parseRules = sets.ParseRules.Where (x => x.Enabled);

			loginName = settings.Login;
			password = settings.Password;
			server = settings.Server;
			folderPath = settings.FolderPath;

			timer = new Timer (settings.Frequency);

			timer.Elapsed += Execute ();
		}


		public void Execute()
		{
			using(var imap = new ImapClient(server, loginName, password, ImapClient.AuthMethods.Login, port, ssl)) {
				var msgs = imap.SearchMessages(
					SearchCondition.Undeleted().And( 
						SearchCondition.SentSince(new DateTime(2000, 1, 1))
					));

				foreach (var msg in msgs) 
				{
					var realMsg = msg.Value;

					var from = realMsg.From;
					var body = realMsg.Body;

				}
			}
		}

		public void Run()
		{
			timer.Start ();
		}

		public void Stop()
		{
			timer.Stop ();
		}
	}
}