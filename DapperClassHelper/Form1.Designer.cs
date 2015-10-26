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
            this.rbCommandText = new System.Windows.Forms.RadioButton();
            this.rbSP = new System.Windows.Forms.RadioButton();
            this.tbCommandText = new System.Windows.Forms.TextBox();
            this.tbClassName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbClass = new System.Windows.Forms.TextBox();
            this.btnGetClass = new System.Windows.Forms.Button();
            this.tbSqlParameter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.cbDbs.Location = new System.Drawing.Point(296, 10);
            this.cbDbs.Name = "cbDbs";
            this.cbDbs.Size = new System.Drawing.Size(121, 20);
            this.cbDbs.TabIndex = 3;
            // 
            // rbCommandText
            // 
            this.rbCommandText.AutoSize = true;
            this.rbCommandText.Checked = true;
            this.rbCommandText.Location = new System.Drawing.Point(15, 44);
            this.rbCommandText.Name = "rbCommandText";
            this.rbCommandText.Size = new System.Drawing.Size(93, 16);
            this.rbCommandText.TabIndex = 4;
            this.rbCommandText.TabStop = true;
            this.rbCommandText.Tag = "action";
            this.rbCommandText.Text = "CommandText";
            this.rbCommandText.UseVisualStyleBackColor = true;
            // 
            // rbSP
            // 
            this.rbSP.AutoSize = true;
            this.rbSP.Location = new System.Drawing.Point(115, 43);
            this.rbSP.Name = "rbSP";
            this.rbSP.Size = new System.Drawing.Size(35, 16);
            this.rbSP.TabIndex = 5;
            this.rbSP.Tag = "action";
            this.rbSP.Text = "SP";
            this.rbSP.UseVisualStyleBackColor = true;
            // 
            // tbCommandText
            // 
            this.tbCommandText.Location = new System.Drawing.Point(15, 67);
            this.tbCommandText.Multiline = true;
            this.tbCommandText.Name = "tbCommandText";
            this.tbCommandText.Size = new System.Drawing.Size(526, 131);
            this.tbCommandText.TabIndex = 6;
            // 
            // tbClassName
            // 
            this.tbClassName.Location = new System.Drawing.Point(86, 281);
            this.tbClassName.Name = "tbClassName";
            this.tbClassName.Size = new System.Drawing.Size(100, 22);
            this.tbClassName.TabIndex = 7;
            this.tbClassName.Text = "Info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Class Name";
            // 
            // tbClass
            // 
            this.tbClass.Location = new System.Drawing.Point(15, 337);
            this.tbClass.Multiline = true;
            this.tbClass.Name = "tbClass";
            this.tbClass.ReadOnly = true;
            this.tbClass.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbClass.Size = new System.Drawing.Size(526, 234);
            this.tbClass.TabIndex = 9;
            // 
            // btnGetClass
            // 
            this.btnGetClass.Location = new System.Drawing.Point(417, 269);
            this.btnGetClass.Name = "btnGetClass";
            this.btnGetClass.Size = new System.Drawing.Size(105, 44);
            this.btnGetClass.TabIndex = 10;
            this.btnGetClass.Text = "Get Class";
            this.btnGetClass.UseVisualStyleBackColor = true;
            this.btnGetClass.Click += new System.EventHandler(this.btnGetClass_Click);
            // 
            // tbSqlParameter
            // 
            this.tbSqlParameter.Location = new System.Drawing.Point(15, 241);
            this.tbSqlParameter.Multiline = true;
            this.tbSqlParameter.Name = "tbSqlParameter";
            this.tbSqlParameter.Size = new System.Drawing.Size(526, 22);
            this.tbSqlParameter.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "SP SqlParameter";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 589);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSqlParameter);
            this.Controls.Add(this.btnGetClass);
            this.Controls.Add(this.tbClass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbClassName);
            this.Controls.Add(this.tbCommandText);
            this.Controls.Add(this.rbSP);
            this.Controls.Add(this.rbCommandText);
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
        private System.Windows.Forms.RadioButton rbCommandText;
        private System.Windows.Forms.RadioButton rbSP;
        private System.Windows.Forms.TextBox tbCommandText;
        private System.Windows.Forms.TextBox tbClassName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbClass;
        private System.Windows.Forms.Button btnGetClass;
        private System.Windows.Forms.TextBox tbSqlParameter;
        private System.Windows.Forms.Label label3;
    }
}

