using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignEngine.Tests
{
    public class NItemsBelongingToCampaign_TestScenarioData : BaseTestScenarioData
    {

        public NItemsBelongingToCampaign_TestScenarioData()
        {
            base._data = new List<object[]>
            {
                new object[] { new List<(string, decimal, int)> { ("A" , 50M , 5), ("B", 30M, 5), ("C", 20M, 1) }, 370M },
                new object[] { new List<(string, decimal, int)> { ("A", 40M, 3), ("B", 20M, 2) },  175M }
            };
        }
    }
}
