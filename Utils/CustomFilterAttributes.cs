using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Filters.Utils
{
    public class CustomFilterAttributes : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var ipAddr = context.HttpContext.Connection.RemoteIpAddress.ToString();
            var page = (PageResult)context.Result;
            page.ViewData["filterMessage"] = ipAddr;
            await next.Invoke();
        }
    }
}
