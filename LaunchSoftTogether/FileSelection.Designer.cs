namespace Launch_Soft_Together
{
	partial class FileSelection
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
            this.dataGridView_FileList = new System.Windows.Forms.DataGridView();
            this.button_ListOpen = new System.Windows.Forms.Button();
            this.checkBox_LaunchConfirm = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_FileList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_FileList
            // 
            this.dataGridView_FileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_FileList.Location = new System.Drawing.Point(16, 15);
            this.dataGridView_FileList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_FileList.Name = "dataGridView_FileList";
            this.dataGridView_FileList.RowHeadersWidth = 51;
            this.dataGridView_FileList.RowTemplate.Height = 21;
            this.dataGridView_FileList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_FileList.Size = new System.Drawing.Size(221, 249);
            this.dataGridView_FileList.TabIndex = 0;
            this.dataGridView_FileList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_FileList_CellContentClick);
            this.dataGridView_FileList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_FileList_CellContentDoubleClick);
            // 
            // button_ListOpen
            // 
            this.button_ListOpen.Location = new System.Drawing.Point(137, 299);
            this.button_ListOpen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_ListOpen.Name = "button_ListOpen";
            this.button_ListOpen.Size = new System.Drawing.Size(100, 29);
            this.button_ListOpen.TabIndex = 1;
            this.button_ListOpen.Text = "開く";
            this.button_ListOpen.UseVisualStyleBackColor = true;
            this.button_ListOpen.Click += new System.EventHandler(this.button_ListOpen_Click);
            // 
            // checkBox_LaunchConfirm
            // 
            this.checkBox_LaunchConfirm.AutoSize = true;
            this.checkBox_LaunchConfirm.Location = new System.Drawing.Point(16, 271);
            this.checkBox_LaunchConfirm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_LaunchConfirm.Name = "checkBox_LaunchConfirm";
            this.checkBox_LaunchConfirm.Size = new System.Drawing.Size(206, 19);
            this.checkBox_LaunchConfirm.TabIndex = 4;
            this.checkBox_LaunchConfirm.Text = "起動時に前回のデータを開く。";
            this.checkBox_LaunchConfirm.UseVisualStyleBackColor = true;
            // 
            // FileSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 338);
            this.Controls.Add(this.checkBox_LaunchConfirm);
            this.Controls.Add(this.button_ListOpen);
            this.Controls.Add(this.dataGridView_FileList);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileSelection";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "開くファイルを選択";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileSelection_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_FileList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView_FileList;
		private System.Windows.Forms.Button button_ListOpen;
		private System.Windows.Forms.CheckBox checkBox_LaunchConfirm;
	}
}