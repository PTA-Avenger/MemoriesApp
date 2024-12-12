using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MemoriesApp.Data
{
	public class MemoryRepository
{
	 private readonly MemoryDbContext _context;
	 
    private readonly string _connectionString;

     public MemoryRepository(MemoryDbContext context)
    {
        _context = context;
    }
	
    public MemoryRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("AzureSqlDb");
    }

    public List<MemoryFile> GetMemories()
    {
        return _context.MemoryFiles.ToList(); // Ensure it returns List<MemoryFile>
    }

        public async Task AddMemoryAsync(Memory memory)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "INSERT INTO Memories (FileName, FileType, FilePath, UploadedDate, Description) VALUES (@FileName, @FileType, @FilePath, @UploadedDate, @Description)";
        await connection.ExecuteAsync(query, memory);
    }

    public async Task DeleteMemoryAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "DELETE FROM Memories WHERE Id = @Id";
        await connection.ExecuteAsync(query, new { Id = id });
    }
}

public class Memory
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string FileType { get; set; }
    public string FilePath { get; set; }
    public DateTime UploadedDate { get; set; }
    public string Description { get; set; }
}

}
