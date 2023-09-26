using FileSystemViewer.Views.PathSelectors.Implementation;

namespace FileSystemViewer.Views.PathSelectors.Interfaces
{
    public interface IPathSelector
    {
        FileType FileType { get; set; }
	    string GetSavePath();
	    string GetOpenPath();
    }
}
