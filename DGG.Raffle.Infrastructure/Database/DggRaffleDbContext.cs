﻿using DGG.Raffle.Infrastructure.Abstract.Entities;
using Microsoft.EntityFrameworkCore;

namespace DGG.Raffle.Infrastructure.Database
{
    public class DggRaffleDbContext : DbContext
    {
        /// <summary>
        /// Dgg Raffle Entity Framework DBContext.
        /// </summary>
        /// <param name="options"></param>
        public DggRaffleDbContext(DbContextOptions<DggRaffleDbContext> options) : base(options) { 
        }

        /// <summary>
        /// Raffle Entries DB table
        /// </summary>
        public DbSet<RaffleEntries> RaffleEntries { get; set;}

        /// <summary>
        /// Charities catalog DB table
        /// </summary>
        public DbSet<Charities> Charities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Charities>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Charities>()
                .HasData(
                new Charities { Id = 1, Name = "Against Malaria Foundation" }
                );

            modelBuilder.Entity<RaffleEntries>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<RaffleEntries>()
                .HasOne(s => s.Charity)
                .WithMany(s => s.RaffleEntry)
                .HasForeignKey(s => s.CharityId);

            modelBuilder.Entity<RaffleEntries>()
                .HasKey(s => s.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
