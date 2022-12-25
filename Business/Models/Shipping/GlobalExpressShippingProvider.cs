using Factory_Pattern_First_Look.Business.Models.Commerce;
using System;

namespace Factory_Pattern_First_Look.Business.Models.Shipping
{
    public class GlobalExpressShippingProvider : ShippingProvider
    {
        public override string GenerateShippingLabelFor(Order order) => "GLOBAL-EXPRESS";
    }
}
