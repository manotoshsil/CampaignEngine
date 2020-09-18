using System.Collections.Generic;

namespace CampaignEngine.Tests
{
    public class FixedPriceForComboCampaign_TestScenarioData : BaseTestScenarioData
    {

        public FixedPriceForComboCampaign_TestScenarioData()
        {
            base._data = new List<object[]>
            {
                new object[] { new List<(string, double, int)> { ("C" , 20 , 1), ("D", 15,1) }, 20 },
                
            };
        }
    }
}