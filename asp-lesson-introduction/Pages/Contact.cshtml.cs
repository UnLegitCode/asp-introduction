using asp_lesson_introduction.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_lesson_introduction.Pages;

public class ContactModel : PageModel
{
    [BindProperty]
    public ContactForm Form { get; set; } = new();
    
    [TempData]
    public string? Message { get; set; }
    
    public void OnGet() {}

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        Message = $"Спасибо, {Form.Name} за обращение";

        return RedirectToPage();
    }
}