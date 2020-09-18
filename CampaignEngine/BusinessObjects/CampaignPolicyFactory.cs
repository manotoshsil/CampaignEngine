using CampaignEngine.CampaignModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignEngine.BusinessObjects
{
    //Todo: unable to use Dependency injection if i mark it "abstract" .. hence removed "abstract" from class definition
    public class CampaignPolicyFactory : ICampaignAbstractFactory
    {
        public IEnumerable<BaseCampaignModel> CreateFixedPriceComboDiscountToCampaign()
        {
            return new List<FixedPriceComboCampaign>
            {
                new FixedPriceComboCampaign()
                {
                    SkuFirstOfCombo= "C",
                    SkuSecondOfCombo = "D",
                    TotalPrice = 30
                }
            };

           
        }

        public IEnumerable<BaseCampaignModel> CreateNItemsDiscountToCampaign()
        {
          return new  List<NItemsDiscountCampaign>
            {
                new NItemsDiscountCampaign()
                {
                    Sku = "A",
                    MandatoryQuantity = 3,
                    TotalPrice = 130
                },
                new NItemsDiscountCampaign()
                {
                    Sku = "B",
                    MandatoryQuantity = 2,
                    TotalPrice = 45
                }
            };
        }
    }
}
