using System.Collections;
using System.Collections.Generic;

namespace CampaignEngine.Tests
{
    public class NoCampaignApplicable_TestScenarioData : BaseTestScenarioData
    {

        public NoCampaignApplicable_TestScenarioData()
        {
            base._data = new List<object[]>
            {
                new object[] { new List<(string, decimal, int)> { ("A" , 50M , 1), ("B", 30M, 1), ("C", 10M, 1) }, 90M },
                new object[] { new List<(string, decimal, int)> { ("B" , 40M , 1), ("C", 20M, 1), ("D", 15M, 1) }, 75M }
            };
        }

    }

}