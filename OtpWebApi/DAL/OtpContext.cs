using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OtpWebApi.DAL.Models;

namespace OtpWebApi.DAL
{
    public sealed class OtpContext : DbContext
    {
        private IConfiguration configuration { get; set; }

        public OtpContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public DbSet<AspNetUser> AspNetUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
