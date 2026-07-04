using BusinessLogicLayer;
using LoggerLayer;
using Model;
using System;
using System.Web.Http;

namespace HRM.RestService.Controllers
{
    public class MasterController : ApiController
    {
        private IMasterBL _masterBLL;
        private ILogger _logger;
        public MasterController(IMasterBL masterBL,ILogger logger)
        {
            this._masterBLL = masterBL;// new MasterBL();
            this._logger = logger;
        }

        [Route("api/Master/GetMasterData/{id:int}")]
        [HttpGet]
        public HRMResponse<Master> GetMasterData(int id)
        {
            HRMResponse<Master> _response = new HRMResponse<Master>();
            try
            {
                _response = _masterBLL.GetMasterData(id);
            }
            catch (Exception ex)
            {
                _response.Status = Common.ResponseStatus.ERROR.ToString();
                _response.Message = "Error in controller: Master:GetMasterData : " + ex.Message.ToString();
                _logger.log(_response.Message, "");
            }
            return _response;
        }
    }
}