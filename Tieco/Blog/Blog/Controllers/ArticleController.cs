using Microsoft.AspNetCore.Mvc;
using Service.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using X.PagedList;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IWeblogService weblogService;
        private readonly IWeblogCategoryService weblogCategoryService;
        private readonly IWeblogGroupService weblogGroupService;
        private readonly IWeblogLabelService weblogLabelService;


        public ArticleController(IWeblogService weblogService,
             IWeblogCategoryService weblogCategoryService, IWeblogGroupService weblogGroupService,
          IWeblogLabelService weblogLabelService)
        {
            this.weblogService = weblogService;
            this.weblogCategoryService = weblogCategoryService;
            this.weblogGroupService = weblogGroupService;
            this.weblogLabelService = weblogLabelService;

        }
        [Route("/category/{url}")]
        public async Task<IActionResult> ShowCategoryBlog(string url,  CancellationToken cancellationToken, int currentPage = 1)
        {
            var categoriesBlogs = await weblogCategoryService.ShowAllWeblogCategoryByUrlAsync(url, cancellationToken);
            var groupsBlogs =  categoriesBlogs.webLog_Groups.ToPagedList(currentPage, 6);
            ViewData["categoriesBlogs"] = categoriesBlogs;
            ViewBag.Keyword_Meta = categoriesBlogs.Keyword_Meta;
            ViewBag.Desc_Meta = categoriesBlogs.Desc_Meta;
            ViewBag.Url_Meta= categoriesBlogs.Url_Meta;
            ViewBag.Image_Met= categoriesBlogs.Image_Meta;
            ViewBag.categoryName = categoriesBlogs.Title_Meta;
            ViewBag.categoryUrl = categoriesBlogs.Url_Meta;
            return View(groupsBlogs);
        }

        [Route("/group/{url}")]
        public async Task<IActionResult> ShowGroupBlog(string url, CancellationToken cancellationToken, int currentPage = 1)
        {
            var groupBlogs = await weblogGroupService.ShowAllWeblogGroupByUrlAsync(url, cancellationToken);
            var blogs = groupBlogs.WebLogs.ToPagedList(currentPage, 6);
            ViewData["groupBlogs"] = groupBlogs;
            ViewBag.Keyword_Meta = groupBlogs.Keyword_Meta;
            ViewBag.Desc_Meta = groupBlogs.Desc_Meta;
            ViewBag.Url_Meta = groupBlogs.Url_Meta;
            ViewBag.Image_Met = groupBlogs.Image_Meta;
            ViewBag.groupName = groupBlogs.Title_Meta;
            ViewBag.groupUrl = groupBlogs.Url_Meta;
            ViewBag.categoryName = groupBlogs.WebLog_Category.Title_Meta;
            ViewBag.categoryUrl = groupBlogs.WebLog_Category.Url_Meta;

            return View(blogs);
          
        }
        [Route("/blog/{url}")]
        [Route("/{shorturl}")]
        public async Task<IActionResult> ShowBlog(string shorturl, string url, CancellationToken cancellationToken, int currentPage = 1)
        {
            if (!string.IsNullOrEmpty(url))
            {
                var blog = await weblogService.ShowWeblogAsync(url, cancellationToken);

                ViewBag.groupName = blog.WebLog_Groups.Title_Meta;
                ViewBag.groupUrl = blog.WebLog_Groups.Url_Meta;              
                ViewBag.blogName = blog.Title_Meta;
                ViewBag.blogUrl = blog.Url_Meta;
                ViewBag.categoryName = blog.WebLog_Groups.WebLog_Category.Title_Meta;
                ViewBag.categoryUrl = blog.WebLog_Groups.WebLog_Category.Url_Meta;

                return View(blog);
            }
            else if (!string.IsNullOrEmpty(shorturl))
            {
                var blog = await weblogService.ShowWeblogShortUrlAsync(shorturl, cancellationToken);
                ViewBag.groupName = blog.WebLog_Groups.Title_Meta;
                ViewBag.groupUrl = blog.WebLog_Groups.Url_Meta;
                ViewBag.blogName = blog.Title_Meta;
                ViewBag.blogUrl = blog.Url_Meta;
                ViewBag.categoryName = blog.WebLog_Groups.WebLog_Category.Title_Meta;
                ViewBag.categoryUrl = blog.WebLog_Groups.WebLog_Category.Url_Meta;
                return Redirect($"/blog/{blog.Url_Meta}");
            }
            else
            {
                var blog = await weblogService.ShowWeblogAsync(url, cancellationToken);
                ViewBag.groupName = blog.WebLog_Groups.Title_Meta;
                ViewBag.groupUrl = blog.WebLog_Groups.Url_Meta;
                ViewBag.blogName = blog.Title_Meta;
                ViewBag.blogUrl = blog.Url_Meta;
                ViewBag.categoryName = blog.WebLog_Groups.WebLog_Category.Title_Meta;
                ViewBag.categoryUrl = blog.WebLog_Groups.WebLog_Category.Url_Meta;
                return View(blog);
            }
        }
    }
}
