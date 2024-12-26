using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }
        // DbSet properties inside the DbContext class, and all of these properties represents collection inside database
        public DbSet<Difficulty>  Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties
            // Easy, Medium, Hard
            var difficulties = new List<Difficulty>() 
            { 
                new Difficulty()
                {
                    Id = Guid.Parse("751882ce-03c1-41df-a7b3-f30065d26890"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("45f803b0-8bba-4fdc-ac4e-b0397d4966e2"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("a242a8d7-65eb-4de7-971f-4292f6e71eb0"),
                    Name = "Hard"
                }
            };

            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for Regions
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("a5d08149-31b3-49f2-88fe-f28f182f8526"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("5c207a38-18e0-4a28-b4fd-2e5eb9157b9a"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("cc573506-64ac-43f8-88d6-1a28132154bc"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("9ddac940-5d19-461b-8bb8-6595b33a4851"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                },
            };
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
