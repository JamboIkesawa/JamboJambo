namespace Launch_Soft_Together
{
	partial class Main
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
			this.button_ChooseList = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.button_Add = new System.Windows.Forms.Button();
			this.button_Launch = new System.Windows.Forms.Button();
			this.button_Close = new System.Windows.Forms.Button();
			this.button_Delete = new System.Windows.Forms.Button();
			this.button_Edit = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// button_ChooseList
			// 
			this.button_ChooseList.Location = new System.Drawing.Point(31, 215);
			this.button_ChooseList.Name = "button_ChooseList";
			this.button_ChooseList.Size = new System.Drawing.Size(75, 23);
			this.button_ChooseList.TabIndex = 0;
			this.button_ChooseList.Text = "リスト選択";
			this.button_ChooseList.UseVisualStyleBackColor = true;
			this.button_ChooseList.Click += new System.EventHandler(this.button_ChooseList_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(21, 29);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(307, 158);
			this.dataGridView1.TabIndex = 1;
			// 
			// button_Add
			// 
			this.button_Add.Location = new System.Drawing.Point(112, 215);
			this.button_Add.Name = "button_Add";
			this.button_Add.Size = new System.Drawing.Size(75, 23);
			this.button_Add.TabIndex = 0;
			this.button_Add.Text = "追加";
			this.button_Add.UseVisualStyleBackColor = true;
			this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
			// 
			// button_Launch
			// 
			this.button_Launch.Location = new System.Drawing.Point(284, 256);
			this.button_Launch.Name = "button_Launch";
			this.button_Launch.Size = new System.Drawing.Size(75, 23);
			this.button_Launch.TabIndex = 0;
			this.button_Launch.Text = "起動";
			this.button_Launch.UseVisualStyleBackColor = true;
			this.button_Launch.Click += new System.EventHandler(this.button_Launch_Click);
			// 
			// button_Close
			// 
			this.button_Close.Location = new System.Drawing.Point(365, 256);
			this.button_Close.Name = "button_Close";
			this.button_Close.Size = new System.Drawing.Size(75, 23);
			this.button_Close.TabIndex = 0;
			this.button_Close.Text = "閉じる";
			this.button_Close.UseVisualStyleBackColor = true;
			this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
			// 
			// button_Delete
			// 
			this.button_Delete.Location = new System.Drawing.Point(193, 215);
			this.button_Delete.Name = "button_Delete";
			this.button_Delete.Size = new System.Drawing.Size(75, 23);
			this.button_Delete.TabIndex = 0;
			this.button_Delete.Text = "削除";
			this.button_Delete.UseVisualStyleBackColor = true;
			this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
			// 
			// button_Edit
			// 
			this.button_Edit.Location = new System.Drawing.Point(31, 244);
			this.button_Edit.Name = "button_Edit";
			this.button_Edit.Size = new System.Drawing.Size(75, 23);
			this.button_Edit.TabIndex = 0;
			this.button_Edit.Text = "リスト編集";
			this.button_Edit.UseVisualStyleBackColor = true;
			this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(452, 291);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.button_Close);
			this.Controls.Add(this.button_Launch);
			this.Controls.Add(this.button_Delete);
			this.Controls.Add(this.button_Add);
			this.Controls.Add(this.button_Edit);
			this.Controls.Add(this.button_ChooseList);
			this.Name = "Main";
			this.Text = "ソフトをまとめて立ち上げるソフト";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button_ChooseList;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Launch;
        private System.Windows.Forms.Button button_Close;
		private System.Windows.Forms.Button button_Delete;
		private System.Windows.Forms.Button button_Edit;
	}
}

