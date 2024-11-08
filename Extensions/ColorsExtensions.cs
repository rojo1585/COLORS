using COLORS.Factory;
using COLORS.Modules;
using COLORS.Modules.Interface;
using COLORS.UI;
using COLORS.UI.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace COLORS.Extensions;
public static class ColorsExtensions
{
    public static IHostBuilder AddServices(this IHostBuilder host) =>
   host.ConfigureServices((context, services) =>
   {
       services.AddScoped<IInterpeter, ColorInterpreter>();
       services.AddScoped<IColorCommandFactory, ColorCommandFactory>();
       services.AddScoped<IUI, ColorProgramUI>();
       services.AddSingleton<App>();
   });
}
