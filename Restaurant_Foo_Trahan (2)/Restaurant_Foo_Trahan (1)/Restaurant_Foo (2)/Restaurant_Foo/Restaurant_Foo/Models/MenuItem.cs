﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_Foo.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}