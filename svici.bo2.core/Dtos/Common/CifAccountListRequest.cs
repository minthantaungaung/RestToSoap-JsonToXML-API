using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svici.bo2.core.Dtos.Common
{
    public class CifAccountListRequest
    {
        public string cardNumber { get; set; }
        public string encPinBlock { get; set; }
        public string cvv2 { get; set; }
    }
}
