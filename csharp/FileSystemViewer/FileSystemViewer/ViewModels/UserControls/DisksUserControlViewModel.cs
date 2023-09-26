using System;
using System.Collections.ObjectModel;
using System.IO;
using FileSystemViewer.Models;
using FileSystemViewer.ViewModels.Base;
using FileSystemViewer.Views.Notification.Implementation;
using FileSystemViewer.Views.Notification.Interfaces;

namespace FileSystemViewer.ViewModels.UserControls
{
    public class DisksUserControlViewModel : ViewModel
    {
        private ObservableCollection<DiskInfo> _disks;

        private readonly INotifier _notifier;

        public ObservableCollection<DiskInfo> Disks
        {
	        get => _disks;
	        set => SetField(ref _disks, value);
        }

        public DisksUserControlViewModel()
        {
            Disks = new ObservableCollection<DiskInfo>();
            _notifier = new MessageBoxNotifier();

            try
            {
	            foreach (var drive in DriveInfo.GetDrives())
	            {
		            Disks.Add
		            (
			            new DiskInfo(drive.Name, drive.DriveFormat,
				            drive.TotalSize / 1073741824, // 1073741824 - число байт в 1гб
				            drive.AvailableFreeSpace / 1073741824,
				            (drive.TotalSize - drive.AvailableFreeSpace) / 1073741824)
		            );
	            }
            }
            catch (IOException)
            {
	            _notifier.Notify("Drive access error");
            }
            catch (UnauthorizedAccessException)
            {
	            _notifier.Notify("Unauthorized access error");
            }
		}
    }
}
