using System;
using FileSystemViewer.Views.PathSelectors.Interfaces;
using Microsoft.Win32;

namespace FileSystemViewer.Views.PathSelectors.Implementation
{
    class WindowsPathSelector : IPathSelector
    {
	    private string _filter
	    {
		    get
		    {
			    switch (FileType)
			    {
					case FileType.Json:
						return "JSON (*.json)|*.json";
					case FileType.Xml:
						return "XML (*.xml)|*.xml";
					case FileType.Zip:
						return "ZIP (*.zip)|*.zip";
					case FileType.Any:
						return "Any (*.*)|*.*";
					default:
						return "";
			    }
		    }
	    }

		public FileType FileType { get; set; }

		public string GetSavePath()
		{
			var dialog = new SaveFileDialog();
			dialog.Filter = _filter;
			dialog.FilterIndex = 2;
			dialog.RestoreDirectory = true;

			dialog.ShowDialog();

			if (String.IsNullOrEmpty(dialog.FileName))
			{
				if (FileType == FileType.Json)
				{
					return "phonebook.json";
				}

				if (FileType == FileType.Xml)
				{
					return "phonebook.xml";
				}

				if (FileType == FileType.Zip)
				{
					return "phonebook.zip";
				}
			}

			return dialog.FileName;

		}

		public string GetOpenPath()
		{
			var dialog = new OpenFileDialog();
			dialog.Filter = _filter;
			dialog.RestoreDirectory = true;

			dialog.ShowDialog();

			return dialog.FileName;
		}

		public WindowsPathSelector()
		{
		}

		public WindowsPathSelector(FileType fileType) => FileType = fileType;
    }
}
