﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9.Models
{
    public class FoodModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }

        public string CategoryName { get; set; }

        public int Price { get; set; }

        public  string Notes { get; set; }
    }
}
