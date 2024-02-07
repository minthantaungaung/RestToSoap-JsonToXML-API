using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using svici.bo2.api.Extensions.ActionFilters;
using svici.bo2.core.Data;
using svici.bo2.core.IServices;
using Microsoft.Extensions.Options;
using svici.bo2.api.Shared;
using svici.bo2.core.Data.XML_Dto;
using System.Text;
using System.Xml.Linq;
using static svici.bo2.api.Extensions.XmlSerializerExtension;
using svici.bo2.core.IServices.Common;
using svici.bo2.core.Dtos.Common;
using svici.bo2.core.Dtos.GetBalance;
using svici.bo2.core.Data.XML_Dto.storeApplicationResponse;
using svici.bo2.core.Data.XML_Dto.storeApplicationRequest;

namespace svici.bo2.api.Controllers
{
    [Route("api/common/")]
    [ServiceFilter(typeof(GetKbzRefNoNTokenActionFilter))]
    [ServiceFilter(typeof(RequestValidationActionFilter))]
    [ApiController]
    public class CommonSvController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly ThirdPartySettings _3rdPartySettings;
        //private readonly ICommonService _service;
        public CommonSvController(ILoggerManager logger, /*ICommonService commonService, */IOptions<ThirdPartySettings> thirdPartySettings)
        {
            _logger = logger;
            //_service = commonService;
            _3rdPartySettings = thirdPartySettings.Value;
        }

        [HttpPost("btrt", Name = "storeApplicaion")]
        public async Task<IActionResult> storeApplicaion(StoreApplicationRequest req)
        {
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            string? KbzRefNo = HttpContext.Items["KBZRefNo"] as string;
            _logger.LogRequest(actionName, req);

            RequestEnvelope<StoreApplicationRequestDto> requestEnvelop = new();
            BaseRespModel<StoreApplicationResponse> response = new() { KBZRefNo = KbzRefNo };

            requestEnvelop.Header!.Security.UsernameToken.Username = _3rdPartySettings.username;
            requestEnvelop.Header!.Security.UsernameToken.Password!.Value = _3rdPartySettings.password;
            requestEnvelop.Body = new() { application =  req };
            var data = SerializeToXml(requestEnvelop);

            _logger.LogRequest("storeApplicaion", data);

            HttpClient client = new HttpClient();
            var httpContent = new StringContent(data, Encoding.UTF8, "text/xml");
            var svResponse = await client.PostAsync(_3rdPartySettings.SoapServiceUrl, httpContent);

            string rawResp = await svResponse.Content.ReadAsStringAsync();
            _logger.LogResponse("storeApplicaion", rawResp);

            if (svResponse.IsSuccessStatusCode)
            {
                try
                {
                    var parsedData = DeserializeXml<ResponseEnvelope<StoreApplicationResponse>>(rawResp);
                    
                    if (string.IsNullOrWhiteSpace(parsedData?.Body?.ApplicationId))
                    {
                        //Function to Error Message Here 
                        // ....
                        response.Error = ErrorCode.ThirdPartyRespError;
                        _logger.LogResponse(actionName, response);
                        return BadRequest(response);
                    }                    
                    response.Data = parsedData.Body;
                    _logger.LogResponse(actionName, response);
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    _logger.LogException(actionName, ex);
                    response.Error = ErrorCode.UnknownExceptionSystem;
                    return BadRequest(response);
                }
            }
            else
            {
                string errorCode = XDocument.Parse(rawResp).Descendants("faultcode").FirstOrDefault()?.Value;
                string errorDesc = XDocument.Parse(rawResp).Descendants("faultstring").FirstOrDefault()?.Value;

                response.Error = ErrorCode.ThirdPartyRespError;
                response.Error.Details!.Add(new() { ErrorCode = errorCode, ErrorDescription = errorDesc });
                _logger.LogResponse(actionName, response);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
