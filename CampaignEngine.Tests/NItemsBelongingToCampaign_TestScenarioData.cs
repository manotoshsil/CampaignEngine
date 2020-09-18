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
                new object[] { new List<(string, double, int)> { ("A" , 50 , 5), ("B", 30, 5), ("C", 20, 1) }, 370 },
                new object[] { new List<(string, double, int)> { ("A", 40, 3), ("B", 20, 2) },  175 }
            };
        }
    }
}
