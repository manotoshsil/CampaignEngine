using CampaignEngine.CampaignModels;

namespace CampaignEngine.BusinessObjects
{
    public interface ICampaignAbstractFactory
    {
        BaseCampaignModel CreateNItemsDiscountToCampaign();
        BaseCampaignModel CreateFixedPriceComboDiscountToCampaign();
    }
}