using System;
using System.Dynamic;
using System.Collections.Generic;

namespace NOCQ.Settings
{
	public class SettingsFile
	{
		public RedisSettings Redis { get; set; }
		public IEnumerable<PluginSettings> InputPlugins {get; set; }
	}
}

