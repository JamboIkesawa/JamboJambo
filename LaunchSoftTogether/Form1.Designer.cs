﻿namespace Launch_Soft_Together
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
			this.button_Display = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.button_Add = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// button_Display
			// 
			this.button_Display.Location = new System.Drawing.Point(31, 169);
			this.button_Display.Name = "button_Display";
			this.button_Display.Size = new System.Drawing.Size(75, 23);
			this.button_Display.TabIndex = 0;
			this.button_Display.Text = "表示";
			this.button_Display.UseVisualStyleBackColor = true;
			this.button_Display.Click += new System.EventHandler(this.button_Display_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(31, 31);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(382, 121);
			this.dataGridView1.TabIndex = 1;
			// 
			// button_Add
			// 
			this.button_Add.Location = new System.Drawing.Point(128, 169);
			this.button_Add.Name = "button_Add";
			this.button_Add.Size = new System.Drawing.Size(75, 23);
			this.button_Add.TabIndex = 0;
			this.button_Add.Text = "追加";
			this.button_Add.UseVisualStyleBackColor = true;
			this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(452, 219);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.button_Add);
			this.Controls.Add(this.button_Display);
			this.Name = "Form1";
			this.Text = "ソフトをまとめて立ち上げるソフト";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button_Display;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button button_Add;
	}
}

