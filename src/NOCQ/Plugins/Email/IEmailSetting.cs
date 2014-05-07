using System;
using System.Collections.Generic;
namespace NOCQ.Plugins.Email
{
	public interface IEmailSetting
    {
		 string Username {get;set;}
		 string Password {get;set;}
		 string Host {get;set;}
		 int Port {get;set;}
		 string Folder {get;set;}
		 bool IsSsl {get;set;}
		 int Frequency { get; set; }
		 IEnumerable<ParseRule> ParseRules {get;set;}
    }
}

