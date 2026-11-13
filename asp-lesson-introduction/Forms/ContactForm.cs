using System.ComponentModel.DataAnnotations;

namespace asp_lesson_introduction.Forms;

public class ContactForm
{
    [Display(Name = "Имя")]
    [Required(ErrorMessage = "Укажите имя")]
    public string Name { get; set; } = string.Empty;
    
    [Display(Name = "Email")]
    [EmailAddress(ErrorMessage = "Некорректный email")]
    public string Email { get; set; } = string.Empty;
    
    [Display(Name = "Сообщение")]
    [Required(ErrorMessage = "Введите сообщение")]
    public string Text { get; set; } = string.Empty;
}