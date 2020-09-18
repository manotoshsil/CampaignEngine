using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignEngine.CampaignModels
{
    public class FixedPriceComboCampaign : BaseCampaignModel
    {
        public string SkuFirstOfCombo { get; set; }
        public string SkuSecondOfCombo { get; set; }
    }
}
