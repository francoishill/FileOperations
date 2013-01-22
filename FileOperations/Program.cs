using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SharedClasses;
using System.Reflection;
using System.Drawing;
using System.IO;

namespace FileOperations
{
	static class Program
	{
		const string ThisAppKeyName = "FileOperations";

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			MainForm mainform = new MainForm();
			AutoUpdating.CheckForUpdates_ExceptionHandler(
				delegate
				{
					ThreadingInterop.UpdateGuiFromThread(mainform, () => mainform.Text += " (up to date version " + AutoUpdating.GetThisAppVersionString() + ")");
				});
			/*AutoUpdating.CheckForUpdates(
				//SharedClasses.AutoUpdatingForm.CheckForUpdates(
				//exitApplicationAction: () => Application.Exit(),
									ActionIfUptoDate_Versionstring: versionstring => ThreadingInterop.UpdateGuiFromThread(mainform, () => mainform.Text += " (up to date version " + versionstring + ")")
				//,
				//ActionIfUnableToCheckForUpdates: errmsg => ThreadingInterop.UpdateGuiFromThread(mainform, () => mainform.Text += " (" + errmsg + ")"));
									);*/

			//PreviewHandlers.RegisterThisDllPreviewHandlers();

			var args = Environment.GetCommandLineArgs();
			//args = new string[] { "", @"C:\Users\francois\Dropbox\Dev\VSprojects\SharedClasses" };//@"C:\Users\francois\Dropbox\Temp\WaterSkills\Source" };
			//args = new string[] { "", "highlighttohtml", @"C:\Francois\Dev\VSprojects\SharedClasses\EncodeAndDecodeInterop.cs" };

			/*if (Application.ExecutablePath.StartsWith(@"C:\Program Files", StringComparison.InvariantCultureIgnoreCase))
			{

				string iconPath = "\"" + Environment.GetCommandLineArgs()[0] + "\"";//"shell32.dll,-320",;
				bool added = RegistryInterop.AddSubMenuCommands(new RegistryInterop.MainContextMenuItem(
					new List<string>() { "Folder", "Directory", "Directory\\Background" },
					"Search in files",
					//"Hex converting",
					iconPath,
					new List<RegistryInterop.SubContextMenuItem>()
				{
					new RegistryInterop.SubContextMenuItem("_FileOperations.FileOperations", "Search in files", iconPath, "\"" + Environment.GetCommandLineArgs()[0] + "\" \"%V\"")
				}));

				if (!added)
					UserMessages.ShowWarningMessage("Cannot register application " + ThisAppKeyName + " to right-click menu, unable to write registry");

				//SharedClasses.RegistryInterop.AddCommandToFolder(
				//    "FileOperations",
				//    "\"" + Environment.GetCommandLineArgs()[0] + "\" \"%V\"",
				//    "Search in files",
				//    "\"" + Environment.GetCommandLineArgs()[0] + "\"",//"shell32.dll,-320",
				//    null,//"FileOperations",
				//    ThisAppKeyName);
			}*/

