using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinsaWeb.Models;

namespace FinsaWeb.Models.EF
{
    public class FinsaContext : DbContext
    {
        public FinsaContext(DbContextOptions<FinsaContext> options) : base(options)
        {
        }
        public DbSet<Allievo> Allievi { get; set; }
    }
}
