using Autofac;
using Autofac.Extensions.DependencyInjection;
using CoreCms.Net.Configuration;
using CoreCms.Net.Core.AutoFac;
using CoreCms.Net.Core.Config;
using CoreCms.Net.Filter;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
//添加本地路径获取支持,AddSingleton表示注入一个单例模式
builder.Services.AddSingleton(new AppSettingsHelper(builder.Environment.ContentRootPath));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//添加数据库连接SqlSugar注入支持
builder.Services.AddSqlSugarSetup();

#region AutoFac注册============================================================================

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    #region 注册控制器，不注册也可以，因为ASP.NET Core 框架会自动扫描你的应用程序程序集，并注册所有符合默认约定的控制器，包括 API 控制器。

    //获取所有控制器类型并使用属性注入,ControllerBase 是 ASP.NET Core MVC 框架中所有控制器的基类。
    var controllerBaseType = typeof(ControllerBase);
    //Autofac 注册指定程序集中的所有类型。
    //controllerBaseType.IsAssignableFrom(t): 类型 t 是 ControllerBase 类型（或者是其子类）。
    //t != controllerBaseType: 类型 t 不是 ControllerBase 本身，因为我们不希望注册基类。
    //PropertiesAutowired(): 这一行指示 Autofac 在创建服务实例时自动注入属性依赖项。
    containerBuilder.RegisterAssemblyTypes(typeof(Program).Assembly)
        .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
        .PropertiesAutowired();

    #endregion 注册控制器，不注册也可以，因为ASP.NET Core 框架会自动扫描你的应用程序程序集，并注册所有符合默认约定的控制器，包括 API 控制器。

    containerBuilder.RegisterModule(new AutoFacModuleRegister());
});

#endregion AutoFac注册============================================================================

//注册mvc，注册razor引擎视图
builder.Services.AddMvc(option =>
{
    //实体验证
    option.Filters.Add<RequiredErrorForClent>();
    //异常处理
    option.Filters.Add<GlobalExceptionsFilterForClent>();
    //Swagger剔除不需要加入api展示的列表
    //option.Conventions.Add(new ApiExplorerIgnores());
});
//强制显示中文
System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();