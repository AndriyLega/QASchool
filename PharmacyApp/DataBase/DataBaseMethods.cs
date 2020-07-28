using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.DataBase
{
    public class DataBaseMethods : DataBaseCommon
    {
        #region Pharmacies table

        public int GetCountOfPharmacies()
        {
            int count = 0;
            DataTable data = ExecuteQuery("GetAllPharmacies.sql");
            foreach (DataRow row in data.Rows)
            {
                count++;
            }
            return count;
        }

        public string GetNameOfLastAddedPharmacy()
        {
            string name = "";
            DataTable data = ExecuteQuery("GetTheLastAddedPharmacy.sql");
            foreach (DataRow row in data.Rows)
            {
                name = row["Name"].ToString();
            }
            return name;
        }

        public SortedDictionary<string, string> GetPharmaciesNameAndDescription()
        {
            SortedDictionary<string, string> namesAndDescriptions = new SortedDictionary<string, string>();
            DataTable data = ExecuteQuery("GetAllPharmacies.sql");
            foreach (DataRow row in data.Rows)
            {
                namesAndDescriptions.Add(row["Name"].ToString(), row["Description"].ToString());
            }
            return namesAndDescriptions;
        }

        #endregion
    }
}
