using Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
	public class Communication
	{
		public string Origin { get; set; }
		public EType Type { get; set; }
		public ETarget Target { get; set; }
		public dynamic Content { get; set; }
		public bool Success { get; set; }

		public override string ToString()
		{
			Content = Content ?? "null";
			return $"Communication from {Origin} = \n" +
				$"Type : {Type},\n" +
				$"Target : {Target}, \n" +
				$"Content : {(Content as object).ToString()}, \n" +
				$"Success : {Success.ToString()}";
		}
	}
}
