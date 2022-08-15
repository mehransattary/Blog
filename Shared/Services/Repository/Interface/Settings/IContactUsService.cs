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
    public interface IContactUsService : IRepository<ContactUs>
    {


        Task AddContactUsAsync(ContactUsDto ContactUsDto, CancellationToken cancellationToken);
        Task UpdateContactUsAsync(ContactUsDto ContactUsDto, string _ContactUs_Image, CancellationToken cancellationToken);
        Task<IList<ContactUs>> ShowAllContactUsAsync(CancellationToken cancellationToken, string UserId);
        Task<ContactUs> ShowAllContactUsAsync(CancellationToken cancellationToken);
        ContactUs ShowAllContactUs();

        IPagedList<ContactUs> ShowAllContactUs_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10);


    }
}
