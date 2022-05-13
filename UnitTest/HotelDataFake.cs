using Domain.Entities;
using Service.HotelFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public static class HotelDataFake
    {

        public static List<Hotel> MockSamples()
        {
            var hotils = new List<Hotel>();
            hotils.Add(new Hotel()
            {
                Id = new Guid("a50e83e0-f374-48ee-ac02-c95d2dfe6388"),
                Name = "Name1",
                State = "State1",
                Description = "Description1"

            });
            hotils.Add(new Hotel()
            {
                Id = new Guid("a50e83e0-f374-48ee-ac02-c95d2dfe6123"),
                Name = "Name2",
                State = "State2",
                Description = "Description2"

            });


            return hotils;
        }

      //  public static DeleteHotelByIdCommand MockDeleteHotelByIdCommand() => new() { hotelId = new Guid("a50e83e0-f374-48ee-ac02-c95d2dfe6123") };
        public static CreateNewHotelCommand MockCreateNewHotelCommand() => new() { Name = "testname", State = "testState", Description = "testDescription" };

    }
}
