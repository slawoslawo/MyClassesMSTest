using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{
    [TestClass]
    public class MyClassesTestInitialization
    {
        [AssemblyInitialize()]
        public static void AssembyInitialize(TestContext tc)
        {
            tc.WriteLine("Text");
        }
        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {

        }
    }
}
