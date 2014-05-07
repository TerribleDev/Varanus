using System;

namespace NOCQ.Plugins.Email
{
	public class ParseRule
	{
		public string Name { get; set; }
		public bool Enabled { get; set; }
		public string From {get;set;}
		public string Source {get;set;}
		public string System {get;set;}
		public string Service {get;set;}
		public string Data {get;set;}
		public string Runbook { get; set;}
		public string Severity {get;set;}
	}
}

