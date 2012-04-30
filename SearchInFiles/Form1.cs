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

namespace SearchInFiles
{
	public partial class Form1 : Form
	{
		public static string SearchText;
		private string fileText;
		private string rootDirectoryForSearching;

		public Form1()
		{
			InitializeComponent();
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
			if (Environment.GetCommandLineArgs().Length > 1)
			{
				rootDirectoryForSearching = Environment.GetCommandLineArgs()[1];
				textBoxSearchText.Text = SearchText;
				PerformSearch();
			}
		}

		private void PerformSearch()
		{
			labelRootFolder.Enabled = false;
			textBoxSearchText.Enabled = false;
			buttonSearchAgain.Enabled = false;

			treeViewFoundInFiles.Nodes.Clear();
			labelRootFolder.Text = rootDirectoryForSearching;
			labelStatusbar.Text = string.Format(
				"Searching for \"{0}\" files in folder: {1}",
				textBoxSearchText.Text,
				rootDirectoryForSearching);

			ThreadingInterop.PerformVoidFunctionSeperateThread(() =>
			{
				try
				{
					foreach (string file in Directory.GetFiles(rootDirectoryForSearching, "*", SearchOption.AllDirectories))
					{
						if (file.IndexOf(".svn", StringComparison.InvariantCultureIgnoreCase) != -1)
							continue;
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

						if (file.IndexOf(SearchText, StringComparison.InvariantCultureIgnoreCase) != -1)
							this.Invoke((Action)delegate
							{
								treeViewFoundInFiles.Nodes.Add(file);
							});
						else
						{
							fileText = File.ReadAllText(file);
							if (fileText.IndexOf(SearchText, StringComparison.InvariantCultureIgnoreCase) != -1)
							{
								this.Invoke((Action)delegate
								{
									treeViewFoundInFiles.Nodes.Add(file);
								});
							}
						}
					}
				}
				catch (Exception exc)
				{
					UserMessages.ShowErrorMessage("Exception occurred: " + exc.Message);
				}
			});

			labelRootFolder.Enabled = true;
			textBoxSearchText.Enabled = true;
			buttonSearchAgain.Enabled = true;
		}

		private void labelRootFolder_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.SelectedPath = rootDirectoryForSearching;
			fbd.Description = "Choose new root folder for searching...";
			if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				rootDirectoryForSearching = fbd.SelectedPath;
		}

		private void textBoxSearchText_TextChanged(object sender, EventArgs e)
		{
			if (SearchText != textBoxSearchText.Text)
				SearchText = textBoxSearchText.Text;
		}

		private void buttonSearchAgain_Click(object sender, EventArgs e)
		{
			PerformSearch();
		}
	}
}
