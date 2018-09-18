using FinsaWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

public class CorsoAllievo
{
    [Key]
    public int IDAllievo { get; set; }
    public EdizioneCorso EdizioneCorso { get; set; }
    public int IDEdizioneCorso { get; set; }
    public int Voto { get; set; }

    // public void Inserisci(int ID, int voto){}
}