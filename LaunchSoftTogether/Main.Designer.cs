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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.button_ChooseList = new System.Windows.Forms.Button();
			this.dataGridView_Current = new System.Windows.Forms.DataGridView();
			this.button_Add = new System.Windows.Forms.Button();
			this.button_Launch = new System.Windows.Forms.Button();
			this.button_Close = new System.Windows.Forms.Button();
			this.button_Delete = new System.Windows.Forms.Button();
			this.button_Edit = new System.Windows.Forms.Button();
			this.button_Save = new System.Windows.Forms.Button();
			this.dataGridView_Prev = new System.Windows.Forms.DataGridView();
			this.label_Previous = new System.Windows.Forms.Label();
			this.label_Current = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Current)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Prev)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// button_ChooseList
			// 
			this.button_ChooseList.Location = new System.Drawing.Point(27, 383);
			this.button_ChooseList.Name = "button_ChooseList";
			this.button_ChooseList.Size = new System.Drawing.Size(75, 23);
			this.button_ChooseList.TabIndex = 0;
			this.button_ChooseList.Text = "リスト選択";
			this.button_ChooseList.UseVisualStyleBackColor = true;
			this.button_ChooseList.Click += new System.EventHandler(this.button_ChooseList_Click);
			// 
			// dataGridView_Current
			// 
			this.dataGridView_Current.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_Current.Location = new System.Drawing.Point(8, 29);
			this.dataGridView_Current.MultiSelect = false;
			this.dataGridView_Current.Name = "dataGridView_Current";
			this.dataGridView_Current.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_Current.Size = new System.Drawing.Size(198, 158);
			this.dataGridView_Current.TabIndex = 1;
			this.dataGridView_Current.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Current_CellContentClick);
			// 
			// button_Add
			// 
			this.button_Add.Location = new System.Drawing.Point(27, 354);
			this.button_Add.Name = "button_Add";
			this.button_Add.Size = new System.Drawing.Size(75, 23);
			this.button_Add.TabIndex = 0;
			this.button_Add.Text = "追加";
			this.button_Add.UseVisualStyleBackColor = true;
			this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
			// 
			// button_Launch
			// 
			this.button_Launch.Location = new System.Drawing.Point(108, 412);
			this.button_Launch.Name = "button_Launch";
			this.button_Launch.Size = new System.Drawing.Size(75, 23);
			this.button_Launch.TabIndex = 0;
			this.button_Launch.Text = "起動";
			this.button_Launch.UseVisualStyleBackColor = true;
			this.button_Launch.Click += new System.EventHandler(this.button_Launch_Click);
			// 
			// button_Close
			// 
			this.button_Close.Location = new System.Drawing.Point(369, 430);
			this.button_Close.Name = "button_Close";
			this.button_Close.Size = new System.Drawing.Size(75, 23);
			this.button_Close.TabIndex = 0;
			this.button_Close.Text = "閉じる";
			this.button_Close.UseVisualStyleBackColor = true;
			this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
			// 
			// button_Delete
			// 
			this.button_Delete.Location = new System.Drawing.Point(108, 354);
			this.button_Delete.Name = "button_Delete";
			this.button_Delete.Size = new System.Drawing.Size(75, 23);
			this.button_Delete.TabIndex = 0;
			this.button_Delete.Text = "削除";
			this.button_Delete.UseVisualStyleBackColor = true;
			this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
			// 
			// button_Edit
			// 
			this.button_Edit.Location = new System.Drawing.Point(27, 412);
			this.button_Edit.Name = "button_Edit";
			this.button_Edit.Size = new System.Drawing.Size(75, 23);
			this.button_Edit.TabIndex = 0;
			this.button_Edit.Text = "リスト編集";
			this.button_Edit.UseVisualStyleBackColor = true;
			this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
			// 
			// button_Save
			// 
			this.button_Save.Location = new System.Drawing.Point(108, 383);
			this.button_Save.Name = "button_Save";
			this.button_Save.Size = new System.Drawing.Size(75, 23);
			this.button_Save.TabIndex = 0;
			this.button_Save.Text = "保存";
			this.button_Save.UseVisualStyleBackColor = true;
			this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
			// 
			// dataGridView_Prev
			// 
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
			this.dataGridView_Prev.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView_Prev.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dataGridView_Prev.Location = new System.Drawing.Point(9, 29);
			this.dataGridView_Prev.MultiSelect = false;
			this.dataGridView_Prev.Name = "dataGridView_Prev";
			this.dataGridView_Prev.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_Prev.Size = new System.Drawing.Size(198, 158);
			this.dataGridView_Prev.TabIndex = 2;
			// 
			// label_Previous
			// 
			this.label_Previous.AutoSize = true;
			this.label_Previous.Location = new System.Drawing.Point(3, 4);
			this.label_Previous.Name = "label_Previous";
			this.label_Previous.Size = new System.Drawing.Size(128, 12);
			this.label_Previous.TabIndex = 3;
			this.label_Previous.Text = "前回最後に起動したリスト";
			// 
			// label_Current
			// 
			this.label_Current.AutoSize = true;
			this.label_Current.Location = new System.Drawing.Point(3, 4);
			this.label_Current.Name = "label_Current";
			this.label_Current.Size = new System.Drawing.Size(96, 12);
			this.label_Current.TabIndex = 4;
			this.label_Current.Text = "今回起動するリスト";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label_Current);
			this.panel1.Controls.Add(this.dataGridView_Current);
			this.panel1.Location = new System.Drawing.Point(238, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(215, 293);
			this.panel1.TabIndex = 5;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label_Previous);
			this.panel2.Controls.Add(this.dataGridView_Prev);
			this.panel2.Location = new System.Drawing.Point(9, 12);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(223, 293);
			this.panel2.TabIndex = 6;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(462, 465);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.button_Close);
			this.Controls.Add(this.button_Launch);
			this.Controls.Add(this.button_Delete);
			this.Controls.Add(this.button_Save);
			this.Controls.Add(this.button_Add);
			this.Controls.Add(this.button_Edit);
			this.Controls.Add(this.button_ChooseList);
			this.Name = "Main";
			this.Text = "ソフトをまとめて立ち上げるソフト";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Current)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Prev)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button_ChooseList;
		private System.Windows.Forms.DataGridView dataGridView_Current;
		private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Launch;
        private System.Windows.Forms.Button button_Close;
		private System.Windows.Forms.Button button_Delete;
		private System.Windows.Forms.Button button_Edit;
		private System.Windows.Forms.Button button_Save;
		private System.Windows.Forms.DataGridView dataGridView_Prev;
		private System.Windows.Forms.Label label_Previous;
		private System.Windows.Forms.Label label_Current;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
	}
}

