using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using BookManagementSystem.Core.IRepository;
using BookManagementSystem.Core.IService;
using BookManagementSystem.Resource.Repository;
using BookManagementSystem.Service.Service;
using Microsoft.AspNetCore.Http;

namespace BookManagementSystem.Utility
{
    public class DIResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            #region Context accesor
            // this is for accessing the http context by interface in view level
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Services

            services.AddScoped<IBookService, BookService>();

            #endregion

            #region Repository

            services.AddScoped<IBookRepository, BookRepository>();
            #endregion
        }
    }
}
