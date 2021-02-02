using System.Data.Entity;

namespace Cars.cs.model
{
    public class CarsContext : DbContext
    {
        public CarsContext() : base("DefaultConnection")
        {

        }
        public DbSet<Auto> Cars { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Refueling> Refuelings { get; set; }
    }
}
