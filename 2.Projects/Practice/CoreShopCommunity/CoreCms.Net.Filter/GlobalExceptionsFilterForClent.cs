using CoreCms.Net.Loging;
using CoreCms.Net.Model.ViewModels.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CoreCms.Net.Filter
{
    /// <summary>
    /// 接口全局异常错误日志
    /// </summary>
    ///
    public class GlobalExceptionsFilterForClent : IExceptionFilter   //IExceptionFilter用来处理控制器的方法抛出的异常
    {
        public void OnException(ExceptionContext context)
        {
            NLogUtil.WriteAll(NLog.LogLevel.Error, LogType.Web, "全局异常", "全局捕获异常", context.Exception);

            HttpStatusCode status = HttpStatusCode.InternalServerError;

            //处理各种异常
            var jm = new WebApiCallBack
            {
                status = false,
                code = (int)status,
                msg = "系统返回异常，请联系管理员进行处理！",
                data = context.Exception
            };
            //ExceptionHandled 设置为 true，您告诉 ASP.NET Core 框架已经手动处理了异常，并且不需要再执行其他异常处理逻辑。
            context.ExceptionHandled = true;
            //这一行代码为异常上下文设置了一个新的结果对象。在这里，一个名为 jm 的 WebApiCallBack 对象被用作响应结果。
            context.Result = new ObjectResult(jm);
        }
    }
}