using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UnitTestReflector.Core
{
    public class ClassUnderTest
    {
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public IList<MethodInfo> PublicMethods { get; set; }
        public IList<PropertyInfo> PublicProperties { get; set; }
        public IList<ClassTest> Tests { get; set; }
    }
}
