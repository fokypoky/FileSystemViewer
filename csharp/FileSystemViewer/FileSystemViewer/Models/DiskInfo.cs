namespace FileSystemViewer.Models
{
    public class DiskInfo
    {
	    public string DiskName { get; set; }
        public decimal Volume { get; set; }
        public decimal FreeSpace { get; set; }
        public decimal UsedSpace { get; set; }

        public DiskInfo(string diskName, decimal volume, decimal freeSpace, decimal usedSpace)
        {
	        DiskName = diskName;
	        Volume = volume;
	        FreeSpace = freeSpace;
	        UsedSpace = usedSpace;
        }
    }
}
