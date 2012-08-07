namespace FileOperations
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
			this.labelRootFolder = new System.Windows.Forms.Label();
			this.textBoxSearchText = new System.Windows.Forms.TextBox();
			this.buttonSearchAgain = new System.Windows.Forms.Button();
			this.splitContainerSplitFileContents = new System.Windows.Forms.SplitContainer();
			this.splitContainerSplitSkippedFiles = new System.Windows.Forms.SplitContainer();
			this.treeViewFoundInFiles = new System.Windows.Forms.TreeView();
			this.label1 = new System.Windows.Forms.Label();
			this.treeViewSkippedNonTextfiles = new System.Windows.Forms.TreeView();
			this.richTextBoxFileContents = new System.Windows.Forms.RichTextBox();
			this.buttonNextInFile = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerSplitFileContents)).BeginInit();
			this.splitContainerSplitFileContents.Panel1.SuspendLayout();
			this.splitContainerSplitFileContents.Panel2.SuspendLayout();
			this.splitContainerSplitFileContents.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerSplitSkippedFiles)).BeginInit();
			this.splitContainerSplitSkippedFiles.Panel1.SuspendLayout();
			this.splitContainerSplitSkippedFiles.Panel2.SuspendLayout();
			this.splitContainerSplitSkippedFiles.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelStatusbar
			// 
			this.labelStatusbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelStatusbar.Location = new System.Drawing.Point(12, 589);
			this.labelStatusbar.Name = "labelStatusbar";
			this.labelStatusbar.Size = new System.Drawing.Size(374, 37);
			this.labelStatusbar.TabIndex = 0;
			this.labelStatusbar.Text = "label1";
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(12, 629);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(1162, 10);
			this.progressBar1.TabIndex = 1;
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
			this.textBoxSearchText.Location = new System.Drawing.Point(12, 28);
			this.textBoxSearchText.Name = "textBoxSearchText";
			this.textBoxSearchText.Size = new System.Drawing.Size(1010, 20);
			this.textBoxSearchText.TabIndex = 6;
			this.textBoxSearchText.TextChanged += new System.EventHandler(this.textBoxSearchText_TextChanged);
			this.textBoxSearchText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearchText_KeyPress);
			// 
			// buttonSearchAgain
			// 
			this.buttonSearchAgain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSearchAgain.Location = new System.Drawing.Point(1075, 25);
			this.buttonSearchAgain.Name = "buttonSearchAgain";
			this.buttonSearchAgain.Size = new System.Drawing.Size(99, 23);
			this.buttonSearchAgain.TabIndex = 7;
			this.buttonSearchAgain.Text = "&Search again";
			this.buttonSearchAgain.UseVisualStyleBackColor = true;
			this.buttonSearchAgain.Click += new System.EventHandler(this.buttonSearchAgain_Click);
			// 
			// splitContainerSplitFileContents
			// 
			this.splitContainerSplitFileContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainerSplitFileContents.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainerSplitFileContents.Location = new System.Drawing.Point(15, 59);
			this.splitContainerSplitFileContents.Name = "splitContainerSplitFileContents";
			// 
			// splitContainerSplitFileContents.Panel1
			// 
			this.splitContainerSplitFileContents.Panel1.Controls.Add(this.splitContainerSplitSkippedFiles);
			// 
			// splitContainerSplitFileContents.Panel2
			// 
			this.splitContainerSplitFileContents.Panel2.Controls.Add(this.richTextBoxFileContents);
			this.splitContainerSplitFileContents.Panel2.Controls.Add(this.buttonNextInFile);
			this.splitContainerSplitFileContents.Panel2.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
			this.splitContainerSplitFileContents.Size = new System.Drawing.Size(1159, 515);
			this.splitContainerSplitFileContents.SplitterDistance = 319;
			this.splitContainerSplitFileContents.TabIndex = 8;
			// 
			// splitContainerSplitSkippedFiles
			// 
			this.splitContainerSplitSkippedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerSplitSkippedFiles.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainerSplitSkippedFiles.Location = new System.Drawing.Point(0, 0);
			this.splitContainerSplitSkippedFiles.Name = "splitContainerSplitSkippedFiles";
			// 
			// splitContainerSplitSkippedFiles.Panel1
			// 
			this.splitContainerSplitSkippedFiles.Panel1.Controls.Add(this.treeViewFoundInFiles);
			// 
			// splitContainerSplitSkippedFiles.Panel2
			// 
			this.splitContainerSplitSkippedFiles.Panel2.Controls.Add(this.label1);
			this.splitContainerSplitSkippedFiles.Panel2.Controls.Add(this.treeViewSkippedNonTextfiles);
			this.splitContainerSplitSkippedFiles.Panel2.Padding = new System.Windows.Forms.Padding(5, 20, 5, 5);
			this.splitContainerSplitSkippedFiles.Panel2Collapsed = true;
			this.splitContainerSplitSkippedFiles.Size = new System.Drawing.Size(319, 515);
			this.splitContainerSplitSkippedFiles.SplitterDistance = 351;
			this.splitContainerSplitSkippedFiles.TabIndex = 10;
			// 
			// treeViewFoundInFiles
			// 
			this.treeViewFoundInFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewFoundInFiles.FullRowSelect = true;
			this.treeViewFoundInFiles.HideSelection = false;
			this.treeViewFoundInFiles.HotTracking = true;
			this.treeViewFoundInFiles.Indent = 5;
			this.treeViewFoundInFiles.Location = new System.Drawing.Point(0, 0);
			this.treeViewFoundInFiles.Name = "treeViewFoundInFiles";
			this.treeViewFoundInFiles.ShowLines = false;
			this.treeViewFoundInFiles.ShowPlusMinus = false;
			this.treeViewFoundInFiles.ShowRootLines = false;
			this.treeViewFoundInFiles.Size = new System.Drawing.Size(319, 515);
			this.treeViewFoundInFiles.TabIndex = 2;
			this.treeViewFoundInFiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFoundInFiles_AfterSelect);
			this.treeViewFoundInFiles.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewFoundInFiles_NodeMouseDoubleClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(2, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Skipped files";
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
			this.treeViewSkippedNonTextfiles.Size = new System.Drawing.Size(86, 75);
			this.treeViewSkippedNonTextfiles.TabIndex = 3;
			// 
			// richTextBoxFileContents
			// 
			this.richTextBoxFileContents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBoxFileContents.Enabled = false;
			this.richTextBoxFileContents.HideSelection = false;
			this.richTextBoxFileContents.Location = new System.Drawing.Point(0, 30);
			this.richTextBoxFileContents.Name = "richTextBoxFileContents";
			this.richTextBoxFileContents.ReadOnly = true;
			this.richTextBoxFileContents.Size = new System.Drawing.Size(836, 485);
			this.richTextBoxFileContents.TabIndex = 2;
			this.richTextBoxFileContents.Text = "";
			this.richTextBoxFileContents.WordWrap = false;
			// 
			// buttonNextInFile
			// 
			this.buttonNextInFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonNextInFile.Location = new System.Drawing.Point(758, 4);
			this.buttonNextInFile.Name = "buttonNextInFile";
			this.buttonNextInFile.Size = new System.Drawing.Size(75, 23);
			this.buttonNextInFile.TabIndex = 1;
			this.buttonNextInFile.Text = "&Next in file";
			this.buttonNextInFile.UseVisualStyleBackColor = true;
			this.buttonNextInFile.Click += new System.EventHandler(this.buttonNextInFile_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1186, 651);
			this.Controls.Add(this.splitContainerSplitFileContents);
			this.Controls.Add(this.buttonSearchAgain);
			this.Controls.Add(this.textBoxSearchText);
			this.Controls.Add(this.labelRootFolder);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.labelStatusbar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Searching in files";
			this.Activated += new System.EventHandler(this.Form1_Activated);
			this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
			this.splitContainerSplitFileContents.Panel1.ResumeLayout(false);
			this.splitContainerSplitFileContents.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerSplitFileContents)).EndInit();
			this.splitContainerSplitFileContents.ResumeLayout(false);
			this.splitContainerSplitSkippedFiles.Panel1.ResumeLayout(false);
			this.splitContainerSplitSkippedFiles.Panel2.ResumeLayout(false);
			this.splitContainerSplitSkippedFiles.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerSplitSkippedFiles)).EndInit();
			this.splitContainerSplitSkippedFiles.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Label labelStatusbar;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label labelRootFolder;
		private System.Windows.Forms.TextBox textBoxSearchText;
		private System.Windows.Forms.Button buttonSearchAgain;
		private System.Windows.Forms.SplitContainer splitContainerSplitFileContents;
		private System.Windows.Forms.SplitContainer splitContainerSplitSkippedFiles;
		private System.Windows.Forms.TreeView treeViewFoundInFiles;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TreeView treeViewSkippedNonTextfiles;
		private System.Windows.Forms.Button buttonNextInFile;
		private System.Windows.Forms.RichTextBox richTextBoxFileContents;


	}
}

