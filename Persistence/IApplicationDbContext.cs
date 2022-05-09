using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Hotel> Hotel { get; set; }
        DbSet<FacilitesHotel> FacilitesHotel { get; set; }
        DbSet<Booking> Booking { get; set; }    
        DbSet<Facilities> Facilities { get; set; }
        Task<int> SaveChangesAsync();
    }
}
