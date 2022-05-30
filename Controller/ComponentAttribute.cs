using System;
using System.Collections.Generic;
using System.Text;

namespace RoboMate.Controller
{
	public class ComponentAttribute : Attribute
	{
		public string Identifier { get; set; }
		public ComponentAttribute(string identifier)
		{
			Identifier = identifier;
		}
	}
}
