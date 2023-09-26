using System.Threading.Tasks;

namespace FileSystemViewer.Infrastructure.Repositories.Interfaces
{
    public interface IFileRepository<T> where T : class
    {
	    void WriteFile(T writeObject, string filePath);
        T? ReadFile(string filePath);
    }
}
