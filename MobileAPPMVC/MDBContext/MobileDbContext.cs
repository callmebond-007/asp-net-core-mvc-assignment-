using Microsoft.EntityFrameworkCore;
using MobileAPPMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAPPMVC.MDBContext
{
    public class MobileDbContext : DbContext
    {
        public MobileDbContext(DbContextOptions<MobileDbContext>options) : base(options)
        {

        }
        public DbSet<Manufacturer> MobileCategory { get; set; }

        public DbSet<Mobile> Mobiles { get; set; }
    }
}
