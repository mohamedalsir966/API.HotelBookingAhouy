using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           // ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<FacilitesHotel> FacilitesHotel { get; set; }
        public DbSet<Facilities> Facilities { get; set; }
        public DbSet<Booking> Booking { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
              .HasIndex(x => x.Id);
            modelBuilder.Entity<FacilitesHotel>()
                .HasIndex(x => x.Id);
            modelBuilder.Entity<Booking>()
               .HasIndex(x => x.Id);
            modelBuilder.Entity<Facilities>()
              .HasIndex(x => x.Id);
        }

        public async Task<int> SaveChangesAsync()
        {
            // UpdateUpdateDate();
           // HandleBookDelete();
            return await base.SaveChangesAsync();
           
        }
        private void HandleBookDelete()
        {
            var entities = ChangeTracker.Entries()
                                .Where(e => e.State == EntityState.Deleted);
            foreach (var entity in entities)
            {
                if (entity.Entity is Hotel)
                {
                    entity.State = EntityState.Modified;
                    var book = entity.Entity as Hotel;
                    book.IsDeleted = true;
                }
            }
        }
        //private void UpdateUpdateDate()
        //{
        //    var updateDate = "ModifiedOn";
        //    ChangeTracker.DetectChanges();
        //    var modified = ChangeTracker.Entries();
        //    foreach (var entity in modified)
        //    {
        //        foreach (var prop in entity.Properties)
        //        {
        //            if (prop.Metadata.Name == updateDate)
        //            {
        //                entity.CurrentValues[updateDate] = DateTime.Now;
        //            }
        //        }
        //    }
        //}

    }
}
