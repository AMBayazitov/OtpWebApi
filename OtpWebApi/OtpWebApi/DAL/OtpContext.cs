using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OtpWebApi.DAL.Models;

namespace OtpWebApi.DAL
{
    public sealed class OtpContext : DbContext
    {
        public DbSet<User> OtpUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=TotpUsersDb;Integrated Security=True");
        }
    }
}
