using Microsoft.EntityFrameworkCore;

namespace SpacePark.DatabaseModels
{
    public class MyContext : DbContext
    {
        public DbSet<ParkingLot> ParkingLots { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<SpaceShip> SpaceShips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }
    }
}
