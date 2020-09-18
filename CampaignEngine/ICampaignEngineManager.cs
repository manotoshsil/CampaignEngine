using CampaignEngine.DomainObjects;

namespace CampaignEngine
{
    public interface ICampaignEngineManager
    {
        ShoppingCart Apply(ShoppingCart cart);
    }
}