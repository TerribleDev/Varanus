using System;

namespace NOCQ
{
	public interface IAlert
    {
		 DateTime TimeStamp {get; set;}
		 string Source {get;set;}
		 string System {get;set;}
		 string Service {get;set;}
		 string Data {get;set;}
		 string Runbook {get; set;}
		 string Severity {get;set;}
    }
}

