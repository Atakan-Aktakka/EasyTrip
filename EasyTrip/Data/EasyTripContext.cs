using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyTrip.Models.Siniflar;

namespace EasyTrip.Data
{
    public class EasyTripContext : DbContext
    {
        public EasyTripContext (DbContextOptions<EasyTripContext> options): base(options){ }

        public DbSet<EasyTrip.Models.Siniflar.iletisim> iletisim { get; set; } = default!;
    }
}
