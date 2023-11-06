using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace lab3_App.Models
{
    public class Contact
    {
        [HiddenInput]
        public int Id { get; set; }
        [Display(Name = "Priorytet")]
        public Priority Priority { get; set; }
        [Required(ErrorMessage = "Musisz podac imie")]
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt dlugie imie, podaj mniejsze")]
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }
        [Display(Name = "Data urodzenia")]
        public DateTime? Birth { get; set; }

        [HiddenInput] 
        [Display(Name = "Został utworzony")]
        public DateTime Created { get; set; }
    }
}
