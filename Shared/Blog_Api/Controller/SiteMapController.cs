using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tieco_Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteMapController : ControllerBase
    {

        private readonly IWeblogService weblogService;
        private readonly IWeblogLabelService weblogLabelService;
        private readonly IWeblogGroupService weblogGroupService;
        private readonly IWeblogCategoryService weblogCategoryService;

        public SiteMapController(IWeblogService weblogService,
          IWeblogLabelService weblogLabelService,
          IWeblogGroupService weblogGroupService,
          IWeblogCategoryService weblogCategoryService
            )
        {
            this.weblogService = weblogService;
            this.weblogLabelService = weblogLabelService;
            this.weblogGroupService = weblogGroupService;
            this.weblogCategoryService = weblogCategoryService;
        }
        [Route("/sitemap")]
        public async Task<ActionResult> SitemapAsync(CancellationToken  cancellationToken)
        {
            var siteMapBuilder = new SitemapBuilder();
            var Host = HttpContext.Request.Host.Value;
            string baseUrl = "https://"+Host;
            siteMapBuilder.AddUrl(baseUrl, modified: DateTime.UtcNow, changeFrequency: ChangeFrequency.Weekly, priority: 1.00);





            #region Services          
            var blogs =await weblogService.ShowAllWeblogsSiteMapsAsync(cancellationToken);
           // var blogLabels = await weblogLabelService.ShowAllWeblogLabelSiteMapsAsync(cancellationToken);
            var goups = await weblogGroupService.ShowAllWeblogGroupSiteMapsAsync(cancellationToken);


            foreach (var item in blogs)
            {
                if (!string.IsNullOrEmpty(item.Url_Meta))
                {
                    siteMapBuilder.AddUrl($"{baseUrl}/blog/{item.Url_Meta}", DateTime.Now, changeFrequency: null, priority: 0.80);

                }          
            }
            foreach (var item in goups)
            {
                if (!string.IsNullOrEmpty(item.Url_Meta))
                {
                    siteMapBuilder.AddUrl($"{baseUrl}/GroupBlog/{item.Url_Meta}", DateTime.Now, changeFrequency: null, priority: 0.80);

                }
            }

            #endregion
   
            siteMapBuilder.AddUrl($"{baseUrl}/AbouteMe", DateTime.Now, changeFrequency: null, priority: 0.9);
            siteMapBuilder.AddUrl($"{baseUrl}/ContactUs", DateTime.Now, changeFrequency: null, priority: 0.9);

            string xml = siteMapBuilder.ToString();
            return Content(xml, "text/xml");
        }
    }
}
