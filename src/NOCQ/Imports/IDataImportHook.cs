
namespace NOCQ
{
	[Export(typeof(IDataImportHook))]
	public interface IDataImportHook
    {
		string Name { get; set; }
		void Run();
		void Stop();
    }
}

