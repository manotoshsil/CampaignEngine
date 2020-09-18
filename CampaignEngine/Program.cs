using CampaignEngine.CampaignModels;
using CampaignEngine.Contracts;
using CampaignEngine.DomainObjects;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CampaignEngine
{
    class Program
    {
        private static ServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            Console.WriteLine("Campaing Engine Initiated ");
            RegisterServices();

            var cart = new ShoppingCart();
            cart.AddItemWithPriceAndQuantity("A", 50M, 3);
            cart.AddItemWithPriceAndQuantity("B", 30M, 5);
            cart.AddItemWithPriceAndQuantity("C", 20M, 1);
            cart.AddItemWithPriceAndQuantity("D", 15M, 1);

            var c = CampaignEngineManager.Apply(cart);
            if (c != null)
            {
                var finalPrice = c.GetCartTotal();
            }
            DisposeServices();
        }
        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ICampaignDiscountHandler, BaseCampaignDiscountHandler>();
            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }

    }
}
