using System.ComponentModel.Composition;


namespace NOCQ
{

	public interface IDataImportHook
    {
		string Name { get; set;}
		void Run();
		void Stop();
    }
}

