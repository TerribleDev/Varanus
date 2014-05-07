using System;

namespace NOCQ.Plugins.Email
{
    public interface IParseRule
    {
		 string Name { get; set; }
		 bool Enabled { get; set; }
		 string From {get;set;}
		 string Source {get;set;}
		 string System {get;set;}
		 string Service {get;set;}
		 string Data {get;set;}
		 string Runbook { get; set;}
		 string Severity {get;set;}
    }
}

