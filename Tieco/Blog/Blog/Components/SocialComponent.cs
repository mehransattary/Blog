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
    public class SocialComponent : ViewComponent
    {
        private readonly ISocialService socialService;
        public SocialComponent(ISocialService socialService)
        {
            this.socialService = socialService;
        }
        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var result = await socialService.ShowAllSocialAsync(cancellationToken);
            return View("/Views/Components/SocialComponent.cshtml", result);
        }
    }
}
