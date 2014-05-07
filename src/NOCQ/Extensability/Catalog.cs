using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;

namespace NOCQ
{
    public class Catalog
    {
		DirectoryCatalog dcatalog = new DirectoryCatalog("plugins", "*.dll");
		AssemblyCatalog acatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
		AggregateCatalog catalog = new AggregateCatalog(dcatalog, acatalog);
		public CompositionContainer Container = new CompositionContainer(catalog);
        public Catalog()
        {
			Container.ComposeParts(this);
        }
    }
}

