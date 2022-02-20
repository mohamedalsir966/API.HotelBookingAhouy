using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum Facilities
    {
       [Description("Breakfast")]
        Breakfast=1,
        Wifi=2,
        Parking=3,
        Spa=4
    }
}
