namespace Acronix
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.backButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.reloadButton = new System.Windows.Forms.Button();
            this.urlBar = new System.Windows.Forms.TextBox();
            this.newTabButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(2, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(27, 23);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "<";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // forwardButton
            // 
            this.forwardButton.Location = new System.Drawing.Point(29, 4);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(27, 23);
            this.forwardButton.TabIndex = 1;
            this.forwardButton.Text = ">";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // reloadButton
            // 
            this.reloadButton.Location = new System.Drawing.Point(62, 4);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(75, 23);
            this.reloadButton.TabIndex = 2;
            this.reloadButton.Text = "Reload";
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // urlBar
            // 
            this.urlBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlBar.Location = new System.Drawing.Point(297, 6);
            this.urlBar.Name = "urlBar";
            this.urlBar.Size = new System.Drawing.Size(574, 20);
            this.urlBar.TabIndex = 3;
            this.urlBar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.urlBar_KeyPress);
            // 
            // newTabButton
            // 
            this.newTabButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newTabButton.Location = new System.Drawing.Point(1110, 4);
            this.newTabButton.Name = "newTabButton";
            this.newTabButton.Size = new System.Drawing.Size(75, 23);
            this.newTabButton.TabIndex = 5;
            this.newTabButton.Text = "New Tab";
            this.newTabButton.UseVisualStyleBackColor = true;
            this.newTabButton.Click += new System.EventHandler(this.newTabButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Location = new System.Drawing.Point(-4, 33);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1195, 596);
            this.tabControl.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 626);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.newTabButton);
            this.Controls.Add(this.urlBar);
            this.Controls.Add(this.reloadButton);
            this.Controls.Add(this.forwardButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Acronix";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Acronix_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.TextBox urlBar;
        private System.Windows.Forms.Button newTabButton;
        private System.Windows.Forms.TabControl tabControl;
    }
}

