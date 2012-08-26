using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using SharedClasses;

namespace FileOperations
{
	public partial class Form1 : Form
	{
		public static string SearchText;
		private string fileText;
		public static string RootDirectoryForSearching;
		private bool PauseActivationPasting = true;
		
		private string SearchButtonText_BeforeSearching;//= "&Search again";
		private const string SearchButtonText_WhileSearching = "C&ancel search";

		public Form1()
		{
			InitializeComponent();
			SearchButtonText_BeforeSearching = buttonSearchAgain.Text;

			labelStatusbar.Text = "";
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			StylingInterop.SetTreeviewVistaStyle(treeViewFoundInFiles);
			StylingInterop.SetTreeviewVistaStyle(treeViewSkippedNonTextfiles);
			base.OnHandleCreated(e);
		}

		//private bool m_Dragging;
		//private Point m_DragStart;

		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			//this.Capture = true;
			//m_DragStart = e.Location;
			//m_Dragging = true;
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			//if (m_Dragging)
			//    this.Location += new Size(e.Location.X - m_DragStart.X, e.Location.Y - m_DragStart.Y);
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			//if (m_Dragging)
			//{
			//    this.Capture = false;
			//    m_Dragging = false;
			//}
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			//if (Environment.GetCommandLineArgs().Length > 1)
			//{
			//    RootDirectoryForSearching = Environment.GetCommandLineArgs()[1];
			textBoxSearchText.Text = SearchText;
			PerformSearch();
			lastClipboard = Clipboard.GetText();
			//}
		}

		private void UpdateProgess(int progressPercentage)
		{
			Action updateAction = new Action(delegate
			{
				if (progressBar1.Value != progressPercentage)
				{
					progressBar1.Value = progressPercentage;
					Application.DoEvents();
				}
			});
			if (this.InvokeRequired)
				this.Invoke(updateAction);
			else
				updateAction();
		}

		private void UpdateProgressOfLoop(int loopVal, int loopMax)
		{
			UpdateProgess((int)Math.Truncate((double)100 * (double)loopVal++ / (double)loopMax));
		}

		private bool CancelSearch = false;
		private void PerformSearch()
		{
			CancelSearch = false;

			labelRootFolder.Enabled = false;
			textBoxSearchText.Enabled = false;
			//buttonSearchAgain.Enabled = false;
			buttonSearchAgain.Text = SearchButtonText_WhileSearching;
			Application.DoEvents();

			treeViewFoundInFiles.Nodes.Clear();
			treeViewFoundInFiles.Tag = null;
			labelRootFolder.Text = RootDirectoryForSearching;
			labelStatusbar.Text = string.Format(
				"Searching for \"{0}\" files in folder: {1}",
				textBoxSearchText.Text,
				RootDirectoryForSearching);
			progressBar1.Value = 0;
			progressBar1.Visible = true;

			treeViewFoundInFiles.Tag = SearchText;
			ThreadingInterop.PerformVoidFunctionSeperateThread(() =>
			{
				try
				{
					var files = Directory.GetFiles(RootDirectoryForSearching, "*", SearchOption.AllDirectories);
					int fileCount = files.Length;
					int totalDone = 0;
					foreach (string filepath in files)
					{
						if (CancelSearch)
							break;

						if (OnlineSettings.SearchInFilesSettings.Instance.ExcludeFileTypes.Contains(Path.GetExtension(filepath), StringComparer.InvariantCultureIgnoreCase))
							continue;

						if (filepath.IndexOf(".svn", StringComparison.InvariantCultureIgnoreCase) != -1)
						{
							UpdateProgressOfLoop(totalDone++, fileCount);
							continue;
						}

						//Not skipping, it always returns UTF8 for all files (text, bitmaps, etc)
						//using (var r = new StreamReader(file, false))//true))
						//{
						//    var en = r.CurrentEncoding;
						//    if (en != Encoding.ASCII)
						//    {
						//        this.Invoke((Action)delegate
						//        {
						//            if (splitContainer1.Panel2Collapsed)
						//                splitContainer1.Panel2Collapsed = false;
						//            treeViewSkippedNonTextfiles.Nodes.Add(en.ToString() + ":" + file);
						//        });
						//        continue;
						//    }
						//}

						if (filepath.IndexOf(SearchText, StringComparison.InvariantCultureIgnoreCase) != -1)
							this.Invoke((Action)delegate
							{
								AddNodeResultPath(filepath);
							});
						else
						{
							try
							{
								fileText = File.ReadAllText(filepath);
								if (fileText.IndexOf(SearchText, StringComparison.InvariantCultureIgnoreCase) != -1)
								{
									this.Invoke((Action)delegate
									{
										AddNodeResultPath(filepath);
									});
								}
							}
							catch (Exception fileReadException)
							{
								UserMessages.ShowWarningMessage(string.Format("Error reading file: '{0}':{1}{2}", filepath, Environment.NewLine, fileReadException.Message));
							}
						}
						UpdateProgressOfLoop(totalDone++, fileCount);
					}
				}
				catch (Exception exc)
				{
					UserMessages.ShowErrorMessage("Exception occurred: " + exc.Message);
				}
				finally
				{
					Action afterSearchAction = new Action(delegate
					{
						labelRootFolder.Enabled = true;
						textBoxSearchText.Enabled = true;
						//buttonSearchAgain.Enabled = true;
						buttonSearchAgain.Text = SearchButtonText_BeforeSearching;
						Application.DoEvents();
						progressBar1.Value = 0;
						progressBar1.Visible = false;
					});
					ThreadingInterop.UpdateGuiFromThread(this, afterSearchAction);
				}
			},
			false);
		}

