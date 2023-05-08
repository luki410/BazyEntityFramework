using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Models;

public partial class Zeznanie
{
    [Key]
    public int ZeznaniaId { get; set; }
    public int PitId { get; set; }
    public int PodatnikId { get; set; }
    public int UrzadId { get; set; }
    public DateTime DataZlozenia { get; set; }
    public virtual Pit? Pit { get; set; }
    public virtual Podatnik? Podatnik { get; set; }
    public virtual UrzadSkarbowy? Urzad { get; set; }
}
