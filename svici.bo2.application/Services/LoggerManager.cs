using svici.bo2.core.IServices;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace svici.bo2.application.Services
{
    public class LoggerManager : ILoggerManager
    {
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoggerManager(ILogger log, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = log;
        }
        private string _KBZRefNo => _httpContextAccessor?.HttpContext?.Items["KBZRefNo"] as string ?? "-";
        public void LogRequest(string ActionName, object? message)
        {
            _logger.Information(
                $"\n" +
                $"CtrlAction: {ActionName}, " +
                $"KbzRefNo : {_KBZRefNo}, " +
                $"Request : {message ?? " - "}\n");
        }

        public void LogResponse(string ActionName, object? message)
        {
            _logger.Information(
                $"\n" +
                $"CtrlAction: {ActionName}, " +
                $"KbzRefNo : {_KBZRefNo}, " +
                $"Response : {message ?? " - "}\n");
        }

        public void LogException(string ActionName, Exception? ex)
        {
            _logger.Error(
                $"\n" +
                $"CtrlAction: {ActionName}, " +
                $"KbzRefNo : {_KBZRefNo}, " +
                $"Exception Msg : {ex?.Message ?? " - "} \n" +
                $"Raw Exception : {JsonConvert.SerializeObject(ex)}\n");
        }

        public void LogDebug(string message)
        {
            _logger.Debug(
                $"\n KbzRefNo : {_KBZRefNo}, Message: {message} \n");
        }

        public void LogError(string message)
        {
            _logger.Error(
                 $"\n KbzRefNo : {_KBZRefNo}, Message: {message} \n");
        }

        public void LogInfo(string message)
        {
            _logger.Information(
               $"\n KbzRefNo : {_KBZRefNo}, Message: {message} \n");
        }

        public void LogWarn(string message)
        {
            _logger.Warning(
                $"\n KbzRefNo : {_KBZRefNo}, Message: {message} \n");
        }
    }
}
