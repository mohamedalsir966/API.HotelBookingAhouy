using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class HotelsResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public List<string> Facilities { get; set; }
        public decimal Price { get; set; }
        public int Rate { get; set; }
        public string ImageUrl { get; set; }
    }
}
