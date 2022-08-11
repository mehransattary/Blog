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
    public class CategoryComponent : ViewComponent
    {
        private readonly IWeblogGroupService weblogGroupService;
        public CategoryComponent(IWeblogGroupService weblogGroupService)
        {
            this.weblogGroupService = weblogGroupService;
        }
       
        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var result =await weblogGroupService.ShowAllWeblogGroupAsync(cancellationToken);
            return View("/Views/Components/CategoryComponent.cshtml", result);
        }
    }
}
