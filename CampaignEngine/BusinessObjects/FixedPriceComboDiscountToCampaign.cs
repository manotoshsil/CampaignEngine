using CampaignEngine.BusinessObjects;
using CampaignEngine.Contracts;
using CampaignEngine.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampaignEngine.CampaignModels
{
    public class FixedPriceComboDiscountToCampaign : BaseCampaignDiscountHandler , IFixedPriceComboDiscountToCampaign
	{
        private readonly ICampaignDiscountManager _campaignDiscountManager;
        public FixedPriceComboDiscountToCampaign(ICampaignDiscountManager campaignDiscountManager)
        {
            _campaignDiscountManager = campaignDiscountManager;
        }
		public override ShoppingCart Handle(ShoppingCart cart)
		{
           var listOfDiscounts= _campaignDiscountManager.ProcessDiscountOnShoppingCartItem(cart, CampaignType.FixedPriceComboCampaign) as List<FixedPriceComboCampaign>;

			foreach (var discount in listOfDiscounts)
			{
				var sKuFirstOfComboCartItem = cart.Items.FirstOrDefault(x => x.Sku == discount.SkuFirstOfCombo && !x.IsBelongsToActiveCampaigns);
				var skuSecondOfComboCartItem = cart.Items.FirstOrDefault(x => x.Sku == discount.SkuSecondOfCombo && !x.IsBelongsToActiveCampaigns);

				if (sKuFirstOfComboCartItem != null && skuSecondOfComboCartItem != null)
				{
					int discountEligibleItemsCount = Math.Min(sKuFirstOfComboCartItem.Quantity, skuSecondOfComboCartItem.Quantity);

					decimal sku1Price = ComputeDiscountedPrice(discountEligibleItemsCount, discount.TotalPrice, sKuFirstOfComboCartItem);
					decimal sku2Price = ComputeDiscountedPrice(discountEligibleItemsCount, discount.TotalPrice, skuSecondOfComboCartItem);
					sKuFirstOfComboCartItem.SetPrice(sku1Price);
					skuSecondOfComboCartItem.SetPrice(sku2Price);
				}

			}
			return base.Handle(cart);
		}

		private static decimal ComputeDiscountedPrice(int discountEligibleItemsCount, decimal discountPrice, ShoppingCartItem cartItem)

		{
			decimal discountedPrice = discountEligibleItemsCount * (discountPrice / 2);
			decimal priceWithoutDiscount = (cartItem.Quantity - discountEligibleItemsCount) * cartItem.UnitPrice;
			return discountedPrice + priceWithoutDiscount;
		}
	}
}
