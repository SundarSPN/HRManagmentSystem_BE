using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerLayer
{
    public  class Logger:ILogger
    {
        public  void log(string errorMessage,string createdBy)
        {
            List<SqlParameter> paramterList = new List<SqlParameter>();
            int ret;
            try
            {
                SqlParameter LogDesc = new SqlParameter();
                LogDesc.ParameterName = "@LogDesc";
                LogDesc.SqlDbType = SqlDbType.VarChar;
                LogDesc.Value = errorMessage;
                LogDesc.Direction = ParameterDirection.Input;
                paramterList.Add(LogDesc);


                SqlParameter CreatedBy = new SqlParameter();
                CreatedBy.ParameterName = "@CreatedBy";
                CreatedBy.SqlDbType = SqlDbType.VarChar;
                CreatedBy.Size = 50;
                CreatedBy.Value = createdBy;
                CreatedBy.Direction = ParameterDirection.Input;
                paramterList.Add(CreatedBy);

                SqlParameter LogId = new SqlParameter();
                LogId.ParameterName = "@LogId";
                LogId.SqlDbType = SqlDbType.Int;
                LogId.Size = -1;
                LogId.Value = 0;
                LogId.Direction = ParameterDirection.Output;
                paramterList.Add(LogId);

                ret = ADODAL.ExecuteNonQueryWithOutParam("InsertErrorLog", paramterList);

            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
    }
}
