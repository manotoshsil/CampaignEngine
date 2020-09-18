using CampaignEngine.BusinessObjects;
using CampaignEngine.CampaignModels;
using CampaignEngine.Contracts;
using CampaignEngine.DomainObjects;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace CampaignEngine.Tests
{
    public class CampaignScenarios
    {
        private ServiceProvider serviceProvider;
        public CampaignScenarios()
        {
              serviceProvider = new ServiceCollection()
              .AddSingleton<ICampaignEngineManager, CampaignEngineManager>()
              .AddSingleton<ICampaignDiscountHandler, BaseCampaignDiscountHandler>()
              .AddSingleton<ICampaignAbstractFactory, CampaignPolicyFactory>()
              .AddSingleton<ICampaignDiscountManager, CampaignDiscountManager>()
              .AddSingleton<IFixedPriceComboDiscountToCampaign, FixedPriceComboDiscountToCampaign>()
              .AddSingleton<INItemsBelongingToCampaign, INItemsBelongingToCampaign>()
              .BuildServiceProvider();
        }
        [Theory]
        [ClassData(typeof(NoCampaignApplicable_TestScenarioData))]
        public void Given_No_Campaign_Applicable_Then_Engine_Should_return_Net_total(List<(string , decimal , int )> cartItems, decimal total)
        {
            var shoppingCart = new ShoppingCart();
            cartItems.ForEach((parameters) => shoppingCart.AddItemWithPriceAndQuantity(parameters.Item1, parameters.Item2 , parameters.Item3));
            var campaign = serviceProvider.GetService<ICampaignEngineManager>();
            shoppingCart= campaign.Apply(shoppingCart);
            Assert.Equal(total, shoppingCart.GetCartTotal());
        }

        [Theory]
        [ClassData(typeof(NItemsBelongingToCampaign_TestScenarioData))]
        public void Given_N_Items_Belonging_To_Campaign_Are_Added_Then_Engine_Should_Apply_Discount(List<(string, decimal, int)> cartItems, decimal total)
        {
            var shoppingCart = new ShoppingCart();
            cartItems.ForEach((parameters) => shoppingCart.AddItemWithPriceAndQuantity(parameters.Item1, parameters.Item2, parameters.Item3));
            var campaign = serviceProvider.GetService<ICampaignEngineManager>();
            shoppingCart = campaign.Apply(shoppingCart);
            Assert.Equal(total, shoppingCart.GetCartTotal());
        }

        [Theory]
        [ClassData(typeof(FixedPriceForComboCampaign_TestScenarioData))]
        public void Given_Sufficient_items_Belonging_To_Fixed_Price_Combo_Campaign_Are_Added_Then_Engine_Should_Apply_Discount(List<(string, decimal, int)> cartItems, decimal total)
        {
            var shoppingCart = new ShoppingCart();
            cartItems.ForEach((parameters) => shoppingCart.AddItemWithPriceAndQuantity(parameters.Item1, parameters.Item2, parameters.Item3));
            var campaign = serviceProvider.GetService<ICampaignEngineManager>();
            shoppingCart = campaign.Apply(shoppingCart);
            Assert.Equal(total, shoppingCart.GetCartTotal());
        }
    }

    


  

}