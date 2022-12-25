using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Factory_Pattern_First_Look.Business.Models.Purchase
{

    //A Factory of factories

    public class PurchaseProviderFactoryProvider
    {

        private IEnumerable<Type> factories;

        public PurchaseProviderFactoryProvider()
        {
            factories = Assembly.GetAssembly(typeof(PurchaseProviderFactoryProvider))
                .GetTypes()
                .Where(t => typeof(IPurchaseProviderfactory).IsAssignableFrom(t));
        }

        public IPurchaseProviderfactory CreateFactoryFor(string name)
        {

            var factory = factories.Single(x =>
            x.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));

            return (IPurchaseProviderfactory)Activator.CreateInstance(factory);

        }

    }
}
