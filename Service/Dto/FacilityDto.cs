using Service.Dto.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class FacilityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class FacilityRespnse : BaseResponse
    {
         public FacilityDto Data { get; set; }
    }
    public class FacilitesRespnse : BaseResponse
    {
        public List< FacilityDto> Data { get; set; }
    }
}
