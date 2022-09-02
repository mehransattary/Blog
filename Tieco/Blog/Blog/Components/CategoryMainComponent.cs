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
    public class CategoryMainComponent : ViewComponent
    {
        private readonly IWeblogCategoryService weblogCategoryService;
        public CategoryMainComponent(IWeblogCategoryService weblogCategoryService)
        {
            this.weblogCategoryService = weblogCategoryService;
        }
       
        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var result = await weblogCategoryService.ShowAllWeblogCategoryFoeMainAsync           (cancellationToken); 
            return View("/Views/Components/CategoryMainComponent.cshtml", result);
        }
    }
}
