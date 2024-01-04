﻿using BalkonyEntity.Poco.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyEntity.Poco
{
    public class Order:BaseEntity
    {
        public string Title { get; set; }
        public double Cost { get; set; }
        public Customer Customer { get; set; }
    }
}
