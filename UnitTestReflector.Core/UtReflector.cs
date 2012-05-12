using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using DemoApp.Tests.Helpers;

namespace UnitTestReflector.Core
{
    public class UtReflector
    {
        public static IList<ClassUnderTest> Get()
        {
            var unitTestAssembly = Assembly.GetAssembly(typeof(IScenario));
            var instances = from t in unitTestAssembly.GetTypes()
                            where t.GetInterfaces().Contains(typeof(IScenario))
                                     && t.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(t) as IScenario;

            var lstClassesUnderTest = new List<ClassUnderTest>();
            instances
                .ToList()
                .ForEach(x=> lstClassesUnderTest.Add(getClassUnderTest(x)));


            return lstClassesUnderTest;
        }

        private static ClassUnderTest getClassUnderTest(IScenario scenario)
        {
            return  new ClassUnderTest()
                        {
                            ClassName = scenario.ClassUnderTest.Name
                        };
        }
    }
}
