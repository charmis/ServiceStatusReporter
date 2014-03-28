using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using Microsoft.Web.Administration;
using StatusReportingLibrary.ViewModels;

namespace FedTaxServiceStatusReporter
{
	public class StatusReportingModule
	{
		public class SampleModule : Nancy.NancyModule
		{
			public SampleModule()
			{
				Get["/"] = _ =>
				{
					string[] servicesToMonitor = 					
					{ 
						"QCenter Service",
						"External Queue Process Service",
						"Locator Services",
						"Email Services"						
					};

					ServiceController[] services = ServiceController.GetServices();

					FTViewModel vm = new FTViewModel();

					vm.Services = (from s in services
								   where servicesToMonitor.Contains(s.DisplayName)
								   select new FTService { Name = s.DisplayName, Status = ((ServiceControllerStatus)s.Status).ToString() }).ToList();

					using (ServerManager serverManager = new ServerManager())
					{

						var site = serverManager.Sites.FirstOrDefault(s => s.Name == "FedTaxServices");

						vm.Site = new StatusReportingLibrary.ViewModels.Site { Name = site.Name, Status = site.State.ToString() };
											
                        vm.AppPools = new List<AppPool>(5);
						foreach (Application app in site.Applications)
						{
                            var status = serverManager.ApplicationPools.FirstOrDefault(p => p.Name == app.ApplicationPoolName).State.ToString();
							vm.AppPools.Add(new AppPool { Name = app.ApplicationPoolName, Status = status });
						}
					}

					return View["index", vm];
				};

				Get["/api/"] = _ =>
				{
					string[] servicesToMonitor = { "ClipBook", "Event Log" };
					ServiceController[] services = ServiceController.GetServices();

					var ser = (from s in services
							   where servicesToMonitor.Contains(s.DisplayName)
							   select new { ServiceName = s.DisplayName, Status = ((ServiceControllerStatus)s.Status).ToString() }).ToList();

					return ser.ToList();
				};
			}
		}
	}
}
