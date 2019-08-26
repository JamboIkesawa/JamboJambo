namespace Launch_Soft_Together
{
	partial class ListManagement
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label_lSoftName = new System.Windows.Forms.Label();
			this.label_SoftName = new System.Windows.Forms.Label();
			this.label_lSoftPath = new System.Windows.Forms.Label();
			this.label_SoftPath = new System.Windows.Forms.Label();
			this.label_ListName = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(14, 33);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 21;
			this.dataGridView1.Size = new System.Drawing.Size(125, 210);
			this.dataGridView1.TabIndex = 0;
			// 
			// label_lSoftName
			// 
			this.label_lSoftName.AutoSize = true;
			this.label_lSoftName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label_lSoftName.Location = new System.Drawing.Point(163, 36);
			this.label_lSoftName.Name = "label_lSoftName";
			this.label_lSoftName.Size = new System.Drawing.Size(58, 16);
			this.label_lSoftName.TabIndex = 1;
			this.label_lSoftName.Text = "ソフト名";
			// 
			// label_SoftName
			// 
			this.label_SoftName.AutoSize = true;
			this.label_SoftName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label_SoftName.Location = new System.Drawing.Point(179, 57);
			this.label_SoftName.Name = "label_SoftName";
			this.label_SoftName.Size = new System.Drawing.Size(32, 16);
			this.label_SoftName.TabIndex = 1;
			this.label_SoftName.Text = "---";
			// 
			// label_lSoftPath
			// 
			this.label_lSoftPath.AutoSize = true;
			this.label_lSoftPath.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label_lSoftPath.Location = new System.Drawing.Point(163, 83);
			this.label_lSoftPath.Name = "label_lSoftPath";
			this.label_lSoftPath.Size = new System.Drawing.Size(33, 16);
			this.label_lSoftPath.TabIndex = 1;
			this.label_lSoftPath.Text = "パス";
			// 
			// label_SoftPath
			// 
			this.label_SoftPath.AutoSize = true;
			this.label_SoftPath.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label_SoftPath.Location = new System.Drawing.Point(179, 104);
			this.label_SoftPath.Name = "label_SoftPath";
			this.label_SoftPath.Size = new System.Drawing.Size(32, 16);
			this.label_SoftPath.TabIndex = 1;
			this.label_SoftPath.Text = "---";
			// 
			// label_ListName
			// 
			this.label_ListName.AutoSize = true;
			this.label_ListName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label_ListName.Location = new System.Drawing.Point(12, 14);
			this.label_ListName.Name = "label_ListName";
			this.label_ListName.Size = new System.Drawing.Size(56, 16);
			this.label_ListName.TabIndex = 1;
			this.label_ListName.Text = "リスト名";
			// 
			// ListManagement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(455, 340);
			this.Controls.Add(this.label_SoftPath);
			this.Controls.Add(this.label_SoftName);
			this.Controls.Add(this.label_lSoftPath);
			this.Controls.Add(this.label_ListName);
			this.Controls.Add(this.label_lSoftName);
			this.Controls.Add(this.dataGridView1);
			this.Name = "ListManagement";
			this.Text = "ListManagement";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label_lSoftName;
		private System.Windows.Forms.Label label_SoftName;
		private System.Windows.Forms.Label label_lSoftPath;
		private System.Windows.Forms.Label label_SoftPath;
		private System.Windows.Forms.Label label_ListName;
	}
}