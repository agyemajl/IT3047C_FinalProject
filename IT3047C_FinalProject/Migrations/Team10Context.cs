using IT3047C_FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace IT3047C_FinalProject.Migrations 
{
    public class Team10Context : DbContext
    {
        public Team10Context(DbContextOptions<Team10Context> options) : base(options) { }

        public DbSet<TeamMember> TeamMembers { get; set; }
        //public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamMember>().HasData(
                new TeamMember
                {
                    Id = 1,
                    Name = "Grant Willis",
                    MNumber = "M17284310",
                    Email = "willisgr@mail.uc.edu",
                    GitHubUsername = "willisgr"
                },
                new TeamMember
                {
                    Id = 2,
                    Name = "",
                    MNumber = "",
                    Email ="",
                    GitHubUsername = ""
                },
                new TeamMember
                {
                    Id = 3,
                    Name = "",
                    MNumber = "",
                    Email ="",
                    GitHubUsername = ""
                }
            );
            //modelBuilder.Entity<Game>().HasData();
        }
        
    }
}