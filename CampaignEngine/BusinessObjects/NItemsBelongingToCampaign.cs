using CampaignEngine.BusinessObjects;
using CampaignEngine.Contracts;
using CampaignEngine.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampaignEngine.CampaignModels
{
    public class NItemsBelongingToCampaign: BaseCampaignDiscountHandler, INItemsBelongingToCampaign
	{
        private readonly ICampaignDiscountManager _campaignDiscountManager;
        public NItemsBelongingToCampaign(ICampaignDiscountManager campaignDiscountManager)
        {
            _campaignDiscountManager = campaignDiscountManager;
        }
		public override ShoppingCart Handle(ShoppingCart cart)
		{
            var listOfDiscounts = _campaignDiscountManager.ProcessDiscountOnShoppingCartItem(cart, CampaignType.NItemsBelongingToCampaign) as List<NItemsDiscountCampaign>;

			foreach (var discount in listOfDiscounts)
			{
				var itemsInPromotionSku =
					cart.Items
						.FirstOrDefault(x => x.Sku == discount.Sku
											 && x.IsBelongsToActiveCampaigns == false);

				if (itemsInPromotionSku != null && itemsInPromotionSku.Quantity >= discount.MandatoryQuantity)
				{

					int itemsWithoutPromotion = itemsInPromotionSku.Quantity % discount.MandatoryQuantity;
					int setOfItemGroupsEligibleForPromotion = itemsInPromotionSku.Quantity / discount.MandatoryQuantity;

					decimal totalPrice = setOfItemGroupsEligibleForPromotion * discount.TotalPrice
									+ itemsWithoutPromotion * itemsInPromotionSku.UnitPrice;

					itemsInPromotionSku.SetPrice(totalPrice);
					itemsInPromotionSku.IsBelongsToActiveCampaigns = true;

				}
			}
			return base.Handle(cart);

		}
    }
}
