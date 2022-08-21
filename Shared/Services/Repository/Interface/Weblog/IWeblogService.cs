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
    public interface IWeblogService : IRepository<WebLog>
    {

        Task AddWebLogAsync(WeblogDto WeblogDto, CancellationToken cancellationToken);
        Task UpdateWebLogAsync(WeblogDto WeblogDto, string _WebLog_Image, string _WebLog_ThumbnaillImage, string _Image_Meta, CancellationToken cancellationToken);
        Task<IList<WebLog>> ShowAllWeblogAsync(CancellationToken cancellationToken, string UserId);
        Task<IList<WebLog>> ShowAllWeblogMainAsync(CancellationToken cancellationToken);

        Task<IList<WebLog>> ShowSelectedFiveWeblogToMiddleSlidersAsync(CancellationToken cancellationToken);
        Task<WebLog> ShowWeblogAsync(string url, CancellationToken cancellationToken);
        Task<WebLog> ShowWeblogShortUrlAsync(string shortUrl, CancellationToken cancellationToken);
        Task<IList<WebLog>> ShowAllWeblogsSiteMapsAsync(CancellationToken cancellationToken);
     
        IPagedList<WebLog> ShowAllWeblog_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10);
        IPagedList<WebLog> ShowAllWeblog_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10,int groupId=0);
        Task<bool> CheckRepeatUrlMeta(string Url_Meta);

        Task<IList<WebLog>> SelectListAsync(CancellationToken cancellationToken, int weblogId = 0);

        Task<IList<WebLog>> SelectListAsync(CancellationToken cancellationToken);

    }
}
