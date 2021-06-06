using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;
using System.IO;
using System.Reflection;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest : TestBase
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
        [Description("Check to see if a file exists")]
        [Owner("PaulS")]
        [TestCategory("FDFSDFDFSD")]
        [Ignore]
        public void FileNameDoesExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;
            
            TestContext.WriteLine("Checking file " + _GoodFileName);

            fromCall = fp.FileExists(_GoodFileName);
            
            Assert.IsTrue(fromCall);
        }
        [TestMethod]
        [Description("Check to see if a file does not exist")]
        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_UsingAttribute()
        {
            FileProcess fp = new FileProcess();
            fp.FileExists("");
        }
        [TestMethod]
        public void FileNameNullOrEmpty_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();
            try
            {

                fp.FileExists("");
            }
            catch (ArgumentNullException)
            {

                return;
            }
            Assert.Fail("Call to FileExists() ");
        }
        [TestMethod]
        [Timeout(3000)]
        public void SimulateTimeout()
        {
            System.Threading.Thread.Sleep(4000);
        }
        [TestMethod]
        [DataRow(1,1, DisplayName ="First Test (1,1)")]
        [DataRow(42, 42, DisplayName = "Second Test (42,42)")]
        public void AreNumbersEqual(int num1, int num2)
        {
            Assert.AreEqual(num1, num2);
        }
        [TestMethod]
        [DataRow(@"C:\Windows\Regedit.exe" , DisplayName = "dd")]
        [DataRow("FileDeploy.txt", DisplayName = "Deployment item")]
        public void FileNameUsingDataRow(string fileName)
        {
            FileProcess fp = new FileProcess();
            bool fromCall;
            if (!fileName.Contains(@"\"))
            {
                fileName = TestContext.DeploymentDirectory + @"\" + fileName;

            }
            TestContext.WriteLine("Checking file " + fileName);
            fromCall = fp.FileExists(fileName);
            Assert.IsTrue(fromCall);
        }   
    }
}
