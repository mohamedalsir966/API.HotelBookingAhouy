using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public static class HotelDataFake
    {
       
        public static List<Hotel> MockSamples() => new()
        {
            new Hotel()
            {
                Id= new Guid("a50e83e0-f374-48ee-ac02-c95d2dfe6311"),
                Name = "Hotel2",
               
            },
            new Hotel()
            {
                Name = "Hotel",
                
            }
        };
        
    }
}
