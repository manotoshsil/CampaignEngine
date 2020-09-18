using CampaignEngine.CampaignModels;
using System.Collections.Generic;

namespace CampaignEngine.BusinessObjects
{
    public interface ICampaignAbstractFactory
    {
        IEnumerable<BaseCampaignModel> CreateNItemsDiscountToCampaign();
        IEnumerable<BaseCampaignModel> CreateFixedPriceComboDiscountToCampaign();
    }
}