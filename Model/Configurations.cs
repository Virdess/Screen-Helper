using System;
using System.Collections.Generic;
using System.Text;

namespace RoboMate.Model
{
	public class Configurations
	{
		public List<string> EnabledComponents { get; set; }
		public int ProcessorThreshold { get; set; }
		public int RamThreshold { get; set; }
		public int IdleThresholdInSeconds { get; set; }
		public string ImagePath { get; set; }

	}
}
