namespace MemoriesApp.Data
{
    public class MemoryFile
    {
        public int Id { get; set; }          // Primary key
        public string FileName { get; set; } // Name of the file
        public string FileType { get; set; } // MIME type of the file
        public string FileUrl { get; set; }  // URL to access the file
        public DateTime UploadDate { get; set; } // When it was uploaded
    }
}
