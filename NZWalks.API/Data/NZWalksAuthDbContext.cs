using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {
        }

         protected override void OnModelCreating(ModelBuilder builder)
         {
            base.OnModelCreating(builder);

            var readerRoleId = "81b1ce8b-066c-4688-9fe5-c0adf311b71f";
            var writerRoleId = "ee6275dc-764b-4b87-bfcd-98df1cbe2f37";

            var roles = new List<IdentityRole>

            {
                new IdentityRole
                {
                Id = readerRoleId,
                ConcurrencyStamp = readerRoleId,
                Name = "Reader",
                NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                Id = writerRoleId,
                ConcurrencyStamp = writerRoleId,
                Name = "Writer",
                NormalizedName = "Writer".ToUpper()
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
         }
    }
}
