using Data.Dto;
using Data.ViewModel;
using Entities;
using IRepositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using X.PagedList;

namespace Service.Repository.Interface
{
    public interface IWeblogCategoryService : IRepository<WebLog_Category>
    {


        Task AddWebLog_CategoryAsync(WebLog_CategoryDto  webLog_CategoryDto, CancellationToken cancellationToken);
        Task UpdateWebLog_CategoryAsync(WebLog_CategoryDto webLog_CategoryDto,  string _WebLog_Category_Image, string _WebLog_Category_ImageHome, string _WebLog_Category_ThumbnaillImage, string _Image_Meta, CancellationToken cancellationToken);
        Task<IList<WebLog_Category>> ShowAllWeblogCategoryAsync(CancellationToken cancellationToken, string UserId);
        Task<IList<WebLog_Category>> ShowAllWeblogCategorySiteMapsAsync(CancellationToken cancellationToken);
        Task<IList<WebLog_Category>> ShowAllWeblogCategoryFoeMainAsync(CancellationToken cancellationToken);
        IPagedList<WebLog_Category> ShowAllWeblogCategory_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10);

        Task<WebLog_Category> ShowAllWeblogCategoryByUrlAsync(string url, CancellationToken cancellationToken);

        
        Task<bool> CheckRepeatUrlMeta(string Url_Meta);
        Task<bool> CheckRepeatOrder(short order);
        string CheckIsExistGroupInCategory(int categoryId);

        Task<IList<WebLog_Category>> SelectListAsync(CancellationToken cancellationToken, int categoryId = 0);

        Task<IList<WebLog_Category>> SelectListAsync(CancellationToken cancellationToken);

    }
}
