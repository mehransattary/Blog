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
    public interface IWeblogGroupService : IRepository<WebLog_Group>
    {


        Task AddWebLog_GroupAsync(WebLog_GroupDto  webLog_GroupDto, CancellationToken cancellationToken);
        Task UpdateWebLog_GroupAsync(WebLog_GroupDto webLog_GroupDto,  string _WebLog_Group_Image, string _WebLog_Group_ImageHome, string _WebLog_Group_ThumbnaillImage, string _Image_Meta, CancellationToken cancellationToken);
        Task<IList<WebLog_Group>> ShowAllWeblogGroupAsync(CancellationToken cancellationToken );
        Task<WebLog_Group> ShowAllWeblogGroupByUrlAsync(string url, CancellationToken cancellationToken);
        Task<IList<WebLog_Group>> ShowAllWeblogGroupSiteMapsAsync( CancellationToken cancellationToken);
        IPagedList<WebLog_Group> ShowAllWeblogGroup_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10);
        IPagedList<WebLog_Group> ShowAllWeblogGroup_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10,int categoryId=0);
        Task<bool> CheckRepeatUrlMeta(string Url_Meta);
        Task<bool> CheckRepeatOrder(short order);
        Task<IList<WebLog_Group>> SelectListAsync(CancellationToken cancellationToken);
        Task<IList<WebLog_Group>> SelectListAsync(CancellationToken cancellationToken, int groupId=0);

    }
}
