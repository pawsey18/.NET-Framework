using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Types;

namespace DAL
{
    public class DataAccess
    {
        // SqlCommand: a Class that is represented as a sql statement or sproc

        // It has methods for executing commands based on a the value that is needed to return. ExecuteReader =>
        // (DataReader object), ExecuteScalar => ( Single scalar value)
        // ExecuteNonQuery =>(Execute a command that does not return any rows) **Used for CRUD operations.**

        
        // This method helps to reduce code duplication
        private SqlCommand CreateCommand(string cmdText, CommandType cmdType, List<ParmStruct> parms)
        {
            // Create the SQL connection.
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CanoeBuilders"].ConnectionString);
            
            
           // Create the SqlCommand object and pass in the  sql string  along with connection. 
            SqlCommand cmd = new SqlCommand(cmdText, conn);
           
            // Set the command type.
            cmd.CommandType = cmdType;
            // Adding the ParmStruct values for the parameter properties for sqlcommand
            // creating multiple instances of sqlParameter
            if (parms != null)
            {
                foreach (ParmStruct p in parms)
                {
                    cmd.Parameters.Add(p.Name, p.DataType, p.Size).Value = p.Value;
                }
            }

            return cmd;
        }

        // We have a DataSet -> [ Inside is the [Collection of tables, relationships, constraints] ] -
        // A Dataset has 0 or more tables that are represented by DataTable objects. 

        // DataTable objects get used to represent the tables in Datasets. DataTables represents 1 table in memory
        // relational data. This data is then  local on .net apps where it lives.
        
        // It lives in memory, but the data can be populated with the help of DataAdapter.


        public DataTable Execute(string cmdText, CommandType cmdType, List<ParmStruct> parms = null)
        {
            SqlCommand cmd = CreateCommand(cmdText, cmdType, parms);
            DataTable dt = new DataTable();
            // Like here for example.
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        public int ExecuteNonQuery(string cmdText, CommandType cmdType, List<ParmStruct> parms = null)
        {
            SqlCommand cmd = CreateCommand(cmdText, cmdType, parms);

            using (cmd.Connection)
            {
                cmd.Connection.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public object ExecuteScaler(string sql, CommandType cmdType, List<ParmStruct> parms = null)
        {
            SqlCommand cmd = CreateCommand(sql, cmdType, parms);
            object retVal;

            using (cmd.Connection)
            {
                cmd.Connection.Open();
                retVal = cmd.ExecuteScalar();
            }

            return retVal;
        }
    }
}
