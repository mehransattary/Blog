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
    public interface IPersonService : IRepository<Person>
    {


        Task AddPersonAsync(PersonDto  personDto, CancellationToken cancellationToken);
        Task UpdatePersonAsync(PersonDto personDto, string _AvatarImage, string _IconImage, CancellationToken cancellationToken);
        Task<IList<Person>> ShowAllPeopleAsync(CancellationToken cancellationToken, string UserId);
        IPagedList<Person> ShowAllPeople_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10);


    }
}
