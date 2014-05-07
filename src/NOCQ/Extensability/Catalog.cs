using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.Reflection;

namespace NOCQ
{
    public class Catalog
    {
        static DirectoryCatalog dcatalog = new DirectoryCatalog("plugins", "*.dll");
        static AssemblyCatalog acatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
        static AggregateCatalog catalog = new AggregateCatalog(dcatalog, acatalog);
        static public CompositionContainer Container = new CompositionContainer(catalog);
        public Catalog()
        {
			Container.ComposeParts(this);
        }
    }
}

