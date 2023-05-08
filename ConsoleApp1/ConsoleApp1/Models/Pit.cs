using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Models;

public partial class Pit
{
    [Key]
    public int PitId { get; set; }
    public int PoleId { get; set; }
    public DateTime RokPodatkowy { get; set; }
    public string? NrDokumentu { get; set; }
    public string? Status { get; set; }
    public virtual Pole? Pole { get; set; }
    public virtual ICollection<Zeznanie> Zeznania { get; set; } = new List<Zeznanie>();
}
