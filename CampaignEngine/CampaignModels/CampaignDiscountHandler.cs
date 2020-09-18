using CampaignEngine.Contracts;
using CampaignEngine.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignEngine.CampaignModels
{
    /// <summary>
    /// Implement Chain of Responsibilty base class 
    /// </summary>
    public abstract class BaseCampaignDiscountHandler : ICampaignDiscountHandler
    {
        public ShoppingCart Handle(ShoppingCart cart)
        {
            // throw new NotImplementedException();
            return default;
        }

        public ICampaignDiscountHandler SetNext(ICampaignDiscountHandler promotionHandler)
        {
            // throw new NotImplementedException();
            return default;
        }
    }
}
