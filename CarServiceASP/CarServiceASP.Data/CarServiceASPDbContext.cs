using CarServiceASP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceASP.Data
{
    public class CarServiceASPDbContext : DbContext
    {
        public CarServiceASPDbContext(DbContextOptions<CarServiceASPDbContext> opitons) : base(opitons)
        {

        }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<Visit> Visits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationData.ConnectionString).UseLazyLoadingProxies();
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //ef fluent api many to many key
            modelbuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.HasIndex(o => o.Phone).IsUnique();
            });

            modelbuilder.Entity<Car>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.HasIndex(c => c.RegNum).IsUnique();

                entity.HasOne(car => car.Owner).WithMany(owner => owner.Cars).HasForeignKey(car => car.OwnerId);
            });

            modelbuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(w => w.Id);
            });

            modelbuilder.Entity<Visit>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.HasOne(visit => visit.Owner).WithMany(owner => owner.Visits).HasForeignKey(visit => visit.OwnerId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(visit => visit.Car).WithMany(car => car.Visits).HasForeignKey(visit => visit.CarId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(visit => visit.Worker).WithMany(worker => worker.Visits).HasForeignKey(visit => visit.WorkerId).OnDelete(DeleteBehavior.NoAction);
            });

            base.OnModelCreating(modelbuilder);
        }
    }
}
