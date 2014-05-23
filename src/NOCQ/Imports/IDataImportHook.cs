using System.ComponentModel.Composition;


namespace NOCQ
{

	public interface IDataImportHook
    {
		string Name { get; }
		void Run();
		void Stop();
    }
}

