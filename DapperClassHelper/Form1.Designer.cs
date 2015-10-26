namespace DapperClassHelper
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbSqlServer = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cbDbs = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sql Server";
            // 
            // tbSqlServer
            // 
            this.tbSqlServer.Location = new System.Drawing.Point(72, 10);
            this.tbSqlServer.Name = "tbSqlServer";
            this.tbSqlServer.Size = new System.Drawing.Size(136, 22);
            this.tbSqlServer.TabIndex = 1;
            this.tbSqlServer.Text = ".\\SQLEXPRESS";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(214, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connecting";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cbDbs
            // 
            this.cbDbs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDbs.FormattingEnabled = true;
            this.cbDbs.Location = new System.Drawing.Point(15, 38);
            this.cbDbs.Name = "cbDbs";
            this.cbDbs.Size = new System.Drawing.Size(121, 20);
            this.cbDbs.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 371);
            this.Controls.Add(this.cbDbs);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tbSqlServer);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSqlServer;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cbDbs;
    }
}

