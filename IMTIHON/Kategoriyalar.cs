﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMTIHON
{
    public class Kategoriyalar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<Product>products { get; set; }= new List<Product>();
        public List<Attach> Products { get; set; } = new List<Attach>();

    }
}
