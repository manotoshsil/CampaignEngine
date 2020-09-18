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
       
        [Theory]
        [ClassData(typeof(NoCampaignApplicable_TestScenarioData))]
        public void Given_No_Campaign_Applicable_Then_Engine_Should_return_Net_total(List<(string , decimal , int )> cartItems, decimal total)
        {
            var shoppingCart = new ShoppingCart();
            cartItems.ForEach((parameters) => shoppingCart.AddItemWithPriceAndQuantity(parameters.Item1, parameters.Item2 , parameters.Item3));

            shoppingCart = CommonInvoke(shoppingCart);
            Assert.Equal(total, shoppingCart.GetCartTotal());
        }

        [Theory]
        [ClassData(typeof(NItemsBelongingToCampaign_TestScenarioData))]
        public void Given_N_Items_Belonging_To_Campaign_Are_Added_Then_Engine_Should_Apply_Discount(List<(string, decimal, int)> cartItems, decimal total)
        {
            var shoppingCart = new ShoppingCart();
            cartItems.ForEach((parameters) => shoppingCart.AddItemWithPriceAndQuantity(parameters.Item1, parameters.Item2, parameters.Item3));
            shoppingCart = CommonInvoke(shoppingCart);
            Assert.Equal(total, shoppingCart.GetCartTotal());
            Assert.Equal(total, shoppingCart.GetCartTotal());
        }

        [Theory]
        [ClassData(typeof(FixedPriceForComboCampaign_TestScenarioData))]
        public void Given_Sufficient_items_Belonging_To_Fixed_Price_Combo_Campaign_Are_Added_Then_Engine_Should_Apply_Discount(List<(string, decimal, int)> cartItems, decimal total)
        {
            var shoppingCart = new ShoppingCart();
            cartItems.ForEach((parameters) => shoppingCart.AddItemWithPriceAndQuantity(parameters.Item1, parameters.Item2, parameters.Item3));
            shoppingCart = CommonInvoke(shoppingCart);
            Assert.Equal(total, shoppingCart.GetCartTotal());
        }


        private ShoppingCart CommonInvoke(ShoppingCart cart)
        {
            var campaignPolicyFactory = new CampaignPolicyFactory();
            var campaignDiscountManager = new CampaignDiscountManager(campaignPolicyFactory);
            var nItemsBelongingToCampaign = new NItemsBelongingToCampaign(campaignDiscountManager);
            var fixedPriceComboDiscountToCampaign = new FixedPriceComboDiscountToCampaign(campaignDiscountManager);
            var campaign = new CampaignEngineManager(nItemsBelongingToCampaign, fixedPriceComboDiscountToCampaign);
            return campaign.Apply(cart);
        }
    }

    


  

}