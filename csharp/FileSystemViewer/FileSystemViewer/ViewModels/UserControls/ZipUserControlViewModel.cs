using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Input;
using FileSystemViewer.Infrastructure.Commands;
using FileSystemViewer.ViewModels.Base;
using FileSystemViewer.Views.Notification.Implementation;
using FileSystemViewer.Views.Notification.Interfaces;
using FileSystemViewer.Views.PathSelectors.Implementation;
using FileSystemViewer.Views.PathSelectors.Interfaces;

namespace FileSystemViewer.ViewModels.UserControls
{
    public class ZipUserControlViewModel : ViewModel
    {
	    private string _zipPath;
	    private string _filePath;
	    private long _decompressedFileSize;
		private long _compressedFileSize;

		private readonly INotifier _notifier;
		private IPathSelector _pathSelector;

	    #region Public fields

	    public string ZipPath
	    {
		    get => _zipPath;
		    set => SetField(ref _zipPath, value);
	    }

	    public string FilePath
	    {
		    get => _filePath;
		    set => SetField(ref _filePath, value);
	    }

	    public long DecompressedFileSize
	    {
		    get => _decompressedFileSize;
		    set => SetField(ref _decompressedFileSize, value);
	    }

	    public long CompressedFileSize
	    {
		    get => _compressedFileSize;
		    set => SetField(ref _compressedFileSize, value);
	    }

		#endregion

		#region Commands

		public ICommand CreateZipCommand
		{
			get => new RelayCommand(CreateZip);
		}

		public ICommand AddFileCommand
		{
			get => new RelayCommand(AddFile);
		}

		public ICommand UnzipCommand
		{
			get => new RelayCommand(Unzip);
		}

		public ICommand RemoveFileCommand
		{
			get => new RelayCommand(RemoveFile);
		}

		#endregion

		#region Command functions

		private void CreateZip(object parameter)
		{
			string zipPath = new WindowsPathSelector(FileType.Zip).GetSavePath();

			if (!FilePathIsCorrect(zipPath))
			{
				return;
			}

			ZipPath = zipPath;
		}

		private void AddFile(object parameter)
		{
			string filePath = new WindowsPathSelector(FileType.Any).GetSavePath();

			if (!FilePathIsCorrect(filePath))
			{
				return;
			}

			FilePath = filePath;

			CompressFile(FilePath, ZipPath);
			_notifier.Notify("Compressed!");
		}

		private void Unzip(object parameter)
		{
			_pathSelector = new WindowsPathSelector(FileType.Any);
			string unzipFile = _pathSelector.GetSavePath();

			if (String.IsNullOrEmpty(unzipFile))
			{
				_notifier.Notify("Invalid path");
				return;
			}

			Decompress(ZipPath, unzipFile);
			_notifier.Notify("Decompressed!");
		}

		private void RemoveFile(object parameter)
		{
			if (File.Exists(FilePath))
			{
				File.Delete(FilePath);
			}

			if (File.Exists(ZipPath))
			{
				File.Delete(ZipPath);
			}

			FilePath = String.Empty;
			ZipPath = String.Empty;
			CompressedFileSize = 0;
			DecompressedFileSize = 0;

			_notifier.Notify("Files removed");
		}

		#endregion

		private bool FilePathIsCorrect(string filePath)
		{
			if (String.IsNullOrEmpty(filePath))
			{
				_notifier.Notify("Invalid file path");
				return false;
			}

			return true;
		}

		public ZipUserControlViewModel()
		{
			_notifier = new MessageBoxNotifier();
		}

		private void CompressFile(string sourceFile, string destinationFile)
		{
			using (var sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
			{
				using (var destinationStream = File.Create(destinationFile))
				{
					using (var compressingStream = new GZipStream(destinationStream, CompressionMode.Compress))
					{
						CompressedFileSize = destinationStream.Length;
						DecompressedFileSize = sourceFile.Length;
						sourceStream.CopyTo(compressingStream);
					}
				}
			}
		}

		private void Decompress(string compressedFile, string destinationFile)
		{
			using (var sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
			{
				using (var destinationStream = File.Create(destinationFile))
				{
					using (var decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
					{
						decompressionStream.CopyTo(destinationStream);
					}
				}
			}
		}

	}
}
