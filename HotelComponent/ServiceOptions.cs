using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelComponent
{
    public class ServiceOptions
    {
        public int HotelID { get; set; }
        public string ServiceType { get; set; }
        public bool IsSelected { get; set; }
        public int ServicePrice { get; set; }
    }
}
