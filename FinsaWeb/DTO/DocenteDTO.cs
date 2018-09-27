using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.DTO
{
    public class DocenteDTO
    {
        public int IdDocente { get; set; }
        public string CF { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string TipoDocente { get; set; }
        public int Eta
        {
            get
            {
                int age = DateTime.Today.Year - DataNascita.Year;
                if (DateTime.Today.Month > DataNascita.Month)
                    return age;
                if(DateTime.Today.Month == DataNascita.Month)
                {
                    if(DateTime.Today.Day < DataNascita.Day)
                    {
                        return age - 1;
                    }
                    else
                    {
                        return age;
                    }
                }
                return age - 1;
            }
        }
    }
}
