using System;

namespace NOCQ
{
	public class Alert 
    {
		public DateTime TimeStamp {get; set;}
		public string Source {get;set;}
		public string System {get;set;}
		public string Service {get;set;}
		public string Data {get;set;}
		public string Runbook {get; set;}
		public string Severity {get;set;}
		public Guid Id {get;set;}
    }
}


