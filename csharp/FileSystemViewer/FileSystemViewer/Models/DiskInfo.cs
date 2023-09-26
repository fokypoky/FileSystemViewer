namespace FileSystemViewer.Models
{
    public class DiskInfo
    {
	    public string DiskName { get; set; }
        public string FileSystem { get; set; }
        public decimal Volume { get; set; }
        public decimal FreeSpace { get; set; }
        public decimal UsedSpace { get; set; }

        public DiskInfo(string diskName, string fileSystem , decimal volume, decimal freeSpace, decimal usedSpace)
        {
	        DiskName = diskName;
            FileSystem = fileSystem;
	        Volume = volume;
	        FreeSpace = freeSpace;
	        UsedSpace = usedSpace;
        }
    }
}
