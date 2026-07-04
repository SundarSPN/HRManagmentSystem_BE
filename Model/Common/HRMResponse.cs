using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class HRMResponse<T> where T : class
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<T> ReturnList { get; set; }
   
        public HRMResponse()
        {
            Status = Common.ResponseStatus.SUCCESS.ToString();
            Message = String.Empty;
        }
    }
}