using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections;

namespace DataAccessLayer
{
    public class ADODAL
    {
        public static int ExecuteNonQueryWithOutParam(string procedureName, List<SqlParameter> paramterList)
        {
            int returnval=0;
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                using (var command = sqlConnection.CreateCommand())
                {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = procedureName;
                        if (paramterList != null)
                        {
                            command.Parameters.AddRange(paramterList.ToArray());
                        }
                    sqlConnection.Open();
                    returnval=command.ExecuteNonQuery();
                    foreach (SqlParameter sparam in paramterList)
                    {
                        if (sparam.Direction == ParameterDirection.Output)
                        {
                            sparam.Value = command.Parameters[sparam.ParameterName].Value.ToString();
                        }
                    }
                }
            }
            return returnval;
        }
        public static DataSet ExecuteStoredProcedureReturnDataSet(string procedureName, List<SqlParameter> paramterList)
        {
            DataSet dataSet = new DataSet();
            string connectionString= ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                using (var command = sqlConnection.CreateCommand())
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = procedureName;
                        if (paramterList != null)
                        {
                            command.Parameters.AddRange(paramterList.ToArray());
                        }

                        sda.Fill(dataSet);
                    }
                }
            }
            return dataSet;
        }
    }
}
