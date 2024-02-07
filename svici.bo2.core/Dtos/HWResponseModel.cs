using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svici.bo2.core.Dtos
{
    public class HWResponseModel
    {
        public HWResponse Response { get; set; }
    }

    public class HWResponse
    {
        public string msg { get; set; }
        public string result { get; set; }
        public string code { get; set; }
        public string nonce_str { get; set; }
        public string sign_type { get; set; }
        public string sign { get; set; }      

    }
}
