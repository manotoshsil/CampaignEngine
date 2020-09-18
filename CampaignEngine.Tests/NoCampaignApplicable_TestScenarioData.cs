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
                new object[] { new List<(string, decimal, int)> { ("A" , 50 , 1), ("B", 30, 1), ("C", 10, 1) }, 90 },
                new object[] { new List<(string, decimal, int)> { ("B" , 40 , 1), ("C", 20, 1), ("D", 15, 1) }, 75 }
            };
        }

    }

}