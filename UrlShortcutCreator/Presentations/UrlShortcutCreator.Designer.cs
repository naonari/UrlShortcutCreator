namespace UrlShortcutCreator.Presentations
{
    partial class UrlShortcutCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrlShortcutCreator));
            this.pnlScreen = new NexFx.Controls.ExPanel();
            this.txtUrl = new NexFx.Controls.ExTextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.btnExecute = new NexFx.Controls.ExButton();
            this.txtFileName = new NexFx.Controls.ExTextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.pnlScreen.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlScreen
            // 
            this.pnlScreen.BackColor = System.Drawing.Color.Transparent;
            this.pnlScreen.Controls.Add(this.txtUrl);
            this.pnlScreen.Controls.Add(this.lblUrl);
            this.pnlScreen.Controls.Add(this.btnExecute);
            this.pnlScreen.Controls.Add(this.txtFileName);
            this.pnlScreen.Controls.Add(this.lblFileName);
            this.pnlScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScreen.Location = new System.Drawing.Point(0, 0);
            this.pnlScreen.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlScreen.Name = "pnlScreen";
            this.pnlScreen.Size = new System.Drawing.Size(484, 112);
            this.pnlScreen.TabIndex = 0;
            // 
            // txtUrl
            // 
            this.txtUrl.CaptionControl = this.lblUrl;
            this.txtUrl.FocusedBackColor = System.Drawing.SystemColors.Info;
            this.txtUrl.FocusedForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUrl.Location = new System.Drawing.Point(89, 9);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(380, 23);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.Leave += new System.EventHandler(this.txtUrl_Leave);
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(38, 12);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(36, 15);
            this.lblUrl.TabIndex = 0;
            this.lblUrl.Text = "URL:";
            // 
            // btnExecute
            // 
            this.btnExecute.CaptionControl = null;
            this.btnExecute.FocusedBackColor = System.Drawing.SystemColors.Info;
            this.btnExecute.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExecute.Location = new System.Drawing.Point(19, 75);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(450, 30);
            this.btnExecute.TabIndex = 4;
            this.btnExecute.Text = "作成";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.CaptionControl = this.lblFileName;
            this.txtFileName.FocusedBackColor = System.Drawing.SystemColors.Info;
            this.txtFileName.FocusedForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFileName.Location = new System.Drawing.Point(89, 42);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(380, 23);
            this.txtFileName.TabIndex = 3;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(16, 45);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(58, 15);
            this.lblFileName.TabIndex = 2;
            this.lblFileName.Text = "ファイル名:";
            // 
            // UrlShortcutCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 112);
            this.Controls.Add(this.pnlScreen);
            this.DuplicateLastTimePosition = true;
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.GradationColor1 = System.Drawing.Color.Azure;
            this.GradationColor2 = System.Drawing.Color.LavenderBlush;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "UrlShortcutCreator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InternetShortcutCreator";
            this.Load += new System.EventHandler(this.UrlShortcutCreator_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UrlShortcutCreator_KeyDown);
            this.pnlScreen.ResumeLayout(false);
            this.pnlScreen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal NexFx.Controls.ExPanel pnlScreen;
        internal System.Windows.Forms.Label lblFileName;
        internal NexFx.Controls.ExTextBox txtFileName;
        internal NexFx.Controls.ExButton btnExecute;
        internal NexFx.Controls.ExTextBox txtUrl;
        internal System.Windows.Forms.Label lblUrl;
    }
}