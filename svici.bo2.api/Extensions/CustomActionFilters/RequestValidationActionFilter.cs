using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using svici.bo2.api.Shared;
using Microsoft.AspNetCore.Http.Extensions;

namespace svici.bo2.api.Extensions.ActionFilters
{
    public class RequestValidationActionFilter : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var _logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<RequestValidationActionFilter>>();
            var request = context.HttpContext.Request;
            context.HttpContext.Request.EnableBuffering();
            context.HttpContext.Request.Headers.TryGetValue("LOGID", out var logId);
            BaseRespModel<object> returndata = new() { Error = new() };
            if (context.Result is BadRequestObjectResult badRequestObjectResult)
                if (badRequestObjectResult.Value is ValidationProblemDetails)
                {
                    returndata.KBZRefNo = logId;
                    returndata.Error = ErrorCode.ValidationError;
                    returndata.Error.Details = new List<BaseRespDetail>();
                    context.Result = new BadRequestObjectResult(returndata);
                }
            _logger.LogInformation($"KBZRefNo :{logId}, {request.Method} {request.GetDisplayUrl()}");
            context.HttpContext.Request.Body.Position = 0;
            base.OnResultExecuting(context);
        }
    }
}
