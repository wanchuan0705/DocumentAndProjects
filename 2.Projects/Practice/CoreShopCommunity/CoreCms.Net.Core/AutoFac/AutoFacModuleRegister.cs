using Autofac;
using System.Reflection;

namespace CoreCms.Net.Core.AutoFac
{
    public class AutoFacModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var basePath = AppContext.BaseDirectory;
            var servicesDllFile = Path.Combine(basePath, "CoreCms.Net.Services.dll");
            var repositoryDllFile = Path.Combine(basePath, "CoreCms.Net.Repository.dll");

            if (!(File.Exists(servicesDllFile) && File.Exists(repositoryDllFile)))
            {
                var mes = "Repository.dll和Services.dll 丢失，因为项目解耦了，所以需要先F6编译，再F5运行，请检查 bin 文件夹，并拷贝。";
                throw new Exception(mes);
            }

            //获取Service.dll程序集服务，并注册
            var assemblyServices = Assembly.LoadFrom(servicesDllFile);
            //支持属性注入依赖重复
            builder.RegisterAssemblyTypes(assemblyServices).AsImplementedInterfaces().InstancePerDependency().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            // 获取 Repository.dll 程序集服务，并注册
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            //支持属性注入依赖重复
            builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces().InstancePerDependency()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
        }
    }
}