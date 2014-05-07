using System;
using System.Timers;
using AE.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

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
		 IEnumerable<ParseRule> parseRules{ get; set; }


		public ImapInput (dynamic settings)
		{
			// Load settings from the dynamic object
			// TODO get it to be a EmailSettings now
			if (settings["Username"] == null
                || settings["Password"] == null
                || settings["Host"] == null
                || settings["Folder"] == null)
				throw new ArgumentException ("You are missing a required setting.");

			if (settings["ParseRules"] != null) {
				var rules = new List<ParseRule> ();
				foreach (JObject rule in settings["ParseRules"]) {

				//var r = rule.Children().Value<ParseRule>();

					var r = new ParseRule () {
						Name = rule["Name"].ToString(),
						From = rule["From"].ToString(),
						Enabled = rule["Enabled"].ToString().Equals("true") ? true:false,
						Source = rule["Source"].ToString(),
						System = rule["System"].ToString(),
						Service = rule["Service"].ToString(),
						Severity = rule["Severity"].ToString(),
						Data = rule["Data"].ToString()
					};

					if (r.Enabled)
						rules.Add (r);
				}

				//var rules = settings ["ParseRules"] as List<ParseRule>;

				parseRules = (IEnumerable<ParseRule>)rules.Where (x => x.Enabled).ToList ();
			}

			loginName = settings["Username"];
			password = settings["Password"];
			server = settings["Host"];
			folderPath = settings["Folder"];
			port = settings["Port"];
			var period = (string) settings ["Frequency"];

			// Set up the timer
			timer = new Timer (Double.Parse(period));
			timer.Elapsed += Execute;
		}

		private List<Alert> getAlerts()
		{
			var alerts = new List<Alert> ();

			using(var imap = new ImapClient(server, loginName, password, ImapClient.AuthMethods.Login, 993, true)) {
				// Find all undeleted messages from today
				// TODO We probably want to check either all and delete or since last run
				var msgs = imap.SearchMessages(
					SearchCondition.Undeleted().And( 
                        SearchCondition.SentSince(new DateTime(2014, 5, 7))
                ));

				foreach (var msg in msgs) 
				{
					var realMsg = msg.Value;

					// Figure out if any enabled parse rules apply
					var rule = parseRules.Where (x => x.From.Equals (realMsg.From.Address, StringComparison.CurrentCultureIgnoreCase));
					if (rule.Any ()) 
					{
						var thisRule = rule.First ();

						// Email + ParseRule = Alert
						var source = thisRule.Source;
						var sysRegex = new Regex(thisRule.System);
						var servRegex = new Regex(thisRule.Service);

						var sysMatch = sysRegex.Match(realMsg.Body);
						var servMatch = servRegex.Match(realMsg.Body);

						if (sysMatch.Success && servMatch.Success) {
							Console.WriteLine ("Source: " + source);
							Console.WriteLine("System: " + sysMatch.Value);
							Console.WriteLine ("Service: " + servMatch.Value);

							alerts.Add (new Alert () {
								Source = source,
								System = sysMatch.Value,
								Service = servMatch.Value
							});
						}
					}
				}
			}

			return alerts;
		}

		// Gather alerts from recent emails and throw them at redis
		public void Execute(object sender, ElapsedEventArgs args)
		{
			var alerts = getAlerts ();

			foreach (var alert in alerts) {
				//RedisDatabase.SaveAlert (alert);
			}
		}

		// Start the timer
		public void Run()
		{
			Console.WriteLine ("Start");
			timer.Enabled = true;
			timer.Start ();
		}

		// Stop the timer
		public void Stop()
		{
			Console.WriteLine ("Stop");
			timer.Stop ();
		}
	}
}