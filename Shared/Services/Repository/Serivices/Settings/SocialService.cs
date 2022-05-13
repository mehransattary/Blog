using Common;
using Data.Context;
using Data.Dto;
using Data.ViewModel;
using Entities;
using Microsoft.AspNetCore.Identity;
using Repositories;
using Service.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using X.PagedList;

namespace Service.Repository
{
    public class SocialService : Repository<Social>, ISocialService
    {
        public SocialService(AppDbContext context) : base(context)
        {
        }

        public  async Task AddSocialAsync(SocialDto SocialDto, CancellationToken cancellationToken)
        {
            try
            {
                #region Image
                string filePathImage = "/images/default.png";

                //check is exist AvatarImage
                if (SocialDto?.Image?.Length > 0)
                {
                    filePathImage = AddImage("noname", "social", SocialDto?.Image, cancellationToken);
                }

                #endregion
                #region Save Customerpage
                var Social = new Social()
                {
                    FontAwseome=SocialDto.FontAwseome,
                    Link=SocialDto.Link,
                    Name= SocialDto.Name,
                    Image = filePathImage,
                    UserId = SocialDto.UserId,
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now

                };
                await AddAsync(Social, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }   

        public async Task UpdateSocialAsync(SocialDto SocialDto, string _Image, CancellationToken cancellationToken)
        {
            var _Social = await GetByIdAsync(cancellationToken, SocialDto.Id);

            #region Save Image
            string filePathImage = "/images/default.png";
            string filePathImageBefore = "/images/default.png";
            //check is exist AvatarImage

            if (SocialDto?.Image?.Length > 0)
            {
                filePathImage = AddImage("noname", "social", SocialDto?.Image, cancellationToken);
                MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_Social.Image));
            }
            if (SocialDto?.Image == null && _Image != null)
                filePathImageBefore = _Image;



            #endregion
            #region Save Customerpage

            #region Properties
            _Social.Name = SocialDto.Name;
            _Social.Link = SocialDto.Link;
            _Social.FontAwseome = SocialDto.FontAwseome;
            _Social.UserId = SocialDto.UserId;
            _Social.CreateDate = _Social.CreateDate;
            _Social.LastUpdateDate = DateTime.Now;
            #endregion

            #region Save Image
            if (SocialDto.Image != null)
                _Social.Image = filePathImage;
            else if (SocialDto.Image == null && !string.IsNullOrEmpty(_Image))
                _Social.Image = filePathImageBefore;
            else
                _Social.Image = filePathImage;
            #endregion



            await UpdateAsync(_Social, cancellationToken);
            #endregion        }
        }

        public async Task<IList<Social>> ShowAllSocialAsync(CancellationToken cancellationToken, string UserId)
        {
            var result = await TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
                   new Social()
                   {
                       Name = x.Name,
                       Link = x.Link,
                       FontAwseome = x.FontAwseome,
                       UserId = x.UserId,               
                       Image = x.Image,
                       Id = x.Id,
                       LastUpdateDate = x.LastUpdateDate,
                       CreateDate = x.CreateDate


                   }).ToListAsync(cancellationToken);
            return result;
        }

        public  IPagedList<Social> ShowAllSocial_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10)
        {
            var result = TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
               new Social()
               {
                   Name = x.Name,
                   FontAwseome = x.FontAwseome,
                   Link = x.Link,
                   UserId = x.UserId,
                   Id = x.Id,
                   LastUpdateDate = x.LastUpdateDate,
                   CreateDate = x.CreateDate,
                   Image = x.Image,

               }).ToPagedList(currentPage, number_showproduct);
                    return result;
        }
 
    }
}
