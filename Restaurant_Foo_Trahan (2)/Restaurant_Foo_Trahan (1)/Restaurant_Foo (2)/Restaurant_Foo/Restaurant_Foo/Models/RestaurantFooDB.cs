using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Restaurant_Foo.Models
{
    public class RestaurantFooDB : DbContext
    {
        public RestaurantFooDB() : base("name=DefaultConnection")
        {

        }
        
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ReservationSlot> ReservationSlots { get; set; }
    }
}