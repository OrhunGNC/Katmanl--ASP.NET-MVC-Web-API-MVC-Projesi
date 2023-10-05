using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcproject.Models
{
    public class EquipmentModel
    {
        public int EquipmentNo { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentType { get; set; }
        public string EquipmentCount { get; set; }
        public decimal EquipmentPrice { get; set; }
    }
}