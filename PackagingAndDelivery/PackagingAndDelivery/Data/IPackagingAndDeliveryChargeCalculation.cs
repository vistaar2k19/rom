using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackagingAndDelivery.Data
{
    interface IPackagingAndDeliveryChargeCalculation
    {
        public int totalCharge { get; set; }
        public int TotalChargeCalculation(string cType, int count);
    }
}
