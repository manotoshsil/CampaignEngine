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
        public CampaignDiscountManager(ICampaignAbstractFactory factory)
        {
            _factory = factory;
        }
        public void ProcessDiscountOnShoppingCartItem(ShoppingCart cart)
        {
           // throw new NotImplementedException();

        }
    }
}
