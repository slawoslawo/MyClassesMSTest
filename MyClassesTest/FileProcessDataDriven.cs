using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessDataDriven : TestBase
    {
        private const string CONNECT_STRING = "Server=localhost;Database=master;Integrated Security=Yes";
        [TestMethod]
        public void FileExistsTestFromDb()
        {
            FileProcess fp = new FileProcess();
            bool fromCall = false;
            bool testFailed = false;
            string fileName;
            bool expectedValue;
            bool causesException;
            string sql = "SELECT * FROM tests.FileProcessTest";
            string conn = TestContext.Properties["ConnectionString"].ToString();

            LoadDataTable(sql, conn);

            if (TestDataTable != null)
            {
                foreach (DataRow row in TestDataTable.Rows)
                {
                    fileName = row["FileName"].ToString();
                    expectedValue = Convert.ToBoolean(row["ExpectedValue"]);
                    causesException = Convert.ToBoolean(row["CausesException"]);

                    try
                    {
                        fromCall = fp.FileExists(fileName);
                    }
                    catch (ArgumentNullException)
                    {
                        if (!causesException)
                        {
                            testFailed = true;
                        }
                     
                    }
                    catch  (Exception)
                    {
                        testFailed = true;
                    }
                    TestContext.WriteLine("Testing file '{0}' , expected value '{1}' , actual value '{2}', result '{3}'", fileName, expectedValue, fromCall, (expectedValue == fromCall ? "Success" : "FAILED"));

                    if (expectedValue != fromCall)
                    {
                        testFailed = true;
                    }
                }
            }
           
        }
    }
}
