using Application.Common.Interface;
using Application.Common.Services;
using AutoMapper;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace Application.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationCore(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();

        //Automaper: class profiles=> AutoMapper Folder in the curent project
        InitioalizeMapper(services);
        //Automaper: Use AutoMapper
        services.AddAutoMapper(assembly);

        //MediatR: Use MediatR
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        //دو روش برای افزودن ولیدیتورها در FluentValidation
        //1.// AddFluentValidation مخصوص MediatR است و ولیدیشن‌ها را به درخواست‌های MediatR متصل می‌کند.
        services.AddFluentValidation(AppDomain.CurrentDomain.GetAssemblies());
        //2.//فقط ولیدیتورها را به صورت عمومی به DI اضافه می‌کند و برای کار با MediatR تنظیمات اضافی نیاز است.
        //services.AddValidatorsFromAssembly(assembly);

        //JWt
        services.AddSingleton<ITokenService, TokenService>();

        return services;
    }
    public static void InitioalizeMapper(IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(config =>
        {
            config.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
        });
        IMapper mapper = mapperConfig.CreateMapper();
    }
}
