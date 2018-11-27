using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY_MANAGEMENT_SYSTEM
{
	class store_data
	{
		private string curr_username;
		private byte[] curr_image;
		private string curr_usn;
		private string checkvar = "Check";

		public void setvariables( string un, string usn)
		{
			curr_username = un;
			curr_usn = usn;
		}

		public void viewvar ()
		{
			Console.Write(checkvar);
		}

		public string get_username()
		{
			return curr_username;
		}

		public byte[] get_curr_image()
		{
			return curr_image;
		}

		public string get_curr_usn()
		{
			return curr_usn;
		}
	}
}
