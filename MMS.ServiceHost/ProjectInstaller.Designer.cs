namespace MMS.ServiceHost
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MMSServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.MMSServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // MMSServiceProcessInstaller
            // 
            this.MMSServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.MMSServiceProcessInstaller.Password = null;
            this.MMSServiceProcessInstaller.Username = null;
            // 
            // MMSServiceInstaller
            // 
            this.MMSServiceInstaller.ServiceName = "MMSService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.MMSServiceProcessInstaller,
            this.MMSServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller MMSServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller MMSServiceInstaller;
    }
}