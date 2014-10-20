using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace NOCQ
{
	[Export]
    public class DataImports
    {
		[ImportMany(AllowRecomposition = true)]
		 IEnumerable<System.Lazy<IDataImportHook>> DataHooks {get; set;}
    }
}

