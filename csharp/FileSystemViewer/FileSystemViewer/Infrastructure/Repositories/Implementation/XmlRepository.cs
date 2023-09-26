using System.IO;
using System.Xml.Serialization;
using FileSystemViewer.Infrastructure.Repositories.Interfaces;

namespace FileSystemViewer.Infrastructure.Repositories.Implementation
{
    public class XmlRepository<T> : IFileRepository<T> where T : class
    {
	    public void WriteFile(T writeObject, string filePath)
	    {
		    using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
		    {
				new XmlSerializer(typeof(T)).Serialize(stream, writeObject);
		    }
	    }

	    public T? ReadFile(string filePath)
	    {
		    if (!File.Exists(filePath))
		    {
				return default(T);
		    }

		    using (var stream = new FileStream(filePath, FileMode.Open))
		    {
				return new XmlSerializer(typeof(T)).Deserialize(stream) as T;
		    }
	    }
    }
}
