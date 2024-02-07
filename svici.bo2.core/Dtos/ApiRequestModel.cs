using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svici.bo2.core.Dtos
{
    public class ApiRequestModel
    {
        public string LoanType { get; set; }
        public string ReceiverId { get; set; }
        public string NotiType { get; set; }
        //public Dictionary<string,string> NotiParams { get; set; }
        public List<Dictionary<string, string>>? NotiParams { get; set; }
    }
}

