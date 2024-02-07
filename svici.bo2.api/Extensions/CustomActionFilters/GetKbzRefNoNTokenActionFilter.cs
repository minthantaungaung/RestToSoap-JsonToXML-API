using Microsoft.AspNetCore.Mvc.Filters;

namespace svici.bo2.api.Extensions.ActionFilters
{
    public class GetKbzRefNoNTokenActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string kbzRefNo = context.HttpContext.Request.Headers.TryGetValue("KBZ_REF_NO", out var refno) ? refno : context.HttpContext.Request.Headers["LOGID"];
            context.HttpContext.Items.Add("KBZ_REF_NO", kbzRefNo);
        }
        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
