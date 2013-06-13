namespace FileOperations
{
	partial class MergeTwoFolderDetailsForm
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
			this.labelBaseFolderPath = new System.Windows.Forms.Label();
			this.labelOtherFolderPath = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBoxChanges = new System.Windows.Forms.GroupBox();
			this.buttonUpdateBaseFolder = new System.Windows.Forms.Button();
			this.labelChangedInOther = new System.Windows.Forms.Label();
			this.labelMissingInOther = new System.Windows.Forms.Label();
			this.labelNewInOther = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonCompareNow = new System.Windows.Forms.Button();
			this.progressBarBaseFolder = new System.Windows.Forms.ProgressBar();
			this.progressBarOtherFolder = new System.Windows.Forms.ProgressBar();
			this.groupBoxChanges.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelBaseFolderPath
			// 
			this.labelBaseFolderPath.AutoSize = true;
			this.labelBaseFolderPath.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelBaseFolderPath.Location = new System.Drawing.Point(81, 30);
			this.labelBaseFolderPath.Name = "labelBaseFolderPath";
			this.labelBaseFolderPath.Size = new System.Drawing.Size(131, 13);
			this.labelBaseFolderPath.TabIndex = 0;
			this.labelBaseFolderPath.Text = "Choose base folder path...";
			this.labelBaseFolderPath.Click += new System.EventHandler(this.labelBaseFolderPath_Click);
			// 
			// labelOtherFolderPath
			// 
			this.labelOtherFolderPath.AutoSize = true;
			this.labelOtherFolderPath.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelOtherFolderPath.Location = new System.Drawing.Point(80, 79);
			this.labelOtherFolderPath.Name = "labelOtherFolderPath";
			this.labelOtherFolderPath.Size = new System.Drawing.Size(132, 13);
			this.labelOtherFolderPath.TabIndex = 1;
			this.labelOtherFolderPath.Text = "Choose other folder path...";
			this.labelOtherFolderPath.Click += new System.EventHandler(this.labelOtherFolderPath_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Base folder:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 79);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Other folder:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(30, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(76, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "New (in other):";
			// 
			// groupBoxChanges
			// 
			this.groupBoxChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxChanges.Controls.Add(this.buttonUpdateBaseFolder);
			this.groupBoxChanges.Controls.Add(this.labelChangedInOther);
			this.groupBoxChanges.Controls.Add(this.labelMissingInOther);
			this.groupBoxChanges.Controls.Add(this.labelNewInOther);
			this.groupBoxChanges.Controls.Add(this.label5);
			this.groupBoxChanges.Controls.Add(this.label4);
			this.groupBoxChanges.Controls.Add(this.label3);
			this.groupBoxChanges.Location = new System.Drawing.Point(12, 175);
			this.groupBoxChanges.Name = "groupBoxChanges";
			this.groupBoxChanges.Size = new System.Drawing.Size(337, 181);
			this.groupBoxChanges.TabIndex = 5;
			this.groupBoxChanges.TabStop = false;
			this.groupBoxChanges.Text = "Changes in other";
			this.groupBoxChanges.Visible = false;
			// 
			// buttonUpdateBaseFolder
			// 
			this.buttonUpdateBaseFolder.Location = new System.Drawing.Point(61, 134);
			this.buttonUpdateBaseFolder.Name = "buttonUpdateBaseFolder";
			this.buttonUpdateBaseFolder.Size = new System.Drawing.Size(221, 23);
			this.buttonUpdateBaseFolder.TabIndex = 10;
			this.buttonUpdateBaseFolder.Text = "Update base folder to be same as other";
			this.buttonUpdateBaseFolder.UseVisualStyleBackColor = true;
			this.buttonUpdateBaseFolder.Visible = false;
			this.buttonUpdateBaseFolder.Click += new System.EventHandler(this.buttonUpdateBaseFolder_Click);
			// 
			// labelChangedInOther
			// 
			this.labelChangedInOther.AutoSize = true;
			this.labelChangedInOther.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelChangedInOther.Location = new System.Drawing.Point(162, 81);
			this.labelChangedInOther.Name = "labelChangedInOther";
			this.labelChangedInOther.Size = new System.Drawing.Size(34, 13);
			this.labelChangedInOther.TabIndex = 9;
			this.labelChangedInOther.Text = "count";
			this.labelChangedInOther.Click += new System.EventHandler(this.labelChangedInOther_Click);
			// 
			// labelMissingInOther
			// 
			this.labelMissingInOther.AutoSize = true;
			this.labelMissingInOther.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelMissingInOther.Location = new System.Drawing.Point(162, 56);
			this.labelMissingInOther.Name = "labelMissingInOther";
			this.labelMissingInOther.Size = new System.Drawing.Size(34, 13);
			this.labelMissingInOther.TabIndex = 8;
			this.labelMissingInOther.Text = "count";
			this.labelMissingInOther.Click += new System.EventHandler(this.labelMissingInOther_Click);
			// 
			// labelNewInOther
			// 
			this.labelNewInOther.AutoSize = true;
			this.labelNewInOther.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelNewInOther.Location = new System.Drawing.Point(162, 32);
			this.labelNewInOther.Name = "labelNewInOther";
			this.labelNewInOther.Size = new System.Drawing.Size(34, 13);
			this.labelNewInOther.TabIndex = 7;
			this.labelNewInOther.Text = "count";
			this.labelNewInOther.Click += new System.EventHandler(this.labelNewInOther_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(30, 81);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(97, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Changed (in other):";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(30, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(101, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Missing (from other):";
			// 
			// buttonCompareNow
			// 
			this.buttonCompareNow.Location = new System.Drawing.Point(126, 111);
			this.buttonCompareNow.Name = "buttonCompareNow";
			this.buttonCompareNow.Size = new System.Drawing.Size(106, 23);
			this.buttonCompareNow.TabIndex = 6;
			this.buttonCompareNow.Text = "&Compare now";
			this.buttonCompareNow.UseVisualStyleBackColor = true;
			this.buttonCompareNow.Click += new System.EventHandler(this.buttonCompareNow_Click);
			// 
			// progressBarBaseFolder
			// 
			this.progressBarBaseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBarBaseFolder.Location = new System.Drawing.Point(12, 46);
			this.progressBarBaseFolder.Name = "progressBarBaseFolder";
			this.progressBarBaseFolder.Size = new System.Drawing.Size(337, 10);
			this.progressBarBaseFolder.TabIndex = 7;
			this.progressBarBaseFolder.Visible = false;
			// 
			// progressBarOtherFolder
			// 
			this.progressBarOtherFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBarOtherFolder.Location = new System.Drawing.Point(12, 95);
			this.progressBarOtherFolder.Name = "progressBarOtherFolder";
			this.progressBarOtherFolder.Size = new System.Drawing.Size(337, 10);
			this.progressBarOtherFolder.TabIndex = 8;
			this.progressBarOtherFolder.Visible = false;
			// 
			// MergeTwoFolderDetailsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(363, 368);
			this.Controls.Add(this.progressBarOtherFolder);
			this.Controls.Add(this.progressBarBaseFolder);
			this.Controls.Add(this.buttonCompareNow);
			this.Controls.Add(this.groupBoxChanges);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelOtherFolderPath);
			this.Controls.Add(this.labelBaseFolderPath);
			this.Name = "MergeTwoFolderDetailsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MergeTwoFolderDetailsForm";
			this.groupBoxChanges.ResumeLayout(false);
			this.groupBoxChanges.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelBaseFolderPath;
		private System.Windows.Forms.Label labelOtherFolderPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBoxChanges;
		private System.Windows.Forms.Label labelChangedInOther;
		private System.Windows.Forms.Label labelMissingInOther;
		private System.Windows.Forms.Label labelNewInOther;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button buttonCompareNow;
		private System.Windows.Forms.ProgressBar progressBarBaseFolder;
		private System.Windows.Forms.ProgressBar progressBarOtherFolder;
		private System.Windows.Forms.Button buttonUpdateBaseFolder;
	}
}