using Moq;
using Persistence;
using Service.HotelFeatures.Commands;
using Service.HotelFeatures.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Service.HotelFeatures.Commands.CreateNewHotelCommand;
using static Service.HotelFeatures.Commands.DeleteHotelByIdCommand;
using static Service.HotelFeatures.Queries.GetHotelByIdQuery;

namespace UnitTest
{
    public class HotilTest : IClassFixture<SharedDatabaseFixture>
    {
        public SharedDatabaseFixture Fixture { get; }
        private readonly Mock<IApplicationDbContext> MockContext;
        public HotilTest(SharedDatabaseFixture fixture)
        {
            Fixture = fixture;
            MockContext = new Mock<IApplicationDbContext>();
            MockContext.Setup(db => db.Hotel).Returns(SharedDatabaseFixture.CreateContext().Hotel);
        }

        [Fact]
        public async Task CanInsertHotelIntoDatabasee()
        {
            var GetHotel = new CreateNewHotelCommandHandler(MockContext.Object);
            var objGetHotelquery = new CreateNewHotelCommand() { Name= HotelDataFake.MockCreateNewHotelCommand().Name };
            var result = await GetHotel.Handle(objGetHotelquery, CancellationToken.None);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Can_GetHotelById()
        {
           
            var GetHotelById = new GetHotelByIdQueryHandler(MockContext.Object);
            var objgetHotelByIdquery = new GetHotelByIdQuery() {hotelId = HotelDataFake.MockSamples()[0].Id };
            var result = await GetHotelById.Handle(objgetHotelByIdquery, CancellationToken.None);
            Assert.Equal(HotelDataFake.MockSamples()[0].Name, result.Name);
        }

        [Fact]
        public async Task CanDelteHotelFromDatabasee()
        {
            var GetHotel = new DeleteHotelByIdCommandHandler(MockContext.Object);
            var objDeletequery = new DeleteHotelByIdCommand() { hotelId = HotelDataFake.MockDeleteHotelByIdCommand().hotelId };
            var result = await GetHotel.Handle(objDeletequery, CancellationToken.None);
            Assert.NotNull(result);
        }
    }
}
