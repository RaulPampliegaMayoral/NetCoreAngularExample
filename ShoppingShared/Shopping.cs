﻿using System;
using System.Collections.Generic;

namespace ShoppingShared.Models
{
    public class Shopping
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public List<Item> Items { get; set; }
    }
}
