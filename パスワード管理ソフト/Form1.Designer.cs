namespace パスワード管理ソフト
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.button_Add = new System.Windows.Forms.Button();
			this.button_Delete = new System.Windows.Forms.Button();
			this.textBox_InputID = new System.Windows.Forms.TextBox();
			this.textBox_InputPass = new System.Windows.Forms.TextBox();
			this.textBox_OutputID = new System.Windows.Forms.TextBox();
			this.textBox_OutputPass = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.dataGridView_Data = new System.Windows.Forms.DataGridView();
			this.label_error = new System.Windows.Forms.Label();
			this.button_Save = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.richTextBox_OutputExplain = new System.Windows.Forms.RichTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.richTextBox_InputExplain = new System.Windows.Forms.RichTextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox_InputTitle = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox_OutputTitle = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
			this.SuspendLayout();
			// 
			// button_Add
			// 
			this.button_Add.Location = new System.Drawing.Point(388, 125);
			this.button_Add.Name = "button_Add";
			this.button_Add.Size = new System.Drawing.Size(75, 23);
			this.button_Add.TabIndex = 2;
			this.button_Add.Text = "追加";
			this.button_Add.UseVisualStyleBackColor = true;
			this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
			// 
			// button_Delete
			// 
			this.button_Delete.Location = new System.Drawing.Point(388, 257);
			this.button_Delete.Name = "button_Delete";
			this.button_Delete.Size = new System.Drawing.Size(75, 23);
			this.button_Delete.TabIndex = 2;
			this.button_Delete.Text = "削除";
			this.button_Delete.UseVisualStyleBackColor = true;
			this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
			// 
			// textBox_InputID
			// 
			this.textBox_InputID.Location = new System.Drawing.Point(23, 91);
			this.textBox_InputID.Name = "textBox_InputID";
			this.textBox_InputID.Size = new System.Drawing.Size(130, 19);
			this.textBox_InputID.TabIndex = 1;
			// 
			// textBox_InputPass
			// 
			this.textBox_InputPass.Location = new System.Drawing.Point(23, 129);
			this.textBox_InputPass.Name = "textBox_InputPass";
			this.textBox_InputPass.Size = new System.Drawing.Size(130, 19);
			this.textBox_InputPass.TabIndex = 1;
			// 
			// textBox_OutputID
			// 
			this.textBox_OutputID.Location = new System.Drawing.Point(192, 222);
			this.textBox_OutputID.Name = "textBox_OutputID";
			this.textBox_OutputID.ReadOnly = true;
			this.textBox_OutputID.Size = new System.Drawing.Size(130, 19);
			this.textBox_OutputID.TabIndex = 1;
			// 
			// textBox_OutputPass
			// 
			this.textBox_OutputPass.Location = new System.Drawing.Point(192, 259);
			this.textBox_OutputPass.Name = "textBox_OutputPass";
			this.textBox_OutputPass.ReadOnly = true;
			this.textBox_OutputPass.Size = new System.Drawing.Size(130, 19);
			this.textBox_OutputPass.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 73);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 12);
			this.label1.TabIndex = 3;
			this.label1.Text = "MailAddress / ID";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 114);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "PassWord";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(179, 204);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(93, 12);
			this.label3.TabIndex = 3;
			this.label3.Text = "MailAddress / ID";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(179, 244);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(55, 12);
			this.label4.TabIndex = 3;
			this.label4.Text = "PassWord";
			// 
			// dataGridView_Data
			// 
			this.dataGridView_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_Data.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dataGridView_Data.Location = new System.Drawing.Point(23, 179);
			this.dataGridView_Data.MultiSelect = false;
			this.dataGridView_Data.Name = "dataGridView_Data";
			this.dataGridView_Data.ReadOnly = true;
			this.dataGridView_Data.RowTemplate.Height = 21;
			this.dataGridView_Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_Data.Size = new System.Drawing.Size(130, 177);
			this.dataGridView_Data.TabIndex = 4;
			this.dataGridView_Data.Click += new System.EventHandler(this.DataGridView_Cell_Clicked);
			// 
			// label_error
			// 
			this.label_error.AutoSize = true;
			this.label_error.ForeColor = System.Drawing.Color.Red;
			this.label_error.Location = new System.Drawing.Point(21, 369);
			this.label_error.Name = "label_error";
			this.label_error.Size = new System.Drawing.Size(37, 12);
			this.label_error.TabIndex = 5;
			this.label_error.Text = "        ";
			this.label_error.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// button_Save
			// 
			this.button_Save.Location = new System.Drawing.Point(388, 369);
			this.button_Save.Name = "button_Save";
			this.button_Save.Size = new System.Drawing.Size(75, 23);
			this.button_Save.TabIndex = 6;
			this.button_Save.Text = "保存";
			this.button_Save.UseVisualStyleBackColor = true;
			this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(182, 31);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(42, 12);
			this.label5.TabIndex = 3;
			this.label5.Text = "Explain";
			// 
			// richTextBox_OutputExplain
			// 
			this.richTextBox_OutputExplain.Location = new System.Drawing.Point(192, 299);
			this.richTextBox_OutputExplain.Name = "richTextBox_OutputExplain";
			this.richTextBox_OutputExplain.ReadOnly = true;
			this.richTextBox_OutputExplain.Size = new System.Drawing.Size(271, 54);
			this.richTextBox_OutputExplain.TabIndex = 8;
			this.richTextBox_OutputExplain.Text = "";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(179, 284);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(42, 12);
			this.label6.TabIndex = 3;
			this.label6.Text = "Explain";
			// 
			// richTextBox_InputExplain
			// 
			this.richTextBox_InputExplain.Location = new System.Drawing.Point(192, 48);
			this.richTextBox_InputExplain.Name = "richTextBox_InputExplain";
			this.richTextBox_InputExplain.Size = new System.Drawing.Size(271, 62);
			this.richTextBox_InputExplain.TabIndex = 8;
			this.richTextBox_InputExplain.Text = "";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(13, 164);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(29, 12);
			this.label7.TabIndex = 3;
			this.label7.Text = "リスト";
			// 
			// textBox_InputTitle
			// 
			this.textBox_InputTitle.Location = new System.Drawing.Point(23, 51);
			this.textBox_InputTitle.Name = "textBox_InputTitle";
			this.textBox_InputTitle.Size = new System.Drawing.Size(130, 19);
			this.textBox_InputTitle.TabIndex = 1;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(13, 33);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(28, 12);
			this.label8.TabIndex = 3;
			this.label8.Text = "Title";
			// 
			// textBox_OutputTitle
			// 
			this.textBox_OutputTitle.Location = new System.Drawing.Point(192, 182);
			this.textBox_OutputTitle.Name = "textBox_OutputTitle";
			this.textBox_OutputTitle.ReadOnly = true;
			this.textBox_OutputTitle.Size = new System.Drawing.Size(130, 19);
			this.textBox_OutputTitle.TabIndex = 1;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(182, 164);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(28, 12);
			this.label9.TabIndex = 3;
			this.label9.Text = "Title";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(493, 409);
			this.Controls.Add(this.richTextBox_InputExplain);
			this.Controls.Add(this.richTextBox_OutputExplain);
			this.Controls.Add(this.button_Save);
			this.Controls.Add(this.label_error);
			this.Controls.Add(this.dataGridView_Data);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button_Delete);
			this.Controls.Add(this.button_Add);
			this.Controls.Add(this.textBox_OutputPass);
			this.Controls.Add(this.textBox_OutputID);
			this.Controls.Add(this.textBox_InputPass);
			this.Controls.Add(this.textBox_OutputTitle);
			this.Controls.Add(this.textBox_InputTitle);
			this.Controls.Add(this.textBox_InputID);
			this.Name = "Form1";
			this.Text = "パスワード管理ソフト";
			this.Load += new System.EventHandler(this.Form_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button_Add;
		private System.Windows.Forms.Button button_Delete;
		private System.Windows.Forms.TextBox textBox_InputID;
		private System.Windows.Forms.TextBox textBox_InputPass;
		private System.Windows.Forms.TextBox textBox_OutputID;
		private System.Windows.Forms.TextBox textBox_OutputPass;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridView dataGridView_Data;
		private System.Windows.Forms.Label label_error;
		private System.Windows.Forms.Button button_Save;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RichTextBox richTextBox_OutputExplain;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RichTextBox richTextBox_InputExplain;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox_InputTitle;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox_OutputTitle;
		private System.Windows.Forms.Label label9;
	}
}

