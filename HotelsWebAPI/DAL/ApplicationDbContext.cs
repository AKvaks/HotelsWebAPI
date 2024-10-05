﻿using HotelsWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelsWebAPI.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }

        //I know Entity infers a lot of things but because of Location I deciced 
        //to ensure how modal will be created
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasKey(h => h.Id);
                entity.Property(h => h.HotelName).IsRequired();
                entity.Property(h => h.Price).HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(h => h.Location).HasColumnType("geography").IsRequired();
            });
        }
    }
}