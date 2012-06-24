using System.Collections.Generic;

namespace UnitTestReflector.Core
{
    public class Test
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<TestScenario> Scenarios { get; set; }
    }
}