using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace UnitTest
{
    public class SharedDatabaseFixture
    {
        private static bool _databaseInitialized;
 
        public SharedDatabaseFixture()
        {
            if (!_databaseInitialized)
            {
                using ApplicationDbContext context = CreateContext();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.AddRange(HotelDataFake.MockSamples());
                context.SaveChanges();
                _databaseInitialized = true;
            }
        }
        public static ApplicationDbContext CreateContext() => 
            new(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("HotelMemoryDB").Options);
    }
}
