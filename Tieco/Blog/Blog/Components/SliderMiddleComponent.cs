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
        private readonly IWebLog_SliderService webLog_SliderService;
        public SliderMiddleComponent(IWebLog_SliderService webLog_SliderService)
        {
            this.webLog_SliderService = webLog_SliderService;
        }
        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var result =await webLog_SliderService.ShowSliderMiddleForBlogAsync(cancellationToken);
            int i = 1;
            foreach (var item in result.Take(3))
            {
                ViewData["Slider" + i] = item;
                i++;
            }
            return View("/Views/Components/SliderMiddleComponent.cshtml");
        }
    }
}
