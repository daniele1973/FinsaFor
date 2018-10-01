using FinsaWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

public class CorsoAllievo
{   
    [Required]
    [RegularExpression(@"^[0-9,\.]+$", ErrorMessage="Inserire solo numeri")]
    public int IdAllievo { get; set; }

    [Required]
    [RegularExpression(@"^[0-9,\.]+$", ErrorMessage="Inserire solo numeri")]
    public int IdEdizioneCorso { get; set; }

    [Required]
    [RegularExpression(@"^[0-9,\.]+$", ErrorMessage="Inserire solo numeri")]
    public int? Voto { get; set; }

    public Allievo Allievo { get; set; }
    public EdizioneCorso EdizioneCorso { get; set; }
}