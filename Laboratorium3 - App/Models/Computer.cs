using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace lab3_App.Models;

public class Computer
{
	[HiddenInput]
	public int Id { get; set; }
	[Required(ErrorMessage = "Musisz podac nazwe komputera")]
	public string Name { get; set; }
	[Required(ErrorMessage = "Musisz podac nazwe procesora")]
	public string CPU { get; set; }
	[Required(ErrorMessage = "Musisz podac ilosc RAMu")]
	public float RAM { get; set; }
	public string? GPU { get; set; }
	public string? Manufacturer { get; set; }
	public DateTime? ProductionDate { get; set; }
}
