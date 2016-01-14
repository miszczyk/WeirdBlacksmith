using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WeirdBlacksmith.Models
{
    public class WeaponsDataContext : DbContext
    {
        public DbSet<WeaponsModels> Home { get; set; }
    }
}