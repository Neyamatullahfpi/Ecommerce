﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Producttypes
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="Product Type")]
        public string Producttype { get; set; }
    }
}
