using Common;
using Data.Context;
using Data.Dto;
using Data.ViewModel;
using Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
    public class SettingsLogoService : Repository<SettingsLogo>, ISettingsLogoesService
    {
        public SettingsLogoService(AppDbContext context) : base(context)
        {
        }

        public async Task AddSettingsLogoAsync(SettingsLogoDto SettingsLogoDto, CancellationToken cancellationToken)
        {
            try
            {
                #region Image
                string filePathSettings_Image_Logo = "/images/default.png";
                string filePathSettings_Image_Logo_Footer = "/images/default.png";
                string filePathSettings_Icon_Path = "/images/default.png";


                //check is exist AvatarImage
                if (SettingsLogoDto?.Settings_Image_Logo?.Length > 0)
                {
                    filePathSettings_Image_Logo = AddImage("noname", "settingsLogo", SettingsLogoDto?.Settings_Image_Logo, cancellationToken);
                }

                if (SettingsLogoDto?.Settings_Image_Logo_Footer?.Length > 0)
                {
                    filePathSettings_Image_Logo_Footer = AddImage("noname", "settingsLogo", SettingsLogoDto?.Settings_Image_Logo_Footer, cancellationToken);
                }


                if (SettingsLogoDto?.Settings_Icon_Path?.Length > 0)
                {
                    filePathSettings_Icon_Path = AddFile("Settings_Icon_Path", "setting", SettingsLogoDto?.Settings_Icon_Path, cancellationToken);
                }
                #endregion
                #region Save Customerpage
                var SettingsLogo = new SettingsLogo()
                {
                    Settings_alt_Logo = SettingsLogoDto.Settings_alt_Logo,
                    Settings_title_Logo = SettingsLogoDto.Settings_title_Logo,
                    Settings_Icon_Path = filePathSettings_Icon_Path,
                    Settings_Image_Logo = filePathSettings_Image_Logo,
                    Settings_Image_Logo_Footer = filePathSettings_Image_Logo_Footer,
                    UserId = SettingsLogoDto.UserId,
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now

                };
                await AddAsync(SettingsLogo, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateSettingsLogoAsync(SettingsLogoDto SettingsLogoDto, string _Settings_Image_Logo, string _Settings_Image_Logo_Footer, string _Settings_Icon_Path, CancellationToken cancellationToken)
        {
            var _SettingsLogo = await GetByIdAsync(cancellationToken, SettingsLogoDto.Id);

            #region Save Image
            string filePathSettings_Image_Logo = "/images/default.png";
            string filePathSettings_Image_LogoBefore = "/images/default.png";
            //===============================================//
            string filePathSettings_Image_Logo_Footer = "/images/default.png";
            string filePathSettings_Image_Logo_FooterBefore = "/images/default.png";
            //===============================================//
            string filePathSettings_Icon_Path = "/images/default.png";
            string filePathSettings_Icon_PathBefore = "/images/default.png";
            //check is exist AvatarImage

            if (SettingsLogoDto?.Settings_Image_Logo?.Length > 0)
            {
                filePathSettings_Image_Logo = AddImage("noname", "settingsLogo", SettingsLogoDto?.Settings_Image_Logo, cancellationToken);
                MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_SettingsLogo.Settings_Image_Logo));
            }
            if (SettingsLogoDto?.Settings_Image_Logo == null && _Settings_Image_Logo != null)
                filePathSettings_Image_LogoBefore = _Settings_Image_Logo;
            //============================================================//
            if (SettingsLogoDto?.Settings_Image_Logo_Footer?.Length > 0)
            {
                filePathSettings_Image_Logo_Footer = AddImage("noname", "settingsLogo", SettingsLogoDto?.Settings_Image_Logo_Footer, cancellationToken);
                MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_SettingsLogo.Settings_Image_Logo_Footer));
            }
            if (SettingsLogoDto?.Settings_Image_Logo_Footer == null && _Settings_Image_Logo_Footer != null)
                filePathSettings_Image_Logo_FooterBefore = _Settings_Image_Logo_Footer;
            //============================================================//
            if (SettingsLogoDto?.Settings_Icon_Path?.Length > 0)
            {
                filePathSettings_Icon_Path = AddFile("noname", "settingsLogo", SettingsLogoDto?.Settings_Icon_Path, cancellationToken);
                MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_SettingsLogo.Settings_Icon_Path));

            }
            if (SettingsLogoDto?.Settings_Icon_Path == null && _Settings_Icon_Path != null)
                filePathSettings_Icon_PathBefore = _Settings_Icon_Path;



            #endregion
            #region Save Customerpage

            #region Properties
            _SettingsLogo.Settings_alt_Logo = SettingsLogoDto.Settings_alt_Logo;
            _SettingsLogo.Settings_title_Logo = SettingsLogoDto.Settings_title_Logo;
            _SettingsLogo.UserId = SettingsLogoDto.UserId;
            _SettingsLogo.CreateDate = _SettingsLogo.CreateDate;
            _SettingsLogo.LastUpdateDate = DateTime.Now;
            #endregion

            #region Save Image
            if (SettingsLogoDto.Settings_Image_Logo != null)
                _SettingsLogo.Settings_Image_Logo = filePathSettings_Image_Logo;
            else if (SettingsLogoDto.Settings_Image_Logo == null && !string.IsNullOrEmpty(_Settings_Image_Logo))
                _SettingsLogo.Settings_Image_Logo = filePathSettings_Image_LogoBefore;
            else
                _SettingsLogo.Settings_Image_Logo = filePathSettings_Image_Logo;
            //==============================================//
            if (SettingsLogoDto.Settings_Image_Logo_Footer != null)
                _SettingsLogo.Settings_Image_Logo_Footer = filePathSettings_Image_Logo_Footer;
            else if (SettingsLogoDto.Settings_Image_Logo_Footer == null && !string.IsNullOrEmpty(_Settings_Image_Logo_Footer))
                _SettingsLogo.Settings_Image_Logo_Footer = filePathSettings_Image_Logo_FooterBefore;
            else
                _SettingsLogo.Settings_Image_Logo_Footer = filePathSettings_Image_Logo_Footer;
            //==============================================//
            if (SettingsLogoDto.Settings_Icon_Path != null)
                _SettingsLogo.Settings_Icon_Path = filePathSettings_Icon_Path;
            else if (SettingsLogoDto.Settings_Icon_Path == null && !string.IsNullOrEmpty(_Settings_Icon_Path))
                _SettingsLogo.Settings_Icon_Path = filePathSettings_Icon_PathBefore;
            else
                _SettingsLogo.Settings_Icon_Path = filePathSettings_Icon_Path;
            #endregion



            await UpdateAsync(_SettingsLogo, cancellationToken);
            #endregion       
        }

        public SettingsLogo ShowAllSettingsLogo()
        {
            var result = TableNoTracking.Select(x =>
                   new SettingsLogo()
                   {

                       UserId = x.UserId,
                       Settings_title_Logo = x.Settings_title_Logo,
                       Settings_Image_Logo = x.Settings_Image_Logo,
                       Settings_Image_Logo_Footer = x.Settings_Image_Logo_Footer

                   }).FirstOrDefault();
            return result;
        }

        public async Task<SettingsLogo> ShowAllSettingsLogoAsync()
        {
            var result = await TableNoTracking.Select(x =>
                  new SettingsLogo()
                  {

                      UserId = x.UserId,
                      Settings_title_Logo = x.Settings_title_Logo,
                      Settings_Image_Logo = x.Settings_Image_Logo,
                      Settings_Image_Logo_Footer = x.Settings_Image_Logo_Footer

                  }).FirstOrDefaultAsync();
            return result;
        }


        public IPagedList<SettingsLogo> ShowAllSettingsLogo_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10)
        {
            var result = TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
               new SettingsLogo()
               {
                   UserId = x.UserId,
                   Id = x.Id,
                   LastUpdateDate = x.LastUpdateDate,
                   CreateDate = x.CreateDate,
                   Settings_title_Logo = x.Settings_title_Logo,
                   Settings_Image_Logo = x.Settings_Image_Logo,
                   Settings_Image_Logo_Footer = x.Settings_Image_Logo_Footer

               }).ToPagedList(currentPage, number_showproduct);
            return result;
        }

    }
}
