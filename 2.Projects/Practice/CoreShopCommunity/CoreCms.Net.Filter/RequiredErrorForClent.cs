using CoreCms.Net.Model.ViewModels.Basics;
using CoreCms.Net.Model.ViewModels.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace CoreCms.Net.Filter
{
    /// <summary>
    /// 请求验证错误处理
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
    public class RequiredErrorForClent : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext actionContext)
        {
            //验证模型验证状态，例如验证字段是否都是必填
            var modelState = actionContext.ModelState;
            List<ErrorView> errors = new List<ErrorView>();
            if (!modelState.IsValid)
            {
                var baseResult = new WebApiCallBack()
                {
                    status = false,
                    code = 0,
                    msg = "请提交必要的参数",
                };
                foreach (var key in modelState.Keys)
                {
                    var state = modelState[key];
                    if (state.Errors.Any())
                    {
                        ErrorView errorView = new ErrorView();
                        errorView.ErrorName = key;
                        errorView.Error = state.Errors.First().ErrorMessage;
                        errors.Add(errorView);
                    }
                }
                baseResult.data = errors;
                actionContext.Result = new ContentResult
                {
                    Content = JsonConvert.SerializeObject(baseResult),
                    ContentType = "application/json"
                };
            }
        }
    }
}