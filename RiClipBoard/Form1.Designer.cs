
namespace RiClipBoard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.computerName = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.allowIncomingCB = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allowIncomingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // computerName
            // 
            this.computerName.Location = new System.Drawing.Point(12, 33);
            this.computerName.Name = "computerName";
            this.computerName.Size = new System.Drawing.Size(185, 22);
            this.computerName.TabIndex = 0;
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.sendButton.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendButton.ForeColor = System.Drawing.Color.White;
            this.sendButton.Location = new System.Drawing.Point(12, 103);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(185, 29);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "SEND";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "RiClipBoard";
            this.notifyIcon1.Visible = true;
            // 
            // allowIncomingCB
            // 
            this.allowIncomingCB.Checked = true;
            this.allowIncomingCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allowIncomingCB.ForeColor = System.Drawing.Color.Black;
            this.allowIncomingCB.Location = new System.Drawing.Point(12, 55);
            this.allowIncomingCB.Name = "allowIncomingCB";
            this.allowIncomingCB.Size = new System.Drawing.Size(185, 42);
            this.allowIncomingCB.TabIndex = 4;
            this.allowIncomingCB.Text = "Allow others to send clipboard to this computer";
            this.allowIncomingCB.CheckedChanged += new System.EventHandler(this.allowIncomingCB_CheckedChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendClipboardToolStripMenuItem,
            this.allowIncomingToolStripMenuItem,
            this.toolStripSeparator1,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 98);
            this.contextMenuStrip1.Text = "RiClipBoard";
            // 
            // sendClipboardToolStripMenuItem
            // 
            this.sendClipboardToolStripMenuItem.Name = "sendClipboardToolStripMenuItem";
            this.sendClipboardToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.sendClipboardToolStripMenuItem.Text = "Send Clipboard";
            this.sendClipboardToolStripMenuItem.Click += new System.EventHandler(this.sendClipboardToolStripMenuItem_Click);
            // 
            // allowIncomingToolStripMenuItem
            // 
            this.allowIncomingToolStripMenuItem.Checked = true;
            this.allowIncomingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allowIncomingToolStripMenuItem.Name = "allowIncomingToolStripMenuItem";
            this.allowIncomingToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.allowIncomingToolStripMenuItem.Text = "Allow incoming";
            this.allowIncomingToolStripMenuItem.Click += new System.EventHandler(this.allowIncomingToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Input destination computer name:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(207, 140);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.allowIncomingCB);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.computerName);
            this.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RiClipBoard";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Form1_HelpButtonClicked);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox computerName;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckBox allowIncomingCB;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sendClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allowIncomingToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

