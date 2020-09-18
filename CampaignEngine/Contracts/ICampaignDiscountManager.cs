
using CampaignEngine.BusinessObjects;
using CampaignEngine.CampaignModels;
using CampaignEngine.DomainObjects;
using System.Collections.Generic;

namespace CampaignEngine.Contracts
{
    public interface ICampaignDiscountManager
    {
        public IEnumerable<BaseCampaignModel> ProcessDiscountOnShoppingCartItem(ShoppingCart cart, CampaignType campaign);
    }
}