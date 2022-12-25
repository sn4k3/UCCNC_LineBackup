namespace Plugins
{
    partial class ConfigForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenBackupFolder = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbBackupFolder = new System.Windows.Forms.Label();
            this.tbBackupFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nmBackupFrequency = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmBackupFrequency)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenBackupFolder
            // 
            this.btnOpenBackupFolder.AutoSize = true;
            this.btnOpenBackupFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenBackupFolder.Location = new System.Drawing.Point(434, 3);
            this.btnOpenBackupFolder.Name = "btnOpenBackupFolder";
            this.btnOpenBackupFolder.Size = new System.Drawing.Size(85, 23);
            this.btnOpenBackupFolder.TabIndex = 0;
            this.btnOpenBackupFolder.Text = "Open";
            this.btnOpenBackupFolder.UseVisualStyleBackColor = true;
            this.btnOpenBackupFolder.Click += new System.EventHandler(this.CtrlClicked);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbBackupFolder, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOpenBackupFolder, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbBackupFolder, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.nmBackupFrequency, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(522, 60);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lbBackupFolder
            // 
            this.lbBackupFolder.AutoSize = true;
            this.lbBackupFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbBackupFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBackupFolder.Location = new System.Drawing.Point(3, 0);
            this.lbBackupFolder.Name = "lbBackupFolder";
            this.lbBackupFolder.Size = new System.Drawing.Size(141, 29);
            this.lbBackupFolder.TabIndex = 0;
            this.lbBackupFolder.Text = "Backup folder:";
            this.lbBackupFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbBackupFolder
            // 
            this.tbBackupFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbBackupFolder.Location = new System.Drawing.Point(150, 3);
            this.tbBackupFolder.Name = "tbBackupFolder";
            this.tbBackupFolder.ReadOnly = true;
            this.tbBackupFolder.Size = new System.Drawing.Size(278, 20);
            this.tbBackupFolder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Backup frequency:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(434, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "milliseconds (ms)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nmBackupFrequency
            // 
            this.nmBackupFrequency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nmBackupFrequency.Location = new System.Drawing.Point(150, 32);
            this.nmBackupFrequency.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nmBackupFrequency.Name = "nmBackupFrequency";
            this.nmBackupFrequency.ReadOnly = true;
            this.nmBackupFrequency.Size = new System.Drawing.Size(278, 20);
            this.nmBackupFrequency.TabIndex = 4;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 70);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(391, 109);
            this.Name = "ConfigForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LineBackup Configuration";
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmBackupFrequency)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenBackupFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbBackupFolder;
        private System.Windows.Forms.TextBox tbBackupFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nmBackupFrequency;
    }
}