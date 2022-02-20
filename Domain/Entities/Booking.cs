using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Booking :BaseEntity
    {
        public Guid HotelId { get; set; }
        [ForeignKey(nameof(HotelId))]
        [Required(ErrorMessage = "Hotel Name is required")]
        public string CustomerName { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int RoomNo { get; set; }
        public int NumOfBed { get; set; }
       
    }
}
