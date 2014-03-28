using System;
using Nancy.Hosting.Self;
using Nancy;
using Nancy.Diagnostics;

namespace StatusReportingLibrary
{
	public static class NancyInfrastructure
	{
		private static NancyHost m_NancyHost = null;

		public static void Start()
		{
			m_NancyHost = new NancyHost(new Uri("http://localhost:2014"));
			m_NancyHost.Start();
		}

		public static void Stop()
		{
			m_NancyHost.Stop();
		}
	}

	public class CustomBootStrapper : DefaultNancyBootstrapper
	{
		protected override DiagnosticsConfiguration DiagnosticsConfiguration
		{
			get { return new DiagnosticsConfiguration { Password = @"charmis" }; }
		}
	}
}
