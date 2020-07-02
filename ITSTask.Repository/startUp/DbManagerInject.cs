using ITSTask.DB;
using ITSTask.Repository.Contracts;
using ITSTask.Repository.Contracts.Base;
using ITSTask.Repository.Implementations;
using ITSTask.Repository.Implementations.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITSTask.Repository.startUp
{
    public sealed class DbManagerInject
    {
        public static void StartUp(IServiceCollection services)
        {
            services.AddTransient<DataContext>();
          
            services.AddTransient<iItemRep, itemRep>(); 
        }
    }
}
