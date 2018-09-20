﻿using FinsaWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

public class CorsoAllievo
{    
    public int IdAllievo { get; set; }
    public int IdEdizioneCorso { get; set; }
    public int? Voto { get; set; }

    public Allievo Allievo { get; set; }
    public EdizioneCorso EdizioneCorso { get; set; }
}