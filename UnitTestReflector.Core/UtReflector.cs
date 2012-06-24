using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using DemoApp.Tests.Helpers;
using YamlDotNet.RepresentationModel;

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

            var testDescriptions = getTestDescriptions(unitTestAssembly);

            concreteClasses
                .ForEach(x => lstClassesUnderTest.Add(getClassUnderTest(x, testScenarios, testDescriptions)));

            return lstClassesUnderTest;
        }

        private static IDictionary<string, string> getTestDescriptions(Assembly assembly)
        {
            var descriptions = new Dictionary<string, string>();

            // Find all the '.yaml' files in the assembly, and parse the YAML to get the test descriptions
            assembly.GetManifestResourceNames()
                .Where(x => x.EndsWith(".yaml"))
                .ToList()
                .ForEach(x =>
                             {
                                 using (var stream = assembly.GetManifestResourceStream(x))
                                 using (var reader = new StreamReader(stream))
                                 {
                                     var yaml = new YamlStream();
                                     yaml.Load(reader);
                                     var mapping = (YamlMappingNode) yaml.Documents[0].RootNode;

                                     var key = getValueFromNode(mapping, "Test Title");
                                     var val = getValueFromNode(mapping, "Description");
                                     descriptions.Add(key, val);
                                 }
                             });

            return descriptions;
        }

        private static string getValueFromNode(YamlMappingNode mapping, string field)
        {
            return ((YamlScalarNode)mapping
                .Children[mapping.Children.Keys.First(y => y.ToString() == field)])
                .Value;
        }

        private static ClassUnderTest getClassUnderTest(Type concreteClass, IEnumerable<IScenario> testScenarios, IDictionary<string, string> testDescriptions)
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
                           ,Tests = getTests(concreteClass, testScenarios, testDescriptions)
                       };
        }

        
        private static IList<Test> getTests(Type concreteClass, IEnumerable<IScenario> testScenarios, IDictionary<string, string> testDescriptions)
        {
            var lst = new List<Test>();

            var tests =
                testScenarios
                    .Where(x => x.ClassUnderTest == concreteClass)
                    .Select(s => s.GetType().GetCustomAttributes(typeof (TestNameAttribute), false).First())
                    .Distinct()
                    .Select(z => ((TestNameAttribute)z).TestName)
                    .ToList();

            tests.ForEach(t=>
                              {
                                  lst.Add(getSingleTest(t, concreteClass, testScenarios.ToList(), testDescriptions));
                              });

            return lst;
        }

        private static Test getSingleTest(string testName, Type concreteClass, IList<IScenario> scenarios, IDictionary<string, string> testDescriptions)
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
                    .Select(a => new TestScenario()
                                     {
                                         Given = a.GivenDescription,
                                         When = a.WhenDescription,
                                         Description = a.SecnarionDescription,
                                         Then = getThenDescription(a.GetType().GetMethods().Select(m => Attribute.GetCustomAttributes(m, typeof(ThenDescriptionAttribute)).FirstOrDefault()))

                                     });


            return new Test()
                       {
                           Title = testName,
                           Description = testDescriptions.ContainsKey(testName) ? testDescriptions[testName] : string.Empty,
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
