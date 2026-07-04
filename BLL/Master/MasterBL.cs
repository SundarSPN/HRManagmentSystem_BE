using BusinessLogicLayer.Helper;
using DataAccessLayer;
using LoggerLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class MasterBL : IMasterBL
    {
        private readonly ILogger _logger;
        public MasterBL(ILogger logger)
        {
                this._logger = logger;
        }
        public HRMResponse<Master> GetMasterData(int listId)
        {
            HRMResponse<Master> _response = new HRMResponse<Master>();
            List<SqlParameter> paramterList = new List<SqlParameter>();
            DataSet ret;
            try
            {
                SqlParameter ListId = new SqlParameter();
                ListId.ParameterName = "@ListId";
                ListId.SqlDbType = SqlDbType.Int;
                ListId.Value = listId;
                ListId.Direction = ParameterDirection.Input;
                paramterList.Add(ListId);

                ret = ADODAL.ExecuteStoredProcedureReturnDataSet("GetMasterListItemsById", paramterList);

                if (ret != null && ret.Tables.Count > 0)
                {
                    if (ret.Tables[0].Rows.Count == 0)
                    {
                        _response.Status = Common.ResponseStatus.ERROR.ToString();
                        _response.Message = "No record found";
                    }
                    else
                    {
                        List<Master> masterDetails = new List<Master>();
                        masterDetails = CommonBehaviour.ConvertDataTableToList<Master>(ret.Tables[0]);
                        _response.ReturnList = masterDetails;
                    }
                }
                else
                {
                    _response.Status = Common.ResponseStatus.ERROR.ToString();
                    _response.Message = "No record found";
                }

            }
            catch (Exception ex)
            {
                _response.Status = Common.ResponseStatus.ERROR.ToString();
                _response.Message = "Error in controller: Master , method: GetMasterData : " + ex.Message.ToString();
                _logger.log(_response.Message, "System");
            }

            return _response;
        }
    }
}
