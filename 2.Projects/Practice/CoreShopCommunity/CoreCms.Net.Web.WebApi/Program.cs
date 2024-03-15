using Autofac;
using Autofac.Extensions.DependencyInjection;
using CoreCms.Net.Configuration;
using CoreCms.Net.Core.AutoFac;
using CoreCms.Net.Core.Config;
using CoreCms.Net.Filter;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
//��ӱ���·����ȡ֧��,AddSingleton��ʾע��һ������ģʽ
builder.Services.AddSingleton(new AppSettingsHelper(builder.Environment.ContentRootPath));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//������ݿ�����SqlSugarע��֧��
builder.Services.AddSqlSugarSetup();

#region AutoFacע��============================================================================

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    #region ע�����������ע��Ҳ���ԣ���ΪASP.NET Core ��ܻ��Զ�ɨ�����Ӧ�ó�����򼯣���ע�����з���Ĭ��Լ���Ŀ����������� API ��������

    //��ȡ���п��������Ͳ�ʹ������ע��,ControllerBase �� ASP.NET Core MVC ��������п������Ļ��ࡣ
    var controllerBaseType = typeof(ControllerBase);
    //Autofac ע��ָ�������е��������͡�
    //controllerBaseType.IsAssignableFrom(t): ���� t �� ControllerBase ���ͣ������������ࣩ��
    //t != controllerBaseType: ���� t ���� ControllerBase ������Ϊ���ǲ�ϣ��ע����ࡣ
    //PropertiesAutowired(): ��һ��ָʾ Autofac �ڴ�������ʵ��ʱ�Զ�ע�����������
    containerBuilder.RegisterAssemblyTypes(typeof(Program).Assembly)
        .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
        .PropertiesAutowired();

    #endregion ע�����������ע��Ҳ���ԣ���ΪASP.NET Core ��ܻ��Զ�ɨ�����Ӧ�ó�����򼯣���ע�����з���Ĭ��Լ���Ŀ����������� API ��������

    containerBuilder.RegisterModule(new AutoFacModuleRegister());
});

#endregion AutoFacע��============================================================================

//ע��mvc��ע��razor������ͼ
builder.Services.AddMvc(option =>
{
    //ʵ����֤
    option.Filters.Add<RequiredErrorForClent>();
    //�쳣����
    option.Filters.Add<GlobalExceptionsFilterForClent>();
    //Swagger�޳�����Ҫ����apiչʾ���б�
    //option.Conventions.Add(new ApiExplorerIgnores());
});
//ǿ����ʾ����
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