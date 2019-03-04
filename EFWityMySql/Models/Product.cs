﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFWityMySql.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [DefaultValue("Unknown")]
        [StringLength(50)]        
        public string Name { get; set; }
    }
}