using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.Reflection;

namespace NOCQ.Extensability
{
    public class Catalog
    {
		//static DirectoryCatalog dcatalog = new DirectoryCatalog("plugins", "*.dll");
        static AssemblyCatalog acatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
		private static AggregateCatalog Cat = new AggregateCatalog(acatalog);
		private static CompositionContainer _container = new CompositionContainer(Cat);
		public CompositionContainer Container { get { return _container; } }
		public Catalog()
        {
			_container.ComposeParts(this);

        }
    }
}

