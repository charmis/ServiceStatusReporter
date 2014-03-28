using System.ServiceProcess;
using StatusReportingLibrary;

namespace FedTaxServiceStatusReporter
{
	public partial class HostService : ServiceBase
	{
		public HostService()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			NancyInfrastructure.Start();
		}

		protected override void OnStop()
		{
			NancyInfrastructure.Stop();
		}
	}
}
