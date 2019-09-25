using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Server.Utils
{
	public class TestPing
	{
		public static bool Test(string address)
		{
			PingReply pingReply;
			try
			{
				pingReply = new Ping().Send(address);
			}
			catch(Exception e)
			{
				pingReply = null;
				Console.WriteLine(e.ToString());
			}

			return pingReply != null && pingReply.Status == IPStatus.Success ? true : false;
		}
	}
}
