using System.ComponentModel.DataAnnotations;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3_App.Models;

public class Manufacturer
{
   [HiddenInput]
   public int Id { get; set; } 
   
   [Required]
   [StringLength(maximumLength: 50, ErrorMessage = "Zbyt długie imię")]
   [Display(Name = "Nazwa")]
   public string Name { get; set; }
   
   [Display(Name = "Opis")]
   public string? Description { get; set; }
   
   [Display(Name = "Strona")]
   public string? WebsiteUrl { get; set; }
   
   [Display(Name = "Adres")]
   public Address? Address { get; set; }
}