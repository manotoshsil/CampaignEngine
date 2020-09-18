using CampaignEngine.DomainObjects;

namespace CampaignEngine.Contracts
{
    public interface ICampaignDiscountHandler
    {

        ICampaignDiscountHandler SetNext(ICampaignDiscountHandler promotionHandler);

        ShoppingCart Handle(ShoppingCart cart);
    }
}