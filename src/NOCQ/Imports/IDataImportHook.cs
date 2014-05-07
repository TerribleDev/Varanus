using System.ComponentModel.Composition;


namespace NOCQ
{
    [InheritedExport]
	public interface IDataImportHook
    {
		string Name { get; set; }
		void Run();
		void Stop();
    }
}

