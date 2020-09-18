using System.Collections.Generic;

namespace CampaignEngine.Tests
{
    public class FixedPriceForComboCampaign_TestScenarioData : BaseTestScenarioData
    {

        public FixedPriceForComboCampaign_TestScenarioData()
        {
            base._data = new List<object[]>
            {
                new object[] { new List<(string, decimal, int)> { ("C" , 20M , 1), ("D", 25M,1) }, 30M },
                
            };
        }
    }
}