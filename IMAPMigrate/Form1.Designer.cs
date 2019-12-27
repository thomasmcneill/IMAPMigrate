namespace IMAPMigrate
{
    partial class Form1
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
            this.treeView_Source = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_SourceServer = new System.Windows.Forms.TextBox();
            this.textBox_SourceUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_SourcePassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_GetSourceFolders = new System.Windows.Forms.Button();
            this.button_Go = new System.Windows.Forms.Button();
            this.button_Dump = new System.Windows.Forms.Button();
            this.textBox_Log = new System.Windows.Forms.TextBox();
            this.progressBar_Status = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // treeView_Source
            // 
            this.treeView_Source.CheckBoxes = true;
            this.treeView_Source.Location = new System.Drawing.Point(12, 89);
            this.treeView_Source.Name = "treeView_Source";
            this.treeView_Source.Size = new System.Drawing.Size(426, 427);
            this.treeView_Source.TabIndex = 0;
            this.treeView_Source.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Source_AfterCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source Server";
            // 
            // textBox_SourceServer
            // 
            this.textBox_SourceServer.Location = new System.Drawing.Point(94, 10);
            this.textBox_SourceServer.Name = "textBox_SourceServer";
            this.textBox_SourceServer.Size = new System.Drawing.Size(192, 20);
            this.textBox_SourceServer.TabIndex = 2;
            this.textBox_SourceServer.Text = "imap.gmail.com";
            // 
            // textBox_SourceUser
            // 
            this.textBox_SourceUser.Location = new System.Drawing.Point(94, 36);
            this.textBox_SourceUser.Name = "textBox_SourceUser";
            this.textBox_SourceUser.Size = new System.Drawing.Size(192, 20);
            this.textBox_SourceUser.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "User";
            // 
            // textBox_SourcePassword
            // 
            this.textBox_SourcePassword.Location = new System.Drawing.Point(94, 63);
            this.textBox_SourcePassword.Name = "textBox_SourcePassword";
            this.textBox_SourcePassword.Size = new System.Drawing.Size(100, 20);
            this.textBox_SourcePassword.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            // 
            // button_GetSourceFolders
            // 
            this.button_GetSourceFolders.Location = new System.Drawing.Point(12, 522);
            this.button_GetSourceFolders.Name = "button_GetSourceFolders";
            this.button_GetSourceFolders.Size = new System.Drawing.Size(75, 23);
            this.button_GetSourceFolders.TabIndex = 7;
            this.button_GetSourceFolders.Text = "Get Folders";
            this.button_GetSourceFolders.UseVisualStyleBackColor = true;
            this.button_GetSourceFolders.Click += new System.EventHandler(this.button_GetSourceFolders_Click);
            // 
            // button_Go
            // 
            this.button_Go.Location = new System.Drawing.Point(363, 522);
            this.button_Go.Name = "button_Go";
            this.button_Go.Size = new System.Drawing.Size(75, 23);
            this.button_Go.TabIndex = 8;
            this.button_Go.Text = "Go";
            this.button_Go.UseVisualStyleBackColor = true;
            this.button_Go.Click += new System.EventHandler(this.button_Go_Click);
            // 
            // button_Dump
            // 
            this.button_Dump.Location = new System.Drawing.Point(244, 522);
            this.button_Dump.Name = "button_Dump";
            this.button_Dump.Size = new System.Drawing.Size(113, 23);
            this.button_Dump.TabIndex = 9;
            this.button_Dump.Text = "Dump To Folder";
            this.button_Dump.UseVisualStyleBackColor = true;
            this.button_Dump.Click += new System.EventHandler(this.button_Dump_Click);
            // 
            // textBox_Log
            // 
            this.textBox_Log.Location = new System.Drawing.Point(444, 89);
            this.textBox_Log.Multiline = true;
            this.textBox_Log.Name = "textBox_Log";
            this.textBox_Log.Size = new System.Drawing.Size(539, 427);
            this.textBox_Log.TabIndex = 10;
            this.textBox_Log.WordWrap = false;
            // 
            // progressBar_Status
            // 
            this.progressBar_Status.Location = new System.Drawing.Point(94, 522);
            this.progressBar_Status.MarqueeAnimationSpeed = 0;
            this.progressBar_Status.Name = "progressBar_Status";
            this.progressBar_Status.Size = new System.Drawing.Size(144, 23);
            this.progressBar_Status.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar_Status.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 602);
            this.Controls.Add(this.progressBar_Status);
            this.Controls.Add(this.textBox_Log);
            this.Controls.Add(this.button_Dump);
            this.Controls.Add(this.button_Go);
            this.Controls.Add(this.button_GetSourceFolders);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_SourcePassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_SourceUser);
            this.Controls.Add(this.textBox_SourceServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView_Source);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_Source;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_SourceServer;
        private System.Windows.Forms.TextBox textBox_SourceUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_SourcePassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_GetSourceFolders;
        private System.Windows.Forms.Button button_Go;
        private System.Windows.Forms.Button button_Dump;
        private System.Windows.Forms.TextBox textBox_Log;
        private System.Windows.Forms.ProgressBar progressBar_Status;
    }
}

