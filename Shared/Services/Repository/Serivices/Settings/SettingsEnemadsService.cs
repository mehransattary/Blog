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
    public class SettingsEnemadService : Repository<SettingsEnemad>, ISettingsEnemadsService
    {
        public SettingsEnemadService(AppDbContext context) : base(context)
        {
        }

        public  async Task AddSettingsEnemadAsync(SettingsEnemadDto SettingsEnemadDto, CancellationToken cancellationToken)
        {
            try
            {
                #region Image
                string filePathSettings_Image_Enemad = "/images/default.png";

                //check is exist AvatarImage
                if (SettingsEnemadDto?.Settings_Image_Enemad?.Length > 0)
                {
                    filePathSettings_Image_Enemad = AddImage("noname", "settingsEnemad", SettingsEnemadDto?.Settings_Image_Enemad, cancellationToken);
                }

                #endregion
                #region Save Customerpage
                var SettingsEnemad = new SettingsEnemad()
                {
                    Settings_href_Enemad = SettingsEnemadDto.Settings_href_Enemad,
                    Settings_Image_Enemad= filePathSettings_Image_Enemad,
                    Settings_IsExist_Enemad = SettingsEnemadDto.Settings_IsExist_Enemad,
                    Settings_Title_Enemad = SettingsEnemadDto.Settings_Title_Enemad,

                    UserId = SettingsEnemadDto.UserId,
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now

                };
                await AddAsync(SettingsEnemad, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }   

        public async Task UpdateSettingsEnemadAsync(SettingsEnemadDto SettingsEnemadDto, string _Settings_Image_Enemad, CancellationToken cancellationToken)
        {
            var _SettingsEnemad = await GetByIdAsync(cancellationToken, SettingsEnemadDto.Id);

            #region Save Image
            string filePathSettings_Image_Enemad = "/images/default.png";
            string filePathSettings_Image_EnemadBefore = "/images/default.png";
            //check is exist AvatarImage

            if (SettingsEnemadDto?.Settings_Image_Enemad?.Length > 0)
            {
                filePathSettings_Image_Enemad = AddImage("noname", "settingsEnemad", SettingsEnemadDto?.Settings_Image_Enemad, cancellationToken);
                MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_SettingsEnemad.Settings_Image_Enemad));
            }
            if (SettingsEnemadDto?.Settings_Image_Enemad == null && _Settings_Image_Enemad != null)
                filePathSettings_Image_EnemadBefore = _Settings_Image_Enemad;



            #endregion
            #region Save Customerpage

            #region Properties
            _SettingsEnemad.Settings_href_Enemad = SettingsEnemadDto.Settings_href_Enemad;
            _SettingsEnemad.Settings_Image_Enemad = filePathSettings_Image_Enemad;
            _SettingsEnemad.Settings_IsExist_Enemad = SettingsEnemadDto.Settings_IsExist_Enemad;
            _SettingsEnemad.Settings_Title_Enemad = SettingsEnemadDto.Settings_Title_Enemad;
            _SettingsEnemad.UserId = SettingsEnemadDto.UserId;
            _SettingsEnemad.CreateDate = _SettingsEnemad.CreateDate;
            _SettingsEnemad.LastUpdateDate = DateTime.Now;
            #endregion

            #region Save Image
            if (SettingsEnemadDto.Settings_Image_Enemad != null)
                _SettingsEnemad.Settings_Image_Enemad = filePathSettings_Image_Enemad;
            else if (SettingsEnemadDto.Settings_Image_Enemad == null && !string.IsNullOrEmpty(_Settings_Image_Enemad))
                _SettingsEnemad.Settings_Image_Enemad = filePathSettings_Image_EnemadBefore;
            else
                _SettingsEnemad.Settings_Image_Enemad = filePathSettings_Image_Enemad;
            #endregion



            await UpdateAsync(_SettingsEnemad, cancellationToken);
            #endregion        
        }

        public async Task<IList<SettingsEnemad>> ShowAllSettingsEnemadAsync(CancellationToken cancellationToken, string UserId)
        {
            var result = await TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
                   new SettingsEnemad()
                   {
                       UserId = x.UserId,
                       Id = x.Id,
                       LastUpdateDate = x.LastUpdateDate,
                       CreateDate = x.CreateDate,
                       Settings_Title_Enemad=x.Settings_Title_Enemad,
                       Settings_Image_Enemad=x.Settings_Image_Enemad,
                       Settings_IsExist_Enemad=x.Settings_IsExist_Enemad

                   }).ToListAsync(cancellationToken);
            return result;
        }

        public  IPagedList<SettingsEnemad> ShowAllSettingsEnemad_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10)
        {
            var result = TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
               new SettingsEnemad()
               {
                   UserId = x.UserId,
                   Id = x.Id,
                   LastUpdateDate = x.LastUpdateDate,
                   CreateDate = x.CreateDate,
                   Settings_Title_Enemad = x.Settings_Title_Enemad,
                   Settings_Image_Enemad = x.Settings_Image_Enemad,
                   Settings_IsExist_Enemad = x.Settings_IsExist_Enemad

               }).ToPagedList(currentPage, number_showproduct);
                    return result;
        }
 
    }
}
