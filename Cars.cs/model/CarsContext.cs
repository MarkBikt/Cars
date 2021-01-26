using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.cs.model
{
    public class CarsContext : DbContext
    {
        public CarsContext() : base("DefaultConnection")
        {

        }
        public DbSet<Auto> Cars { get; set; }
    }
}
