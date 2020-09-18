using CampaignEngine.CampaignModels;
using CampaignEngine.Contracts;
using CampaignEngine.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignEngine.BusinessObjects
{
    public class CampaignDiscountManager : ICampaignDiscountManager
    {
        private readonly ICampaignAbstractFactory _factory;
        private readonly  CampaignType campaign;
        public CampaignDiscountManager(ICampaignAbstractFactory factory)
        {
            _factory = factory;
        }
        public IEnumerable<BaseCampaignModel> ProcessDiscountOnShoppingCartItem(ShoppingCart cart , CampaignType campaign = CampaignType.None)
        {
            IEnumerable<BaseCampaignModel> campaignModel = default ;
            switch (campaign)
            {
                case CampaignType.NItemsBelongingToCampaign:
                    campaignModel = _factory.CreateNItemsDiscountToCampaign();
                    break;
                case CampaignType.FixedPriceComboCampaign:
                    campaignModel = _factory.CreateFixedPriceComboDiscountToCampaign();
                    break;
                case CampaignType.None:
                    break;
                default:
                    break;
            }
            return campaignModel;
        }
    }

    public enum CampaignType
    {
        NItemsBelongingToCampaign,
        FixedPriceComboCampaign,
        None
    }
}
