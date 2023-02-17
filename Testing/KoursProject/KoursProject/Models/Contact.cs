using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Cors;

namespace KoursProject.Models
{
    public class Contact
    {
        [Display(Name = "Введите имя")]
        [Required(ErrorMessage = "Вам нужно ввести имя")]
        public string Name { get; set; }
        [Display(Name = "Введите фамилию")]
        [Required(ErrorMessage = "Вам нужно ввести фамилию")]
        public string Surame { get; set; }
        [Display(Name = "Введите возраст")]
        [Required(ErrorMessage = "Вам нужно ввести возраст")]
        public int Age { get; set; }
        [Display(Name = "Введите почту")]
        [Required(ErrorMessage = "Вам нужно ввести почту")]
        public string Email { get; set; }
        [Display(Name = "Введите сообщение")]
        [StringLength(30, ErrorMessage = "Текст менее 30 символов")]
        [Required(ErrorMessage = "Вам нужно ввести сообщение")]
        public string Message { get; set; }

    }
}
