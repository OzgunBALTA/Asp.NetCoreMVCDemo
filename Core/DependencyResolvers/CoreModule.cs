using Core.CrossCuttingConcers.Caching.Abstract;
using Core.CrossCuttingConcers.Caching.Concrete.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollections)
        {
            serviceCollections.AddMemoryCache();
            serviceCollections.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollections.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollections.AddSingleton<Stopwatch>();
        }
    }
}
