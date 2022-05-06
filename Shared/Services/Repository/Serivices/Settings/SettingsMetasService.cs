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
    public class SettingsMetaService : Repository<SettingsMeta>, ISettingsMetasService
    {
        public SettingsMetaService(AppDbContext context) : base(context)
        {
        }

        public  async Task AddSettingsMetaAsync(SettingsMetaDto SettingsMetaDto, CancellationToken cancellationToken)
        {
            try
            {
                #region Image
                string filePathSettings_twitter_image = "/images/default.png";
                string filePathSettings_ogimage = "/images/default.png";

                //check is exist AvatarImage
                if (SettingsMetaDto?.Settings_twitter_image?.Length > 0)
                {
                    filePathSettings_twitter_image = AddImage("noname", "settingsMeta", SettingsMetaDto?.Settings_twitter_image, cancellationToken);
                }

                if (SettingsMetaDto?.Settings_ogimage?.Length > 0)
                {
                    filePathSettings_ogimage = AddImage("noname", "settingsMeta", SettingsMetaDto?.Settings_ogimage, cancellationToken);
                }
                #endregion
                #region Save Customerpage
                var SettingsMeta = new SettingsMeta()
                {
                    Settings_author = SettingsMetaDto.Settings_author,
                    Settings_description = SettingsMetaDto.Settings_description,
                    Settings_Google_Analytics = SettingsMetaDto.Settings_Google_Analytics,
                    Settings_twitter_description = SettingsMetaDto.Settings_twitter_description,
                    Settings_canonical = SettingsMetaDto.Settings_canonical,
                    Settings_keywords = SettingsMetaDto.Settings_keywords,
                    Settings_ogdescription = SettingsMetaDto.Settings_ogdescription,
                    Settings_ogurl = SettingsMetaDto.Settings_ogurl,
                    Settings_ogtitle = SettingsMetaDto.Settings_ogtitle,
                    Settings_ogsite_name = SettingsMetaDto.Settings_ogsite_name,
                    Settings_Search_Console = SettingsMetaDto.Settings_Search_Console,
                    Settings_Service_Adver_1 = SettingsMetaDto.Settings_Service_Adver_1,
                    Settings_Service_Adver_2 = SettingsMetaDto.Settings_Service_Adver_2,
                    Settings_Service_Adver_3 = SettingsMetaDto.Settings_Service_Adver_3,
                    Settings_Service_Adver_4 = SettingsMetaDto.Settings_Service_Adver_4,
                    Settings_twitter_image = filePathSettings_twitter_image,
                    Settings_ogimage = filePathSettings_ogimage,

                    UserId = SettingsMetaDto.UserId,
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now

                };
                await AddAsync(SettingsMeta, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }   

        public async Task UpdateSettingsMetaAsync(SettingsMetaDto SettingsMetaDto, string _Settings_twitter_image,string _Settings_ogimage, CancellationToken cancellationToken)
        {
            var _SettingsMeta = await GetByIdAsync(cancellationToken, SettingsMetaDto.Id);

            #region Save Image
            string filePathSettings_twitter_image = "/images/default.png";
            string filePathSettings_twitter_imageBefore = "/images/default.png";
            //===================================================================//
            string filePathSettings_ogimag = "/images/default.png";
            string filePathSettings_ogimageBefore = "/images/default.png";
            //check is exist AvatarImage

            if (SettingsMetaDto?.Settings_twitter_image?.Length > 0)
            {
                filePathSettings_twitter_image = AddImage("noname", "settingsMeta", SettingsMetaDto?.Settings_twitter_image, cancellationToken);
                MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_SettingsMeta.Settings_twitter_image));
            }
            if (SettingsMetaDto?.Settings_twitter_image == null && _Settings_twitter_image != null)
                filePathSettings_twitter_imageBefore = _Settings_twitter_image;
            //===================================================================//
            if (SettingsMetaDto?.Settings_ogimage?.Length > 0)
            {
                filePathSettings_ogimag = AddImage("noname", "settingsMeta", SettingsMetaDto?.Settings_ogimage, cancellationToken);
                MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_SettingsMeta.Settings_ogimage));
            }
            if (SettingsMetaDto?.Settings_ogimage == null && _Settings_ogimage != null)
                filePathSettings_ogimageBefore = _Settings_ogimage;

            #endregion
            #region Save Customerpage

            #region Properties
            _SettingsMeta.Settings_author = SettingsMetaDto.Settings_author;
            _SettingsMeta.Settings_description = SettingsMetaDto.Settings_description;
            _SettingsMeta.Settings_Google_Analytics = SettingsMetaDto.Settings_Google_Analytics;
            _SettingsMeta.Settings_twitter_description = SettingsMetaDto.Settings_twitter_description;
            _SettingsMeta.Settings_canonical = SettingsMetaDto.Settings_canonical;
            _SettingsMeta.Settings_keywords = SettingsMetaDto.Settings_keywords;
            _SettingsMeta.Settings_ogdescription = SettingsMetaDto.Settings_ogdescription;
            _SettingsMeta.Settings_ogurl = SettingsMetaDto.Settings_ogurl;
            _SettingsMeta.Settings_ogtitle = SettingsMetaDto.Settings_ogtitle;
            _SettingsMeta.Settings_ogsite_name = SettingsMetaDto.Settings_ogsite_name;
            _SettingsMeta.Settings_Search_Console = SettingsMetaDto.Settings_Search_Console;
            _SettingsMeta.Settings_Service_Adver_1 = SettingsMetaDto.Settings_Service_Adver_1;
            _SettingsMeta.Settings_Service_Adver_2 = SettingsMetaDto.Settings_Service_Adver_2;
            _SettingsMeta.Settings_Service_Adver_3 = SettingsMetaDto.Settings_Service_Adver_3;
            _SettingsMeta.Settings_Service_Adver_4 = SettingsMetaDto.Settings_Service_Adver_4;
            _SettingsMeta.UserId = SettingsMetaDto.UserId;
            _SettingsMeta.CreateDate = _SettingsMeta.CreateDate;
            _SettingsMeta.LastUpdateDate = DateTime.Now;
            #endregion

            #region Save Image
            if (SettingsMetaDto.Settings_twitter_image != null)
                _SettingsMeta.Settings_twitter_image = filePathSettings_twitter_image;
            else if (SettingsMetaDto.Settings_twitter_image == null && !string.IsNullOrEmpty(_Settings_twitter_image))
                _SettingsMeta.Settings_twitter_image = filePathSettings_twitter_imageBefore;
            else
                _SettingsMeta.Settings_twitter_image = filePathSettings_twitter_image;
            //==============================================//
            if (SettingsMetaDto.Settings_ogimage != null)
                _SettingsMeta.Settings_ogimage = filePathSettings_ogimag;
            else if (SettingsMetaDto.Settings_ogimage == null && !string.IsNullOrEmpty(_Settings_ogimage))
                _SettingsMeta.Settings_ogimage = filePathSettings_ogimageBefore;
            else
                _SettingsMeta.Settings_ogimage = filePathSettings_ogimag;
            #endregion



            await UpdateAsync(_SettingsMeta, cancellationToken);
            #endregion     
        }

        public async Task<IList<SettingsMeta>> ShowAllSettingsMetaAsync(CancellationToken cancellationToken, string UserId)
        {
            var result = await TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
                   new SettingsMeta()
                   {
                      Settings_ogsite_name=x.Settings_ogsite_name,
                      Settings_ogimage= x.Settings_ogimage,
                      Settings_twitter_image=x.Settings_twitter_image,
                       UserId = x.UserId,
                       Id = x.Id,
                       LastUpdateDate = x.LastUpdateDate,
                       CreateDate = x.CreateDate,

                   }).ToListAsync(cancellationToken);
            return result;
        }

        public  IPagedList<SettingsMeta> ShowAllSettingsMeta_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10)
        {
            var result = TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
               new SettingsMeta()
               {
                   Settings_ogsite_name = x.Settings_ogsite_name,
                   Settings_ogimage = x.Settings_ogimage,
                   Settings_twitter_image = x.Settings_twitter_image,
                   UserId = x.UserId,
                   Id = x.Id,
                   LastUpdateDate = x.LastUpdateDate,
                   CreateDate = x.CreateDate,

               }).ToPagedList(currentPage, number_showproduct);
                    return result;
        }
 
    }
}
