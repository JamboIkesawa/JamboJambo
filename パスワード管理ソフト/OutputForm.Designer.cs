namespace パスワード管理ソフト
{
	partial class OutputForm
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
			this.groupBox_Output = new System.Windows.Forms.GroupBox();
			this.richTextBox_OutputExplain = new System.Windows.Forms.RichTextBox();
			this.label_OutputPassword = new System.Windows.Forms.Label();
			this.label_OutputMailID = new System.Windows.Forms.Label();
			this.label_OutputExplain = new System.Windows.Forms.Label();
			this.label_OutputTitle = new System.Windows.Forms.Label();
			this.textBox_OutputPass = new System.Windows.Forms.TextBox();
			this.textBox_OutputID = new System.Windows.Forms.TextBox();
			this.textBox_OutputTitle = new System.Windows.Forms.TextBox();
			this.button_Close = new System.Windows.Forms.Button();
			this.groupBox_Output.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox_Output
			// 
			this.groupBox_Output.Controls.Add(this.richTextBox_OutputExplain);
			this.groupBox_Output.Controls.Add(this.label_OutputPassword);
			this.groupBox_Output.Controls.Add(this.label_OutputMailID);
			this.groupBox_Output.Controls.Add(this.label_OutputExplain);
			this.groupBox_Output.Controls.Add(this.label_OutputTitle);
			this.groupBox_Output.Controls.Add(this.textBox_OutputPass);
			this.groupBox_Output.Controls.Add(this.textBox_OutputID);
			this.groupBox_Output.Controls.Add(this.textBox_OutputTitle);
			this.groupBox_Output.Location = new System.Drawing.Point(12, 12);
			this.groupBox_Output.Name = "groupBox_Output";
			this.groupBox_Output.Size = new System.Drawing.Size(174, 220);
			this.groupBox_Output.TabIndex = 10;
			this.groupBox_Output.TabStop = false;
			this.groupBox_Output.Text = "出力フィールド";
			// 
			// richTextBox_OutputExplain
			// 
			this.richTextBox_OutputExplain.Location = new System.Drawing.Point(28, 154);
			this.richTextBox_OutputExplain.Name = "richTextBox_OutputExplain";
			this.richTextBox_OutputExplain.ReadOnly = true;
			this.richTextBox_OutputExplain.Size = new System.Drawing.Size(130, 54);
			this.richTextBox_OutputExplain.TabIndex = 11;
			this.richTextBox_OutputExplain.Text = "";
			// 
			// label_OutputPassword
			// 
			this.label_OutputPassword.AutoSize = true;
			this.label_OutputPassword.Location = new System.Drawing.Point(15, 99);
			this.label_OutputPassword.Name = "label_OutputPassword";
			this.label_OutputPassword.Size = new System.Drawing.Size(52, 12);
			this.label_OutputPassword.TabIndex = 3;
			this.label_OutputPassword.Text = "パスワード";
			// 
			// label_OutputMailID
			// 
			this.label_OutputMailID.AutoSize = true;
			this.label_OutputMailID.Location = new System.Drawing.Point(15, 59);
			this.label_OutputMailID.Name = "label_OutputMailID";
			this.label_OutputMailID.Size = new System.Drawing.Size(86, 12);
			this.label_OutputMailID.TabIndex = 3;
			this.label_OutputMailID.Text = "メールアドレス/ID";
			// 
			// label_OutputExplain
			// 
			this.label_OutputExplain.AutoSize = true;
			this.label_OutputExplain.Location = new System.Drawing.Point(15, 139);
			this.label_OutputExplain.Name = "label_OutputExplain";
			this.label_OutputExplain.Size = new System.Drawing.Size(29, 12);
			this.label_OutputExplain.TabIndex = 3;
			this.label_OutputExplain.Text = "備考";
			// 
			// label_OutputTitle
			// 
			this.label_OutputTitle.AutoSize = true;
			this.label_OutputTitle.Location = new System.Drawing.Point(18, 19);
			this.label_OutputTitle.Name = "label_OutputTitle";
			this.label_OutputTitle.Size = new System.Drawing.Size(40, 12);
			this.label_OutputTitle.TabIndex = 3;
			this.label_OutputTitle.Text = "タイトル";
			// 
			// textBox_OutputPass
			// 
			this.textBox_OutputPass.Location = new System.Drawing.Point(28, 114);
			this.textBox_OutputPass.Name = "textBox_OutputPass";
			this.textBox_OutputPass.ReadOnly = true;
			this.textBox_OutputPass.Size = new System.Drawing.Size(130, 19);
			this.textBox_OutputPass.TabIndex = 10;
			// 
			// textBox_OutputID
			// 
			this.textBox_OutputID.Location = new System.Drawing.Point(28, 77);
			this.textBox_OutputID.Name = "textBox_OutputID";
			this.textBox_OutputID.ReadOnly = true;
			this.textBox_OutputID.Size = new System.Drawing.Size(130, 19);
			this.textBox_OutputID.TabIndex = 9;
			// 
			// textBox_OutputTitle
			// 
			this.textBox_OutputTitle.Location = new System.Drawing.Point(28, 37);
			this.textBox_OutputTitle.Name = "textBox_OutputTitle";
			this.textBox_OutputTitle.ReadOnly = true;
			this.textBox_OutputTitle.Size = new System.Drawing.Size(130, 19);
			this.textBox_OutputTitle.TabIndex = 8;
			// 
			// button_Close
			// 
			this.button_Close.Location = new System.Drawing.Point(111, 248);
			this.button_Close.Name = "button_Close";
			this.button_Close.Size = new System.Drawing.Size(75, 23);
			this.button_Close.TabIndex = 11;
			this.button_Close.Text = "閉じる";
			this.button_Close.UseVisualStyleBackColor = true;
			this.button_Close.Click += new System.EventHandler(this.Button_Close_Click);
			// 
			// OutputForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(201, 283);
			this.Controls.Add(this.button_Close);
			this.Controls.Add(this.groupBox_Output);
			this.Name = "OutputForm";
			this.Text = "OutputForm";
			this.groupBox_Output.ResumeLayout(false);
			this.groupBox_Output.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox_Output;
		private System.Windows.Forms.RichTextBox richTextBox_OutputExplain;
		private System.Windows.Forms.Label label_OutputPassword;
		private System.Windows.Forms.Label label_OutputMailID;
		private System.Windows.Forms.Label label_OutputExplain;
		private System.Windows.Forms.Label label_OutputTitle;
		private System.Windows.Forms.TextBox textBox_OutputPass;
		private System.Windows.Forms.TextBox textBox_OutputID;
		private System.Windows.Forms.TextBox textBox_OutputTitle;
		private System.Windows.Forms.Button button_Close;
	}
}