using Data.Dto;
using Data.ViewModel;
using Entities;
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
    public interface ISettingsCopyRightsService : IRepository<SettingsCopyRight>
    {


        Task AddSettingsCopyRightAsync(SettingsCopyRightDto SettingsCopyRightDto, CancellationToken cancellationToken);
        Task UpdateSettingsCopyRightAsync(SettingsCopyRightDto SettingsCopyRightDto, string _Settings_Tarah_Logo_Image, CancellationToken cancellationToken);
        Task<IList<SettingsCopyRight>> ShowAllSettingsCopyRightAsync(CancellationToken cancellationToken, string UserId);
        IPagedList<SettingsCopyRight> ShowAllSettingsCopyRight_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10);


    }
}
