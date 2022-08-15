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

    public class WeblogService : Repository<WebLog>, IWeblogService
    {

        public WeblogService(AppDbContext context) : base(context)
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
   
        public async Task AddWebLogAsync(WeblogDto WeblogDto, CancellationToken cancellationToken)
        {
            try
            {

                #region CheckRepeatShortLink
                string random_shortlink = RandomNumber.Random(100000, 190000).ToString();
                bool result = TableNoTracking.Any(x => x.Weblog_ShortLink == random_shortlink);
                while (result)
                {
                    random_shortlink = RandomNumber.Random(100000, 190000).ToString();
                }
                #endregion
                #region Save AvatarImage + IconImage
                string filePathWebLog_Image = "/images/default.png";
                string filePathWeblog_Thumbnail_Image = "/images/default.png";
                string filePathWebLog_Image_Meta = "/images/default.png";

                //check is exist AvatarImage
                if (WeblogDto?.Weblog_Image?.Length > 0)
                {
                    filePathWebLog_Image = AddImage("noname", "WebLog", WeblogDto?.Weblog_Image, cancellationToken);
                }
                if (WeblogDto?.Weblog_Thumbnail_Image?.Length > 0)
                {
                    filePathWeblog_Thumbnail_Image = AddImage("noname", "WebLog", WeblogDto?.Weblog_Thumbnail_Image, cancellationToken);
                }
              
                if (WeblogDto?.Image_Meta?.Length > 0)
                {
                    filePathWebLog_Image_Meta = AddImage("noname", "WebLog", WeblogDto?.Image_Meta, cancellationToken);
                }
                #endregion
                #region Save Customerpage
                var WebLog = new WebLog()
                {

                     Weblog_ShortLink= random_shortlink,
                     Weblog_IsShow= WeblogDto.Weblog_IsShow,
                     Weblog_Short_Description= WeblogDto.Weblog_Short_Description,
                     Weblog_Star= WeblogDto.Weblog_Star,
                     Weblog_StudyTime= WeblogDto.Weblog_StudyTime,
                     Weblog_GroupId= WeblogDto.Weblog_GroupId,
                     Weblog_Text= WeblogDto.Weblog_Text,
                     Weblog_Title_One= WeblogDto.Weblog_Title_One,
                     Weblog_Title_Two= WeblogDto.Weblog_Title_Two,
                     Weblog_Writer= WeblogDto.Weblog_Writer,
                     Weblog_Image= filePathWebLog_Image,
                     Weblog_Thumbnail_Image= filePathWeblog_Thumbnail_Image,
                     
                    //=======Meta Tags==========//
                    Title_Meta = WeblogDto.Title_Meta,
                    TitleEnglish_Meta = WeblogDto.TitleEnglish_Meta,
                    Url_Meta = WeblogDto.Url_Meta.ToLower().Trim().Replace(' ', '-'),
                    Desc_Meta = WeblogDto.Desc_Meta,
                    Canonical_Meta = WeblogDto.Canonical_Meta,
                    Keyword_Meta = WeblogDto.Keyword_Meta,
                    Image_Meta = filePathWebLog_Image_Meta,
                    //=======Meta Tags==========//


                    UserId = WeblogDto.UserId,
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now

                };
                await AddAsync(WebLog, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateWebLogAsync(WeblogDto WeblogDto, string _Weblog_Image, string _Weblog_Thumbnail_Image, string _Image_Meta, CancellationToken cancellationToken)
        {
            try
            {
                var _WebLog = await GetByIdAsync(cancellationToken, WeblogDto.Id);
                #region CheckRepeatShortLink
                string random_shortlink = RandomNumber.RandomChars();
                bool result = TableNoTracking.Any(x => x.Weblog_ShortLink == random_shortlink);
                while (result)
                {
                    random_shortlink = RandomNumber.RandomChars();
                }
                #endregion
                #region Save AvatarImage + IconImage
                string filePathWebLog_Image = "/images/default.png";
                string filePathWeblog_Thumbnail_Image = "/images/default.png";
                string filePathWebLog_Image_Meta = "/images/default.png";

                string Before_filePathWebLog_Image = "/images/default.png";
                string Before_filePathWeblog_Thumbnail_Image = "/images/default.png";
                string Before_filePathWebLog_Image_Meta = "/images/default.png";

                //check is exist AvatarImage



                if (WeblogDto?.Weblog_Image?.Length > 0)
                {
                    filePathWebLog_Image = AddImage("noname", "WebLog", WeblogDto?.Weblog_Image, cancellationToken);
                    MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_WebLog.Weblog_Image));

                }
                if (WeblogDto?.Weblog_Thumbnail_Image?.Length > 0)
                {
                    filePathWeblog_Thumbnail_Image = AddImage("noname", "WebLog", WeblogDto?.Weblog_Thumbnail_Image, cancellationToken);
                    MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_WebLog.Weblog_Thumbnail_Image));

                }
            
                if (WeblogDto?.Image_Meta?.Length > 0)
                {
                    filePathWebLog_Image_Meta = AddImage("noname", "WebLog", WeblogDto?.Image_Meta, cancellationToken);
                    MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_WebLog.Image_Meta));

                }
                if (WeblogDto?.Weblog_Image == null && _Weblog_Image != null)
                    Before_filePathWebLog_Image = _Weblog_Image;
                if (WeblogDto?.Weblog_Thumbnail_Image == null && _Weblog_Thumbnail_Image != null)
                    Before_filePathWeblog_Thumbnail_Image = _Weblog_Thumbnail_Image;        
                if (WeblogDto?.Image_Meta == null && _Image_Meta != null)
                    Before_filePathWebLog_Image_Meta = _Image_Meta;
                #endregion
                #region Save Customerpage

                #region Properties

                _WebLog.Weblog_ShortLink = random_shortlink;
                _WebLog.Weblog_IsShow = WeblogDto.Weblog_IsShow;
                _WebLog.Weblog_Short_Description = WeblogDto.Weblog_Short_Description;
                _WebLog.Weblog_Star = WeblogDto.Weblog_Star;
                _WebLog.Weblog_StudyTime = WeblogDto.Weblog_StudyTime;
                _WebLog.Weblog_GroupId = WeblogDto.Weblog_GroupId;
                _WebLog.Weblog_Text = WeblogDto.Weblog_Text;
                _WebLog.Weblog_Title_One = WeblogDto.Weblog_Title_One;
                _WebLog.Weblog_Title_Two = WeblogDto.Weblog_Title_Two;
                _WebLog.Weblog_Writer = WeblogDto.Weblog_Writer;
                _WebLog.UserId = WeblogDto.UserId;


                //=======Meta Tags==========//
                _WebLog.Title_Meta = WeblogDto.Title_Meta;
                _WebLog.TitleEnglish_Meta = WeblogDto.TitleEnglish_Meta;
                _WebLog.Url_Meta = WeblogDto.Url_Meta.ToLower().Trim().Replace(' ', '-');
                _WebLog.Desc_Meta = WeblogDto.Desc_Meta;
                _WebLog.Canonical_Meta = WeblogDto.Canonical_Meta;
                _WebLog.Keyword_Meta = WeblogDto.Keyword_Meta;
                //=======Meta Tags==========//



                _WebLog.CreateDate = _WebLog.CreateDate;
                _WebLog.LastUpdateDate = DateTime.Now;
                #endregion

                #region Save WebLog_Image
                if (WeblogDto.Weblog_Image != null)
                    _WebLog.Weblog_Image = filePathWebLog_Image;
                else if (WeblogDto.Weblog_Image == null && !string.IsNullOrEmpty(_Weblog_Image))
                    _WebLog.Weblog_Image = Before_filePathWebLog_Image;
                else
                    _WebLog.Weblog_Image = filePathWebLog_Image;
                #endregion

                #region Save Weblog_Thumbnail_Image
                if (WeblogDto.Weblog_Thumbnail_Image != null)
                    _WebLog.Weblog_Thumbnail_Image = filePathWeblog_Thumbnail_Image;
                else if (WeblogDto.Weblog_Thumbnail_Image == null && !string.IsNullOrEmpty(_Weblog_Thumbnail_Image))
                    _WebLog.Weblog_Thumbnail_Image = Before_filePathWeblog_Thumbnail_Image;
                else
                    _WebLog.Weblog_Thumbnail_Image = filePathWeblog_Thumbnail_Image;
                #endregion      

                #region Save Image_Meta
                if (WeblogDto.Image_Meta != null)
                    _WebLog.Image_Meta = filePathWebLog_Image_Meta;
                else if (WeblogDto.Image_Meta == null && !string.IsNullOrEmpty(_Image_Meta))
                    _WebLog.Image_Meta = Before_filePathWebLog_Image_Meta;
                else
                    _WebLog.Image_Meta = filePathWebLog_Image_Meta;
                #endregion


                await UpdateAsync(_WebLog, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<WebLog>> ShowAllWeblogAsync(CancellationToken cancellationToken, string UserId)
        {

            var result = await TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
            new WebLog()
          {

            Weblog_IsShow=x.Weblog_IsShow,
            Weblog_ShortLink=x.Weblog_ShortLink,
            Weblog_Star=x.Weblog_Star,
            Weblog_StudyTime=x.Weblog_StudyTime,
            Image_Meta=x.Image_Meta,
            Weblog_Title_One=x.Weblog_Title_One,
            Weblog_Title_Two=x.Weblog_Title_Two,
            Canonical_Meta=x.Canonical_Meta,
            Weblog_Thumbnail_Image=x.Weblog_Thumbnail_Image,
                Weblog_Image = x.Weblog_Image,

                Id = x.Id,
              LastUpdateDate = x.LastUpdateDate,
              CreateDate = x.CreateDate


          }).ToListAsync(cancellationToken);
            return result;
        }
        public async Task<WebLog> ShowWeblogAsync(string url, CancellationToken cancellationToken)
        {
            var result = await TableNoTracking.Where(x => x.Url_Meta == url).Include(x=>x.WebLog_Groups).Select(x =>
           new WebLog()
           {

               Weblog_IsShow = x.Weblog_IsShow,
               Weblog_ShortLink = x.Weblog_ShortLink,
               Weblog_Star = x.Weblog_Star,
               Weblog_StudyTime = x.Weblog_StudyTime,
               Image_Meta = x.Image_Meta,
               Weblog_Title_One = x.Weblog_Title_One,
               Weblog_Title_Two = x.Weblog_Title_Two,
               Title_Meta=x.Title_Meta,
               Weblog_Short_Description=x.Weblog_Short_Description,
               Weblog_Writer=x.Weblog_Writer,
               Canonical_Meta = x.Canonical_Meta,
               Weblog_Thumbnail_Image = x.Weblog_Thumbnail_Image,
               Weblog_Image = x.Weblog_Image,
               Weblog_Text=x.Weblog_Text,
               Id = x.Id,
               LastUpdateDate = x.LastUpdateDate,
               CreateDate = x.CreateDate,
               WebLog_Groups=x.WebLog_Groups


           }).FirstOrDefaultAsync(cancellationToken);
            return result;
        }
        public async Task<IList<WebLog>> ShowSelectedFiveWeblogToMiddleSlidersAsync(CancellationToken cancellationToken)
        {
            var result = await TableNoTracking.Where(x => x.Weblog_IsShow ).Include(x=>x.WebLog_Groups).Select(x =>
          new WebLog()
          {

              Weblog_IsShow = x.Weblog_IsShow,
              Weblog_Star = x.Weblog_Star,
              Weblog_StudyTime = x.Weblog_StudyTime,
              Image_Meta = x.Image_Meta,
              Weblog_Title_One = x.Weblog_Title_One,
              Weblog_Title_Two = x.Weblog_Title_Two,
              Title_Meta=x.Title_Meta,              
              Weblog_Thumbnail_Image = x.Weblog_Thumbnail_Image,
              Id = x.Id,
              LastUpdateDate = x.LastUpdateDate,
              CreateDate = x.CreateDate,
              Url_Meta=x.Url_Meta,
              WebLog_Groups =new WebLog_Group() 
              { 
                Url_Meta=x.WebLog_Groups.Url_Meta,
                Title_Meta=x.Title_Meta,
                WebLog_Group_Title_One=x.Weblog_Title_One,
                WebLog_Group_Title_Two=x.Weblog_Title_Two
              }


          }).OrderByDescending(x=>x.LastUpdateDate).Skip(0).Take(5).ToListAsync(cancellationToken);
            return result;
        }

        public async Task<IList<WebLog>> ShowAllWeblogMainAsync(CancellationToken cancellationToken)
        {
            var result = await TableNoTracking.Where(x => x.Weblog_IsShow).Select(x =>
        new WebLog()
        {

            Weblog_IsShow = x.Weblog_IsShow,        
            Image_Meta = x.Image_Meta,
            Weblog_Title_One = x.Weblog_Title_One,
            Weblog_Title_Two = x.Weblog_Title_Two,
            Title_Meta = x.Title_Meta,
            Weblog_Thumbnail_Image = x.Weblog_Thumbnail_Image,
            Id = x.Id,
            LastUpdateDate = x.LastUpdateDate,
            CreateDate = x.CreateDate,
            Url_Meta = x.Url_Meta,          


        }).OrderByDescending(x => x.LastUpdateDate).Skip(0).Take(10).ToListAsync(cancellationToken);
            return result;
        }
        public IPagedList<WebLog> ShowAllWeblog_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10)
        {
            var result = TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
             new WebLog()
             {

                 Weblog_IsShow = x.Weblog_IsShow,
                 Weblog_ShortLink = x.Weblog_ShortLink,
                 Weblog_Star = x.Weblog_Star,
                 Weblog_StudyTime = x.Weblog_StudyTime,
                 Image_Meta = x.Image_Meta,
                 Weblog_Title_One = x.Weblog_Title_One,
                 Weblog_Title_Two = x.Weblog_Title_Two,
                 Canonical_Meta = x.Canonical_Meta,
                 Weblog_Thumbnail_Image = x.Weblog_Thumbnail_Image,
                 Weblog_Image = x.Weblog_Image,
                 Id = x.Id,
                 LastUpdateDate = x.LastUpdateDate,
                 CreateDate = x.CreateDate

             }).ToPagedList(currentPage, number_showproduct);
            return result;
        }

        public IPagedList<WebLog> ShowAllWeblog_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10,int groupId=0)
        {
            var result = TableNoTracking.Where(x => x.UserId == UserId&& x.Weblog_GroupId==groupId).Select(x =>
             new WebLog()
             {

                 Weblog_IsShow = x.Weblog_IsShow,
                 Weblog_ShortLink = x.Weblog_ShortLink,
                 Weblog_Star = x.Weblog_Star,
                 Weblog_StudyTime = x.Weblog_StudyTime,
                 Image_Meta = x.Image_Meta,
                 Weblog_Title_One = x.Weblog_Title_One,
                 Weblog_Title_Two = x.Weblog_Title_Two,
                 Canonical_Meta = x.Canonical_Meta,
                 Weblog_Thumbnail_Image = x.Weblog_Thumbnail_Image,
                 Weblog_Image = x.Weblog_Image,
                 Id = x.Id,
                 LastUpdateDate = x.LastUpdateDate,
                 CreateDate = x.CreateDate

             }).ToPagedList(currentPage, number_showproduct);
            return result;
        }

        public async Task<IList<WebLog>> SelectListAsync(CancellationToken cancellationToken, int weblogId = 0)
        {
            var result = await TableNoTracking.Where(x => x.Id == weblogId).Select(x =>
              new WebLog()
              {
                  Id = x.Id,
                  Weblog_Title_One = x.Weblog_Title_One

              }).ToListAsync(cancellationToken);
            return result;
        }

        public async Task<IList<WebLog>> SelectListAsync(CancellationToken cancellationToken)
        {
            var result = await TableNoTracking.Select(x =>
              new WebLog()
              {
                  Id = x.Id,
                  Weblog_Title_One = x.Weblog_Title_One

              }).ToListAsync(cancellationToken);
                        return result;
        }
    }
}
