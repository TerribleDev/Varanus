using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace NOCQ
{
	[Export]
    public class DataImports
    {
		[ImportMany(AllowRecomposition = true)]
		public IEnumerable<System.Lazy<IDataImportHook,IDataImportMetadata>> DataHooks {get; set;}
    }
}

