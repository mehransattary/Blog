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
    public interface ISettingsService : IRepository<Settings>
    {


        Task AddSettingsAsync(SettingsDto SettingDto, CancellationToken cancellationToken);
        Task UpdateSettingsAsync(SettingsDto SettingDto, string _Settings_ImageFooter, string _Settings_ImageTopMain, CancellationToken cancellationToken);
        Task<IList<Settings>> ShowAllSettingsAsync(CancellationToken cancellationToken, string UserId);
        IPagedList<Settings> ShowAllSettings_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10);


    }
}
