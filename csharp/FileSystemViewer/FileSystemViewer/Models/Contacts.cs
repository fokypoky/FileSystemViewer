using System.Runtime.Serialization;

namespace FileSystemViewer.Models
{
    [DataContract]
    public class Contacts
    {
        [DataMember] public string Name { get; set; }
        [DataMember] public string PhoneNumber { get; set; }
        [DataMember] public string Email { get; set; }
        [DataMember] public string Address {get; set;}
    }
}
