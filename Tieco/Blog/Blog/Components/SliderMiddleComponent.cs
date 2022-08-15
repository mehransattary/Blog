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
    public class SliderMiddleComponent : ViewComponent
    {
       
        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
           
            return View("/Views/Components/SliderMiddleComponent.cshtml");
        }
    }
}
