using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Models;

public partial class Pole
{
    [Key]
    public int PoleId { get; set; }
    public string? NazwaPola { get; set; }
    public string? OpisPola { get; set; }
    public bool CzyBool { get; set; }
    public virtual ICollection<Pit> Pity { get; set; } = new List<Pit>();
}
