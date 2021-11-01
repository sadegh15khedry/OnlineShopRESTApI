﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Models
{
    public class Spec
    {
        public int SpecId { get; set; }

        public int SpecProductId { get; set; }

        public string SpecKey { get; set; }

        public string SpecVlaue { get; set; }
    }
}
