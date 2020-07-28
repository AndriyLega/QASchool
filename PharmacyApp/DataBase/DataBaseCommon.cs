using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.DataBase
{
    public class DataBaseCommon
    {
        private string serverName = "AZHAR.arvixe.com";
        private string dbName = "ForTestDB";
        private string userName = "QAschool";
        private string password = "123456";

        /// <summary>
        /// Method provides and returns connection to DB
        /// </summary>
        /// <returns></returns>
        private SqlConnection SqlConnection()
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=" + serverName + ";Initial Catalog=" + dbName + ";User ID=" + userName + ";Password=" + password + ";Integrated Security =False");
            return sqlCon;
        }

        /// <summary>
        /// Method executed sql query and returns data
        /// </summary>
        /// <param name="sqlFieldName"></param>
        /// <returns></returns>
        protected DataTable ExecuteQuery(string sqlFieldName)
        {
            string script = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "/DataBase", sqlFieldName));
            SqlDataAdapter sqlData = new SqlDataAdapter(script, SqlConnection());
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            return dataTable;
        }
    }

}
