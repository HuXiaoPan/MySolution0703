﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyModel
{
    public partial class DishInfo
    {
        public int DId { get; set; }
        public string DTitle { get; set; }
        public int DTypeId { get; set; }
        public decimal DPrice { get; set; }
        public string DChar { get; set; }
        public int DIsDelete { get; set; }
        public string DTypeTitle { get; set; }
    }
}
