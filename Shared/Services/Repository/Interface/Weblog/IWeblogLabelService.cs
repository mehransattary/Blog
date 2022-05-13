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
    public interface IWeblogLabelService : IRepository<WebLog_Label>
    {


        Task AddWebLog_LabelAsync(WebLog_LabelDto webLog_LabelDto, CancellationToken cancellationToken);
        Task UpdateWebLog_LabelAsync(WebLog_LabelDto webLog_LabelDto, string _WebLog_Label_Image, string _WebLog_Label_ImageHome, string _WebLog_Label_ThumbnaillImage, string _Image_Meta, CancellationToken cancellationToken);
        Task<IList<WebLog_Label>> ShowAllWeblogLabelAsync(CancellationToken cancellationToken, string UserId);
        IPagedList<WebLog_Label> ShowAllWeblogLabel_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10);
        Task<bool> CheckRepeatUrlMeta(string Url_Meta);
        Task<bool> CheckRepeatOrder(short order);
    }
}
