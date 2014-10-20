using System;
using System.IO;
namespace NOCQ.Settings
{
	public static class SettingsParser
	{
		public static SettingsFile Parse(string filePath = "settings.json"){

			return Newtonsoft.Json.JsonConvert.DeserializeObject<SettingsFile>(File.ReadAllText(filePath));
		}
	}
}

