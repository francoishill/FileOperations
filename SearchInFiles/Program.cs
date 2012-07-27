using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SharedClasses;
using System.Reflection;
using System.Drawing;

namespace SearchInFiles
{
	static class Program
	{
		const string ThisAppKeyName = "SearchInFiles";

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var args = Environment.GetCommandLineArgs();
			//args = new string[] { "", @"C:\Users\francois\Dropbox\Dev\VSprojects\SharedClasses" };//@"C:\Users\francois\Dropbox\Temp\WaterSkills\Source" };

			if (Application.ExecutablePath.StartsWith(@"C:\Program Files", StringComparison.InvariantCultureIgnoreCase))
			{

				string iconPath = "\"" + Environment.GetCommandLineArgs()[0] + "\"";//"shell32.dll,-320",;
				bool added = RegistryInterop.AddSubMenuCommands(new RegistryInterop.MainContextMenuItem(
					new List<string>() { "Folder" },
					"Search in files",
					//"Hex converting",
					iconPath,
					new List<RegistryInterop.SubContextMenuItem>()
				{
					new RegistryInterop.SubContextMenuItem("_SearchInFiles.SearchInFiles", "Search in files", iconPath, "\"" + Environment.GetCommandLineArgs()[0] + "\" \"%1\"")
				}));

				if (!added)
					UserMessages.ShowWarningMessage("Cannot register application " + ThisAppKeyName + " to right-click menu, unable to write registry");

				//SharedClasses.RegistryInterop.AddCommandToFolder(
				//    "SearchInFiles",
				//    "\"" + Environment.GetCommandLineArgs()[0] + "\" \"%1\"",
				//    "Search in files",
				//    "\"" + Environment.GetCommandLineArgs()[0] + "\"",//"shell32.dll,-320",
				//    null,//"SearchInFiles",
				//    ThisAppKeyName);
			}

			if (args.Length <= 1)
				UserMessages.ShowWarningMessage("This program (" + ThisAppKeyName + ") needs a commandline argument which should be the root directory to search in");
			else
			{
				typeof(Form).GetField("defaultIcon", BindingFlags.NonPublic | BindingFlags.Static)
						.SetValue(null, new Icon(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("SearchInFiles.app.ico")));
				string searchText = DialogBoxStuff.InputDialog("Please enter the text to search for in all files (recursively) in folder:" + Environment.NewLine + args[1]);
				if (!string.IsNullOrWhiteSpace(searchText))
				{
					Form1.SearchText = searchText;
					Form1.RootDirectoryForSearching = args[1];
					Form1 mainform = new Form1();
					SharedClasses.AutoUpdatingForm.CheckForUpdates(
					exitApplicationAction: delegate { Application.Exit(); },
					ActionIfUptoDate_Versionstring: (versionstring) => { mainform.Text += " (up to date version " + versionstring + ")"; }
					);
					Application.Run(mainform);
				}
			}
		}
	}
}
