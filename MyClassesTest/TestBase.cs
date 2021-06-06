using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{
    public class TestBase
    {
        public TestContext TestContext { get; set; }
        protected string _GoodFileName;
        public DataTable TestDataTable { get; set; }
        public DataTable LoadDataTable(string sql, string connection)
        {
            TestDataTable = null;
            try
            {
                using (SqlConnection ConnectionObject = new SqlConnection(connection))
                {
                    using (SqlCommand CommandObject = new SqlCommand(sql,ConnectionObject))
                    {
                        using(SqlDataAdapter da = new SqlDataAdapter(CommandObject))
                        {
                            TestDataTable = new DataTable();
                            da.Fill(TestDataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Error in LoadDataTable() method." + Environment.NewLine);
            }
            return TestDataTable;
        }
        protected void SetGoodFileName()
        {
            _GoodFileName = TestContext.Properties["GoodFileName"].ToString();
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

    }
}
