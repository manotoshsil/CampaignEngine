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
    public  class BaseCampaignDiscountHandler : ICampaignDiscountHandler
    {
        private  ICampaignDiscountHandler _nextPromotionHandler;

        public virtual ShoppingCart Handle(ShoppingCart cart)
        {
          return  this._nextPromotionHandler != null ?
                 this._nextPromotionHandler.Handle(cart) : cart;
        }

        public ICampaignDiscountHandler SetNext(ICampaignDiscountHandler campaignDiscountHandler)
        {
            this._nextPromotionHandler = campaignDiscountHandler;
            return _nextPromotionHandler;
        }
    }
}
