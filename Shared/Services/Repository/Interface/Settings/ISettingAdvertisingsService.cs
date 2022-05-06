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
    public interface ISettingAdvertisingService : IRepository<SettingAdvertising>
    {


        Task AddSettingAdvertisingAsync(SettingAdvertisingDto SettingAdvertisingsDto, CancellationToken cancellationToken);
        Task UpdateSettingAdvertisingAsync(SettingAdvertisingDto SettingAdvertisingsDto, CancellationToken cancellationToken);
        Task<IList<SettingAdvertising>> ShowAllSettingAdvertisingAsync(CancellationToken cancellationToken, string UserId);
        IPagedList<SettingAdvertising> ShowAllSettingAdvertising_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10);


    }
}
