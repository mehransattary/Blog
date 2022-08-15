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
    public class SliderTopComponent : ViewComponent
    {
        private readonly IWebLog_SliderService webLog_SliderService;
        public SliderTopComponent(IWebLog_SliderService webLog_SliderService)
        {
            this.webLog_SliderService = webLog_SliderService;
        }
        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var result =await webLog_SliderService.ShowSliderTopForBlogAsync(cancellationToken);
            return View("/Views/Components/SliderTopComponent.cshtml", result);
        }
    }
}
