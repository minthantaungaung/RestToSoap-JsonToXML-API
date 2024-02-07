using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svici.bo2.core.Dtos
{
    public class BaseResponseModel<T> : AutoConvert where T : class
    {
        public string? KBZRefNo { get; set; }
        public T? Data { get; set; }
        public BaseRespError? Error { get; set; }
    }

    public class BaseRespError
    {
        public string? Code { get; set; }
        public string? Message { get; set; }
        public IList<BaseRespErrorDetail>? Details { get; set; } = new List<BaseRespErrorDetail>();
    }
    public class BaseRespErrorDetail
    {
        public string? ErrorCode { get; set; }
        public string? ErrorDescription { get; set; }
    }

    public class AutoConvert
    {
        public override string ToString() => JsonConvert.SerializeObject(this);
    }

    public class ErrorCodeModel
    {
        public static BaseRespError Timeout { get { return new BaseRespError { Code = "1002", Message = "Timeout error." }; } }
        public static BaseRespError DbQueryTimeout { get { return new BaseRespError { Code = "1002", Message = "Database Query Timeout." }; } }
        public static BaseRespError UnknownException { get { return new BaseRespError { Code = "1004", Message = "Unknown error." }; } }
        public static BaseRespError Maintenance { get { return new BaseRespError { Code = "1005", Message = "Service is in Maintenance mode." }; } }
        public static BaseRespError ForcedUpdate { get { return new BaseRespError { Code = "1006", Message = "Latest version of the app is required to access the API." }; } }
        public static BaseRespError Unauthorized { get { return new BaseRespError { Code = "1000", Message = "Unauthorized." }; } }
        public static BaseRespError NotFoundError { get { return new BaseRespError { Code = "1009", Message = "Target System Not Found." }; } }
        public static BaseRespError ThirdPartyError { get { return new BaseRespError { Code = "1017", Message = "ThirdParty Error!" }; } }
        public static BaseRespError ClientRespError { get { return new BaseRespError { Code = "1016", Message = "ThirdParty Response Error!" }; } }

        public static BaseRespError InvalidRequestPayload { get { return new BaseRespError { Code = "1001", Message = "Invalid Request Payload." }; } }
        public static BaseRespError LoginError { get { return new BaseRespError { Code = "1020", Message = "Application Unauthorized " }; } }
        public static BaseRespError DBError { get { return new BaseRespError { Code = "1015", Message = "Database error." }; } }
        public static BaseRespError NoRecordsFound { get { return new BaseRespError { Code = "1013", Message = "No Records Found!" }; } }
        public static BaseRespError NoRecordsAffect { get { return new BaseRespError { Code = "1012", Message = "No Rows Affected!" }; } }
        public static BaseRespError ValidateError { get { return new BaseRespError { Code = "1001", Message = "Validation error." }; } }
        public static BaseRespError ApplicationUnauthorized { get { return new BaseRespError { Code = "1020", Message = "Application Unauthorized." }; } }
    }
}
