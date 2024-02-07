using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svici.bo2.core.Dtos.GetBalance
{
    public class GetCWBalanceRequest
    {
        public string? cardId { get; set; }

    }

    public class CWBalanceServiceRequest
    {
        public string? cardId { get; set; }
        public string? kbzRefNo { get; set; }

    }
}
