using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Models;

public partial class UrzadSkarbowy
{
    [Key]
    public int UrzadId { get; set; }
    public string? Województwo { get; set; }
    public string? Powiat { get; set; }
    public string? Ulica { get; set; }
    public string? NrDomu { get; set; }
    public string? Miejsowość { get; set; }
    public string? KodPocztowy { get; set; }
    public virtual ICollection<Zeznanie> Zeznania { get; set; } = new List<Zeznanie>();
}
