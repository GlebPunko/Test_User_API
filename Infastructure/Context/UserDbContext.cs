using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infastructure.Context
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Email> Emails { get; set; } = null!;

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
