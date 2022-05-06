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
    public interface ISettingsMetasService : IRepository<SettingsMeta>
    {


        Task AddSettingsMetaAsync(SettingsMetaDto SettingsMetaDto, CancellationToken cancellationToken);
        Task UpdateSettingsMetaAsync(SettingsMetaDto SettingsMetaDto, string _Settings_twitter_image, string _Settings_ogimage, CancellationToken cancellationToken);
        Task<IList<SettingsMeta>> ShowAllSettingsMetaAsync(CancellationToken cancellationToken, string UserId);
        IPagedList<SettingsMeta> ShowAllSettingsMeta_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10);


    }
}
