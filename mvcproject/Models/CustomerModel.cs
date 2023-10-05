using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcproject.Models
{
    public class CustomerModel
    {
        public int CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string MembershipType { get; set; }
        public DateTime MembershipEnding { get; set; }
        public decimal AnnualFee { get; set; }
    }
}