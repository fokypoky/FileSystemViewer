using System.IO;
using FileSystemViewer.Infrastructure.Repositories.Interfaces;
using System.Runtime.Serialization.Json;

namespace FileSystemViewer.Infrastructure.Repositories.Implementation
{
    public class JsonRepository<T> : IFileRepository<T> where T : class
    {
	    public void WriteFile(T writeObject, string filePath)
	    {
		    using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
		    {
			    new DataContractJsonSerializer(typeof(T)).WriteObject(stream, writeObject);
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
				return new DataContractJsonSerializer(typeof(T)).ReadObject(stream) as T;
			}
		}
    }
}
