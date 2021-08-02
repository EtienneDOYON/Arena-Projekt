using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Core.Unity.Config
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection RegisterAutoMapperConfiguration(this IServiceCollection services, params Assembly[] assemblies)
        {
            var mappingConfig = new MapperConfiguration(cfg => { cfg.AddMaps(assemblies); });

            mappingConfig.AssertConfigurationIsValid();
            mappingConfig.CompileMappings();
            var mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