		private void AddNodeResultPath(string path)
		{
			var displaytext = path;
			if (displaytext.StartsWith(labelRootFolder.Text, StringComparison.InvariantCultureIgnoreCase))
				displaytext = ".." + displaytext.Substring(labelRootFolder.Text.Length);
			TreeNode tn = new TreeNode(displaytext);
			tn.Name = path;
			tn.ToolTipText = path;
			tn.Tag = path;
			treeViewFoundInFiles.Nodes.Add(tn);
		}

		private void labelRootFolder_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.SelectedPath = RootDirectoryForSearching;
			fbd.Description = "Choose new root folder for searching...";
			if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				RootDirectoryForSearching = fbd.SelectedPath;
				labelRootFolder.Text = RootDirectoryForSearching;
			}
		}

		private void textBoxSearchText_TextChanged(object sender, EventArgs e)
		{
			if (SearchText != textBoxSearchText.Text)
				SearchText = textBoxSearchText.Text;
		}

		private void buttonSearchAgain_Click(object sender, EventArgs e)
		{
			if (buttonSearchAgain.Text == SearchButtonText_BeforeSearching)
				PerformSearch();
			else
				CancelSearch = true;
		}

		private string lastClipboard = null;
		private void Form1_Activated(object sender, EventArgs e)
		{
			if (!PauseActivationPasting)
			{
				var clipboardText = Clipboard.GetText();
				if (clipboardText != lastClipboard && !string.IsNullOrEmpty(clipboardText))
				{
					textBoxSearchText.Text = clipboardText;
					SearchText = clipboardText;
					textBoxSearchText.Focus();
					labelStatusbar.Text = "Pasted text into search box: " + clipboardText;
				}
				lastClipboard = clipboardText;
			}
		}

		private void Form1_Deactivate(object sender, EventArgs e)
		{
			PauseActivationPasting = false;
		}

		private void textBoxSearchText_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (13 == (int)e.KeyChar)
				PerformSearch();
		}

		private void treeViewFoundInFiles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			string filepath = e.Node.Tag == null ? "" : e.Node.Tag.ToString();
			if (File.Exists(filepath))
				Process.Start("explorer", "/select,\"" + filepath + "\"");
			else
				UserMessages.ShowWarningMessage("Cannot find file: " + filepath);
		}

		private void treeViewFoundInFiles_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node == null || e.Node.Tag == null)
			{
				richTextBoxFileContents.Enabled = false;
				buttonNextInFile.Enabled = false;
				return;
			}

			richTextBoxFileContents.Enabled = true;
			buttonNextInFile.Enabled = true;

			string filepath = e.Node.Tag.ToString();
			if (!File.Exists(filepath))
				UserMessages.ShowWarningMessage("Cannot find file: " + filepath);
			else
			{
				//richTextBoxFileContents.Text = File.ReadAllText(filepath);
				richTextBoxFileContents.LoadFile(filepath, RichTextBoxStreamType.PlainText);
				richTextBoxFileContents.Find(textBoxSearchText.Text, 0);
			}
		}

		private void buttonNextInFile_Click(object sender, EventArgs e)
		{
			if (treeViewFoundInFiles.Tag == null)
			{
				labelStatusbar.Text = "Last search text is NULL";
				return;
			}

			string searchText = treeViewFoundInFiles.Tag.ToString();

			int start = 0;
			if (richTextBoxFileContents.SelectionStart >= 0)
				start = richTextBoxFileContents.SelectionStart + (richTextBoxFileContents.SelectionLength >= 0 ? richTextBoxFileContents.SelectionLength : 0);
			if (richTextBoxFileContents.Find(searchText, start, RichTextBoxFinds.None) == -1)
				richTextBoxFileContents.Find(searchText, 0, RichTextBoxFinds.None);			
		}
	}
}
