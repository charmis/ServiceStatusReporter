using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatusReportingLibrary.ViewModels
{
	public class FTViewModel
	{
		public List<FTService> Services { get; set; }
		public Site Site { get; set; }
		public List<AppPool> AppPools { get; set; }
	}

	public class FTService
	{
		public string Name { get; set; }
		public string Status { get; set; }
	}

	public class Site
	{
		public string Name { get; set; }
		public string Status { get; set; }
	}

	public class AppPool
	{
		public string Name { get; set; }
		public string Status { get; set; }
	}
}
