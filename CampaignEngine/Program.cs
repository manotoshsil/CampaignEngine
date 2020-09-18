using CampaignEngine.BusinessObjects;
using CampaignEngine.CampaignModels;
using CampaignEngine.Contracts;
using CampaignEngine.DomainObjects;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CampaignEngine
{
    class Program
    {

        public static void Main(string[] args)
        {
           
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ICampaignEngineManager, CampaignEngineManager>()
                .AddSingleton<ICampaignDiscountHandler, BaseCampaignDiscountHandler>()
                .AddSingleton<ICampaignAbstractFactory, CampaignPolicyFactory>()
                .AddSingleton<ICampaignDiscountManager, CampaignDiscountManager>()
                .AddSingleton<IFixedPriceComboDiscountToCampaign, FixedPriceComboDiscountToCampaign>()
                .AddSingleton<INItemsBelongingToCampaign, NItemsBelongingToCampaign>()
                .BuildServiceProvider();


            var campaign = serviceProvider.GetService<ICampaignEngineManager>();
            var cart = new ShoppingCart();
            cart.AddItemWithPriceAndQuantity("A", 50M, 3);
            cart.AddItemWithPriceAndQuantity("B", 30M, 5);
            cart.AddItemWithPriceAndQuantity("C", 20M, 1);
            cart.AddItemWithPriceAndQuantity("D", 15M, 1);
            var shoppingCart = campaign.Apply(cart);
            if (shoppingCart != null)
            {
                Console.WriteLine( shoppingCart.GetCartTotal());
            }


        }
    }
}
