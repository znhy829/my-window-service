namespace Instar_Project
{
    partial class Service1
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
            this.FileWatcherWatchDesktop = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.FileWatcherWatchDesktop)).BeginInit();
            // 
            // FileWatcherWatchDesktop
            // 
            this.FileWatcherWatchDesktop.EnableRaisingEvents = true;
            // 
            // Service1
            // 
            this.ServiceName = "Service1";
            ((System.ComponentModel.ISupportInitialize)(this.FileWatcherWatchDesktop)).EndInit();

        }

        #endregion

        private System.IO.FileSystemWatcher FileWatcherWatchDesktop;
    }
}
