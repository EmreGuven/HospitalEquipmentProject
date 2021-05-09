using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Equipment:IEntity
    {
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public DateTime SupplyDate { get; set; }
        public int UnitInStock { get; set; }
        public double UnitPrice { get; set; }
        public double UsageRate { get; set; }
    }
}
