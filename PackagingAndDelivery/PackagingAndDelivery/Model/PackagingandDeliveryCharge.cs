                                                                                using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackagingAndDelivery.Model
{
    public class PackagingandDeliveryCharge
    {
        public string componentType { get; set; }
        public int packagingCharge { get; set; }
        public int deliveryCharge { get; set; }
        public int protectiveSheath { get; set; }

        //public PackagingandDeliveryCharge(string cType)
        //{
        //    this.componentType = cType;
        //}
    }
}
