using System;

namespace NOCQ
{
	[Export(typeof(IDataImportHook))]
	public interface IDataImportHook
    {
		void Run();
		void Stop();
    }
}

