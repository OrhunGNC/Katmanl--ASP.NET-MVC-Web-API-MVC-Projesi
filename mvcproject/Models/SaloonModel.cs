using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcproject.Models
{
    public class SaloonModel
    {
        public int SaloonNo { get; set; }
        public string SaloonAddress { get; set; }
        public decimal SaloonPrice { get; set; }
        public string PersonelCount { get; set; }   
        public string CustomerCount { get; set; }
        public string SaloonType { get; set; }

    }
}