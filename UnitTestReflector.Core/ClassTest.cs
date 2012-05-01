using System.Collections.Generic;

namespace UnitTestReflector.Core
{
    public class ClassTest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<TestScenarion> Scenarios { get; set; }
    }
}