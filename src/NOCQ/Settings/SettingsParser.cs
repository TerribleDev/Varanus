using System;

namespace NOCQ.Settings
{
	public class SettingsParser
	{
		public static SettingsFile Parse(string json){
			return Newtonsoft.Json.JsonConvert.DeserializeObject<SettingsFile>(json);
		}
	}
}

