using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Plugins
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
            tbBackupFolder.Text = BackupManager.Folder;
            nmBackupFrequency.Value = BackupManager.BackupFrequencyMs;
        }

        private void CtrlClicked(object sender, EventArgs e)
        {
            if (ReferenceEquals(sender, btnOpenBackupFolder))
            {
                if (!Directory.Exists(BackupManager.Folder)) return;
                using (Process.Start(BackupManager.Folder)) { }

                return;
            }
        }
    }
}
