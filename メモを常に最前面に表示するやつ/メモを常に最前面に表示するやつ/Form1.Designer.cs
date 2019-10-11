namespace メモを常に最前面に表示するやつ
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
			this.label_Title = new System.Windows.Forms.Label();
			this.richTextBox_Memo = new System.Windows.Forms.RichTextBox();
			this.button_Save = new System.Windows.Forms.Button();
			this.button_Open = new System.Windows.Forms.Button();
			this.checkBox_ReadOnly = new System.Windows.Forms.CheckBox();
			this.checkBox_topMost = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label_Title
			// 
			this.label_Title.AutoSize = true;
			this.label_Title.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label_Title.Location = new System.Drawing.Point(9, 10);
			this.label_Title.Name = "label_Title";
			this.label_Title.Size = new System.Drawing.Size(39, 13);
			this.label_Title.TabIndex = 0;
			this.label_Title.Text = "label1";
			// 
			// richTextBox_Memo
			// 
			this.richTextBox_Memo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox_Memo.Location = new System.Drawing.Point(13, 27);
			this.richTextBox_Memo.Name = "richTextBox_Memo";
			this.richTextBox_Memo.Size = new System.Drawing.Size(150, 107);
			this.richTextBox_Memo.TabIndex = 1;
			this.richTextBox_Memo.Text = "";
			this.richTextBox_Memo.TextChanged += new System.EventHandler(this.richTextBox_Memo_TextChanged);
			// 
			// button_Save
			// 
			this.button_Save.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.button_Save.Location = new System.Drawing.Point(93, 159);
			this.button_Save.Name = "button_Save";
			this.button_Save.Size = new System.Drawing.Size(75, 23);
			this.button_Save.TabIndex = 2;
			this.button_Save.Text = "保存";
			this.button_Save.UseVisualStyleBackColor = true;
			this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
			// 
			// button_Open
			// 
			this.button_Open.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.button_Open.Location = new System.Drawing.Point(12, 159);
			this.button_Open.Name = "button_Open";
			this.button_Open.Size = new System.Drawing.Size(75, 23);
			this.button_Open.TabIndex = 2;
			this.button_Open.Text = "開く";
			this.button_Open.UseVisualStyleBackColor = true;
			this.button_Open.Click += new System.EventHandler(this.button_Open_Click);
			// 
			// checkBox_ReadOnly
			// 
			this.checkBox_ReadOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox_ReadOnly.AutoSize = true;
			this.checkBox_ReadOnly.Location = new System.Drawing.Point(12, 140);
			this.checkBox_ReadOnly.Name = "checkBox_ReadOnly";
			this.checkBox_ReadOnly.Size = new System.Drawing.Size(91, 16);
			this.checkBox_ReadOnly.TabIndex = 3;
			this.checkBox_ReadOnly.Text = "読み込みのみ";
			this.checkBox_ReadOnly.UseVisualStyleBackColor = true;
			this.checkBox_ReadOnly.CheckedChanged += new System.EventHandler(this.checkBox_ReadOnly_CheckedChanged);
			// 
			// checkBox_topMost
			// 
			this.checkBox_topMost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox_topMost.AutoSize = true;
			this.checkBox_topMost.Location = new System.Drawing.Point(104, 140);
			this.checkBox_topMost.Name = "checkBox_topMost";
			this.checkBox_topMost.Size = new System.Drawing.Size(72, 16);
			this.checkBox_topMost.TabIndex = 3;
			this.checkBox_topMost.Text = "最前表示";
			this.checkBox_topMost.UseVisualStyleBackColor = true;
			this.checkBox_topMost.CheckedChanged += new System.EventHandler(this.checkBox_TopMost_CheckedChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(175, 187);
			this.Controls.Add(this.checkBox_topMost);
			this.Controls.Add(this.checkBox_ReadOnly);
			this.Controls.Add(this.button_Open);
			this.Controls.Add(this.button_Save);
			this.Controls.Add(this.richTextBox_Memo);
			this.Controls.Add(this.label_Title);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(191, 226);
			this.Name = "Form1";
			this.Text = "Form";
			this.TopMost = true;
			this.SizeChanged += new System.EventHandler(this.richTextBox_Memo_Resize);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label_Title;
		private System.Windows.Forms.RichTextBox richTextBox_Memo;
		private System.Windows.Forms.Button button_Save;
		private System.Windows.Forms.Button button_Open;
		private System.Windows.Forms.CheckBox checkBox_ReadOnly;
		private System.Windows.Forms.CheckBox checkBox_topMost;
	}
}

