using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace lab3_App.Models;

public class Computer
{
    [HiddenInput]
    public int Id { get; set; }
    [Required(ErrorMessage = "Musisz podac nazwe komputera")]
    [Display(Name = "Imię")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Musisz podac nazwe procesora")]
    [Display(Name = "Procesor")]
    public string CPU { get; set; }
    [Required(ErrorMessage = "Musisz podac ilosc RAMu")]
    [Display(Name = "Pamięć")]
    public float RAM { get; set; }
    [Display(Name = "Karta graficzna")]
    public string? GPU { get; set; }
    [Display(Name = "Producent")]
    public string? Manufacturer { get; set; }
    [Display(Name = "Data produkcji")]
    public DateTime? ProductionDate { get; set; }
    [HiddenInput]
    [Display(Name = "Został utworzony")]
    public DateTime Created { get; set; }
}
