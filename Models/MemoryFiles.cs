namespace MemoriesApp.Models
{
    public class MemoryFiles
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public DateTime UploadedDate { get; set; }
        public string Description { get; set; } // Optional, for notes about the memory
        public string FilePath { get; set; } // Full path to the file in the system
    }
}
