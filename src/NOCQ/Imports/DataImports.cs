using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace NOCQ
{
	[Export]
    public class DataImports
    {
		[ImportMany]
		IEnumerable<IDataImportHook> DataHooks {get; set;}

    }
}

