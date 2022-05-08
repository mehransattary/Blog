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
    public interface ISettingsLogoesService : IRepository<SettingsLogo>
    {


        Task AddSettingsLogoAsync(SettingsLogoDto SettingsLogoDto, CancellationToken cancellationToken);
        Task UpdateSettingsLogoAsync(SettingsLogoDto SettingsLogoDto, string _Settings_Image_Logo, string _Settings_Image_Logo_Footer, CancellationToken cancellationToken);
        SettingsLogo ShowAllSettingsLogo( string UserId);
        IPagedList<SettingsLogo> ShowAllSettingsLogo_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10);


    }
}
