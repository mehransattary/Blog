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
    public interface ISocialService : IRepository<Social>
    {


        Task AddSocialAsync(SocialDto SocialDto, CancellationToken cancellationToken);
        Task UpdateSocialAsync(SocialDto SocialDto, string _Image, CancellationToken cancellationToken);
        Task<IList<Social>> ShowAllSocialAsync(CancellationToken cancellationToken, string UserId);
        Task<IList<Social>> ShowAllSocialAsync(CancellationToken cancellationToken);
        IPagedList<Social> ShowAllSocial_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10);


    }
}