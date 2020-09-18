using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace CampaignEngine.Tests
{
    public class CampaignScenarios
    {
        [Theory(Skip = "Ideation Phase [Red]")]
        [ClassData(typeof(NoCampaignApplicable_TestScenarioData))]
        public void Given_No_Campaign_Applicable_Then_Engine_Should_return_Net_total(List<Tuple<string , double , int >> cartItems, Double total)
        {
            var shoppingCart = new ShoppingCart();
            cartItems.ForEach((parameters) => shoppingCart.AddItemWithPriceAndQuantity(parameters.Item1, parameters.Item2 , parameters.Item3));

            shoppingCart = CampaignEngineManager.Apply(shoppingCart);
            Assert.Equal(total, shoppingCart.GetCartTotal());
        }

        [Theory(Skip ="Ideation phase [Red]")]
        [ClassData(typeof(NItemsBelongingToCampaign_TestScenarioData))]
        public void Given_N_Items_Belonging_To_Campaign_Are_Added_Then_Engine_Should_Apply_Discount(List<Tuple<string, double, int>> cartItems, Double total)
        {
            var shoppingCart = new ShoppingCart();
            cartItems.ForEach((parameters) => shoppingCart.AddItemWithPriceAndQuantity(parameters.Item1, parameters.Item2, parameters.Item3));

            shoppingCart = CampaignEngineManager.Apply(shoppingCart);
            Assert.Equal(total, shoppingCart.GetCartTotal());
        }

        [Theory(Skip = "Ideation phase [Red]")]
        [ClassData(typeof(FixedPriceForComboCampaign_TestScenarioData))]
        public void Given_Sufficient_items_Belonging_To_Fixed_Price_Combo_Campaign_Are_Added_Then_Engine_Should_Apply_Discount(List<Tuple<string, double, int>> cartItems, Double total)
        {
            var shoppingCart = new ShoppingCart();
            cartItems.ForEach((parameters) => shoppingCart.AddItemWithPriceAndQuantity(parameters.Item1, parameters.Item2, parameters.Item3));

            shoppingCart = CampaignEngineManager.Apply(shoppingCart);
            Assert.Equal(total, shoppingCart.GetCartTotal());
        }
    }

    


  

}