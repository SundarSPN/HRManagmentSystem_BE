using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRM.RestService.Helper
{
    public class HRMResponse<T> where T : class
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T ReturnObject { get; set; }
        //public HRMResponse(Common.ResponseStatus _resStatus,String _message,T _retObj)
        //{
        //    Status = _resStatus.ToString();
        //    Message = _message;
        //    ReturnObject = _retObj;
        //}
        public HRMResponse()
        {
            Status = Common.ResponseStatus.Success.ToString();
            Message = String.Empty;
        }
    }
}