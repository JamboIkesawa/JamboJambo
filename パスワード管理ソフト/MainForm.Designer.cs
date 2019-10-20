namespace パスワード管理ソフト
{
	partial class MainForm
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
			this.textBox_InputID = new System.Windows.Forms.TextBox();
			this.textBox_InputPass = new System.Windows.Forms.TextBox();
			this.label_InputMailID = new System.Windows.Forms.Label();
			this.label_InputPassword = new System.Windows.Forms.Label();
			this.dataGridView_Data = new System.Windows.Forms.DataGridView();
			this.label_error = new System.Windows.Forms.Label();
			this.button_Save = new System.Windows.Forms.Button();
			this.label_Explain = new System.Windows.Forms.Label();
			this.richTextBox_InputExplain = new System.Windows.Forms.RichTextBox();
			this.label_List = new System.Windows.Forms.Label();
			this.textBox_InputTitle = new System.Windows.Forms.TextBox();
			this.label_InputTitle = new System.Windows.Forms.Label();
			this.textBox_OutputTitle = new System.Windows.Forms.TextBox();
			this.textBox_OutputID = new System.Windows.Forms.TextBox();
			this.textBox_OutputPass = new System.Windows.Forms.TextBox();
			this.button_Delete = new System.Windows.Forms.Button();
			this.label_OutputTitle = new System.Windows.Forms.Label();
			this.label_OutputExplain = new System.Windows.Forms.Label();
			this.label_OutputMailID = new System.Windows.Forms.Label();
			this.label_OutputPassword = new System.Windows.Forms.Label();
			this.richTextBox_OutputExplain = new System.Windows.Forms.RichTextBox();
			this.groupBox_Output = new System.Windows.Forms.GroupBox();
			this.button_FormOpen = new System.Windows.Forms.Button();
			this.groupBox_Input = new System.Windows.Forms.GroupBox();
			this.button_Load = new System.Windows.Forms.Button();
			this.button_Close = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
			this.groupBox_Output.SuspendLayout();
			this.groupBox_Input.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button_Add
			// 
			this.button_Add.Location = new System.Drawing.Point(207, 110);
			this.button_Add.Name = "button_Add";
			this.button_Add.Size = new System.Drawing.Size(75, 23);
			this.button_Add.TabIndex = 5;
			this.button_Add.Text = "追加";
			this.button_Add.UseVisualStyleBackColor = true;
			this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
			// 
			// textBox_InputID
			// 
			this.textBox_InputID.Location = new System.Drawing.Point(11, 76);
			this.textBox_InputID.Name = "textBox_InputID";
			this.textBox_InputID.Size = new System.Drawing.Size(130, 19);
			this.textBox_InputID.TabIndex = 2;
			// 
			// textBox_InputPass
			// 
			this.textBox_InputPass.Location = new System.Drawing.Point(11, 114);
			this.textBox_InputPass.Name = "textBox_InputPass";
			this.textBox_InputPass.Size = new System.Drawing.Size(130, 19);
			this.textBox_InputPass.TabIndex = 3;
			// 
			// label_InputMailID
			// 
			this.label_InputMailID.AutoSize = true;
			this.label_InputMailID.Location = new System.Drawing.Point(1, 58);
			this.label_InputMailID.Name = "label_InputMailID";
			this.label_InputMailID.Size = new System.Drawing.Size(86, 12);
			this.label_InputMailID.TabIndex = 3;
			this.label_InputMailID.Text = "メールアドレス/ID";
			// 
			// label_InputPassword
			// 
			this.label_InputPassword.AutoSize = true;
			this.label_InputPassword.Location = new System.Drawing.Point(1, 99);
			this.label_InputPassword.Name = "label_InputPassword";
			this.label_InputPassword.Size = new System.Drawing.Size(52, 12);
			this.label_InputPassword.TabIndex = 3;
			this.label_InputPassword.Text = "パスワード";
			// 
			// dataGridView_Data
			// 
			this.dataGridView_Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView_Data.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_Data.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dataGridView_Data.Location = new System.Drawing.Point(21, 270);
			this.dataGridView_Data.MultiSelect = false;
			this.dataGridView_Data.Name = "dataGridView_Data";
			this.dataGridView_Data.ReadOnly = true;
			this.dataGridView_Data.RowTemplate.Height = 21;
			this.dataGridView_Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_Data.Size = new System.Drawing.Size(156, 177);
			this.dataGridView_Data.TabIndex = 12;
			this.dataGridView_Data.Click += new System.EventHandler(this.DataGridView_Cell_Clicked);
			// 
			// label_error
			// 
			this.label_error.AutoSize = true;
			this.label_error.ForeColor = System.Drawing.Color.Red;
			this.label_error.Location = new System.Drawing.Point(206, 270);
			this.label_error.Name = "label_error";
			this.label_error.Size = new System.Drawing.Size(37, 12);
			this.label_error.TabIndex = 5;
			this.label_error.Text = "        ";
			this.label_error.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// button_Save
			// 
			this.button_Save.Location = new System.Drawing.Point(208, 424);
			this.button_Save.Name = "button_Save";
			this.button_Save.Size = new System.Drawing.Size(75, 23);
			this.button_Save.TabIndex = 7;
			this.button_Save.Text = "保存";
			this.button_Save.UseVisualStyleBackColor = true;
			this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
			// 
			// label_Explain
			// 
			this.label_Explain.AutoSize = true;
			this.label_Explain.Location = new System.Drawing.Point(1, 138);
			this.label_Explain.Name = "label_Explain";
			this.label_Explain.Size = new System.Drawing.Size(29, 12);
			this.label_Explain.TabIndex = 3;
			this.label_Explain.Text = "備考";
			// 
			// richTextBox_InputExplain
			// 
			this.richTextBox_InputExplain.Location = new System.Drawing.Point(11, 154);
			this.richTextBox_InputExplain.Name = "richTextBox_InputExplain";
			this.richTextBox_InputExplain.Size = new System.Drawing.Size(271, 52);
			this.richTextBox_InputExplain.TabIndex = 4;
			this.richTextBox_InputExplain.Text = "";
			// 
			// label_List
			// 
			this.label_List.AutoSize = true;
			this.label_List.Location = new System.Drawing.Point(11, 255);
			this.label_List.Name = "label_List";
			this.label_List.Size = new System.Drawing.Size(29, 12);
			this.label_List.TabIndex = 3;
			this.label_List.Text = "リスト";
			// 
			// textBox_InputTitle
			// 
			this.textBox_InputTitle.Location = new System.Drawing.Point(11, 36);
			this.textBox_InputTitle.Name = "textBox_InputTitle";
			this.textBox_InputTitle.Size = new System.Drawing.Size(130, 19);
			this.textBox_InputTitle.TabIndex = 1;
			// 
			// label_InputTitle
			// 
			this.label_InputTitle.AutoSize = true;
			this.label_InputTitle.Location = new System.Drawing.Point(1, 18);
			this.label_InputTitle.Name = "label_InputTitle";
			this.label_InputTitle.Size = new System.Drawing.Size(40, 12);
			this.label_InputTitle.TabIndex = 3;
			this.label_InputTitle.Text = "タイトル";
			// 
			// textBox_OutputTitle
			// 
			this.textBox_OutputTitle.Location = new System.Drawing.Point(28, 37);
			this.textBox_OutputTitle.Name = "textBox_OutputTitle";
			this.textBox_OutputTitle.ReadOnly = true;
			this.textBox_OutputTitle.Size = new System.Drawing.Size(130, 19);
			this.textBox_OutputTitle.TabIndex = 8;
			// 
			// textBox_OutputID
			// 
			this.textBox_OutputID.Location = new System.Drawing.Point(28, 77);
			this.textBox_OutputID.Name = "textBox_OutputID";
			this.textBox_OutputID.ReadOnly = true;
			this.textBox_OutputID.Size = new System.Drawing.Size(130, 19);
			this.textBox_OutputID.TabIndex = 9;
			// 
			// textBox_OutputPass
			// 
			this.textBox_OutputPass.Location = new System.Drawing.Point(28, 114);
			this.textBox_OutputPass.Name = "textBox_OutputPass";
			this.textBox_OutputPass.ReadOnly = true;
			this.textBox_OutputPass.Size = new System.Drawing.Size(130, 19);
			this.textBox_OutputPass.TabIndex = 10;
			// 
			// button_Delete
			// 
			this.button_Delete.Location = new System.Drawing.Point(224, 112);
			this.button_Delete.Name = "button_Delete";
			this.button_Delete.Size = new System.Drawing.Size(75, 23);
			this.button_Delete.TabIndex = 6;
			this.button_Delete.Text = "削除";
			this.button_Delete.UseVisualStyleBackColor = true;
			this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
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
			// label_OutputExplain
			// 
			this.label_OutputExplain.AutoSize = true;
			this.label_OutputExplain.Location = new System.Drawing.Point(15, 139);
			this.label_OutputExplain.Name = "label_OutputExplain";
			this.label_OutputExplain.Size = new System.Drawing.Size(29, 12);
			this.label_OutputExplain.TabIndex = 3;
			this.label_OutputExplain.Text = "備考";
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
			// label_OutputPassword
			// 
			this.label_OutputPassword.AutoSize = true;
			this.label_OutputPassword.Location = new System.Drawing.Point(15, 99);
			this.label_OutputPassword.Name = "label_OutputPassword";
			this.label_OutputPassword.Size = new System.Drawing.Size(52, 12);
			this.label_OutputPassword.TabIndex = 3;
			this.label_OutputPassword.Text = "パスワード";
			// 
			// richTextBox_OutputExplain
			// 
			this.richTextBox_OutputExplain.Location = new System.Drawing.Point(28, 154);
			this.richTextBox_OutputExplain.Name = "richTextBox_OutputExplain";
			this.richTextBox_OutputExplain.ReadOnly = true;
			this.richTextBox_OutputExplain.Size = new System.Drawing.Size(271, 54);
			this.richTextBox_OutputExplain.TabIndex = 11;
			this.richTextBox_OutputExplain.Text = "";
			// 
			// groupBox_Output
			// 
			this.groupBox_Output.Controls.Add(this.button_FormOpen);
			this.groupBox_Output.Controls.Add(this.richTextBox_OutputExplain);
			this.groupBox_Output.Controls.Add(this.label_OutputPassword);
			this.groupBox_Output.Controls.Add(this.label_OutputMailID);
			this.groupBox_Output.Controls.Add(this.label_OutputExplain);
			this.groupBox_Output.Controls.Add(this.label_OutputTitle);
			this.groupBox_Output.Controls.Add(this.button_Delete);
			this.groupBox_Output.Controls.Add(this.textBox_OutputPass);
			this.groupBox_Output.Controls.Add(this.textBox_OutputID);
			this.groupBox_Output.Controls.Add(this.textBox_OutputTitle);
			this.groupBox_Output.Location = new System.Drawing.Point(324, 24);
			this.groupBox_Output.Name = "groupBox_Output";
			this.groupBox_Output.Size = new System.Drawing.Size(339, 228);
			this.groupBox_Output.TabIndex = 9;
			this.groupBox_Output.TabStop = false;
			this.groupBox_Output.Text = "出力フィールド";
			// 
			// button_FormOpen
			// 
			this.button_FormOpen.Location = new System.Drawing.Point(224, 83);
			this.button_FormOpen.Name = "button_FormOpen";
			this.button_FormOpen.Size = new System.Drawing.Size(75, 23);
			this.button_FormOpen.TabIndex = 12;
			this.button_FormOpen.Text = "別窓で開く";
			this.button_FormOpen.UseVisualStyleBackColor = true;
			this.button_FormOpen.Click += new System.EventHandler(this.Button_FormOpen_Click);
			// 
			// groupBox_Input
			// 
			this.groupBox_Input.Controls.Add(this.richTextBox_InputExplain);
			this.groupBox_Input.Controls.Add(this.label_Explain);
			this.groupBox_Input.Controls.Add(this.label_InputPassword);
			this.groupBox_Input.Controls.Add(this.label_InputTitle);
			this.groupBox_Input.Controls.Add(this.label_InputMailID);
			this.groupBox_Input.Controls.Add(this.button_Add);
			this.groupBox_Input.Controls.Add(this.textBox_InputPass);
			this.groupBox_Input.Controls.Add(this.textBox_InputTitle);
			this.groupBox_Input.Controls.Add(this.textBox_InputID);
			this.groupBox_Input.Location = new System.Drawing.Point(10, 24);
			this.groupBox_Input.Name = "groupBox_Input";
			this.groupBox_Input.Size = new System.Drawing.Size(301, 227);
			this.groupBox_Input.TabIndex = 10;
			this.groupBox_Input.TabStop = false;
			this.groupBox_Input.Text = "入力フィールド";
			// 
			// button_Load
			// 
			this.button_Load.Location = new System.Drawing.Point(208, 395);
			this.button_Load.Name = "button_Load";
			this.button_Load.Size = new System.Drawing.Size(75, 23);
			this.button_Load.TabIndex = 13;
			this.button_Load.Text = "開く";
			this.button_Load.UseVisualStyleBackColor = true;
			this.button_Load.Click += new System.EventHandler(this.Button_Load_Click);
			// 
			// button_Close
			// 
			this.button_Close.Location = new System.Drawing.Point(548, 424);
			this.button_Close.Name = "button_Close";
			this.button_Close.Size = new System.Drawing.Size(75, 23);
			this.button_Close.TabIndex = 14;
			this.button_Close.Text = "閉じる";
			this.button_Close.UseVisualStyleBackColor = true;
			this.button_Close.Click += new System.EventHandler(this.Button_Close_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.richTextBox1);
			this.panel1.Location = new System.Drawing.Point(326, 279);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(336, 116);
			this.panel1.TabIndex = 15;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(7, 9);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(322, 99);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "ヘルプ\n<入力フィールド>で入力した内容を追加すると、<リスト>に追加されます。\n<リスト>に追加したものをクリックすると、<出力フィールド>に情報を表示します。" +
    "\n";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(675, 481);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.button_Close);
			this.Controls.Add(this.button_Load);
			this.Controls.Add(this.groupBox_Input);
			this.Controls.Add(this.groupBox_Output);
			this.Controls.Add(this.button_Save);
			this.Controls.Add(this.label_error);
			this.Controls.Add(this.dataGridView_Data);
			this.Controls.Add(this.label_List);
			this.Name = "MainForm";
			this.Text = "パスワード管理ソフト";
			this.Load += new System.EventHandler(this.Form_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
			this.groupBox_Output.ResumeLayout(false);
			this.groupBox_Output.PerformLayout();
			this.groupBox_Input.ResumeLayout(false);
			this.groupBox_Input.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button_Add;
		private System.Windows.Forms.TextBox textBox_InputID;
		private System.Windows.Forms.TextBox textBox_InputPass;
		private System.Windows.Forms.Label label_InputMailID;
		private System.Windows.Forms.Label label_InputPassword;
		private System.Windows.Forms.DataGridView dataGridView_Data;
		private System.Windows.Forms.Label label_error;
		private System.Windows.Forms.Button button_Save;
		private System.Windows.Forms.Label label_Explain;
		private System.Windows.Forms.RichTextBox richTextBox_InputExplain;
		private System.Windows.Forms.Label label_List;
		private System.Windows.Forms.TextBox textBox_InputTitle;
		private System.Windows.Forms.Label label_InputTitle;
		private System.Windows.Forms.TextBox textBox_OutputTitle;
		private System.Windows.Forms.TextBox textBox_OutputID;
		private System.Windows.Forms.TextBox textBox_OutputPass;
		private System.Windows.Forms.Button button_Delete;
		private System.Windows.Forms.Label label_OutputTitle;
		private System.Windows.Forms.Label label_OutputExplain;
		private System.Windows.Forms.Label label_OutputMailID;
		private System.Windows.Forms.Label label_OutputPassword;
		private System.Windows.Forms.RichTextBox richTextBox_OutputExplain;
		private System.Windows.Forms.GroupBox groupBox_Output;
		private System.Windows.Forms.GroupBox groupBox_Input;
		private System.Windows.Forms.Button button_FormOpen;
		private System.Windows.Forms.Button button_Load;
		private System.Windows.Forms.Button button_Close;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RichTextBox richTextBox1;
	}
}

