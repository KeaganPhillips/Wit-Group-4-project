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


            return null;
//                getUniqueClasses(instances.ToList()
//                                     .ToList()
//                                     .ForEach(x => lstClassesUnderTest.Add(getClassUnderTest(x))));

        }



        private static ClassUnderTest getClassUnderTest(IScenario scenario)
        {
            var methods = scenario
                .ClassUnderTest
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => !m.IsSpecialName)
                .Select(x => x.Name);

            return  new ClassUnderTest()
                        {
                            ClassName = scenario.ClassUnderTest.Name,
                            PublicMethods = methods.ToList()
                        };
        }
    }
}
