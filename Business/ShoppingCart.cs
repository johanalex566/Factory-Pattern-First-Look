using Factory_Pattern_First_Look.Business.Models.Commerce;
using Factory_Pattern_First_Look.Business.Models.Shipping;
using Factory_Pattern_First_Look.Business.Models.Shipping.Factories;

namespace Factory_Pattern_First_Look.Business
{
    public class ShoppingCart
    {
        private readonly Order order;
        private readonly ShippingProviderFactory shippingProviderFactory;

        public ShoppingCart(Order order, ShippingProviderFactory shippingProviderFactory)
        {
            this.order = order;
            this.shippingProviderFactory = shippingProviderFactory;
        }

        public string Finalize()    
        {
            var shippingProvider = shippingProviderFactory.GetShippingProvider(order.Sender.Country);

            order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }
}
