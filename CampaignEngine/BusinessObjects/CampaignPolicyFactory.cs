using CampaignEngine.CampaignModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignEngine.BusinessObjects
{
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
