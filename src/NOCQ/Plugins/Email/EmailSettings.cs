using System;
using System.Collections.Generic;

namespace NOCQ.Plugins.Email
{
    public class EmailSettings
	{
		public string Username {get;set;}
		public string Password {get;set;}
		public string Host {get;set;}
		public int Port {get;set;}
		public string Folder {get;set;}
		public bool IsSsl {get;set;}
		public int Frequency { get; set; }
		public IEnumerable<ParseRule> ParseRules {get;set;}
	}
}

