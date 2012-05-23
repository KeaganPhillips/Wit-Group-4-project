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
            var lstClassesUnderTest = new List<ClassUnderTest>();

            var unitTestAssembly = Assembly.GetAssembly(typeof(IScenario));
            var testScenarios = from t in unitTestAssembly.GetTypes()
                            where t.GetInterfaces().Contains(typeof(IScenario))
                                     && t.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(t) as IScenario;

            var concreteClasses = testScenarios
                .Select(x => x.ClassUnderTest)
                .Distinct()
                .ToList();

            concreteClasses
                .ForEach(x=> lstClassesUnderTest.Add( getClassUnderTest(x, testScenarios)) );

            return lstClassesUnderTest;
        }

        private static ClassUnderTest getClassUnderTest(Type concreteClass, IEnumerable<IScenario> testScenarios)
        {
            var methodsToExclude = new[] {"ToString", "GetType", "Equals", "GetHashCode"};

            return new ClassUnderTest()
                       {
                           ClassName = concreteClass.Name,
                           PublicProperties = concreteClass
                               .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                               .Select(x => x.Name)
                               .ToList(),
                           PublicMethods = concreteClass
                               .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                               .Where(m => !m.IsSpecialName &&  !methodsToExclude.Contains(m.Name) )
                               .Select(x => x.Name)
                               .ToList()
                           ,Tests = getTests(concreteClass, testScenarios)
                       };
        }

        
        private static IList<ClassTest> getTests(Type concreteClass, IEnumerable<IScenario> testScenarios)
        {
            var lst = new List<ClassTest>();

            var tests =
                testScenarios
                    .Where(x => x.ClassUnderTest == concreteClass)
                    .Select(s => s.GetType().GetCustomAttributes(typeof (TestNameAttribute), false).First())
                    .Distinct()
                    .Select(z => ((TestNameAttribute)z).TestName)
                    .ToList();

            tests.ForEach(t=>
                              {
                                  lst.Add(getSingleTest(t, concreteClass, testScenarios.ToList()));
                              });

            return lst;
        }

        private static ClassTest getSingleTest(string testName, Type concreteClass, IList<IScenario> scenarios)
        {
            var testScenarions =
                scenarios
                    .Where(x => x.ClassUnderTest == concreteClass)
                    .Where(s =>
                               {
                                   var obj =
                                       s.GetType().GetCustomAttributes(typeof (TestNameAttribute), false).First() as
                                       TestNameAttribute;
                                   return obj.TestName == testName;
                               })
                    .ToList()
                    .Select(a => new TestScenarion()
                                     {
                                         Given = a.GivenDescription,
                                         When = a.WhenDescription,
                                         Description = a.SecnarionDescription,
                                         Then = getThenDescription(a.GetType().GetMethods().Select(m => Attribute.GetCustomAttributes(m, typeof(ThenDescriptionAttribute)).FirstOrDefault()))

                                     });


            return new ClassTest()
            {
                Title = testName,
                Scenarios = testScenarions.ToList() 
            };
        }

        private static string getThenDescription(IEnumerable<Attribute> attributeses)
        {
            var thenDecriptions =
                attributeses.Select(x => x as ThenDescriptionAttribute)
                    .Where(z => z != null)
                    .Select(y => y.Description)
                    .ToList();


            if (thenDecriptions.Count == 0)
                return string.Empty;

            if (thenDecriptions.Count == 1)
                return thenDecriptions.First();

            var sb = new StringBuilder();
            sb.Append(thenDecriptions[0]);
            for (var i = 1; i < thenDecriptions.Count; i++)
                sb.AppendFormat("{0}And {1}", Environment.NewLine, thenDecriptions[i]);

            return sb.ToString();
        }
    }
}
