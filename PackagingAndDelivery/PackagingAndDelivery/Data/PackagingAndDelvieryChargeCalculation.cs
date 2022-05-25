using PackagingAndDelivery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackagingAndDelivery.Data
{
    public class PackagingAndDelvieryChargeCalculation : IPackagingAndDeliveryChargeCalculation
    {
        public int totalCharge { get ; set ; }

        public int TotalChargeCalculation(string cType, int count)
        {
            List<PackagingandDeliveryCharge> packagingCharges = new List<PackagingandDeliveryCharge>
            {
                new PackagingandDeliveryCharge {componentType="Integral", packagingCharge =100, deliveryCharge= 200, protectiveSheath=50 },
                new PackagingandDeliveryCharge {componentType="Accessory", packagingCharge =50, deliveryCharge= 100, protectiveSheath=50 }
            };

            foreach(var temp in packagingCharges)
            {
                if(temp.componentType.Equals(cType))
                {                
                    totalCharge = count * (temp.packagingCharge + temp.deliveryCharge + temp.protectiveSheath);
                }
            }

            return totalCharge;
        }
    }
}
