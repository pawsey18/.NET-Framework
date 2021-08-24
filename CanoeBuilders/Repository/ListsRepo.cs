using DAL;
using Model.Lookups;
using System;
using System.Collections.Generic;
using System.Data;

namespace Repository
{
    public class ListsRepo
    {
        public List<BuilderLookup> RetrieveBuilderList()
        {
            string sql = "select * from Builder";
            DataAccess da = new DataAccess();
            DataTable dt = da.Execute(sql, CommandType.Text);

            List<BuilderLookup> listBuilders = new List<BuilderLookup>();

            foreach (DataRow row in dt.Rows)
            {
                listBuilders.Add(
                       new BuilderLookup()
                       {
                           BuilderID = Convert.ToInt32(row["BuilderID"].ToString()),
                           FirstName = row["FirstName"].ToString()
                       }
                    );
            }
            return listBuilders;
        }
    }
}
