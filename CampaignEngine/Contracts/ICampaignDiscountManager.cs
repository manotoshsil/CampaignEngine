
using CampaignEngine.DomainObjects;

namespace CampaignEngine.Contracts
{
    public interface ICampaignDiscountManager
    {
        public void ProcessDiscountOnShoppingCartItem(ShoppingCart cart);
    }
}