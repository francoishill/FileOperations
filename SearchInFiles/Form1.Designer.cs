namespace SearchInFiles
{
    partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.labelStatusbar = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.treeViewFoundInFiles = new System.Windows.Forms.TreeView();
			this.treeViewSkippedNonTextfiles = new System.Windows.Forms.TreeView();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.label1 = new System.Windows.Forms.Label();
			this.labelRootFolder = new System.Windows.Forms.Label();
			this.textBoxSearchText = new System.Windows.Forms.TextBox();
			this.buttonSearchAgain = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelStatusbar
			// 
			this.labelStatusbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelStatusbar.AutoSize = true;
			this.labelStatusbar.Location = new System.Drawing.Point(12, 224);
			this.labelStatusbar.Name = "labelStatusbar";
			this.labelStatusbar.Size = new System.Drawing.Size(35, 13);
			this.labelStatusbar.TabIndex = 0;
			this.labelStatusbar.Text = "label1";
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(12, 240);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(751, 10);
			this.progressBar1.TabIndex = 1;
			// 
			// treeViewFoundInFiles
			// 
			this.treeViewFoundInFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewFoundInFiles.Indent = 5;
			this.treeViewFoundInFiles.Location = new System.Drawing.Point(0, 0);
			this.treeViewFoundInFiles.Name = "treeViewFoundInFiles";
			this.treeViewFoundInFiles.ShowLines = false;
			this.treeViewFoundInFiles.ShowPlusMinus = false;
			this.treeViewFoundInFiles.ShowRootLines = false;
			this.treeViewFoundInFiles.Size = new System.Drawing.Size(758, 138);
			this.treeViewFoundInFiles.TabIndex = 2;
			// 
			// treeViewSkippedNonTextfiles
			// 
			this.treeViewSkippedNonTextfiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewSkippedNonTextfiles.Indent = 5;
			this.treeViewSkippedNonTextfiles.Location = new System.Drawing.Point(5, 20);
			this.treeViewSkippedNonTextfiles.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
			this.treeViewSkippedNonTextfiles.Name = "treeViewSkippedNonTextfiles";
			this.treeViewSkippedNonTextfiles.ShowLines = false;
			this.treeViewSkippedNonTextfiles.ShowPlusMinus = false;
			this.treeViewSkippedNonTextfiles.ShowRootLines = false;
			this.treeViewSkippedNonTextfiles.Size = new System.Drawing.Size(343, 160);
			this.treeViewSkippedNonTextfiles.TabIndex = 3;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.Location = new System.Drawing.Point(12, 59);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.treeViewFoundInFiles);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Panel2.Controls.Add(this.treeViewSkippedNonTextfiles);
			this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5, 20, 5, 5);
			this.splitContainer1.Panel2Collapsed = true;
			this.splitContainer1.Size = new System.Drawing.Size(758, 138);
			this.splitContainer1.SplitterDistance = 401;
			this.splitContainer1.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Skipped files";
			// 
			// labelRootFolder
			// 
			this.labelRootFolder.AutoSize = true;
			this.labelRootFolder.Location = new System.Drawing.Point(12, 9);
			this.labelRootFolder.Name = "labelRootFolder";
			this.labelRootFolder.Size = new System.Drawing.Size(35, 13);
			this.labelRootFolder.TabIndex = 5;
			this.labelRootFolder.Text = "label2";
			this.labelRootFolder.Click += new System.EventHandler(this.labelRootFolder_Click);
			// 
			// textBoxSearchText
			// 
			this.textBoxSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSearchText.Location = new System.Drawing.Point(12, 26);
			this.textBoxSearchText.Name = "textBoxSearchText";
			this.textBoxSearchText.Size = new System.Drawing.Size(139, 20);
			this.textBoxSearchText.TabIndex = 6;
			this.textBoxSearchText.TextChanged += new System.EventHandler(this.textBoxSearchText_TextChanged);
			// 
			// buttonSearchAgain
			// 
			this.buttonSearchAgain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSearchAgain.Location = new System.Drawing.Point(167, 24);
			this.buttonSearchAgain.Name = "buttonSearchAgain";
			this.buttonSearchAgain.Size = new System.Drawing.Size(99, 23);
			this.buttonSearchAgain.TabIndex = 7;
			this.buttonSearchAgain.Text = "&Search again";
			this.buttonSearchAgain.UseVisualStyleBackColor = true;
			this.buttonSearchAgain.Click += new System.EventHandler(this.buttonSearchAgain_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(775, 262);
			this.Controls.Add(this.buttonSearchAgain);
			this.Controls.Add(this.textBoxSearchText);
			this.Controls.Add(this.labelRootFolder);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.labelStatusbar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Searching in files";
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Label labelStatusbar;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.TreeView treeViewFoundInFiles;
		private System.Windows.Forms.TreeView treeViewSkippedNonTextfiles;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelRootFolder;
		private System.Windows.Forms.TextBox textBoxSearchText;
		private System.Windows.Forms.Button buttonSearchAgain;


	}
}

