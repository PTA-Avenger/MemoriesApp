using Microsoft.AspNetCore.Mvc.RazorPages;
using MemoriesApp.Data;

public class IndexModel : PageModel
{
    private readonly MemoryRepository _memoryRepository;

    private readonly MemoryRepository _repository;

    // Inject the repository
    public IndexModel(MemoryRepository memoryRepository)
    {
        _memoryRepository = memoryRepository;
    }

    public List<MemoryFile> MemoryFiles { get; set; }

    public void OnGet()
    {
        MemoryFiles = _repository.GetMemories();
    }
}
