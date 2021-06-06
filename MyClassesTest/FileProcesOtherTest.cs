using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcesOtherTest : TestBase
    {
        private const string BAD_FILE_NAME = @"C:\xxa.a";
        [ClassInitialize()]
        public static void ClassInitialize(TestContext tc)
        {
            tc.WriteLine("ddad");
        }
        [TestInitialize]
        public void TestInitialize()
        {
            TestContext.WriteLine("fs");
            //WriteDescription(this.GetType());

            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Creating File: " + _GoodFileName);
                    File.AppendAllText(_GoodFileName, "Some Text");
                }
            }
        }
        [TestCleanup]
        public void TestCleanup()
        {
            TestContext.WriteLine("fsfdfs");
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                if (File.Exists(_GoodFileName))
                {
                    TestContext.WriteLine("Deleting file: " + _GoodFileName);
                    File.Delete(_GoodFileName);
                }
            }
        }
        [ClassCleanup()]
        public static void ClassCleanup()
        {

        }
        [TestMethod]
        public void FileNameDoesExistSimpleMessage()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;
            fromCall = fp.FileExists(_GoodFileName);
            Assert.IsFalse(fromCall, "File" + _GoodFileName + " Does Not Exist. ");

        }
        [TestMethod]
        public void AreEqualTest()
        {
            string str1 = "Paul";
            string str2 = "paul";
            Assert.AreEqual(str1, str2, true);

        }
        [TestMethod]
        public void AreNotEqualTest()
        {
            string str1 = "Paul";
            string str2 = "John";
            Assert.AreNotEqual(str1, str2);
        }
        [TestMethod]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.AreNotSame(x, y);

        }
    }
}
