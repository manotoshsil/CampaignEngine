using CampaignEngine.CampaignModels;
using CampaignEngine.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignEngine
{
   public class CampaignEngineManager : ICampaignEngineManager
    {
        private readonly INItemsBelongingToCampaign _nItemsBelongingToCampaign;
        private readonly IFixedPriceComboDiscountToCampaign _fixedPriceComboDiscountToCampaign;
        public CampaignEngineManager(INItemsBelongingToCampaign nItemsBelongingToCampaign, IFixedPriceComboDiscountToCampaign fixedPriceComboDiscountToCampaign )
        {
            _nItemsBelongingToCampaign = nItemsBelongingToCampaign;
            _fixedPriceComboDiscountToCampaign = fixedPriceComboDiscountToCampaign;
        }

        public  ShoppingCart Apply(ShoppingCart cart)
        {

            var rootCampaignDiscount = _nItemsBelongingToCampaign as BaseCampaignDiscountHandler;
            var nextCampaignDiscount = _fixedPriceComboDiscountToCampaign as BaseCampaignDiscountHandler;

           
            rootCampaignDiscount.SetNext(nextCampaignDiscount);
            BaseCampaignDiscountHandler abstractCampaignDiscountHandler = rootCampaignDiscount;

            return abstractCampaignDiscountHandler.Handle(cart);
        }
    }
}
