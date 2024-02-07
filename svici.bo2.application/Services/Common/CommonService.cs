using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using svici.bo2.core.Data;
using svici.bo2.core.Dtos;
using svici.bo2.core.IServices;
using svici.bo2.core.IServices.Common;

namespace svici.bo2.application.Services.Common
{
    public class CommonService : ICommonService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ThirdPartySettings _3rdPartySettings;
        private readonly ILoggerManager _logger;

        public CommonService(IHttpClientFactory httpClientFactory, ILoggerManager logger, IOptions<ThirdPartySettings> thirdPartySettings)
        {
            _httpClientFactory = httpClientFactory;
            _3rdPartySettings = thirdPartySettings.Value;
            _logger = logger;
        }
        public async Task<ServiceResult<object>> SoapGetCardInfoAsync(string cardNumber, string KbzRefNo)
        {
            throw new NotImplementedException();
        }
    }
}
