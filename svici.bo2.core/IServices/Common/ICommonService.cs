using svici.bo2.core.Data.XML_Dto;
using svici.bo2.core.Dtos;
using svici.bo2.core.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svici.bo2.core.IServices.Common
{
    public interface ICommonService
    {
        Task<ServiceResult<object>> SoapGetCardInfoAsync(string cardNumber, string KbzRefNo);  
    }
}
