using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyClassesTest
{
    [TestClass]
    public class StringAssertClassTest : TestBase
    {
        [TestMethod]
        public void ContainsTest()
        {
            string str1 = "Steve Nystrom";
            string str2 = "Nystrom";

            StringAssert.Contains(str1, str2);

        }
        [TestMethod]
        public void StartsWith()
        {
            string str1 = "All Lower case";
            string str2 = "All Lower";

            StringAssert.StartsWith(str1, str2);
        }
        [TestMethod]
        public void IsAllLowerCaseTest()
        {
            Regex x = new Regex(@"^([^A-Z])+$");
            StringAssert.Matches("all lower case", x);
        }
        [TestMethod]
        public void IsNotAllLowerCaseTest()
        {
            Regex x = new Regex(@"^([^A-Z])+$");
            StringAssert.DoesNotMatch("All Lower Case", x);
        }
    }
}
