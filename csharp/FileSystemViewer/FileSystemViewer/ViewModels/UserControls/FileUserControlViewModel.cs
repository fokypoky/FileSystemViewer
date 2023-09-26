using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using FileSystemViewer.Infrastructure.Commands;
using FileSystemViewer.Infrastructure.Repositories.Implementation;
using FileSystemViewer.Infrastructure.Repositories.Interfaces;
using FileSystemViewer.Models;
using FileSystemViewer.ViewModels.Base;
using FileSystemViewer.Views.Notification.Implementation;
using FileSystemViewer.Views.Notification.Interfaces;
using FileSystemViewer.Views.PathSelectors.Implementation;
using FileSystemViewer.Views.PathSelectors.Interfaces;

namespace FileSystemViewer.ViewModels.UserControls
{
    public class FileUserControlViewModel : ViewModel
    {
	    private ObservableCollection<Contacts> _contacts;
	    private Contacts _selectedContacts;

	    private readonly INotifier _notifier;
		private readonly IPathSelector _pathSelector;

	    public ObservableCollection<Contacts> Contacts
	    {
		    get => _contacts;
		    set => SetField(ref _contacts, value);
	    }

	    public Contacts SelectedContacts
	    {
		    get => _selectedContacts;
		    set => SetField(ref _selectedContacts, value);
	    }

	    #region Commands

	    public ICommand AddContactsCommand
	    {
		    get => new RelayCommand((object parameter) =>
		    {
				Contacts?.Add(new Contacts());
		    });
	    }

	    public ICommand CreateNewPhoneBookCommand
	    {
		    get => new RelayCommand((object parameter) =>
		    {
				Contacts?.Clear();
		    });
	    }

	    public ICommand RemoveContactsCommand
	    {
		    get => new RelayCommand((object parameter) =>
		    {
			    if (SelectedContacts is not null)
			    {
					Contacts?.Remove(SelectedContacts);
			    }
		    });
	    }

	    public ICommand SavePhoneBookCommand
	    {
		    get => new RelayCommand(SavePhoneBook);
	    }

	    public ICommand OpenPhoneBookCommand
	    {
		    get => new RelayCommand(OpenPhoneBook);
	    }

		#endregion

		#region Command functions

		private void SavePhoneBook(object parameter)
		{
			if (Contacts.Count == 0)
			{
				_notifier.Notify("Phone book is empty");
				return;
			}

			IFileRepository<PhoneBook> fileRepository;

			switch (parameter.ToString().ToLower())
			{
				case "json":
					fileRepository = new JsonRepository<PhoneBook>();
					_pathSelector.FileType = FileType.Json;
					break;
				case "xml":
					fileRepository = new XmlRepository<PhoneBook>();
					_pathSelector.FileType = FileType.Xml;
					break;
				default:
					return;
			}

			fileRepository.WriteFile(new PhoneBook(Contacts.ToList()), _pathSelector.GetSavePath());
			_notifier.Notify("Phone book saved successfully");

		}

		private void OpenPhoneBook(object parameter)
		{
			string filePath = _pathSelector.GetOpenPath();

			if (String.IsNullOrEmpty(filePath))
			{
				_notifier.Notify("Invalid path");
				return;
			}

			string fileExtension = Path.GetExtension(filePath);

			IFileRepository<PhoneBook> fileRepository;

			switch (fileExtension.ToLower())
			{
				case ".json":
					fileRepository = new JsonRepository<PhoneBook>();
					break;
				case ".xml":
					fileRepository = new XmlRepository<PhoneBook>();
					break;
				default:
					_notifier.Notify("Invalid file extension");
					return;
			}

			Contacts = new ObservableCollection<Contacts>(
				fileRepository.ReadFile(filePath).Contacts
			);
		}

		#endregion

		public FileUserControlViewModel()
		{
			Contacts = new ObservableCollection<Contacts>();
			_notifier = new MessageBoxNotifier();
			_pathSelector = new WindowsPathSelector();
		}
    }
}
