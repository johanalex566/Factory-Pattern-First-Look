using Factory_Pattern_First_Look.Business.Models.Commerce;
using Factory_Pattern_First_Look.Business.Models.Shipping;
using Factory_Pattern_First_Look.Business.Models.Shipping.Factories;

namespace Factory_Pattern_First_Look.Business
{
    public class ShoppingCart
    {
        private readonly Order order;
        private readonly IPurchaseProviderfactory purchaseProviderfactory;

        public ShoppingCart(Order order, IPurchaseProviderfactory purchaseProviderfactory)
        {
            this.order = order;
            this.purchaseProviderfactory = purchaseProviderfactory;
        }

        public string Finalize()    
        {
            var shippingProvider = purchaseProviderfactory.CreateShippingProvider(order);

            var invoice = purchaseProviderfactory.CreateInvoice(order);

            // Send invoice...

            var summary = purchaseProviderfactory.CreateSummary(order);

            summary.Send();

            order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }
}
