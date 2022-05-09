using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FacilitesHotel :BaseEntity
    {
        public Guid hotelId { get; set; }
        public Guid FacilitiesId { get; set; }
        public  Facilities facilities { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
