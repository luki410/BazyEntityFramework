using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Models;

public partial class Podatnik
{
    [Key]
    public int PodatnikId { get; set; }
    public string? Pesel { get; set; }
    public string? Nip { get; set; }
    public string? Imie { get; set; }
    public string? Nazwisko { get; set; }
    public DateTime DataUrodzenia { get; set; }
    public string? Kraj { get; set; }
    public string? Województwo { get; set; }
    public string? Powiat { get; set; }
    public string? Gmina { get; set; }
    public string? Ulica { get; set; }
    public string? NrDomu { get; set; }
    public string? NrLokalu { get; set; }
    public string? Miejsowość { get; set; }
    public string? KodPocztowy { get; set; }
    public virtual ICollection<Zeznanie> Zeznania { get; set; } = new List<Zeznanie>();
}
