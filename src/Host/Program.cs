using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;

namespace Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            //var pathToContentRoot = Path.GetDirectoryName(pathToExe);

            //var host = WebHost.CreateDefaultBuilder(args)
            //    .UseContentRoot(pathToContentRoot)
            //    .UseStartup<Startup>()
            //    // .UseApplicationInsights()
            //    .Build();

            //host.RunAsService();
            // BuildWebHost(args).Run();

            var servicesToRun = new ServiceBase[]
            {
                new WexflowWindowsService(null)
            };

            bool isService = true;
            if (Debugger.IsAttached || args.Contains("--console"))
            {
                isService = false;
            }

            var pathToContentRoot = Directory.GetCurrentDirectory();
            if (isService)
            {
                var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                pathToContentRoot = Path.GetDirectoryName(pathToExe);
            }

            var host = WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(pathToContentRoot)
                .UseStartup<Startup>()
                .Build();

            if (isService)
            {
                host.RunAsCustomService();
            }
            else
            {
                BuildWebHost(args).Run();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
