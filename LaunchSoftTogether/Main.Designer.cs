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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.button_ChooseList = new System.Windows.Forms.Button();
			this.dataGridView_Current = new System.Windows.Forms.DataGridView();
			this.button_Add = new System.Windows.Forms.Button();
			this.button_Launch = new System.Windows.Forms.Button();
			this.button_Close = new System.Windows.Forms.Button();
			this.button_Delete = new System.Windows.Forms.Button();
			this.button_Edit = new System.Windows.Forms.Button();
			this.button_Save = new System.Windows.Forms.Button();
			this.label_Current = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.checkBox_LaunchConfirm = new System.Windows.Forms.CheckBox();
			this.checkBox_Message = new System.Windows.Forms.CheckBox();
			this.checkBox_DeleteConfirm = new System.Windows.Forms.CheckBox();
			this.checkBox_DuplicateCheck = new System.Windows.Forms.CheckBox();
			this.dataGridView_Prev = new System.Windows.Forms.DataGridView();
			this.label_Previous = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Current)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Prev)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// button_ChooseList
			// 
			this.button_ChooseList.Location = new System.Drawing.Point(27, 360);
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
			this.dataGridView_Current.ReadOnly = true;
			this.dataGridView_Current.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_Current.Size = new System.Drawing.Size(198, 158);
			this.dataGridView_Current.TabIndex = 1;
			this.dataGridView_Current.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Current_CellContentClick);
			// 
			// button_Add
			// 
			this.button_Add.Location = new System.Drawing.Point(27, 331);
			this.button_Add.Name = "button_Add";
			this.button_Add.Size = new System.Drawing.Size(75, 23);
			this.button_Add.TabIndex = 0;
			this.button_Add.Text = "追加";
			this.button_Add.UseVisualStyleBackColor = true;
			this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
			// 
			// button_Launch
			// 
			this.button_Launch.Location = new System.Drawing.Point(108, 389);
			this.button_Launch.Name = "button_Launch";
			this.button_Launch.Size = new System.Drawing.Size(75, 23);
			this.button_Launch.TabIndex = 0;
			this.button_Launch.Text = "起動";
			this.button_Launch.UseVisualStyleBackColor = true;
			this.button_Launch.Click += new System.EventHandler(this.button_Launch_Click);
			// 
			// button_Close
			// 
			this.button_Close.Location = new System.Drawing.Point(108, 418);
			this.button_Close.Name = "button_Close";
			this.button_Close.Size = new System.Drawing.Size(75, 23);
			this.button_Close.TabIndex = 0;
			this.button_Close.Text = "閉じる";
			this.button_Close.UseVisualStyleBackColor = true;
			this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
			// 
			// button_Delete
			// 
			this.button_Delete.Location = new System.Drawing.Point(108, 331);
			this.button_Delete.Name = "button_Delete";
			this.button_Delete.Size = new System.Drawing.Size(75, 23);
			this.button_Delete.TabIndex = 0;
			this.button_Delete.Text = "削除";
			this.button_Delete.UseVisualStyleBackColor = true;
			this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
			// 
			// button_Edit
			// 
			this.button_Edit.Location = new System.Drawing.Point(27, 389);
			this.button_Edit.Name = "button_Edit";
			this.button_Edit.Size = new System.Drawing.Size(75, 23);
			this.button_Edit.TabIndex = 0;
			this.button_Edit.Text = "リスト編集";
			this.button_Edit.UseVisualStyleBackColor = true;
			this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
			// 
			// button_Save
			// 
			this.button_Save.Location = new System.Drawing.Point(108, 360);
			this.button_Save.Name = "button_Save";
			this.button_Save.Size = new System.Drawing.Size(75, 23);
			this.button_Save.TabIndex = 0;
			this.button_Save.Text = "保存";
			this.button_Save.UseVisualStyleBackColor = true;
			this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
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
			// panel3
			// 
			this.panel3.Controls.Add(this.checkBox_LaunchConfirm);
			this.panel3.Controls.Add(this.checkBox_Message);
			this.panel3.Controls.Add(this.checkBox_DeleteConfirm);
			this.panel3.Controls.Add(this.checkBox_DuplicateCheck);
			this.panel3.Location = new System.Drawing.Point(238, 331);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(215, 89);
			this.panel3.TabIndex = 7;
			// 
			// checkBox_LaunchConfirm
			// 
			this.checkBox_LaunchConfirm.AutoSize = true;
			this.checkBox_LaunchConfirm.Location = new System.Drawing.Point(8, 47);
			this.checkBox_LaunchConfirm.Name = "checkBox_LaunchConfirm";
			this.checkBox_LaunchConfirm.Size = new System.Drawing.Size(166, 16);
			this.checkBox_LaunchConfirm.TabIndex = 3;
			this.checkBox_LaunchConfirm.Text = "起動時に前回のデータを開く。";
			this.checkBox_LaunchConfirm.UseVisualStyleBackColor = true;
			// 
			// checkBox_Message
			// 
			this.checkBox_Message.AutoSize = true;
			this.checkBox_Message.Location = new System.Drawing.Point(8, 69);
			this.checkBox_Message.Name = "checkBox_Message";
			this.checkBox_Message.Size = new System.Drawing.Size(136, 16);
			this.checkBox_Message.TabIndex = 2;
			this.checkBox_Message.Text = "次回から起動させない。";
			this.checkBox_Message.UseVisualStyleBackColor = true;
			// 
			// checkBox_DeleteConfirm
			// 
			this.checkBox_DeleteConfirm.AutoSize = true;
			this.checkBox_DeleteConfirm.Checked = true;
			this.checkBox_DeleteConfirm.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_DeleteConfirm.Location = new System.Drawing.Point(8, 25);
			this.checkBox_DeleteConfirm.Name = "checkBox_DeleteConfirm";
			this.checkBox_DeleteConfirm.Size = new System.Drawing.Size(177, 16);
			this.checkBox_DeleteConfirm.TabIndex = 1;
			this.checkBox_DeleteConfirm.Text = "削除時に確認画面を表示する。";
			this.checkBox_DeleteConfirm.UseVisualStyleBackColor = true;
			// 
			// checkBox_DuplicateCheck
			// 
			this.checkBox_DuplicateCheck.AutoSize = true;
			this.checkBox_DuplicateCheck.Checked = true;
			this.checkBox_DuplicateCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_DuplicateCheck.Location = new System.Drawing.Point(8, 4);
			this.checkBox_DuplicateCheck.Name = "checkBox_DuplicateCheck";
			this.checkBox_DuplicateCheck.Size = new System.Drawing.Size(117, 16);
			this.checkBox_DuplicateCheck.TabIndex = 0;
			this.checkBox_DuplicateCheck.Text = "データの重複を許す";
			this.checkBox_DuplicateCheck.UseVisualStyleBackColor = true;
			// 
			// dataGridView_Prev
			// 
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
			this.dataGridView_Prev.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridView_Prev.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dataGridView_Prev.Location = new System.Drawing.Point(9, 29);
			this.dataGridView_Prev.MultiSelect = false;
			this.dataGridView_Prev.Name = "dataGridView_Prev";
			this.dataGridView_Prev.ReadOnly = true;
			this.dataGridView_Prev.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_Prev.Size = new System.Drawing.Size(198, 158);
			this.dataGridView_Prev.TabIndex = 2;
			// 
			// label_Previous
			// 
			this.label_Previous.AutoSize = true;
			this.label_Previous.Location = new System.Drawing.Point(3, 4);
			this.label_Previous.Name = "label_Previous";
			this.label_Previous.Size = new System.Drawing.Size(63, 12);
			this.label_Previous.TabIndex = 3;
			this.label_Previous.Text = "前回のリスト";
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
			this.ClientSize = new System.Drawing.Size(462, 465);
			this.Controls.Add(this.panel3);
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
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Prev)).EndInit();
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
		private System.Windows.Forms.Label label_Current;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.CheckBox checkBox_LaunchConfirm;
		private System.Windows.Forms.CheckBox checkBox_Message;
		private System.Windows.Forms.CheckBox checkBox_DeleteConfirm;
		private System.Windows.Forms.CheckBox checkBox_DuplicateCheck;
		private System.Windows.Forms.DataGridView dataGridView_Prev;
		private System.Windows.Forms.Label label_Previous;
		private System.Windows.Forms.Panel panel2;
	}
}

