using Microsoft.AspNetCore.Mvc;

namespace lab3_App.Models;

public class SoftwareConfiguration
{
    [HiddenInput]
    public int Id { get; set; }
    public string? OperatingSystem { get; set; }
    public List<int> ApplicationIds { get; set; }
}