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
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-5NIA6HR\SQLEXPRESS;Initial Catalog=SpacePort;User ID=sa;Password=Knalleanka");
        }
    }
}
