using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Capstone.DAL
{
    public class AppDbContext : DbContext
    {

        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<CharacterWeapon> CharacterWeapon { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Weapon> Weapon { get; set; }

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterWeapon>()
                .HasKey(cw => new { cw.CharacterId, cw.WeaponId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured) builder.UseSqlServer(ConfigurationManager.GetConnectionString());
        }

    }
}
