﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptToShop.Models
{
    public class AdopterCreate
    {
        public Guid AdopterId { get; set; }
        public string FullName { get; set; }
        public string Contact { get; set; }
    }
}
