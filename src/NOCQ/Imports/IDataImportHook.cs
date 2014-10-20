using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace NOCQ
{
	[InheritedExport]
	public interface IDataImportHook
    {
		string Name { get; }
		string Description { get; }
		string Version {get;}
		IEnumerable<Alert> ImportAlerts (System.DateTime lastRun);
    }
}

