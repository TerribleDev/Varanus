using System;

namespace NOCQ
{
	public class ImapInput
	{
		private string loginName { get; set; }
		private string password { get; set; }
		private string server { get; set; }
		private string folderPath { get; set; }

		public ImapInput (dynamic settings)
		{
			if (settings.Login == null
				|| settings.Password == null
				|| settings.Server == null
				|| settings.FolderPath == null)
				throw new ArgumentException ("You are missing a required setting.");

			loginName = settings.Login;
			password = settings.Password;
			server = settings.Server;
			folderPath = settings.FolderPath;
		}

		public void Run()
		{

		}

		public void Stop()
		{

		}
	}
}

