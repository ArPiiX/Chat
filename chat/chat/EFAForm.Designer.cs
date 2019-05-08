namespace chat
{
    partial class EFAForm
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
            this.btnChat = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.combBoxStation = new System.Windows.Forms.ComboBox();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnChat
            // 
            this.btnChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnChat.Location = new System.Drawing.Point(370, 390);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(71, 48);
            this.btnChat.TabIndex = 1;
            this.btnChat.Text = "Back 2 Chat";
            this.btnChat.UseVisualStyleBackColor = true;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCheck.Location = new System.Drawing.Point(370, 282);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(71, 102);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // combBoxStation
            // 
            this.combBoxStation.AllowDrop = true;
            this.combBoxStation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combBoxStation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combBoxStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combBoxStation.FormattingEnabled = true;
            this.combBoxStation.Items.AddRange(new object[] {
            "Feuerbach",
            "Hauptbahnhof",
            "Wallgraben"});
            this.combBoxStation.Location = new System.Drawing.Point(12, 12);
            this.combBoxStation.Name = "combBoxStation";
            this.combBoxStation.Size = new System.Drawing.Size(146, 21);
            this.combBoxStation.TabIndex = 3;
            this.combBoxStation.SelectedIndexChanged += new System.EventHandler(this.combBoxStation_SelectedIndexChanged);
            // 
            // rtbOutput
            // 
            this.rtbOutput.Location = new System.Drawing.Point(12, 39);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ReadOnly = true;
            this.rtbOutput.Size = new System.Drawing.Size(352, 399);
            this.rtbOutput.TabIndex = 4;
            this.rtbOutput.Text = "";
            // 
            // EFAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 450);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.combBoxStation);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnChat);
            this.Name = "EFAForm";
            this.Text = "EFAForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.ComboBox combBoxStation;
        private System.Windows.Forms.RichTextBox rtbOutput;
    }
}