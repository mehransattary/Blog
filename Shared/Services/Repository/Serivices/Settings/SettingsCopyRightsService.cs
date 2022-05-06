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
    public class SettingsCopyRightService : Repository<SettingsCopyRight>, ISettingsCopyRightsService
    {
        public SettingsCopyRightService(AppDbContext context) : base(context)
        {
        }

        public  async Task AddSettingsCopyRightAsync(SettingsCopyRightDto SettingsCopyRightDto, CancellationToken cancellationToken)
        {
            try
            {
                #region Image
                string filePathSettings_Tarah_Logo_Image = "/images/default.png";

                //check is exist AvatarImage
                if (SettingsCopyRightDto?.Settings_Tarah_Logo_Image?.Length > 0)
                {
                    filePathSettings_Tarah_Logo_Image = AddImage("noname", "settingsCopyRight", SettingsCopyRightDto?.Settings_Tarah_Logo_Image, cancellationToken);
                }

                #endregion
                #region Save Customerpage
                var SettingsCopyRight = new SettingsCopyRight()
                {
                    Settings_Tarah_Href = SettingsCopyRightDto.Settings_Tarah_Href,
                    Settings_Tarah_FullName= SettingsCopyRightDto.Settings_Tarah_FullName,
                    Settings_Tarah_Logo_alt = SettingsCopyRightDto.Settings_Tarah_Logo_alt,
                    Settings_Tarah_Logo_Title = SettingsCopyRightDto.Settings_Tarah_Logo_Title,
                    Settings_Tarah_Title = SettingsCopyRightDto.Settings_Tarah_Title,

                    Settings_Tarah_Logo_Image = filePathSettings_Tarah_Logo_Image,
                    UserId = SettingsCopyRightDto.UserId,
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now

                };
                await AddAsync(SettingsCopyRight, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }   

        public async Task UpdateSettingsCopyRightAsync(SettingsCopyRightDto SettingsCopyRightDto, string _Settings_Tarah_Logo_Image, CancellationToken cancellationToken)
        {
            var _SettingsCopyRight = await GetByIdAsync(cancellationToken, SettingsCopyRightDto.Id);

            #region Save Image
            string filePathSettings_Tarah_Logo_Image = "/images/default.png";
            string filePathSettings_Tarah_Logo_ImageBefore = "/images/default.png";
            //check is exist AvatarImage

            if (SettingsCopyRightDto?.Settings_Tarah_Logo_Image?.Length > 0)
            {
                filePathSettings_Tarah_Logo_Image = AddImage("noname", "settingsCopyRight", SettingsCopyRightDto?.Settings_Tarah_Logo_Image, cancellationToken);
                MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_SettingsCopyRight.Settings_Tarah_Logo_Image));
            }
            if (SettingsCopyRightDto?.Settings_Tarah_Logo_Image == null && _Settings_Tarah_Logo_Image != null)
                filePathSettings_Tarah_Logo_ImageBefore = _Settings_Tarah_Logo_Image;



            #endregion
            #region Save Customerpage

            #region Properties
            _SettingsCopyRight.Settings_Tarah_Href = SettingsCopyRightDto.Settings_Tarah_Href;
            _SettingsCopyRight.Settings_Tarah_FullName = SettingsCopyRightDto.Settings_Tarah_FullName;
            _SettingsCopyRight.Settings_Tarah_Logo_alt = SettingsCopyRightDto.Settings_Tarah_Logo_alt;
            _SettingsCopyRight.Settings_Tarah_Logo_Title = SettingsCopyRightDto.Settings_Tarah_Logo_Title;
            _SettingsCopyRight.Settings_Tarah_Title = SettingsCopyRightDto.Settings_Tarah_Title;

            _SettingsCopyRight.UserId = SettingsCopyRightDto.UserId;
            _SettingsCopyRight.CreateDate = _SettingsCopyRight.CreateDate;
            _SettingsCopyRight.LastUpdateDate = DateTime.Now;
            #endregion

            #region Save Image
            if (SettingsCopyRightDto.Settings_Tarah_Logo_Image != null)
                _SettingsCopyRight.Settings_Tarah_Logo_Image = filePathSettings_Tarah_Logo_Image;
            else if (SettingsCopyRightDto.Settings_Tarah_Logo_Image == null && !string.IsNullOrEmpty(_Settings_Tarah_Logo_Image))
                _SettingsCopyRight.Settings_Tarah_Logo_Image = filePathSettings_Tarah_Logo_ImageBefore;
            else
                _SettingsCopyRight.Settings_Tarah_Logo_Image = filePathSettings_Tarah_Logo_Image;
            #endregion



            await UpdateAsync(_SettingsCopyRight, cancellationToken);
            #endregion       
        }

        public async Task<IList<SettingsCopyRight>> ShowAllSettingsCopyRightAsync(CancellationToken cancellationToken, string UserId)
        {
            var result = await TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
                   new SettingsCopyRight()
                   {
                       UserId = x.UserId,
                       Id = x.Id,
                       LastUpdateDate = x.LastUpdateDate,
                       CreateDate = x.CreateDate,
                       Settings_Tarah_Logo_Image=x.Settings_Tarah_Logo_Image,
                       Settings_Tarah_FullName=x.Settings_Tarah_FullName,
                       Settings_Tarah_Title=x.Settings_Tarah_Title,
                       Settings_Tarah_Href=x.Settings_Tarah_Href


                   }).ToListAsync(cancellationToken);
            return result;
        }

        public  IPagedList<SettingsCopyRight> ShowAllSettingsCopyRight_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10)
        {
            var result = TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
               new SettingsCopyRight()
               {
                   UserId = x.UserId,
                   Id = x.Id,
                   LastUpdateDate = x.LastUpdateDate,
                   CreateDate = x.CreateDate,
                   Settings_Tarah_Logo_Image = x.Settings_Tarah_Logo_Image,
                   Settings_Tarah_FullName = x.Settings_Tarah_FullName,
                   Settings_Tarah_Title = x.Settings_Tarah_Title,
                   Settings_Tarah_Href = x.Settings_Tarah_Href

               }).ToPagedList(currentPage, number_showproduct);
                    return result;
        }
 
    }
}
