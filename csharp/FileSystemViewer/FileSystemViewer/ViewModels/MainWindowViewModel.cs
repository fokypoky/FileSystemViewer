using System.Windows.Controls;
using FileSystemViewer.ViewModels.Base;
using FileSystemViewer.Views.UserControls;

namespace FileSystemViewer.ViewModels
{
	public class MainWindowViewModel : ViewModel
	{
		public UserControl DisksUserControl
		{
			get => new DisksUserControl();
		}

		public UserControl JsonUserControl
		{
			get => new JsonUserControl();
		}

		public UserControl XmlUserControl
		{
			get => new XmlUserControl();
		}

		public UserControl ZipUserControl
		{
			get => new ZipUserControl();
		}
	}
}
