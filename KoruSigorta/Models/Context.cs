using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Rezervasyon.Models
{
    public class Context :DbContext
    {
        public DbSet<Randevu> Randevus { get; set; }
    }
}