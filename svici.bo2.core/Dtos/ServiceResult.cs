using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svici.bo2.core.Dtos
{
    public class ServiceResult<T> where T : class
    {
        public bool Success { get; set; }
        public BaseResponseModel<T>? apiResponse { get; set; }

        public ServiceResult(BaseResponseModel<T>? apiResponse)
        {
            this.apiResponse = apiResponse;
        }

        //public bool Success { get; set; }
        //public BaseResponseModel<HWResponseModel> apiResponse { get; set; }
    }
}
