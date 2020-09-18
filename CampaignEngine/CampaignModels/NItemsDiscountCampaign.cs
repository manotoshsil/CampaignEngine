using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignEngine.CampaignModels
{
   public class NItemsDiscountCampaign : BaseCampaignModel
    {
        public string Sku { get; set; }
        public int MandatoryQuantity { get; set; }
    }
}
