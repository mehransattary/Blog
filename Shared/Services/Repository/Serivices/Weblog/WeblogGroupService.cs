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

    public class WeblogGroupService : Repository<WebLog_Group>, IWeblogGroupService
    {

        public WeblogGroupService(AppDbContext context) : base(context)
        {
        }
        public async Task<bool> CheckRepeatUrlMeta(string Url_Meta)
        {
            var isUrl_Meta =await TableNoTracking.FirstOrDefaultAsync(x => x.Url_Meta == Url_Meta);
            if (isUrl_Meta!=null)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> CheckRepeatOrder(short order)
        {
            var isUrl_Meta = await TableNoTracking.FirstOrDefaultAsync(x => x.WebLog_Group_Order == order);
            if (isUrl_Meta != null)
            {
                return true;
            }
            return false;
        }
        public async Task AddWebLog_GroupAsync(WebLog_GroupDto WebLog_GroupDto, CancellationToken cancellationToken)
        {
            try
            {

                #region CheckRepeatShortLink
                string random_shortlink = RandomNumber.Random(100000, 190000).ToString();
                bool result = TableNoTracking.Any(x => x.WebLog_Group_ShortLink == random_shortlink);         
                while (result)
                {
                   random_shortlink = RandomNumber.Random(100000, 190000).ToString();
                }
                #endregion
                #region Save AvatarImage + IconImage
                string filePathWebLog_Group_Image = "/images/default.png";
                string filePathWebLog_Group_ImageHome = "/images/default.png";
                string filePathWebLog_Group_ThumbnaillImage = "/images/default.png";
                string filePathWebLog_Image_Meta = "/images/default.png";

                //check is exist AvatarImage
                if (WebLog_GroupDto?.WebLog_Group_Image?.Length > 0)
                {
                    filePathWebLog_Group_Image = AddImage("noname", "WebLog_Group", WebLog_GroupDto?.WebLog_Group_Image, cancellationToken);
                }
                if (WebLog_GroupDto?.WebLog_Group_ImageHome?.Length > 0)
                {
                    filePathWebLog_Group_ImageHome = AddImage("noname", "WebLog_Group", WebLog_GroupDto?.WebLog_Group_ImageHome, cancellationToken);
                }
                if (WebLog_GroupDto?.WebLog_Group_ThumbnaillImage?.Length > 0)
                {
                    filePathWebLog_Group_ThumbnaillImage = AddImage("noname", "WebLog_Group", WebLog_GroupDto?.WebLog_Group_ThumbnaillImage, cancellationToken);
                }
                if (WebLog_GroupDto?.Image_Meta?.Length > 0)
                {
                    filePathWebLog_Image_Meta = AddImage("noname", "WebLog_Group", WebLog_GroupDto?.Image_Meta, cancellationToken);
                }
                #endregion
                #region Save Customerpage
                var WebLog_Group = new WebLog_Group()
                {

                    WebLog_Group_IsShow = WebLog_GroupDto.WebLog_Group_IsShow,
                    WebLog_Group_ShortDescription = WebLog_GroupDto.WebLog_Group_ShortDescription,
                    WebLog_Group_ShortLink = random_shortlink,
                    WebLog_Group_Description = WebLog_GroupDto.WebLog_Group_Description,
                    WebLog_Group_Image = filePathWebLog_Group_Image,
                    WebLog_Group_ImageHome = filePathWebLog_Group_ImageHome,
                    WebLog_Group_ThumbnaillImage = filePathWebLog_Group_ThumbnaillImage,
                    WebLog_Group_Order = WebLog_GroupDto.WebLog_Group_Order,
                    WebLog_Group_Title_One = WebLog_GroupDto.WebLog_Group_Title_One,
                    WebLog_Group_Title_Two = WebLog_GroupDto.WebLog_Group_Title_Two,
                    WebLog_Group_CategoryId = WebLog_GroupDto.WebLog_Group_CategoryId,

                    //=======Meta Tags==========//
                    Title_Meta = WebLog_GroupDto.Title_Meta,
                    TitleEnglish_Meta = WebLog_GroupDto.TitleEnglish_Meta,
                    Url_Meta = WebLog_GroupDto.Url_Meta,
                    Desc_Meta = WebLog_GroupDto.Desc_Meta,
                    Canonical_Meta = WebLog_GroupDto.Canonical_Meta,
                    Keyword_Meta = WebLog_GroupDto.Keyword_Meta,
                    Image_Meta = filePathWebLog_Image_Meta,
                    //=======Meta Tags==========//


                    UserId = WebLog_GroupDto.UserId,
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now

                };
                await AddAsync(WebLog_Group, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateWebLog_GroupAsync(WebLog_GroupDto WebLog_GroupDto, string _WebLog_Group_Image, string _WebLog_Group_ImageHome, string _WebLog_Group_ThumbnaillImage,string _Image_Meta, CancellationToken cancellationToken)
        {
            try
            {
                var _WebLog_Group = await GetByIdAsync(cancellationToken, WebLog_GroupDto.Id);
  
                #region Save AvatarImage + IconImage
                string filePathWebLog_Group_Image = "/images/default.png";
                string filePathWebLog_Group_ImageHome = "/images/default.png";
                string filePathWebLog_Group_ThumbnaillImage = "/images/default.png";
                string filePathWebLog_Image_Meta = "/images/default.png";

                string Before_filePathWebLog_Group_Image = "/images/default.png";
                string Before_filePathWebLog_Group_ImageHome = "/images/default.png";
                string Before_filePathWebLog_Group_ThumbnaillImage = "/images/default.png";
                string Before_filePathWebLog_Image_Meta = "/images/default.png";

                //check is exist AvatarImage



                if (WebLog_GroupDto?.WebLog_Group_Image?.Length > 0)
                {
                    filePathWebLog_Group_Image = AddImage("noname", "WebLog_Group", WebLog_GroupDto?.WebLog_Group_Image, cancellationToken);
                    MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_WebLog_Group.WebLog_Group_Image));

                }
                if (WebLog_GroupDto?.WebLog_Group_ImageHome?.Length > 0)
                {
                    filePathWebLog_Group_ImageHome = AddImage("noname", "WebLog_Group", WebLog_GroupDto?.WebLog_Group_ImageHome, cancellationToken);
                    MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_WebLog_Group.WebLog_Group_ImageHome));

                }
                if (WebLog_GroupDto?.WebLog_Group_ThumbnaillImage?.Length > 0)
                {
                    filePathWebLog_Group_ThumbnaillImage = AddImage("noname", "WebLog_Group", WebLog_GroupDto?.WebLog_Group_ThumbnaillImage, cancellationToken);
                    MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_WebLog_Group.WebLog_Group_ThumbnaillImage));

                }
                if (WebLog_GroupDto?.Image_Meta?.Length > 0)
                {
                    filePathWebLog_Image_Meta = AddImage("noname", "WebLog_Group", WebLog_GroupDto?.Image_Meta, cancellationToken);
                    MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_WebLog_Group.Image_Meta));

                }
                if (WebLog_GroupDto?.WebLog_Group_Image == null && _WebLog_Group_Image != null)
                    Before_filePathWebLog_Group_Image = _WebLog_Group_Image;
                if (WebLog_GroupDto?.WebLog_Group_ImageHome == null && _WebLog_Group_ImageHome != null)
                    Before_filePathWebLog_Group_ImageHome = _WebLog_Group_ImageHome;
                if (WebLog_GroupDto?.WebLog_Group_ThumbnaillImage == null && _WebLog_Group_ThumbnaillImage != null)
                    Before_filePathWebLog_Group_ThumbnaillImage = _WebLog_Group_ThumbnaillImage;
                if (WebLog_GroupDto?.Image_Meta == null && _Image_Meta != null)
                    Before_filePathWebLog_Image_Meta = _Image_Meta;
                #endregion
                #region Save Customerpage

                #region Properties

                _WebLog_Group.WebLog_Group_IsShow = WebLog_GroupDto.WebLog_Group_IsShow;
                _WebLog_Group.WebLog_Group_ShortDescription = WebLog_GroupDto.WebLog_Group_ShortDescription;
                _WebLog_Group.WebLog_Group_ShortLink = _WebLog_Group.WebLog_Group_ShortLink;
              
                _WebLog_Group.WebLog_Group_Description = WebLog_GroupDto.WebLog_Group_Description;
                _WebLog_Group.WebLog_Group_Image = filePathWebLog_Group_Image;
                _WebLog_Group.WebLog_Group_ImageHome = filePathWebLog_Group_ImageHome;
                _WebLog_Group.WebLog_Group_ThumbnaillImage = filePathWebLog_Group_ThumbnaillImage;
                _WebLog_Group.WebLog_Group_Order = WebLog_GroupDto.WebLog_Group_Order;
                _WebLog_Group.WebLog_Group_Title_One = WebLog_GroupDto.WebLog_Group_Title_One;
                _WebLog_Group.WebLog_Group_Title_Two = WebLog_GroupDto.WebLog_Group_Title_Two;
                _WebLog_Group.UserId = WebLog_GroupDto.UserId;
                _WebLog_Group.WebLog_Group_CategoryId = WebLog_GroupDto.WebLog_Group_CategoryId;


                //=======Meta Tags==========//
                _WebLog_Group.Title_Meta = WebLog_GroupDto.Title_Meta;
                _WebLog_Group.TitleEnglish_Meta = WebLog_GroupDto.TitleEnglish_Meta;
                _WebLog_Group.Url_Meta = WebLog_GroupDto.Url_Meta;
                _WebLog_Group.Desc_Meta = WebLog_GroupDto.Desc_Meta;
                _WebLog_Group.Canonical_Meta = WebLog_GroupDto.Canonical_Meta;
                _WebLog_Group.Keyword_Meta = WebLog_GroupDto.Keyword_Meta;
                //=======Meta Tags==========//



                _WebLog_Group.CreateDate = _WebLog_Group.CreateDate;
                _WebLog_Group.LastUpdateDate = DateTime.Now;
                #endregion

                #region Save WebLog_Group_Image
                if (WebLog_GroupDto.WebLog_Group_Image != null)
                    _WebLog_Group.WebLog_Group_Image = filePathWebLog_Group_Image;
                else if (WebLog_GroupDto.WebLog_Group_Image == null && !string.IsNullOrEmpty(_WebLog_Group_Image))
                    _WebLog_Group.WebLog_Group_Image = Before_filePathWebLog_Group_Image;
                else
                    _WebLog_Group.WebLog_Group_Image = filePathWebLog_Group_Image;
                #endregion

                #region Save WebLog_Group_ImageHome
                if (WebLog_GroupDto.WebLog_Group_ImageHome != null)
                    _WebLog_Group.WebLog_Group_ImageHome = filePathWebLog_Group_ImageHome;
                else if (WebLog_GroupDto.WebLog_Group_ImageHome == null && !string.IsNullOrEmpty(_WebLog_Group_ImageHome))
                    _WebLog_Group.WebLog_Group_ImageHome = Before_filePathWebLog_Group_ImageHome;
                else
                    _WebLog_Group.WebLog_Group_ImageHome = filePathWebLog_Group_ImageHome;
                #endregion

                #region Save WebLog_Group_ThumbnaillImage
                if (WebLog_GroupDto.WebLog_Group_ThumbnaillImage != null)
                    _WebLog_Group.WebLog_Group_ThumbnaillImage = filePathWebLog_Group_ThumbnaillImage;
                else if (WebLog_GroupDto.WebLog_Group_ThumbnaillImage == null && !string.IsNullOrEmpty(_WebLog_Group_ThumbnaillImage))
                    _WebLog_Group.WebLog_Group_ThumbnaillImage = Before_filePathWebLog_Group_ThumbnaillImage;
                else
                    _WebLog_Group.WebLog_Group_ThumbnaillImage = filePathWebLog_Group_ThumbnaillImage;
                #endregion

                #region Save Image_Meta
                if (WebLog_GroupDto.Image_Meta != null)
                    _WebLog_Group.Image_Meta = filePathWebLog_Image_Meta;
                else if (WebLog_GroupDto.Image_Meta == null && !string.IsNullOrEmpty(_Image_Meta))
                    _WebLog_Group.Image_Meta = Before_filePathWebLog_Image_Meta;
                else
                    _WebLog_Group.Image_Meta = filePathWebLog_Image_Meta;
                #endregion


                await UpdateAsync(_WebLog_Group, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<WebLog_Group>> ShowAllWeblogGroupAsync(CancellationToken cancellationToken)
        {

            var result = await TableNoTracking.Select(x =>
          new WebLog_Group()
          {
         
              WebLog_Group_IsShow = x.WebLog_Group_IsShow,
              WebLog_Group_ShortLink = x.WebLog_Group_ShortLink,            
              WebLog_Group_Image = x.WebLog_Group_Image,
              WebLog_Group_ImageHome = x.WebLog_Group_ImageHome,
              WebLog_Group_ThumbnaillImage = x.WebLog_Group_ThumbnaillImage,
              WebLog_Group_Order = x.WebLog_Group_Order,
              WebLog_Group_Title_One = x.WebLog_Group_Title_One,
              WebLog_Group_Title_Two = x.WebLog_Group_Title_Two,
          
              Id = x.Id,
              LastUpdateDate = x.LastUpdateDate,
              CreateDate = x.CreateDate,
              WebLog_Group_CategoryId = x.WebLog_Group_CategoryId


          }).ToListAsync(cancellationToken);
            return result;
        }
        public IPagedList<WebLog_Group> ShowAllWeblogGroup_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10)
        {
            var result = TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
             new WebLog_Group()
             {
             
                 WebLog_Group_IsShow = x.WebLog_Group_IsShow,
                 WebLog_Group_ShortLink = x.WebLog_Group_ShortLink,            
                 WebLog_Group_ThumbnaillImage = x.WebLog_Group_ThumbnaillImage,
                 WebLog_Group_Order = x.WebLog_Group_Order,
                 WebLog_Group_Title_One = x.WebLog_Group_Title_One,
                 WebLog_Group_Title_Two = x.WebLog_Group_Title_Two,
                 Id = x.Id,
                 LastUpdateDate = x.LastUpdateDate,
                 CreateDate = x.CreateDate,
                 WebLog_Group_CategoryId=x.WebLog_Group_CategoryId

             }).ToPagedList(currentPage, number_showproduct);
            return result;
        }
        public IPagedList<WebLog_Group> ShowAllWeblogGroup_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10,int categoryId=0)
        {
            var result = TableNoTracking.Where(x => x.UserId == UserId&&x.WebLog_Group_CategoryId== categoryId).Select(x =>
             new WebLog_Group()
             {

                 WebLog_Group_IsShow = x.WebLog_Group_IsShow,
                 WebLog_Group_ShortLink = x.WebLog_Group_ShortLink,              
                 WebLog_Group_ThumbnaillImage = x.WebLog_Group_ThumbnaillImage,
                 WebLog_Group_Order = x.WebLog_Group_Order,
                 WebLog_Group_Title_One = x.WebLog_Group_Title_One,
                 WebLog_Group_Title_Two = x.WebLog_Group_Title_Two,
                 Id = x.Id,
                 LastUpdateDate = x.LastUpdateDate,
                 CreateDate = x.CreateDate

             }).ToPagedList(currentPage, number_showproduct);
            return result;
        }
        public async Task<IList<WebLog_Group>> SelectListAsync(CancellationToken cancellationToken, string UserId)
        {
            var result = await TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
            new WebLog_Group()
            {

                Id = x.Id,
                WebLog_Group_Title_One = x.WebLog_Group_Title_One


            }).ToListAsync(cancellationToken);
            return result;
        }
        public async Task<IList<WebLog_Group>> SelectListAsync(CancellationToken cancellationToken, string UserId,int groupId=0)
        {
            var result = await TableNoTracking.Where(x => x.UserId == UserId && x.Id== groupId).Select(x =>
            new WebLog_Group()
            {

                Id = x.Id,
                WebLog_Group_Title_One = x.WebLog_Group_Title_One


            }).ToListAsync(cancellationToken);
            return result;
        }


    }
}
