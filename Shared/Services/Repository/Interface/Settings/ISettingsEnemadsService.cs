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
    public interface ISettingsEnemadsService : IRepository<SettingsEnemad>
    {


        Task AddSettingsEnemadAsync(SettingsEnemadDto SettingsEnemadDto, CancellationToken cancellationToken);
        Task UpdateSettingsEnemadAsync(SettingsEnemadDto SettingsEnemadDto, string _Settings_Image_Enemad, CancellationToken cancellationToken);
        Task<IList<SettingsEnemad>> ShowAllSettingsEnemadAsync(CancellationToken cancellationToken, string UserId);
        IPagedList<SettingsEnemad> ShowAllSettingsEnemad_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10);


    }
}
