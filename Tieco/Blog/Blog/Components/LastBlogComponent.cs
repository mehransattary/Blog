using Entities;
using IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Components
{
    public class LastBlogComponent : ViewComponent
    {
        private readonly IWeblogService weblogService;
        public LastBlogComponent(IWeblogService weblogService)
        {
            this.weblogService = weblogService;
        }
        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var result =await weblogService.ShowSelectedFiveWeblogToMiddleSlidersAsync(cancellationToken);
            return View("/Views/Components/LastBlogComponent.cshtml", result);
        }
    }
}
