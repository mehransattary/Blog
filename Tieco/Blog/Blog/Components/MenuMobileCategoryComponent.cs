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
    public class MenuMobileCategoryComponent : ViewComponent
    {
        private readonly IWeblogCategoryService weblogCategoryService;
        public MenuMobileCategoryComponent(IWeblogCategoryService weblogCategoryService)
        {
            this.weblogCategoryService = weblogCategoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var result = await weblogCategoryService.ShowAllWeblogCategoryFoeMainAsync(cancellationToken);
            return View("/Views/Components/MenuMobileCategoryComponent.cshtml", result);
        }
    }
}
