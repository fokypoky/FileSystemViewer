using System.Windows;
using FileSystemViewer.Views.Notification.Interfaces;

namespace FileSystemViewer.Views.Notification.Implementation
{
    public class MessageBoxNotifier : INotifier
    {
	    public void Notify(string message) => MessageBox.Show(message);
    }
}
