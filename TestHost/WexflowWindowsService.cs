using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Wexflow.Core;

namespace Host
{
    public partial class WexflowWindowsService : WebHostService
    {
        public static string SettingFile = "C:\\Wexflow\\Wexflow.xml";
        public static WexflowEngine WexflowEngine = new WexflowEngine(SettingFile);
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.ServiceName = "Service1";
        }

        public WexflowWindowsService(IWebHost host) : base(host)
        {
            InitializeComponent();
            ServiceName = "Wexflow";
            WexflowEngine.Run();
        }

        protected override void OnStarting(string[] args)
        {
            base.OnStarting(args);
        }

        protected override void OnStarted()
        {
            base.OnStarted();
        }

        protected override void OnStopping()
        {
            base.OnStopping();
        }
    }
}
