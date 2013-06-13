using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharedClasses;

namespace FileOperations
{
	public partial class MergeTwoFolderDetailsForm : Form
	{
		FolderDetails lastChecked_BaseDetails = null;
		FolderDetails lastChecked_OtherDetails = null;
		Dictionary<string, FileDetails> lastChecked_NewInOther;
		Dictionary<string, FileDetails> lastChecked_MissingInOther;
		Dictionary<string, FileDetails> lastChecked_ChangedInOther;

		public MergeTwoFolderDetailsForm(string baseFolder = null, string otherFolder = null)
		{
			InitializeComponent();

			//baseFolder = @"C:\Francois\Other\tmpCompare\1";
			//otherFolder = @"C:\Francois\Other\tmpCompare\2";

			if (baseFolder != null)
				labelBaseFolderPath.Text = baseFolder;

			if (otherFolder != null)
				labelOtherFolderPath.Text = otherFolder;
		}

		private void labelBaseFolderPath_Click(object sender, EventArgs e)
		{
			string selectedDir = null;
			if (!Directory.Exists(labelBaseFolderPath.Text)
				&& Directory.Exists(labelOtherFolderPath.Text))
				selectedDir = labelOtherFolderPath.Text;

			var newBasePath = FileSystemInterop.SelectFolder("Select the base folder for comparing", selectedDir);
			if (newBasePath == null) return;
			labelBaseFolderPath.Text = newBasePath;

			if (labelBaseFolderPath.Text == labelOtherFolderPath.Text)
				UserMessages.ShowWarningMessage("The two folders are the same, there will be no differences when compared.");
		}

		private void labelOtherFolderPath_Click(object sender, EventArgs e)
		{
			string selectedDir = null;
			if (!Directory.Exists(labelOtherFolderPath.Text)
				&& Directory.Exists(labelBaseFolderPath.Text))
				selectedDir = labelBaseFolderPath.Text;

			var newOtherPath = FileSystemInterop.SelectFolder("Select the other folder for comparing", selectedDir);
			if (newOtherPath == null) return;
			labelOtherFolderPath.Text = newOtherPath;

			if (labelBaseFolderPath.Text == labelOtherFolderPath.Text)
				UserMessages.ShowWarningMessage("The two folders are the same, there will be no differences when compared.");
		}

		private void UpdateProgessBar(ProgressBar progressBar, int percentage)
		{
			Action<int> actionUpdateGui = (per) =>
			{
				progressBar.Value = per;
				progressBar.Update();
				Application.DoEvents();
			};

			if (progressBar.InvokeRequired)
				progressBar.Invoke(actionUpdateGui, percentage);
			else
				actionUpdateGui(percentage);
		}

		private bool HaveWeGotAllTheInfoWeNeed(out string baseDir, out string otherDir)
		{
			baseDir = labelBaseFolderPath.Text;
			otherDir = labelOtherFolderPath.Text;

			if (!Directory.Exists(baseDir))
			{
				UserMessages.ShowWarningMessage("Please select a valid Base Dir, not valid: " + baseDir);
				return false;
			}
			else if (!Directory.Exists(otherDir))
			{
				UserMessages.ShowWarningMessage("Please select a valid Other Dir, not valid: " + otherDir);
				return false;
			}
			else
				return true;
		}

		bool isBusy = false;
		private void buttonCompareNow_Click(object sender, EventArgs e)
		{
			Todo: Remember to build an HTML output mode for comparison results too

			string baseDir, otherDir;
			if (!HaveWeGotAllTheInfoWeNeed(out baseDir, out otherDir))
				return;

			if (isBusy)
			{
				UserMessages.ShowWarningMessage("Operation already busy, please wait for it to finish");
				return;
			}
			isBusy = true;

			ResetControlsToBeforeComparing();
			buttonCompareNow.Enabled = false;

			ThreadingInterop.DoAction(delegate
			{
				try
				{
					var baseDetails = new FolderDetails(baseDir, onProgressChanged: (per) => UpdateProgessBar(progressBarBaseFolder, per));
					var otherDetails = new FolderDetails(otherDir, onProgressChanged: (per) => UpdateProgessBar(progressBarOtherFolder, per));

					Dictionary<string, FileDetails> newIn2;
					Dictionary<string, FileDetails> missingIn2;
					Dictionary<string, FileDetails> changedIn2;

					bool? compareResult = baseDetails.CompareDetails(otherDetails, out newIn2, out missingIn2, out changedIn2);

					if (!compareResult.HasValue)
						UserMessages.ShowWarningMessage("Cannot compare, excluded folders list differs");
					else
					{
						bool hadChanges = compareResult.Value == false;
						if (hadChanges)
						{
							lastChecked_BaseDetails = baseDetails;
							lastChecked_OtherDetails = otherDetails;

							lastChecked_NewInOther = newIn2;
							lastChecked_MissingInOther = missingIn2;
							lastChecked_ChangedInOther = changedIn2;
						}

						Action updateGuiAction = delegate
							{
								int newCnt = newIn2 != null ? newIn2.Count : 0;
								int missingCnt = missingIn2 != null ? missingIn2.Count : 0;
								int changedCnt = changedIn2 != null ? changedIn2.Count : 0;
								labelNewInOther.Text = newCnt.ToString() + " file" + (newCnt != 1 ? "s" : "") + " new in other";
								labelMissingInOther.Text = missingCnt.ToString() + " file" + (missingCnt != 1 ? "s" : "") + " missing from other";
								labelChangedInOther.Text = changedCnt.ToString() + " file" + (changedCnt != 1 ? "s" : "") + " changed in other";

								if (hadChanges)
									buttonUpdateBaseFolder.Visible = true;
								else
								{
									if (lastChecked_BaseDetails != null && lastChecked_BaseDetails.HasExcludedFolders())
										UserMessages.ShowInfoMessage("Folders are identical (some folder were excluded and not compared).");
									else
										UserMessages.ShowInfoMessage("Folders are identical (no excluded folders).");
								}

								groupBoxChanges.Visible = true;
							};
						if (this.InvokeRequired)
							this.Invoke(updateGuiAction);
						else
							updateGuiAction();
					}
				}
				finally
				{
					isBusy = false;

					Action updateGuiAction = delegate
						{
							buttonCompareNow.Enabled = true;
						};

					if (this.InvokeRequired)
						this.Invoke(updateGuiAction);
					else
						updateGuiAction();
				}
			},
			false,
			"Comparing folders");
		}

