using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svici.bo2.core.IServices
{
    public interface ILoggerManager
    {
        void LogInfo(string message);

        void LogWarn(string message);

        void LogDebug(string message);

        void LogError(string message);

        void LogRequest(string ActionName, object? message);
        void LogResponse(string ActionName, object? message);
        void LogException(string ActionName, Exception? ex);
    }
}
