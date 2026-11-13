using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_lesson_introduction.Pages;

public class HelloModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? Name { get; set; } = string.Empty;
    
    public DateTime Time { get; private set; }
    
    public int Number { get; private set; }
    
    public void OnGet()
    {
        Name ??= "World";
        Time = DateTime.Now;
        Number = Random.Shared.Next(-1, 2);
    }
}