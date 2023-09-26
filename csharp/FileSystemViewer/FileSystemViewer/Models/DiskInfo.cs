namespace FileSystemViewer.Models
{
    public class DiskInfo
    {
	    public string DiskName { get; set; }
        public string FileSystem { get; set; }
        public decimal TotalSize { get; set; }
        public decimal FreeSpace { get; set; }
        public decimal UsedSpace { get; set; }

        public DiskInfo(string diskName, string fileSystem , decimal totalSize, decimal freeSpace, decimal usedSpace)
        {
	        DiskName = diskName;
            FileSystem = fileSystem;
	        TotalSize = totalSize;
	        FreeSpace = freeSpace;
	        UsedSpace = usedSpace;
        }
    }
}
