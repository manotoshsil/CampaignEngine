using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignEngine.Tests
{
  public abstract   class BaseTestScenarioData : IEnumerable<object[]>
    {
        protected List<object[]> _data;

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }        

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.IEnumerable)_data).GetEnumerator();
        }
    }
}
