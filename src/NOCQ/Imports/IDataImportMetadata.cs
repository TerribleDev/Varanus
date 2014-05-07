using System;
using System.ComponentModel.Composition;

namespace NOCQ
{
	interface IDataImportMetadata
    {
		string Name {get;set;}
    }
	[MetadataAttribute]
	public class IDataImportAttr : ExportAttribute, IDataImportMetadata
	{
		public string Name {get;set;}

		IDataImportAttr(string name)
			:base(typeof(IDataImportHook))
		{
			Name = name;
		}
	}
}

