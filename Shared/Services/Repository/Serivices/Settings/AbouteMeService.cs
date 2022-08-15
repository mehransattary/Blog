using Common;
using Data.Context;
using Data.Dto;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Service.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using X.PagedList;

namespace Service.Repository
{
    public class AbouteMeService : Repository<AbouteMe>, IAbouteMeService
    {
        public AbouteMeService(AppDbContext context) : base(context)
        {
        }

        public async Task AddAbouteMeAsync(AbouteMeDto abouteMeDto, CancellationToken cancellationToken)
        {
            try
            {
                string filePathAbouteMe_ImageDto = "/images/default.png";
                if (abouteMeDto?.AbouteMe_Image?.Length > 0)
                {
                    filePathAbouteMe_ImageDto = AddImage("noname", "AbouteMe", abouteMeDto?.AbouteMe_Image, cancellationToken);
                }
                #region Save Customerpage
                var abouteMe = new AbouteMe()
                {
                    AbouteMe_Text = abouteMeDto.AbouteMe_Text,
                    AbouteMe_Image = filePathAbouteMe_ImageDto,
                    UserId = abouteMeDto.UserId,
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    //=============BaseMetaTag=====================//
                    Title_Meta = abouteMeDto.Title_Meta,
                    TitleEnglish_Meta = abouteMeDto.TitleEnglish_Meta,
                    Url_Meta = abouteMeDto.Url_Meta.ToLower().Trim().Replace(' ', '-'),
                    Desc_Meta = abouteMeDto.Desc_Meta,
                    Canonical_Meta = abouteMeDto.Canonical_Meta,
                    Keyword_Meta = abouteMeDto.Keyword_Meta,
                    Image_Meta = filePathAbouteMe_ImageDto,
                    //===========================================//
                };
                await AddAsync(abouteMe, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAbouteMeAsync(AbouteMeDto abouteMeDto, string _AbouteMe_Image, CancellationToken cancellationToken)
        {
            var _abouteMe = await TableNoTracking.SingleOrDefaultAsync(x => x.Id == abouteMeDto.Id, cancellationToken);
            #region Save Image
            string filePathabouteMe = "/images/default.png";
            string filePathabouteMeBefore = "/images/default.png";
            if (abouteMeDto?.AbouteMe_Image?.Length > 0)
            {
                filePathabouteMe = AddImage("noname", "AbouteMe", abouteMeDto?.AbouteMe_Image, cancellationToken);
                MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_abouteMe.AbouteMe_Image));
            }
            if (abouteMeDto?.AbouteMe_Image == null && _AbouteMe_Image != null)
                filePathabouteMeBefore = _AbouteMe_Image;
            #endregion
            #region Save abouteMe

            #region Properties

            _abouteMe.AbouteMe_Text = abouteMeDto.AbouteMe_Text;
            _abouteMe.UserId = abouteMeDto.UserId;
            _abouteMe.CreateDate = _abouteMe.CreateDate;
            _abouteMe.LastUpdateDate = DateTime.Now;

            _abouteMe.Title_Meta = abouteMeDto.Title_Meta;
            _abouteMe.TitleEnglish_Meta = abouteMeDto.TitleEnglish_Meta;
            _abouteMe.Url_Meta = _abouteMe.Url_Meta;
            _abouteMe.Desc_Meta = _abouteMe.Desc_Meta;
            _abouteMe.Canonical_Meta = _abouteMe.Canonical_Meta;
            _abouteMe.Keyword_Meta = _abouteMe.Keyword_Meta;

            #endregion
            #region Save Image
            if (abouteMeDto.AbouteMe_Image != null)
                _abouteMe.AbouteMe_Image = filePathabouteMe;
            else if (abouteMeDto.AbouteMe_Image == null && !string.IsNullOrEmpty(_AbouteMe_Image))
                _abouteMe.AbouteMe_Image = filePathabouteMeBefore;
            else
                _abouteMe.AbouteMe_Image = filePathabouteMe;
            //==============================================//
            if (abouteMeDto.Image_Meta != null)
                _abouteMe.Image_Meta = filePathabouteMe;
            else if (abouteMeDto.Image_Meta == null && !string.IsNullOrEmpty(_AbouteMe_Image))
                _abouteMe.Image_Meta = filePathabouteMeBefore;
            else
                _abouteMe.Image_Meta = filePathabouteMe;
            #endregion
            await UpdateAsync(_abouteMe, cancellationToken);
            #endregion       
        }

        public async Task<IList<AbouteMe>> ShowAllAbouteMeAsync(CancellationToken cancellationToken, string UserId)
        {
            var result = await TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
                   new AbouteMe()
                   {
                       UserId = x.UserId,
                       Id = x.Id,
                       LastUpdateDate = x.LastUpdateDate,
                       CreateDate = x.CreateDate,
                       AbouteMe_Image = x.AbouteMe_Image,
                       AbouteMe_Text = x.AbouteMe_Text,


                   }).ToListAsync(cancellationToken);
            return result;
        }
        public async Task<AbouteMe> ShowAllAbouteMeAsync(CancellationToken cancellationToken)
        {
            var result = await TableNoTracking.Select(x =>
                   new AbouteMe()
                   {
                       UserId = x.UserId,
                       Id = x.Id,
                       LastUpdateDate = x.LastUpdateDate,
                       CreateDate = x.CreateDate,
                       AbouteMe_Image = x.AbouteMe_Image,
                       AbouteMe_Text = x.AbouteMe_Text,


                   }).FirstOrDefaultAsync(cancellationToken);
            return result;
        }
        public AbouteMe ShowAllAbouteMe()
        {
            var result = TableNoTracking.Select(x =>
                   new AbouteMe()
                   {
                       UserId = x.UserId,
                       Id = x.Id,
                       LastUpdateDate = x.LastUpdateDate,
                       CreateDate = x.CreateDate,
                       AbouteMe_Image = x.AbouteMe_Image,
                       AbouteMe_Text = x.AbouteMe_Text,


                   }).FirstOrDefault();
            return result;
        }

        public IPagedList<AbouteMe> ShowAllAbouteMe_PagingAsync(CancellationToken cancellationToken,
            string UserId, int currentPage = 0, int number_showproduct = 10)
        {


            var result = TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
            new AbouteMe()
            {
                UserId = x.UserId,
                Id = x.Id,
                LastUpdateDate = x.LastUpdateDate,
                CreateDate = x.CreateDate,
                AbouteMe_Image = x.AbouteMe_Image,

            }).ToPagedList(currentPage, number_showproduct);
            return result;

        }

    }
}
