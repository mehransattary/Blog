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

    public class WeblogCategoryService : Repository<WebLog_Category>, IWeblogCategoryService
    {

        public WeblogCategoryService(AppDbContext context) : base(context)
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
        public string CheckIsExistGroupInCategory(int categoryId)
        {
            string errors = "";
           
            var isExistGroup = DbContext.WebLog_Groups.Where(x => x.WebLog_Group_CategoryId == categoryId);
            if (isExistGroup != null)
            {
                foreach (var item in isExistGroup.Select(x => new WebLog_Group() { WebLog_Group_Title_One = x.WebLog_Group_Title_One }).ToList())
                {
                    errors += "✔" + item.WebLog_Group_Title_One + "\n";
                }
                return errors;

            }
            return errors;
        }
        public async Task<bool> CheckRepeatOrder(short order)
        {
            var isUrl_Meta = await TableNoTracking.FirstOrDefaultAsync(x => x.WebLog_Category_Order == order);
            if (isUrl_Meta != null)
            {
                return true;
            }
            return false;
        }
        public async Task AddWebLog_CategoryAsync(WebLog_CategoryDto WebLog_CategoryDto, CancellationToken cancellationToken)
        {
            try
            {
                #region CheckRepeatShortLink
                string random_shortlink = RandomNumber.Random(100000,190000).ToString();
                bool result = TableNoTracking.Any(x => x.WebLog_Category_ShortLink == random_shortlink);
                while (result)
                {
                    random_shortlink = RandomNumber.Random(100000, 190000).ToString();
                }
                #endregion
                #region Save AvatarImage + IconImage
                string filePathWebLog_Category_Image = "/images/default.png";
                string filePathWebLog_Category_ImageHome = "/images/default.png";
                string filePathWebLog_Category_ThumbnaillImage = "/images/default.png";
                string filePathWebLog_Image_Meta = "/images/default.png";

                //check is exist AvatarImage
                if (WebLog_CategoryDto?.WebLog_Category_Image?.Length > 0)
                {
                    filePathWebLog_Category_Image = AddImage("noname", "WebLog_Category", WebLog_CategoryDto?.WebLog_Category_Image, cancellationToken);
                }
                if (WebLog_CategoryDto?.WebLog_Category_ImageHome?.Length > 0)
                {
                    filePathWebLog_Category_ImageHome = AddImage("noname", "WebLog_Category", WebLog_CategoryDto?.WebLog_Category_ImageHome, cancellationToken);
                }
                if (WebLog_CategoryDto?.WebLog_Category_ThumbnaillImage?.Length > 0)
                {
                    filePathWebLog_Category_ThumbnaillImage = AddImage("noname", "WebLog_Category", WebLog_CategoryDto?.WebLog_Category_ThumbnaillImage, cancellationToken);
                }
                if (WebLog_CategoryDto?.Image_Meta?.Length > 0)
                {
                    filePathWebLog_Image_Meta = AddImage("noname", "WebLog_Category", WebLog_CategoryDto?.Image_Meta, cancellationToken);
                }
                #endregion
                #region Save Customerpage
                var WebLog_Category = new WebLog_Category()
                {

                    WebLog_Category_IsShow = WebLog_CategoryDto.WebLog_Category_IsShow,
                    WebLog_Category_ShortDescription = WebLog_CategoryDto.WebLog_Category_ShortDescription,
                    WebLog_Category_ShortLink = random_shortlink,
                    WebLog_Category_Description = WebLog_CategoryDto.WebLog_Category_Description,
                    WebLog_Category_Image = filePathWebLog_Category_Image,
                    WebLog_Category_ImageHome = filePathWebLog_Category_ImageHome,
                    WebLog_Category_ThumbnaillImage = filePathWebLog_Category_ThumbnaillImage,
                    WebLog_Category_Order = WebLog_CategoryDto.WebLog_Category_Order,
                    WebLog_Category_Title_One = WebLog_CategoryDto.WebLog_Category_Title_One,
                    WebLog_Category_Title_Two = WebLog_CategoryDto.WebLog_Category_Title_Two,

                    //=======Meta Tags==========//
                    Title_Meta = WebLog_CategoryDto.Title_Meta,
                    TitleEnglish_Meta = WebLog_CategoryDto.TitleEnglish_Meta,
                    Url_Meta = WebLog_CategoryDto.Url_Meta,
                    Desc_Meta = WebLog_CategoryDto.Desc_Meta,
                    Canonical_Meta = WebLog_CategoryDto.Canonical_Meta,
                    Keyword_Meta = WebLog_CategoryDto.Keyword_Meta,
                    Image_Meta = filePathWebLog_Image_Meta,
                    //=======Meta Tags==========//


                    UserId = WebLog_CategoryDto.UserId,
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now

                };
                await AddAsync(WebLog_Category, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateWebLog_CategoryAsync(WebLog_CategoryDto WebLog_CategoryDto, string _WebLog_Category_Image, string _WebLog_Category_ImageHome, string _WebLog_Category_ThumbnaillImage, string _Image_Meta, CancellationToken cancellationToken)
        {
            try
            {
                var _WebLog_Category = await GetByIdAsync(cancellationToken, WebLog_CategoryDto.Id);
 
                #region Save AvatarImage + IconImage
                string filePathWebLog_Category_Image = "/images/default.png";
                string filePathWebLog_Category_ImageHome = "/images/default.png";
                string filePathWebLog_Category_ThumbnaillImage = "/images/default.png";
                string filePathWebLog_Image_Meta = "/images/default.png";

                string Before_filePathWebLog_Category_Image = "/images/default.png";
                string Before_filePathWebLog_Category_ImageHome = "/images/default.png";
                string Before_filePathWebLog_Category_ThumbnaillImage = "/images/default.png";
                string Before_filePathWebLog_Image_Meta = "/images/default.png";

                //check is exist AvatarImage



                if (WebLog_CategoryDto?.WebLog_Category_Image?.Length > 0)
                {
                    filePathWebLog_Category_Image = AddImage("noname", "WebLog_Category", WebLog_CategoryDto?.WebLog_Category_Image, cancellationToken);
                    MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_WebLog_Category.WebLog_Category_Image));

                }
                if (WebLog_CategoryDto?.WebLog_Category_ImageHome?.Length > 0)
                {
                    filePathWebLog_Category_ImageHome = AddImage("noname", "WebLog_Category", WebLog_CategoryDto?.WebLog_Category_ImageHome, cancellationToken);
                    MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_WebLog_Category.WebLog_Category_ImageHome));

                }
                if (WebLog_CategoryDto?.WebLog_Category_ThumbnaillImage?.Length > 0)
                {
                    filePathWebLog_Category_ThumbnaillImage = AddImage("noname", "WebLog_Category", WebLog_CategoryDto?.WebLog_Category_ThumbnaillImage, cancellationToken);
                    MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_WebLog_Category.WebLog_Category_ThumbnaillImage));

                }
                if (WebLog_CategoryDto?.Image_Meta?.Length > 0)
                {
                    filePathWebLog_Image_Meta = AddImage("noname", "WebLog_Category", WebLog_CategoryDto?.Image_Meta, cancellationToken);
                    MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_WebLog_Category.Image_Meta));

                }
                if (WebLog_CategoryDto?.WebLog_Category_Image == null && _WebLog_Category_Image != null)
                    Before_filePathWebLog_Category_Image = _WebLog_Category_Image;
                if (WebLog_CategoryDto?.WebLog_Category_ImageHome == null && _WebLog_Category_ImageHome != null)
                    Before_filePathWebLog_Category_ImageHome = _WebLog_Category_ImageHome;
                if (WebLog_CategoryDto?.WebLog_Category_ThumbnaillImage == null && _WebLog_Category_ThumbnaillImage != null)
                    Before_filePathWebLog_Category_ThumbnaillImage = _WebLog_Category_ThumbnaillImage;
                if (WebLog_CategoryDto?.Image_Meta == null && _Image_Meta != null)
                    Before_filePathWebLog_Image_Meta = _Image_Meta;
                #endregion
                #region Save Customerpage

                #region Properties

                _WebLog_Category.WebLog_Category_IsShow = WebLog_CategoryDto.WebLog_Category_IsShow;
                _WebLog_Category.WebLog_Category_ShortDescription = WebLog_CategoryDto.WebLog_Category_ShortDescription;
                _WebLog_Category.WebLog_Category_ShortLink = _WebLog_Category.WebLog_Category_ShortLink;

                _WebLog_Category.WebLog_Category_Description = WebLog_CategoryDto.WebLog_Category_Description;
                _WebLog_Category.WebLog_Category_Image = filePathWebLog_Category_Image;
                _WebLog_Category.WebLog_Category_ImageHome = filePathWebLog_Category_ImageHome;
                _WebLog_Category.WebLog_Category_ThumbnaillImage = filePathWebLog_Category_ThumbnaillImage;
                _WebLog_Category.WebLog_Category_Order = WebLog_CategoryDto.WebLog_Category_Order;
                _WebLog_Category.WebLog_Category_Title_One = WebLog_CategoryDto.WebLog_Category_Title_One;
                _WebLog_Category.WebLog_Category_Title_Two = WebLog_CategoryDto.WebLog_Category_Title_Two;
                _WebLog_Category.UserId = WebLog_CategoryDto.UserId;

                //=======Meta Tags==========//
                _WebLog_Category.Title_Meta = WebLog_CategoryDto.Title_Meta;
                _WebLog_Category.TitleEnglish_Meta = WebLog_CategoryDto.TitleEnglish_Meta;
                _WebLog_Category.Url_Meta = WebLog_CategoryDto.Url_Meta;
                _WebLog_Category.Desc_Meta = WebLog_CategoryDto.Desc_Meta;
                _WebLog_Category.Canonical_Meta = WebLog_CategoryDto.Canonical_Meta;
                _WebLog_Category.Keyword_Meta = WebLog_CategoryDto.Keyword_Meta;
                //=======Meta Tags==========//



                _WebLog_Category.CreateDate = _WebLog_Category.CreateDate;
                _WebLog_Category.LastUpdateDate = DateTime.Now;
                #endregion

                #region Save WebLog_Category_Image
                if (WebLog_CategoryDto.WebLog_Category_Image != null)
                    _WebLog_Category.WebLog_Category_Image = filePathWebLog_Category_Image;
                else if (WebLog_CategoryDto.WebLog_Category_Image == null && !string.IsNullOrEmpty(_WebLog_Category_Image))
                    _WebLog_Category.WebLog_Category_Image = Before_filePathWebLog_Category_Image;
                else
                    _WebLog_Category.WebLog_Category_Image = filePathWebLog_Category_Image;
                #endregion

                #region Save WebLog_Category_ImageHome
                if (WebLog_CategoryDto.WebLog_Category_ImageHome != null)
                    _WebLog_Category.WebLog_Category_ImageHome = filePathWebLog_Category_ImageHome;
                else if (WebLog_CategoryDto.WebLog_Category_ImageHome == null && !string.IsNullOrEmpty(_WebLog_Category_ImageHome))
                    _WebLog_Category.WebLog_Category_ImageHome = Before_filePathWebLog_Category_ImageHome;
                else
                    _WebLog_Category.WebLog_Category_ImageHome = filePathWebLog_Category_ImageHome;
                #endregion

                #region Save WebLog_Category_ThumbnaillImage
                if (WebLog_CategoryDto.WebLog_Category_ThumbnaillImage != null)
                    _WebLog_Category.WebLog_Category_ThumbnaillImage = filePathWebLog_Category_ThumbnaillImage;
                else if (WebLog_CategoryDto.WebLog_Category_ThumbnaillImage == null && !string.IsNullOrEmpty(_WebLog_Category_ThumbnaillImage))
                    _WebLog_Category.WebLog_Category_ThumbnaillImage = Before_filePathWebLog_Category_ThumbnaillImage;
                else
                    _WebLog_Category.WebLog_Category_ThumbnaillImage = filePathWebLog_Category_ThumbnaillImage;
                #endregion

                #region Save Image_Meta
                if (WebLog_CategoryDto.Image_Meta != null)
                    _WebLog_Category.Image_Meta = filePathWebLog_Image_Meta;
                else if (WebLog_CategoryDto.Image_Meta == null && !string.IsNullOrEmpty(_Image_Meta))
                    _WebLog_Category.Image_Meta = Before_filePathWebLog_Image_Meta;
                else
                    _WebLog_Category.Image_Meta = filePathWebLog_Image_Meta;
                #endregion


                await UpdateAsync(_WebLog_Category, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<WebLog_Category>> ShowAllWeblogCategoryAsync(CancellationToken cancellationToken, string UserId)
        {

            var result = await TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
          new WebLog_Category()
          {

              WebLog_Category_IsShow = x.WebLog_Category_IsShow,
              WebLog_Category_ShortLink = x.WebLog_Category_ShortLink,

              WebLog_Category_Image = x.WebLog_Category_Image,
              WebLog_Category_ImageHome = x.WebLog_Category_ImageHome,
              WebLog_Category_ThumbnaillImage = x.WebLog_Category_ThumbnaillImage,
              WebLog_Category_Order = x.WebLog_Category_Order,
              WebLog_Category_Title_One = x.WebLog_Category_Title_One,
              WebLog_Category_Title_Two = x.WebLog_Category_Title_Two,
              Id = x.Id,
              LastUpdateDate = x.LastUpdateDate,
              CreateDate = x.CreateDate


          }).ToListAsync(cancellationToken);
            return result;
        }
        public IPagedList<WebLog_Category> ShowAllWeblogCategory_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10)
        {
            var result = TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
             new WebLog_Category()
             {

                 WebLog_Category_IsShow = x.WebLog_Category_IsShow,
                 WebLog_Category_ShortLink = x.WebLog_Category_ShortLink,

                 WebLog_Category_Image = x.WebLog_Category_Image,
                 WebLog_Category_ImageHome = x.WebLog_Category_ImageHome,
                 WebLog_Category_ThumbnaillImage = x.WebLog_Category_ThumbnaillImage,
                 WebLog_Category_Order = x.WebLog_Category_Order,
                 WebLog_Category_Title_One = x.WebLog_Category_Title_One,
                 WebLog_Category_Title_Two = x.WebLog_Category_Title_Two,
                 Id = x.Id,
                 LastUpdateDate = x.LastUpdateDate,
                 CreateDate = x.CreateDate

             }).ToPagedList(currentPage, number_showproduct);
            return result;
        }

        public async Task<IList<WebLog_Category>>  SelectListAsync(CancellationToken cancellationToken, string UserId)
        {
            var result = await TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
            new WebLog_Category()
            {

             Id=x.Id,
             WebLog_Category_Title_One=x.WebLog_Category_Title_One


            }).ToListAsync(cancellationToken);
                return result;
        }
        public async Task<IList<WebLog_Category>> SelectListAsync(CancellationToken cancellationToken, string UserId,int categoryId=0)
        {
            var result = await TableNoTracking.Where(x => x.UserId == UserId&&x.Id== categoryId).Select(x =>
            new WebLog_Category()
            {

                Id = x.Id,
                WebLog_Category_Title_One = x.WebLog_Category_Title_One


            }).ToListAsync(cancellationToken);
            return result;
        }
    }
}
