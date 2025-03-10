using Microsoft.AspNetCore.Mvc.Filters;

namespace SmartFactoryApi.Utility.Filter
{
    public class CustomAlwaysOnResultFilterAttribute : Attribute, IAsyncAlwaysRunResultFilter
    {

        /// <summary>
        /// 解决跨域的具体方案
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            context.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            await next.Invoke();
        }
    }
}
