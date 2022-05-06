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
    public class SettingsService : Repository<Settings>, ISettingsService
    {
        public SettingsService(AppDbContext context) : base(context)
        {
        }

        public  async Task AddSettingsAsync(SettingsDto SettingsDto, CancellationToken cancellationToken)
        {
            try
            {
                #region Image
                string filePathSettings_ImageFooter = "/images/default.png";
                string filePathSettings_ImageTopMain = "/images/default.png";

                //check is exist AvatarImage
                if (SettingsDto?.Settings_ImageFooter?.Length > 0)
                {
                    filePathSettings_ImageFooter = AddImage("noname", "settings", SettingsDto?.Settings_ImageFooter, cancellationToken);
                }
                if (SettingsDto?.Settings_ImageTopMain?.Length > 0)
                {
                    filePathSettings_ImageTopMain = AddImage("noname", "settings", SettingsDto?.Settings_ImageTopMain, cancellationToken);
                }
                #endregion
                #region Save Customerpage
                var Settings = new Settings()
                {
                   Settings_Address= SettingsDto.Settings_Address,
                   Settings_Email= SettingsDto.Settings_Email,
                   Settings_HelperSell= SettingsDto.Settings_HelperSell,
                   Settings_ImageFooter= filePathSettings_ImageFooter,
                   Settings_ImageTopMain= filePathSettings_ImageTopMain,
                   Settings_Mobile= SettingsDto.Settings_Mobile,
                   Settings_Questions= SettingsDto.Settings_Questions,
                   Settings_Sitename= SettingsDto.Settings_Sitename,
                   Settings_Tell= SettingsDto.Settings_Tell,
                    UserId = SettingsDto.UserId,
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now

                };
                await AddAsync(Settings, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }   

        public async Task UpdateSettingsAsync(SettingsDto SettingsDto, string _Settings_ImageFooter, string _Settings_ImageTopMain, CancellationToken cancellationToken)
        {
            var _Settings = await GetByIdAsync(cancellationToken, SettingsDto.Id);

            #region Save Image
            string filePathSettings_ImageFooter = "/images/default.png";
            string filePathSettings_ImageFooterBefore = "/images/default.png";

            string filePathSettings_ImageTopMain = "/images/default.png";
            string filePathSettings_ImageTopMainBefore = "/images/default.png";
            //check is exist AvatarImage

            if (SettingsDto?.Settings_ImageFooter?.Length > 0)
            {
                filePathSettings_ImageFooter = AddImage("noname", "settings", SettingsDto?.Settings_ImageFooter, cancellationToken);
                MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_Settings.Settings_ImageFooter));
            }
            if (SettingsDto?.Settings_ImageFooter == null && _Settings_ImageFooter != null)
                filePathSettings_ImageFooterBefore = _Settings_ImageFooter;

            if (SettingsDto?.Settings_ImageTopMain?.Length > 0)
            {
                filePathSettings_ImageTopMain = AddImage("noname", "settings", SettingsDto?.Settings_ImageTopMain, cancellationToken);
                MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_Settings.Settings_ImageTopMain));
            }
            if (SettingsDto?.Settings_ImageTopMain == null && _Settings_ImageTopMain != null)
                filePathSettings_ImageTopMainBefore = _Settings_ImageTopMain;

            #endregion
            #region Save Customerpage

            #region Properties
            _Settings.Settings_Address = SettingsDto.Settings_Address;
            _Settings.Settings_Email = SettingsDto.Settings_Email;
            _Settings.Settings_HelperSell = SettingsDto.Settings_HelperSell;
            _Settings.Settings_ImageFooter = filePathSettings_ImageFooter;
            _Settings.Settings_ImageTopMain = filePathSettings_ImageTopMain;
            _Settings.Settings_Mobile = SettingsDto.Settings_Mobile;
            _Settings.Settings_Questions = SettingsDto.Settings_Questions;
            _Settings.Settings_Sitename = SettingsDto.Settings_Sitename;
            _Settings.Settings_Tell = SettingsDto.Settings_Tell;
            _Settings.UserId = SettingsDto.UserId;
            _Settings.CreateDate = _Settings.CreateDate;
            _Settings.LastUpdateDate = DateTime.Now;
            #endregion

            #region Save Image
            if (SettingsDto.Settings_ImageFooter != null)
                _Settings.Settings_ImageFooter = filePathSettings_ImageFooter;
            else if (SettingsDto.Settings_ImageFooter == null && !string.IsNullOrEmpty(_Settings_ImageFooter))
                _Settings.Settings_ImageFooter = filePathSettings_ImageFooterBefore;
            else
                _Settings.Settings_ImageFooter = filePathSettings_ImageFooter;
            //================================================//
            if (SettingsDto.Settings_ImageTopMain != null)
                _Settings.Settings_ImageTopMain = filePathSettings_ImageTopMain;
            else if (SettingsDto.Settings_ImageTopMain == null && !string.IsNullOrEmpty(_Settings_ImageTopMain))
                _Settings.Settings_ImageTopMain = filePathSettings_ImageTopMainBefore;
            else
                _Settings.Settings_ImageTopMain = filePathSettings_ImageTopMain;
            #endregion



            await UpdateAsync(_Settings, cancellationToken);
            #endregion     
  
        }

        public async Task<IList<Settings>> ShowAllSettingsAsync(CancellationToken cancellationToken, string UserId)
        {
            var result = await TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
                   new Settings()
                   {
                      
                       Settings_ImageFooter = x.Settings_ImageFooter,
                       Settings_ImageTopMain = x.Settings_ImageTopMain,
                       Settings_Mobile = x.Settings_Mobile,
                       Settings_Sitename = x.Settings_Sitename,
                       Settings_Tell = x.Settings_Tell,
                       UserId = x.UserId,
                       Id = x.Id,
                       LastUpdateDate = x.LastUpdateDate,
                       CreateDate = x.CreateDate,


                   }).ToListAsync(cancellationToken);
            return result;
        }

        public  IPagedList<Settings> ShowAllSettings_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10)
        {
            var result = TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
               new Settings()
               {
                   Settings_ImageFooter = x.Settings_ImageFooter,
                   Settings_ImageTopMain = x.Settings_ImageTopMain,
                   Settings_Mobile = x.Settings_Mobile,
                   Settings_Sitename = x.Settings_Sitename,
                   Settings_Tell = x.Settings_Tell,
                   UserId = x.UserId,
                   Id = x.Id,
                   LastUpdateDate = x.LastUpdateDate,
                   CreateDate = x.CreateDate,

               }).ToPagedList(currentPage, number_showproduct);
                    return result;
        }
 
    }
}
