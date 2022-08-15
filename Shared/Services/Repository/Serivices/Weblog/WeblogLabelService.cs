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

    public class WeblogLabelService : Repository<WebLog_Label>, IWeblogLabelService
    {

        public WeblogLabelService(AppDbContext context) : base(context)
        {
        }
        public async Task<bool> CheckRepeatUrlMeta(string Url_Meta)
        {
            var isUrl_Meta = await TableNoTracking.FirstOrDefaultAsync(x => x.Url_Meta == Url_Meta);
            if (isUrl_Meta != null)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> CheckRepeatOrder(short order)
        {
            var isUrl_Meta = await TableNoTracking.FirstOrDefaultAsync(x => x.WebLog_Label_Order == order);
            if (isUrl_Meta != null)
            {
                return true;
            }
            return false;
        }
        public async Task AddWebLog_LabelAsync(WebLog_LabelDto WebLog_LabelDto, CancellationToken cancellationToken)
        {
            try
            {

                #region CheckRepeatShortLink
                string random_shortlink = RandomNumber.Random(100000, 190000).ToString();
                bool result = TableNoTracking.Any(x => x.WebLog_Label_ShortLink == random_shortlink);
                while (result)
                {
                    random_shortlink = RandomNumber.Random(100000, 190000).ToString();
                }
                #endregion
                #region Save AvatarImage + IconImage
                string filePathWebLog_Label_Image = "/images/default.png";
                string filePathWebLog_Label_ImageHome = "/images/default.png";
                string filePathWebLog_Label_ThumbnaillImage = "/images/default.png";
                string filePathWebLog_Image_Meta = "/images/default.png";

                //check is exist AvatarImage
                if (WebLog_LabelDto?.WebLog_Label_Image?.Length > 0)
                {
                    filePathWebLog_Label_Image = AddImage("noname", "WebLog_Label", WebLog_LabelDto?.WebLog_Label_Image, cancellationToken);
                }
                if (WebLog_LabelDto?.WebLog_Label_ImageHome?.Length > 0)
                {
                    filePathWebLog_Label_ImageHome = AddImage("noname", "WebLog_Label", WebLog_LabelDto?.WebLog_Label_ImageHome, cancellationToken);
                }
                if (WebLog_LabelDto?.WebLog_Label_ThumbnaillImage?.Length > 0)
                {
                    filePathWebLog_Label_ThumbnaillImage = AddImage("noname", "WebLog_Label", WebLog_LabelDto?.WebLog_Label_ThumbnaillImage, cancellationToken);
                }
                if (WebLog_LabelDto?.Image_Meta?.Length > 0)
                {
                    filePathWebLog_Image_Meta = AddImage("noname", "WebLog_Label", WebLog_LabelDto?.Image_Meta, cancellationToken);
                }
                #endregion
                #region Save Customerpage
                var WebLog_Label = new WebLog_Label()
                {

                    WebLog_Label_IsShow = WebLog_LabelDto.WebLog_Label_IsShow,
                    WebLog_Label_ShortDescription = WebLog_LabelDto.WebLog_Label_ShortDescription,
                    WebLog_Label_ShortLink = random_shortlink,
                    WebLog_Label_Description = WebLog_LabelDto.WebLog_Label_Description,
                    WebLog_Label_Image = filePathWebLog_Label_Image,
                    WebLog_Label_ImageHome = filePathWebLog_Label_ImageHome,
                    WebLog_Label_ThumbnaillImage = filePathWebLog_Label_ThumbnaillImage,
                    WebLog_Label_Order = WebLog_LabelDto.WebLog_Label_Order,
                    WebLog_Label_Title_One = WebLog_LabelDto.WebLog_Label_Title_One,
                    WebLog_Label_Title_Two = WebLog_LabelDto.WebLog_Label_Title_Two,

                    //=======Meta Tags==========//
                    Title_Meta = WebLog_LabelDto.Title_Meta,
                    TitleEnglish_Meta = WebLog_LabelDto.TitleEnglish_Meta,
                    Url_Meta = WebLog_LabelDto.Url_Meta.ToLower().Trim().Replace(' ', '-'),
                    Desc_Meta = WebLog_LabelDto.Desc_Meta,
                    Canonical_Meta = WebLog_LabelDto.Canonical_Meta,
                    Keyword_Meta = WebLog_LabelDto.Keyword_Meta,
                    Image_Meta = filePathWebLog_Image_Meta,
                    //=======Meta Tags==========//


                    UserId = WebLog_LabelDto.UserId,
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now

                };
                await AddAsync(WebLog_Label, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateWebLog_LabelAsync(WebLog_LabelDto WebLog_LabelDto, string _WebLog_Label_Image, string _WebLog_Label_ImageHome, string _WebLog_Label_ThumbnaillImage, string _Image_Meta, CancellationToken cancellationToken)
        {
            try
            {
                var _WebLog_Label = await GetByIdAsync(cancellationToken, WebLog_LabelDto.Id);

                #region Save AvatarImage + IconImage
                string filePathWebLog_Label_Image = "/images/default.png";
                string filePathWebLog_Label_ImageHome = "/images/default.png";
                string filePathWebLog_Label_ThumbnaillImage = "/images/default.png";
                string filePathWebLog_Image_Meta = "/images/default.png";

                string Before_filePathWebLog_Label_Image = "/images/default.png";
                string Before_filePathWebLog_Label_ImageHome = "/images/default.png";
                string Before_filePathWebLog_Label_ThumbnaillImage = "/images/default.png";
                string Before_filePathWebLog_Image_Meta = "/images/default.png";

                //check is exist AvatarImage



                if (WebLog_LabelDto?.WebLog_Label_Image?.Length > 0)
                {
                    filePathWebLog_Label_Image = AddImage("noname", "WebLog_Label", WebLog_LabelDto?.WebLog_Label_Image, cancellationToken);
                    MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_WebLog_Label.WebLog_Label_Image));

                }
                if (WebLog_LabelDto?.WebLog_Label_ImageHome?.Length > 0)
                {
                    filePathWebLog_Label_ImageHome = AddImage("noname", "WebLog_Label", WebLog_LabelDto?.WebLog_Label_ImageHome, cancellationToken);
                    MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_WebLog_Label.WebLog_Label_ImageHome));

                }
                if (WebLog_LabelDto?.WebLog_Label_ThumbnaillImage?.Length > 0)
                {
                    filePathWebLog_Label_ThumbnaillImage = AddImage("noname", "WebLog_Label", WebLog_LabelDto?.WebLog_Label_ThumbnaillImage, cancellationToken);
                    MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_WebLog_Label.WebLog_Label_ThumbnaillImage));

                }
                if (WebLog_LabelDto?.Image_Meta?.Length > 0)
                {
                    filePathWebLog_Image_Meta = AddImage("noname", "WebLog_Label", WebLog_LabelDto?.Image_Meta, cancellationToken);
                    MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_WebLog_Label.Image_Meta));

                }
                if (WebLog_LabelDto?.WebLog_Label_Image == null && _WebLog_Label_Image != null)
                    Before_filePathWebLog_Label_Image = _WebLog_Label_Image;
                if (WebLog_LabelDto?.WebLog_Label_ImageHome == null && _WebLog_Label_ImageHome != null)
                    Before_filePathWebLog_Label_ImageHome = _WebLog_Label_ImageHome;
                if (WebLog_LabelDto?.WebLog_Label_ThumbnaillImage == null && _WebLog_Label_ThumbnaillImage != null)
                    Before_filePathWebLog_Label_ThumbnaillImage = _WebLog_Label_ThumbnaillImage;
                if (WebLog_LabelDto?.Image_Meta == null && _Image_Meta != null)
                    Before_filePathWebLog_Image_Meta = _Image_Meta;
                #endregion
                #region Save Customerpage

                #region Properties

                _WebLog_Label.WebLog_Label_IsShow = WebLog_LabelDto.WebLog_Label_IsShow;
                _WebLog_Label.WebLog_Label_ShortDescription = WebLog_LabelDto.WebLog_Label_ShortDescription;
                _WebLog_Label.WebLog_Label_ShortLink = _WebLog_Label.WebLog_Label_ShortLink;

                _WebLog_Label.WebLog_Label_Description = WebLog_LabelDto.WebLog_Label_Description;
                _WebLog_Label.WebLog_Label_Image = filePathWebLog_Label_Image;
                _WebLog_Label.WebLog_Label_ImageHome = filePathWebLog_Label_ImageHome;
                _WebLog_Label.WebLog_Label_ThumbnaillImage = filePathWebLog_Label_ThumbnaillImage;
                _WebLog_Label.WebLog_Label_Order = WebLog_LabelDto.WebLog_Label_Order;
                _WebLog_Label.WebLog_Label_Title_One = WebLog_LabelDto.WebLog_Label_Title_One;
                _WebLog_Label.WebLog_Label_Title_Two = WebLog_LabelDto.WebLog_Label_Title_Two;
                _WebLog_Label.UserId = WebLog_LabelDto.UserId;


                //=======Meta Tags==========//
                _WebLog_Label.Title_Meta = WebLog_LabelDto.Title_Meta;
                _WebLog_Label.TitleEnglish_Meta = WebLog_LabelDto.TitleEnglish_Meta;
                _WebLog_Label.Url_Meta = WebLog_LabelDto.Url_Meta.ToLower().Trim().Replace(' ', '-');
                _WebLog_Label.Desc_Meta = WebLog_LabelDto.Desc_Meta;
                _WebLog_Label.Canonical_Meta = WebLog_LabelDto.Canonical_Meta;
                _WebLog_Label.Keyword_Meta = WebLog_LabelDto.Keyword_Meta;
                //=======Meta Tags==========//



                _WebLog_Label.CreateDate = _WebLog_Label.CreateDate;
                _WebLog_Label.LastUpdateDate = DateTime.Now;
                #endregion

                #region Save WebLog_Label_Image
                if (WebLog_LabelDto.WebLog_Label_Image != null)
                    _WebLog_Label.WebLog_Label_Image = filePathWebLog_Label_Image;
                else if (WebLog_LabelDto.WebLog_Label_Image == null && !string.IsNullOrEmpty(_WebLog_Label_Image))
                    _WebLog_Label.WebLog_Label_Image = Before_filePathWebLog_Label_Image;
                else
                    _WebLog_Label.WebLog_Label_Image = filePathWebLog_Label_Image;
                #endregion

                #region Save WebLog_Label_ImageHome
                if (WebLog_LabelDto.WebLog_Label_ImageHome != null)
                    _WebLog_Label.WebLog_Label_ImageHome = filePathWebLog_Label_ImageHome;
                else if (WebLog_LabelDto.WebLog_Label_ImageHome == null && !string.IsNullOrEmpty(_WebLog_Label_ImageHome))
                    _WebLog_Label.WebLog_Label_ImageHome = Before_filePathWebLog_Label_ImageHome;
                else
                    _WebLog_Label.WebLog_Label_ImageHome = filePathWebLog_Label_ImageHome;
                #endregion

                #region Save WebLog_Label_ThumbnaillImage
                if (WebLog_LabelDto.WebLog_Label_ThumbnaillImage != null)
                    _WebLog_Label.WebLog_Label_ThumbnaillImage = filePathWebLog_Label_ThumbnaillImage;
                else if (WebLog_LabelDto.WebLog_Label_ThumbnaillImage == null && !string.IsNullOrEmpty(_WebLog_Label_ThumbnaillImage))
                    _WebLog_Label.WebLog_Label_ThumbnaillImage = Before_filePathWebLog_Label_ThumbnaillImage;
                else
                    _WebLog_Label.WebLog_Label_ThumbnaillImage = filePathWebLog_Label_ThumbnaillImage;
                #endregion

                #region Save Image_Meta
                if (WebLog_LabelDto.Image_Meta != null)
                    _WebLog_Label.Image_Meta = filePathWebLog_Image_Meta;
                else if (WebLog_LabelDto.Image_Meta == null && !string.IsNullOrEmpty(_Image_Meta))
                    _WebLog_Label.Image_Meta = Before_filePathWebLog_Image_Meta;
                else
                    _WebLog_Label.Image_Meta = filePathWebLog_Image_Meta;
                #endregion


                await UpdateAsync(_WebLog_Label, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<WebLog_Label>> ShowAllWeblogLabelAsync(CancellationToken cancellationToken, string UserId)
        {

            var result = await TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
          new WebLog_Label()
          {

              WebLog_Label_IsShow = x.WebLog_Label_IsShow,
              WebLog_Label_ShortLink = x.WebLog_Label_ShortLink,
              WebLog_Label_Image = x.WebLog_Label_Image,
              WebLog_Label_ImageHome = x.WebLog_Label_ImageHome,
              WebLog_Label_ThumbnaillImage = x.WebLog_Label_ThumbnaillImage,
              WebLog_Label_Order = x.WebLog_Label_Order,
              WebLog_Label_Title_One = x.WebLog_Label_Title_One,
              WebLog_Label_Title_Two = x.WebLog_Label_Title_Two,

              Id = x.Id,
              LastUpdateDate = x.LastUpdateDate,
              CreateDate = x.CreateDate


          }).ToListAsync(cancellationToken);
            return result;
        }
        public IPagedList<WebLog_Label> ShowAllWeblogLabel_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10)
        {
            var result = TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
             new WebLog_Label()
             {

                 WebLog_Label_IsShow = x.WebLog_Label_IsShow,
                 WebLog_Label_ShortLink = x.WebLog_Label_ShortLink,
                 WebLog_Label_Image = x.WebLog_Label_Image,
                 WebLog_Label_ImageHome = x.WebLog_Label_ImageHome,
                 WebLog_Label_ThumbnaillImage = x.WebLog_Label_ThumbnaillImage,
                 WebLog_Label_Order = x.WebLog_Label_Order,
                 WebLog_Label_Title_One = x.WebLog_Label_Title_One,
                 WebLog_Label_Title_Two = x.WebLog_Label_Title_Two,
                 Id = x.Id,
                 LastUpdateDate = x.LastUpdateDate,
                 CreateDate = x.CreateDate

             }).ToPagedList(currentPage, number_showproduct);
            return result;
        }


        public async Task<IList<WebLog_Label>> SelectListAsync(CancellationToken cancellationToken, int labelId = 0)
        {
            var result = await TableNoTracking.Where(x=>x.Id== labelId).Select(x =>
          new WebLog_Label()
          {
              Id = x.Id,
              WebLog_Label_Title_One = x.WebLog_Label_Title_One

          }).ToListAsync(cancellationToken);
            return result;
        }

        public async Task<IList<WebLog_Label>> SelectListAsync(CancellationToken cancellationToken)
        {
            var result = await TableNoTracking.Select(x =>
             new WebLog_Label()
             {
                 Id = x.Id,
                 WebLog_Label_Title_One = x.WebLog_Label_Title_One

             }).ToListAsync(cancellationToken);
                    return result;
        }

    }
}
