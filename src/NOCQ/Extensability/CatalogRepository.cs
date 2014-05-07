using System;
using System.Collections.Generic;

namespace NOCQ.Extensability
{
	public static class CatalogRepository
    {
		public static IEnumerable<Lazy<IDataImportHook>> GetImportPlugins()
		{
			var ts = new Catalog().Container.GetExports<IDataImportHook>();
			return ts;
		}
    }
}

