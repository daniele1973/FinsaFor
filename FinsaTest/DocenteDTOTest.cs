using FinsaWeb.DTO;
using System;
using Xunit;
using FluentAssertions;
namespace FinsaTest
{
    public class DocenteDTOTest
    {
        private const int AGE = 30;
        [Fact]
        public void Docente_Nato_N_AnniFa_Dovrebbe_Avere_N_Anni()
        {
            var doc = new DocenteDTO
            {
                DataNascita = DateTime.Today.AddYears(-AGE)
            };

            doc.Eta.Should().Be(AGE);
        }

        [Fact]
        public void Docente_Nato_N_Anni_Domani_Fa_Dovrebbe_Avere_N_Meno_Uno_Anni()
        {
            var doc = new DocenteDTO
            {
                DataNascita = DateTime.Today.AddYears(-AGE).AddDays(1)
            };

            doc.Eta.Should().Be(AGE-1);
        }
    }
}
