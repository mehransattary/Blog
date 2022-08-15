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
    public interface IAbouteMeService : IRepository<AbouteMe>
    {


        Task AddAbouteMeAsync(AbouteMeDto AbouteMeDto, CancellationToken cancellationToken);
        Task UpdateAbouteMeAsync(AbouteMeDto AbouteMeDto, string _AbouteMe_Image, CancellationToken cancellationToken);
        Task<IList<AbouteMe>> ShowAllAbouteMeAsync(CancellationToken cancellationToken, string UserId);
        Task<AbouteMe> ShowAllAbouteMeAsync(CancellationToken cancellationToken);
       AbouteMe ShowAllAbouteMe();

        IPagedList<AbouteMe> ShowAllAbouteMe_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10);


    }
}
