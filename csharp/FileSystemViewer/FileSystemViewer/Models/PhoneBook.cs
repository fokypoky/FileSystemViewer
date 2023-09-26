using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FileSystemViewer.Models
{
    [DataContract]
    public class PhoneBook
    {
        [DataMember] public List<Contacts> Contacts { get; set; }

        public PhoneBook(List<Contacts> contacts)
        {
	        Contacts = contacts;
        }

        // for serialization
        public PhoneBook()
        {
        }
    }
}
