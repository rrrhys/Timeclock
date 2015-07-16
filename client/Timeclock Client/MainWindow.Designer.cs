namespace Timeclock_Client
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.bStartJob = new DevExpress.XtraEditors.SimpleButton();
            this.bFinishJob = new DevExpress.XtraEditors.SimpleButton();
            this.tComments = new DevExpress.XtraEditors.MemoEdit();
            this.lRecordingEntries = new DevExpress.XtraEditors.LabelControl();
            this.lTimeStarted = new DevExpress.XtraEditors.LabelControl();
            this.cJobNumber = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cWorkTypes = new DevExpress.XtraEditors.ComboBoxEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tComments.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJobNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cWorkTypes.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bStartJob
            // 
            this.bStartJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bStartJob.Location = new System.Drawing.Point(197, 263);
            this.bStartJob.Name = "bStartJob";
            this.bStartJob.Size = new System.Drawing.Size(75, 23);
            this.bStartJob.TabIndex = 0;
            this.bStartJob.Text = "Start";
            this.bStartJob.Click += new System.EventHandler(this.bStartJob_Click);
            // 
            // bFinishJob
            // 
            this.bFinishJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bFinishJob.Location = new System.Drawing.Point(197, 292);
            this.bFinishJob.Name = "bFinishJob";
            this.bFinishJob.Size = new System.Drawing.Size(75, 23);
            this.bFinishJob.TabIndex = 1;
            this.bFinishJob.Text = "Stop";
            this.bFinishJob.Click += new System.EventHandler(this.bFinishJob_Click);
            // 
            // tComments
            // 
            this.tComments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tComments.Location = new System.Drawing.Point(12, 82);
            this.tComments.Name = "tComments";
            this.tComments.Size = new System.Drawing.Size(260, 175);
            this.tComments.TabIndex = 2;
            // 
            // lRecordingEntries
            // 
            this.lRecordingEntries.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lRecordingEntries.Dock = System.Windows.Forms.DockStyle.Right;
            this.lRecordingEntries.Location = new System.Drawing.Point(262, 0);
            this.lRecordingEntries.LookAndFeel.SkinName = "Visual Studio 2013 Dark";
            this.lRecordingEntries.Name = "lRecordingEntries";
            this.lRecordingEntries.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lRecordingEntries.Size = new System.Drawing.Size(22, 13);
            this.lRecordingEntries.TabIndex = 3;
            this.lRecordingEntries.Text = "gg";
            // 
            // lTimeStarted
            // 
            this.lTimeStarted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTimeStarted.Location = new System.Drawing.Point(12, 263);
            this.lTimeStarted.Name = "lTimeStarted";
            this.lTimeStarted.Size = new System.Drawing.Size(0, 13);
            this.lTimeStarted.TabIndex = 4;
            // 
            // cJobNumber
            // 
            this.cJobNumber.EditValue = "Choose/Enter a job";
            this.cJobNumber.Location = new System.Drawing.Point(12, 29);
            this.cJobNumber.Name = "cJobNumber";
            this.cJobNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cJobNumber.Size = new System.Drawing.Size(260, 20);
            this.cJobNumber.TabIndex = 6;
            // 
            // cWorkTypes
            // 
            this.cWorkTypes.EditValue = "Choose/Enter a work type";
            this.cWorkTypes.Location = new System.Drawing.Point(12, 55);
            this.cWorkTypes.Name = "cWorkTypes";
            this.cWorkTypes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cWorkTypes.Size = new System.Drawing.Size(260, 20);
            this.cWorkTypes.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(12, 292);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(81, 23);
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "Reporting";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 327);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.cWorkTypes);
            this.Controls.Add(this.cJobNumber);
            this.Controls.Add(this.lTimeStarted);
            this.Controls.Add(this.lRecordingEntries);
            this.Controls.Add(this.tComments);
            this.Controls.Add(this.bFinishJob);
            this.Controls.Add(this.bStartJob);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Visual Studio 2013 Dark";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "MainWindow";
            this.Text = "Timeclock";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tComments.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJobNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cWorkTypes.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bStartJob;
        private DevExpress.XtraEditors.SimpleButton bFinishJob;
        private DevExpress.XtraEditors.MemoEdit tComments;
        private DevExpress.XtraEditors.LabelControl lRecordingEntries;
        private DevExpress.XtraEditors.LabelControl lTimeStarted;
        private DevExpress.XtraEditors.ComboBoxEdit cJobNumber;
        private DevExpress.XtraEditors.ComboBoxEdit cWorkTypes;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}