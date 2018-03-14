//using MMS.Service.Assingment;
using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;
using System.Configuration;

namespace MMS.ServiceHost
{
    partial class WexflowService : ServiceBase
    {
        Timer syncTimer;
        Timer uploadReportTimer;
        Timer uploadAcceptorTimer;
        System.Diagnostics.EventLog _eventLoger;
        public MMSService()
        {
            InitializeComponent();
            syncTimer = new Timer(2 * 60 * 1000); // every 2 minustes
            uploadReportTimer = new Timer(2 * 60 * 1000); // every 2 minustes
            uploadAcceptorTimer = new Timer(2 * 60 * 1000); // every 2 minustes

            _eventLoger = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists(Properties.Settings.Default.EventViewerSourceName))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    Properties.Settings.Default.EventViewerSourceName, Properties.Settings.Default.EventViewerLogName);
            }
            _eventLoger.Source = Properties.Settings.Default.EventViewerSourceName;
            _eventLoger.Log = Properties.Settings.Default.EventViewerLogName;
        }

        protected override void OnStart(string[] args)
        {
            if (_serviceHost != null)
            {
                _serviceHost.Close();
            }

            // Create a ServiceHost for the WexflowService type and 
            // provide the base address.
            _serviceHost = new ServiceHost(typeof(WexflowService));

            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            _serviceHost.Open();
        }

        private void UploadAcceptorTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            StructureMap.IContainer container = MMS.Service.IOC.IocContainer.Initialize();
            IUploadManagement uploadManagement = container.GetInstance<IUploadManagement>();
            uploadManagement.Initialize(container);
            var sftpConfig = new SFTPConfig
            {
                IP = ConfigurationManager.AppSettings.Get("SFTP_IP"),
                Username = ConfigurationManager.AppSettings.Get("SFTP_UserName"),
                Password = ConfigurationManager.AppSettings.Get("SFTP_Password"),
                OrginalFilePath = ConfigurationManager.AppSettings.Get("OrginalFilePath"),
                ExportFilePath = ConfigurationManager.AppSettings.Get("AcceptorResponsePath")
            };
            var result = uploadManagement.ExportAcceptorRequestFile(sftpConfig);
            if (!result.Value)
            {
                _eventLoger.WriteEntry($"Upload Acceptor : {result.Exception.Message}");
            }
        }

        private void UploadTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            StructureMap.IContainer container = MMS.Service.IOC.IocContainer.Initialize();
            IUploadManagement uploadManagement = container.GetInstance<IUploadManagement>();
            uploadManagement.Initialize(container);
            var sftpConfig = new SFTPConfig
            {
                IP = ConfigurationManager.AppSettings.Get("SFTP_IP"),
                Username = ConfigurationManager.AppSettings.Get("SFTP_UserName"),
                Password = ConfigurationManager.AppSettings.Get("SFTP_Password"),
                OrginalFilePath = ConfigurationManager.AppSettings.Get("OrginalFilePath"),
                ExportFilePath = ConfigurationManager.AppSettings.Get("ExportFilePath")
            };
            var result = uploadManagement.ExportDocumentSerial(sftpConfig);
            if (!result.Value)
            {
                _eventLoger.WriteEntry($"Export Document : {result.Exception.Message}");
            }

        }

        private void SyncTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            StructureMap.IContainer container = MMS.Service.IOC.IocContainer.Initialize();
            IAddAcceptor addAcceptor = container.GetInstance<IAddAcceptor>();
            addAcceptor.Initialize(container);
            addAcceptor.RequestFileManagement();
        }

        protected override void OnStop()
        {
            _eventLoger.WriteEntry("MMS Stop");
        }
    }
}
