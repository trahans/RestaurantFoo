using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_Foo.Models
{
    public class ReservationSlot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string NumberOfGuests { get; set; }
        public string EmailAddress { get; set; }
    }
}