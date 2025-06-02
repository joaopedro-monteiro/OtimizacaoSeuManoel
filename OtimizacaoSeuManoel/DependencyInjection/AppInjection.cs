using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OtimizacaoSeuManoel.Context;
using System.Reflection;

namespace OtimizacaoSeuManoel.DependencyInjection;

public static class AppInjection
{
    public static void AddApp(this IServiceCollection serviceCollection, IConfiguration configuration, params Assembly[] assemblies)
    {
        serviceCollection.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(configuration["MSSQL:ConnectionString"]));
        serviceCollection.AddScoped<DbContext>(s => s.GetRequiredService<AppDbContext>());        

        serviceCollection.AddValidatorsFromAssemblies(assemblies);
        serviceCollection.AddAutoMapper(assemblies);        

        serviceCollection.Scan(scan => scan.FromAssemblies(assemblies).AddClasses().AsImplementedInterfaces(type => assemblies.Contains(type.Assembly)));

        serviceCollection.AddScoped(_ => typeof(AppInjection).Assembly);
    }
}
