namespace chat
{
    partial class ChatForm
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
            this.btnSend = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            lblHeader = new System.Windows.Forms.Label();
            this.txbInput = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnGameSelection = new System.Windows.Forms.Button();
            this.txbOutput = new System.Windows.Forms.RichTextBox();
            this.btnVVS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSend.Location = new System.Drawing.Point(12, 540);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(518, 48);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Nachricht senden";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnQuit.Location = new System.Drawing.Point(536, 540);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(71, 48);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "Ende";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Location = new System.Drawing.Point(536, 76);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new System.Drawing.Size(0, 13);
            lblHeader.TabIndex = 3;
            // 
            // txbInput
            // 
            this.txbInput.Location = new System.Drawing.Point(12, 486);
            this.txbInput.Multiline = true;
            this.txbInput.Name = "txbInput";
            this.txbInput.Size = new System.Drawing.Size(518, 48);
            this.txbInput.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnRefresh.Location = new System.Drawing.Point(536, 432);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(71, 48);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Reload";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLogOut.Location = new System.Drawing.Point(536, 486);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(71, 48);
            this.btnLogOut.TabIndex = 6;
            this.btnLogOut.Text = "Logout";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnGameSelection
            // 
            this.btnGameSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnGameSelection.Location = new System.Drawing.Point(536, 25);
            this.btnGameSelection.Name = "btnGameSelection";
            this.btnGameSelection.Size = new System.Drawing.Size(71, 48);
            this.btnGameSelection.TabIndex = 7;
            this.btnGameSelection.Text = "Games";
            this.btnGameSelection.UseVisualStyleBackColor = true;
            this.btnGameSelection.Click += new System.EventHandler(this.btnGameSelection_Click);
            // 
            // txbOutput
            // 
            this.txbOutput.ForeColor = System.Drawing.Color.Black;
            this.txbOutput.Location = new System.Drawing.Point(12, 25);
            this.txbOutput.Name = "txbOutput";
            this.txbOutput.ReadOnly = true;
            this.txbOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txbOutput.Size = new System.Drawing.Size(518, 455);
            this.txbOutput.TabIndex = 8;
            this.txbOutput.Text = "";
            this.txbOutput.TextChanged += new System.EventHandler(this.txbOutput_TextChanged);
            // 
            // btnVVS
            // 
            this.btnVVS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnVVS.Location = new System.Drawing.Point(536, 378);
            this.btnVVS.Name = "btnVVS";
            this.btnVVS.Size = new System.Drawing.Size(71, 48);
            this.btnVVS.TabIndex = 9;
            this.btnVVS.Text = "VVS EFA";
            this.btnVVS.UseVisualStyleBackColor = true;
            this.btnVVS.Click += new System.EventHandler(this.btnVVS_Click);
            // 
            // ChatForm
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 600);
            this.Controls.Add(this.btnVVS);
            this.Controls.Add(this.txbOutput);
            this.Controls.Add(this.btnGameSelection);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txbInput);
            this.Controls.Add(lblHeader);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnSend);
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BOSCH ChatRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.TextBox txbInput;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnGameSelection;
        private System.Windows.Forms.Button btnVVS;
        public static System.Windows.Forms.Label lblHeader;
        public System.Windows.Forms.RichTextBox txbOutput;
    }
}

