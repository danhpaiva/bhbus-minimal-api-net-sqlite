using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BhBusApi.Models;

namespace BhBusApi.Data
{
    public class BhBusApiContext : DbContext
    {
        public BhBusApiContext (DbContextOptions<BhBusApiContext> options)
            : base(options)
        {
        }

        public DbSet<BhBusApi.Models.Onibus> Onibus { get; set; } = default!;
    }
}
