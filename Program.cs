using COLORS;
using COLORS.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
        .AddServices()
        .Build();

var app = host.Services.GetRequiredService<App>();
app.Run();
