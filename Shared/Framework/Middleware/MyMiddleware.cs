
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Framework.Middleware
{
    public class MyMiddleware
    {
        private RequestDelegate _nextDelegate;
        private IServiceProvider _serviceProvider;

        public MyMiddleware(RequestDelegate nextDelegate, IServiceProvider serviceProvider)
        {
            _nextDelegate = nextDelegate;
            _serviceProvider = serviceProvider;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string requestURL = httpContext.Request.Path;
            var Path = httpContext.Request.Path.Value;

            var queryString = httpContext.Request.QueryString.Value;
            //string[] arraypath = new string[4];
            //arraypath = Path.Split('/');
            var Host = httpContext.Request.Host.Value;
            //if (Host.Contains("ngt-medical.ir"))
            //{
            //    if (queryString != "")
            //    {
            //        httpContext.Response.Redirect($"https://ngt-medical.com{Path}/{queryString}");
            //        return;
            //    }
            //    else
            //    {
            //        httpContext.Response.Redirect($"https://ngt-medical.com{Path}");
            //        return;
            //    }

            //}

        
            await _nextDelegate.Invoke(httpContext);



        }
    }
}
