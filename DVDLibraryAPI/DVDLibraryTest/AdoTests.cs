using System;
using NUnit.Framework;
using DVDLibrary.Models;
using DVDLibrary.Controllers;
using DVDLibrary.Factory;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace DVDLibraryTest
{
    [TestFixture]
    public class AdoTests
    {
        [SetUp]
        [TearDown]
        public void Init()
        {
            using SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString) {
                var cmd = new SqlCommand();
                cmd.CommandText = "usp_DBResetData";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = conn;
                conn.Open();

                cmd.ExecuteNonQuery();
        }
    }
}