		private void ResetControlsToBeforeComparing()
		{
			lastChecked_BaseDetails = null;
			lastChecked_OtherDetails = null;

			lastChecked_NewInOther = null;
			lastChecked_MissingInOther = null;
			lastChecked_ChangedInOther = null;

			groupBoxChanges.Visible = false;
			buttonUpdateBaseFolder.Visible = false;

			progressBarBaseFolder.Value = 0;
			progressBarBaseFolder.Visible = true;

			progressBarOtherFolder.Value = 0;
			progressBarOtherFolder.Visible = true;
		}

		private bool WereThereChangesInTheComparison(bool showWarningIfNot)
		{
			bool wereChanges = lastChecked_BaseDetails != null;
			if (!wereChanges
				&& showWarningIfNot)
				UserMessages.ShowWarningMessage("No changes found in last comparison");
			return wereChanges;
		}

		private string[] GetRootDirectoriesArray()
		{
			return new string[] 
			{
				lastChecked_BaseDetails.LocalRootDirectory,
				lastChecked_OtherDetails.LocalRootDirectory
			};
		}

		private void labelNewInOther_Click(object sender, EventArgs e)
		{
			if (!WereThereChangesInTheComparison(true))
				return;

			UserMessageWithTextbox.ShowUserMessageWithTextbox(
				"New files in other folder",
				string.Join(Environment.NewLine, lastChecked_NewInOther.Keys),
				"New in other",
				RootDirsUsedIfFilesSelected: GetRootDirectoriesArray());
		}

		private void labelMissingInOther_Click(object sender, EventArgs e)
		{
			if (!WereThereChangesInTheComparison(true))
				return;

			UserMessageWithTextbox.ShowUserMessageWithTextbox(
				"Missing files in other folder",
				string.Join(Environment.NewLine, lastChecked_MissingInOther.Keys),
				"Missing in other",
				RootDirsUsedIfFilesSelected: GetRootDirectoriesArray());
		}

		private void labelChangedInOther_Click(object sender, EventArgs e)
		{
			if (!WereThereChangesInTheComparison(true))
				return;

			UserMessageWithTextbox.ShowUserMessageWithTextbox(
				"Changed files in other folder",
				string.Join(Environment.NewLine, lastChecked_ChangedInOther.Keys),
				"Changed in other",
				RootDirsUsedIfFilesSelected: GetRootDirectoriesArray());
		}

		private void buttonUpdateBaseFolder_Click(object sender, EventArgs e)
		{
			if (!WereThereChangesInTheComparison(true))
				return;

			if (isBusy)
			{
				UserMessages.ShowWarningMessage("Operation already busy, please wait for it to finish");
				return;
			}
			isBusy = true;

			buttonUpdateBaseFolder.Enabled = false;

			try
			{
				if (!UserMessages.Confirm(
					"Note that files in BASE folder will be added, deleted and overwritten to get in sync with other folder, continue?"
					+ Environment.NewLine + Environment.NewLine
					+ "Directory which will lose its current data: " + Environment.NewLine + labelBaseFolderPath.Text))
					return;

				if (lastChecked_BaseDetails.UpdateToMatchOtherFolder(lastChecked_OtherDetails, lastChecked_NewInOther, lastChecked_MissingInOther, lastChecked_ChangedInOther))
				{
					UserMessages.ShowInfoMessage("Successfully updated folder " + lastChecked_BaseDetails.LocalRootDirectory);
					//UserMessages.ShowErrorMessage("Warning: currently the Folders itsself is not checked, so missing folder will not currently be deleted in sync process.");
				}
				ResetControlsToBeforeComparing();
			}
			finally
			{
				isBusy = false;
				buttonUpdateBaseFolder.Enabled = true;
			}
		}
	}
}
