using System;
using System.Reflection;

namespace FedTaxServiceStatusReporter
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{
			var svc = new HostService();
#if DEBUG
			MethodInfo mi = svc.GetType().GetMethod("OnStart", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic);
			mi.Invoke(svc, new object[] { new string[0] });
			Console.WriteLine("Started...");
			Console.ReadLine();
#else
			ServiceBase.Run(new ServiceBase[] { svc });
#endif
		}
	}
}