			if (args.Length <= 1)
				UserMessages.ShowWarningMessage("This program (" + ThisAppKeyName + ") needs commandline argument(s) to run.");
			else
			{
				if (args.Length == 2)
				{
				}
				else if (args.Length >= 3)
				{
					string searchtextinfiles = "searchtextinfiles";
					string toHex = "tohex";
					string fromHex = "fromhex";
					string getmetadata = "getmetadata";
					string comparetocachedmetadata = "comparetocachedmetadata";
					string createdowloadlinktextfile = "createdowloadlinktextfile";
					string resizeimage = "resizeimage";
					string rotatepdf90degrees = "rotatepdf90degrees";
					string rotatepdf180degrees = "rotatepdf180degrees";
					string rotatepdf270degrees = "rotatepdf270degrees";
					string highlighttohtml = "highlighttohtml";
					string dumpclipboardimage = "dumpclipboardimage";

					typeof(Form).GetField("defaultIcon", BindingFlags.NonPublic | BindingFlags.Static)
							.SetValue(null, new Icon(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("FileOperations.app.ico")));

					if (args[1].Equals(searchtextinfiles, StringComparison.InvariantCultureIgnoreCase))
					{
						args[2] = args[2].Trim(' ', '"', '\'', '\\');
						if (!Directory.Exists(args[2]))
							UserMessages.ShowWarningMessage("Cannot find Directory (passed as command-line argument with 'searchtextinfiles'): \"" + args[2] + "\"");
						else
						{
							string searchText =
								args.Length >= 4
								? args[3]
								: DialogBoxStuff.InputDialog(
									"Please enter the text to search for in all files (recursively) in folder:"
									+ Environment.NewLine
									+ Environment.NewLine
									+ args[2],
									"Search text in files");
							if (!string.IsNullOrWhiteSpace(searchText))
							{
								string rootDirForSearching = args[2];
								SearchWindow sw = new SearchWindow(searchText, rootDirForSearching);
								sw.ShowDialog();
								//MainForm.SearchText = searchText;
								//MainForm.RootDirectoryForSearching = args[2];
								//Application.Run(mainform);
							}
						}
					}
					else if (args[1].Equals(fromHex, StringComparison.InvariantCultureIgnoreCase))
					{
						if (!File.Exists(args[2]))
							UserMessages.ShowWarningMessage("Cannot find file (passed as command-line argument with 'fromhex'): " + args[2]);
						{
							string hexfile = args[2];
							string normfile =
							args[2].EndsWith(".hex", StringComparison.InvariantCultureIgnoreCase)
								? Path.ChangeExtension(hexfile, null)
								: args[2] + ".bin";
							EncodeAndDecodeInterop.DecodeFileFromHex(hexfile, normfile);
						}
					}
					else if (args[1].Equals(toHex, StringComparison.InvariantCultureIgnoreCase))
					{
						if (!File.Exists(args[2]))
							UserMessages.ShowWarningMessage("Cannot find file (passed as command-line argument with 'tohex'): " + args[2]);
						else
						{
							string origfile = args[2];
							string hexfilepath = origfile + ".hex";
							EncodeAndDecodeInterop.EncodeFileToHex(origfile, hexfilepath, err => UserMessages.ShowErrorMessage(err));
						}
					}
					else if (args[1].Equals(getmetadata, StringComparison.InvariantCultureIgnoreCase))
					{
						if (!Directory.Exists(args[2]))
							UserMessages.ShowWarningMessage("Cannot find directory (passed as command-line argument with 'getmetadata'): " + args[2]);
						else
						{
							string dir = args[2];
							var fd = new FolderDetails(dir, null);
							fd.SaveDetails(GetmetaFilenameFromDirpath(dir));
						}
					}
					else if (args[1].Equals(comparetocachedmetadata, StringComparison.InvariantCultureIgnoreCase))
					{
						if (!Directory.Exists(args[2]))
							UserMessages.ShowWarningMessage("Cannot find directory (passed as command-line argument with 'comparetocachedmetadata'): " + args[2]);
						else
						{
							string dir = args[2];
							string jsonfile = GetmetaFilenameFromDirpath(dir);
							string changesfile = Path.ChangeExtension(jsonfile, ".changes.txt");
							string addedfile = Path.ChangeExtension(jsonfile, ".added.txt");
							string missingfile = Path.ChangeExtension(jsonfile, ".missing.txt");
							if (File.Exists(changesfile))
								File.Delete(changesfile);
							if (File.Exists(addedfile))
								File.Delete(addedfile);
							if (File.Exists(missingfile))
								File.Delete(missingfile);

							if (File.Exists(jsonfile))
							{
								var curr = new FolderDetails(dir, null);
								Dictionary<string, FileDetails> newIn2;
								Dictionary<string, FileDetails> missingIn2;
								Dictionary<string, FileDetails> changedItems;
								bool? compareResult =
									FolderDetails.CreateFromJsonFile(GetmetaFilenameFromDirpath(dir))
									.CompareDetails(curr, out newIn2, out missingIn2, out changedItems);
								if (!compareResult.HasValue)
									UserMessages.ShowWarningMessage("Cannot compare to cached copy, excluded folders list differs");
								else
								{
									if (compareResult.Value == false)//Changes/added/missing
									{
										if (changedItems != null && changedItems.Count > 0)
											File.WriteAllLines(changesfile, changedItems.Keys.Select(s => "\\" + s));
										if (newIn2 != null && newIn2.Count > 0)
											File.WriteAllLines(addedfile, newIn2.Keys.Select(s => "\\" + s));
										if (missingIn2 != null && missingIn2.Count > 0)
											File.WriteAllLines(missingfile, missingIn2.Keys.Select(s => "\\" + s));
									}
									else
										UserMessages.ShowInfoMessage("There are no changes compared to the cached metadata.");
								}
							}
							else if (UserMessages.Confirm("Cannot find cached json file, generate this metadata-file now?: " + jsonfile))
								new FolderDetails(dir, null).SaveDetails(GetmetaFilenameFromDirpath(dir));
						}
					}
					else if (args[1].Equals(createdowloadlinktextfile, StringComparison.InvariantCultureIgnoreCase))
					{
						if (!Directory.Exists(args[2]))
							UserMessages.ShowWarningMessage("Cannot find directory (passed as command-line argument with 'createdowloadlinktextfile'): " + args[2]);
						else
						{
							string dir = args[2];
							string tmpfilepath = Path.Combine(dir, "Download link.txt");
							if (!File.Exists(tmpfilepath))
							{
								string filecontents = DialogBoxStuff.InputDialog("Paste the download link here (to be placed inside 'Download link.txt' file)", "Download link");
								File.WriteAllText(tmpfilepath, filecontents ?? "");
							}
							else
								UserMessages.ShowWarningMessage("File already existed: " + tmpfilepath, AlwaysOnTop: true);
						}
					}
					else if (args[1].Equals(resizeimage, StringComparison.InvariantCultureIgnoreCase))
					{
						if (!File.Exists(args[2]))
							UserMessages.ShowWarningMessage("Cannot find file (passed as command-line argument with 'resizeimage'): " + args[2]);
						else
						{
							string origFile = args[2];
							//if (args.Length < 4)
							//    UserMessages.ShowWarningMessage("To resize image, command must have another argument to specify the max-side length");
							//else
							//{
							//int maxsidelength;
							//if (int.TryParse(args[3], out maxsidelength))

							//Point? pickedMaxSideLength = PickItemForm.PickItem<Point?>(
							//    new List<Point?>()
							//    {
							//        new Point(800, 600),
							//        new Point(1280, 720),
							//        new Point(1600, 900),
							//        new Point(1920, 1080)
							//    },
							//    "Please choose the new size (max-width, max-height)",
							//    null);

							int? pickedMaxSideLength = PickItemForm.PickItem<int?>(
								new List<int?>()
								{
									800,
									1280,
									1600,
									1920
								},
								"Please choose the new size (maximum side-length)",
								null);

							if (pickedMaxSideLength.HasValue)
								ImagesInterop.ResizeImage(
									origFile,
									Path.ChangeExtension(origFile, ".new" + Path.GetExtension(origFile)),
									pickedMaxSideLength.Value);
							//else
							//    UserMessages.ShowWarningMessage("Cannot resize image, invalid size specified = " + args[3]);
							//}
						}
					}
					else if (args[1].Equals(rotatepdf90degrees, StringComparison.InvariantCultureIgnoreCase))
					{
						if (!File.Exists(args[2]))
							UserMessages.ShowWarningMessage("Cannot find file (passed as command-line argument with 'rotatepdf90degrees'): " + args[2]);
						else
						{
							string origfile = args[2];
							string rotatedfilepath = Path.ChangeExtension(origfile, ".rotate90.pdf");
							List<string> allfeedbackCatched;
							if (!PdfToolkitInterop.PerformRotation(origfile, rotatedfilepath, PdfToolkitInterop.RotationTypes._90clockwise, out allfeedbackCatched))
								UserMessages.ShowErrorMessage("Could not perform rotation: "
									+ Environment.NewLine + string.Join(Environment.NewLine, allfeedbackCatched));
						}
					}
					else if (args[1].Equals(rotatepdf180degrees, StringComparison.InvariantCultureIgnoreCase))
					{
						if (!File.Exists(args[2]))
							UserMessages.ShowWarningMessage("Cannot find file (passed as command-line argument with 'rotatepdf180degrees'): " + args[2]);
						else
						{
							string origfile = args[2];
							string rotatedfilepath = Path.ChangeExtension(origfile, ".rotate180.pdf");
							List<string> allfeedbackCatched;
							if (!PdfToolkitInterop.PerformRotation(origfile, rotatedfilepath, PdfToolkitInterop.RotationTypes._180clockwise, out allfeedbackCatched))
								UserMessages.ShowErrorMessage("Could not perform rotation: "
									+ Environment.NewLine + string.Join(Environment.NewLine, allfeedbackCatched));
						}
					}
					else if (args[1].Equals(rotatepdf270degrees, StringComparison.InvariantCultureIgnoreCase))
					{
						if (!File.Exists(args[2]))
							UserMessages.ShowWarningMessage("Cannot find file (passed as command-line argument with 'rotatepdf270degrees'): " + args[2]);
						else
						{
							string origfile = args[2];
							string rotatedfilepath = Path.ChangeExtension(origfile, ".rotate270.pdf");
							List<string> allfeedbackCatched;
							if (!PdfToolkitInterop.PerformRotation(origfile, rotatedfilepath, PdfToolkitInterop.RotationTypes._270clockwise, out allfeedbackCatched))
								UserMessages.ShowErrorMessage("Could not perform rotation: "
									+ Environment.NewLine + string.Join(Environment.NewLine, allfeedbackCatched));
						}
					}
					else if (args[1].Equals(highlighttohtml, StringComparison.InvariantCultureIgnoreCase))
					{
						if (!File.Exists(args[2]))
							UserMessages.ShowWarningMessage("Cannot find file (passed as command-line argument with 'highlighttohtml'): " + args[2]);
						else
						{
							string origfile = args[2];
							string htmlfile_highlighted = Path.ChangeExtension(origfile, ".highlighted.html");
							string extension = Path.GetExtension(origfile);

							string origFileContents = File.ReadAllText(origfile);

							string htmlContents = null;
							if (extension.Equals(".cs", StringComparison.InvariantCultureIgnoreCase))
								htmlContents = HighlightToHtml.FromCSharpCode(origFileContents);
							else if (extension.Equals(".html", StringComparison.InvariantCultureIgnoreCase))
								htmlContents = HighlightToHtml.FromHTMLcode(origFileContents);
							else if (extension.Equals(".java", StringComparison.InvariantCultureIgnoreCase))
								htmlContents = HighlightToHtml.FromJava(origFileContents);
							else if (extension.Equals(".js", StringComparison.InvariantCultureIgnoreCase))
								htmlContents = HighlightToHtml.FromJavaStript(origFileContents);
							else if (extension.Equals(".pas", StringComparison.InvariantCultureIgnoreCase))
								htmlContents = HighlightToHtml.FromPascal(origFileContents);
							else if (extension.Equals(".php", StringComparison.InvariantCultureIgnoreCase))
								htmlContents = HighlightToHtml.FromPhp(origFileContents);
							else if (extension.Equals(".sql", StringComparison.InvariantCultureIgnoreCase))
								htmlContents = HighlightToHtml.FromSQL(origFileContents);
							else if (extension.Equals(".xml", StringComparison.InvariantCultureIgnoreCase))
								htmlContents = HighlightToHtml.FromXML(origFileContents);

							if (htmlContents != null)
								File.WriteAllText(htmlfile_highlighted, htmlContents);
							else
								UserMessages.ShowWarningMessage("Unable to HTML for file: " + origfile);
						}
					}
					else if (args[1].Equals(dumpclipboardimage, StringComparison.InvariantCultureIgnoreCase))
					{
						string dir = args[2].Trim(' ', '"', '\'', '\\');
						if (!Directory.Exists(dir))
							UserMessages.ShowWarningMessage("Cannot find Directory (passed as command-line argument with 'dumpclipboardimage'): \"" + dir + "\"");
						else
						{
							string timeStr = DateTime.Now.ToString(@"yyyy-MM-dd HH_mm_ss");
							string imagePathToSave = Path.Combine(dir, "Clipboard image " + timeStr + ".jpg");
							if (!Clipboard.ContainsImage())
								UserMessages.ShowWarningMessage("No image currently in clipboard");
							else
								Clipboard.GetImage().Save(imagePathToSave, System.Drawing.Imaging.ImageFormat.Png);
						}
					}
				}
			}
			Application.Exit();
		}

		private static string GetmetaFilenameFromDirpath(string dir)
		{
			return dir.TrimEnd('\\') + ".meta.json";
		}
	}
}