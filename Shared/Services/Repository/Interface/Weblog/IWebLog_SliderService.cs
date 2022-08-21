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
    public interface IWebLog_SliderService : IRepository<WebLog_Slider>
    {

        Task AddWebLog_SliderAsync(WebLog_SliderDto WebLog_SliderDto, CancellationToken cancellationToken);
        Task UpdateWebLog_SliderAsync(WebLog_SliderDto WebLog_SliderDto, string _WebLog_Slider_Image, CancellationToken cancellationToken);
        Task<IList<WebLog_Slider>> ShowAllWebLog_SliderAsync(CancellationToken cancellationToken, string UserId);

        Task<IList<WebLog_Slider>> ShowSliderTopForBlogAsync(CancellationToken cancellationToken);
        Task<IList<WebLog_Slider>> ShowSliderMiddleForBlogAsync(CancellationToken cancellationToken);
        IPagedList<WebLog_Slider> ShowAllWebLog_Slider_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10);
        IPagedList<WebLog_Slider> ShowAllWebLog_Slider_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10,int groupId=0);


    }
}
