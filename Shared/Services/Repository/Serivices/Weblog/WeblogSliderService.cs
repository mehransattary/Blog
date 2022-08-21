using AutoMapper;
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
    public class WeblogSliderService : Repository<WebLog_Slider>, IWebLog_SliderService
    {
        private readonly IMapper mapper;


        public WeblogSliderService(AppDbContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }
  
        public async Task AddWebLog_SliderAsync(WebLog_SliderDto WebLog_SliderDto, CancellationToken cancellationToken)
        {
            try
            {

                #region CheckRepeatShortLink
        
                #endregion
                #region Save AvatarImage + IconImage
                string filePathWebLog_Slider_Image = "/images/default.png";


                //check is exist AvatarImage
                if (WebLog_SliderDto?.WebLog_Slider_Image?.Length > 0)
                {
                    filePathWebLog_Slider_Image = AddImage("noname", "WebLog_Slider", WebLog_SliderDto?.WebLog_Slider_Image, cancellationToken);
                }

                #endregion
                #region Save Customerpage
                var webLog_Slider = mapper.Map<WebLog_SliderDto, WebLog_Slider>(WebLog_SliderDto);
                webLog_Slider.WebLog_Slider_Image = filePathWebLog_Slider_Image;
                webLog_Slider.LastUpdateDate = DateTime.Now;
                webLog_Slider.CreateDate = DateTime.Now;         
                await AddAsync(webLog_Slider, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateWebLog_SliderAsync(WebLog_SliderDto WebLog_SliderDto, string _WebLog_Slider_Image, CancellationToken cancellationToken)
        {
            try
            {
                var _WebLog_Slider = await TableNoTracking.FirstOrDefaultAsync(x=>x.Id== WebLog_SliderDto.Id);
  
                #region Save AvatarImage + IconImage
                string filePathWebLog_Slider_Image = "/images/default.png";
                string Before_filePathWebLog_Slider_Image_Meta = "/images/default.png";

                //check is exist AvatarImage



                if (WebLog_SliderDto?.WebLog_Slider_Image?.Length > 0)
                {
                    filePathWebLog_Slider_Image = AddImage("noname", "WebLog_Slider", WebLog_SliderDto?.WebLog_Slider_Image, cancellationToken);
                    MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_WebLog_Slider.WebLog_Slider_Image));

                }              
                if (WebLog_SliderDto?.WebLog_Slider_Image == null && _WebLog_Slider_Image != null)
                    Before_filePathWebLog_Slider_Image_Meta = _WebLog_Slider_Image;

                #endregion
                #region Save Customerpage

                #region Properties

                var webLog_Slider = mapper.Map<WebLog_SliderDto, WebLog_Slider>(WebLog_SliderDto);


                webLog_Slider.CreateDate = _WebLog_Slider.CreateDate;
                webLog_Slider.LastUpdateDate = DateTime.Now;
                #endregion

                #region Save WebLog_Slider_Image
                if (WebLog_SliderDto.WebLog_Slider_Image != null)
                    webLog_Slider.WebLog_Slider_Image = filePathWebLog_Slider_Image;
                else if (WebLog_SliderDto.WebLog_Slider_Image == null && !string.IsNullOrEmpty(_WebLog_Slider_Image))
                    webLog_Slider.WebLog_Slider_Image = Before_filePathWebLog_Slider_Image_Meta;
                else
                    webLog_Slider.WebLog_Slider_Image = filePathWebLog_Slider_Image;
                #endregion

              


                await UpdateAsync(webLog_Slider, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<WebLog_Slider>> ShowAllWebLog_SliderAsync(CancellationToken cancellationToken, string UserId)
        {

            var result = await TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
            new WebLog_Slider()
            {


                WebLog_Slider_Image = x.WebLog_Slider_Image,
                WebLog_Slider_Title = x.WebLog_Slider_Title,
                WebLog_Slider_Category_IsActive = x.WebLog_Slider_Category_IsActive,
                WebLog_Slider_Group_IsActive = x.WebLog_Slider_Group_IsActive,
                WebLog_Slider_Blog_IsActive = x.WebLog_Slider_Blog_IsActive,
                WebLog_Slider_Label_IsActive = x.WebLog_Slider_Label_IsActive,
                WebLog_Slider_IsActive = x.WebLog_Slider_IsActive,
                WebLog_Slider_IsActive_TopPage = x.WebLog_Slider_IsActive_TopPage,
                WebLog_Slider_IsActive_MiddlePage = x.WebLog_Slider_IsActive_MiddlePage,
                WebLog_Slider_IsActive_BottomPage = x.WebLog_Slider_IsActive_BottomPage,
                Id = x.Id,
                LastUpdateDate = x.LastUpdateDate,
                CreateDate = x.CreateDate


            }).ToListAsync(cancellationToken);
            return result;
        }

        public async Task<IList<WebLog_Slider>> ShowSliderTopForBlogAsync(CancellationToken cancellationToken)
        {
            var result = await TableNoTracking.Where(x=>x.WebLog_Slider_IsActive && x.WebLog_Slider_IsActive_TopPage).Include(x => x.webLog).ThenInclude(x=>x.WebLog_Groups).Include(x=>x.webLog_Label).Include(x => x.webLog_Category).Include(x => x.WebLog_Group).Select(x =>
           new WebLog_Slider()
           {

               WebLog_Slider_Image = x.WebLog_Slider_Image,
               WebLog_Slider_Title = x.WebLog_Slider_Title,
               WebLog_Slider_Category_IsActive = x.WebLog_Slider_Category_IsActive,
               WebLog_Slider_Group_IsActive = x.WebLog_Slider_Group_IsActive,
               WebLog_Slider_Blog_IsActive = x.WebLog_Slider_Blog_IsActive,
               WebLog_Slider_Label_IsActive = x.WebLog_Slider_Label_IsActive,
               WebLog_Slider_IsActive = x.WebLog_Slider_IsActive,
               WebLog_Slider_IsActive_TopPage = x.WebLog_Slider_IsActive_TopPage,
               WebLog_Slider_IsActive_MiddlePage = x.WebLog_Slider_IsActive_MiddlePage,
               WebLog_Slider_IsActive_BottomPage = x.WebLog_Slider_IsActive_BottomPage,
               webLog_Label =new WebLog_Label() 
               {
                   WebLog_Label_Title_Two = x.webLog_Label.WebLog_Label_Title_Two,
                   WebLog_Label_Title_One = x.webLog_Label.WebLog_Label_Title_One,
                   Title_Meta = x.webLog.Title_Meta,
                   Url_Meta = x.webLog.Url_Meta,
                   LastUpdateDate = x.webLog.LastUpdateDate
               },
               webLog=new WebLog()
               {
                    WebLog_Groups=new WebLog_Group()
                    {
                        Url_Meta=x.webLog.WebLog_Groups.Url_Meta,
                        WebLog_Group_Title_Two = x.webLog.WebLog_Groups.WebLog_Group_Title_Two,
                        WebLog_Group_Title_One = x.webLog.WebLog_Groups.WebLog_Group_Title_One,
                        Title_Meta = x.webLog.WebLog_Groups.Title_Meta,
                    },
                  
                   Weblog_Title_Two =x.webLog.Weblog_Title_Two,
                    Weblog_Title_One = x.webLog.Weblog_Title_One,
                    Title_Meta=x.webLog.Title_Meta,
                    Weblog_Writer=x.webLog.Weblog_Writer,
                    Url_Meta=x.webLog.Url_Meta,
                    LastUpdateDate=x.webLog.LastUpdateDate
               },
               WebLog_Group = new WebLog_Group()
               {
                  Url_Meta=x.webLog_Category.Url_Meta,
                   WebLog_Group_Title_One=x.WebLog_Group.WebLog_Group_Title_One,
                   WebLog_Group_Title_Two=x.WebLog_Group.WebLog_Group_Title_Two,
                   LastUpdateDate=x.WebLog_Group.LastUpdateDate

               },
               webLog_Category = new WebLog_Category()
               {
                   Url_Meta = x.webLog_Category.Url_Meta,
                   WebLog_Category_Title_One = x.webLog_Category.WebLog_Category_Title_One,
                   WebLog_Category_Title_Two = x.webLog_Category.WebLog_Category_Title_Two,
                   LastUpdateDate = x.webLog_Category.LastUpdateDate

               },
               Id = x.Id,
               LastUpdateDate = x.LastUpdateDate,
               CreateDate = x.CreateDate



           }).OrderByDescending(x => x.LastUpdateDate).ToListAsync(cancellationToken);
            return result;
        }


        public async Task<IList<WebLog_Slider>> ShowSliderMiddleForBlogAsync(CancellationToken cancellationToken)
        {
            var result = await TableNoTracking.Where(x => x.WebLog_Slider_IsActive && x.WebLog_Slider_IsActive_MiddlePage).Include(x => x.webLog).Include(x => x.webLog_Label).Include(x => x.webLog_Category).Include(x => x.WebLog_Group).Select(x =>
         new WebLog_Slider()
         {

             WebLog_Slider_Image = x.WebLog_Slider_Image,
             WebLog_Slider_Title = x.WebLog_Slider_Title,
             WebLog_Slider_Category_IsActive = x.WebLog_Slider_Category_IsActive,
             WebLog_Slider_Group_IsActive = x.WebLog_Slider_Group_IsActive,
             WebLog_Slider_Blog_IsActive = x.WebLog_Slider_Blog_IsActive,
             WebLog_Slider_Label_IsActive = x.WebLog_Slider_Label_IsActive,
             WebLog_Slider_IsActive = x.WebLog_Slider_IsActive,
             WebLog_Slider_IsActive_TopPage = x.WebLog_Slider_IsActive_TopPage,
             WebLog_Slider_IsActive_MiddlePage = x.WebLog_Slider_IsActive_MiddlePage,
             WebLog_Slider_IsActive_BottomPage = x.WebLog_Slider_IsActive_BottomPage,
             webLog_Label = new WebLog_Label()
             {
                 WebLog_Label_Title_Two = x.webLog_Label.WebLog_Label_Title_Two,
                 WebLog_Label_Title_One = x.webLog_Label.WebLog_Label_Title_One,
                 Title_Meta = x.webLog_Label.Title_Meta,
                 Url_Meta = x.webLog_Label.Url_Meta,
                 LastUpdateDate = x.webLog_Label.LastUpdateDate
             },
             webLog = new WebLog()
             {
               

                 Weblog_Title_Two = x.webLog.Weblog_Title_Two,
                 Weblog_Title_One = x.webLog.Weblog_Title_One,
                 Title_Meta = x.webLog.Title_Meta,
                 Weblog_Writer = x.webLog.Weblog_Writer,
                 Url_Meta = x.webLog.Url_Meta,
                 LastUpdateDate = x.webLog.LastUpdateDate,
                 
             },
             WebLog_Group = new WebLog_Group()
             {
                 Url_Meta = x.WebLog_Group.Url_Meta,
                 WebLog_Group_Title_One = x.WebLog_Group.WebLog_Group_Title_One,
                 WebLog_Group_Title_Two = x.WebLog_Group.WebLog_Group_Title_Two,
                 LastUpdateDate = x.WebLog_Group.LastUpdateDate,
                   Title_Meta = x.webLog.Title_Meta,
             },
             webLog_Category = new WebLog_Category()
             {
                 Url_Meta = x.webLog_Category.Url_Meta,
                 WebLog_Category_Title_One = x.webLog_Category.WebLog_Category_Title_One,
                 WebLog_Category_Title_Two = x.webLog_Category.WebLog_Category_Title_Two,
                 LastUpdateDate = x.webLog_Category.LastUpdateDate

             },
             Id = x.Id,
             LastUpdateDate = x.LastUpdateDate,
             CreateDate = x.CreateDate,
             WebLog_Slider_Order=x.WebLog_Slider_Order
             


         }).OrderBy(x => x.WebLog_Slider_Order).ToListAsync(cancellationToken);
            return result;
        }
        public IPagedList<WebLog_Slider> ShowAllWebLog_Slider_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10)
        {
            var result = TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
             new WebLog_Slider()
             {
                 WebLog_Slider_Image = x.WebLog_Slider_Image,
                 WebLog_Slider_Title = x.WebLog_Slider_Title,
                 WebLog_Slider_Category_IsActive = x.WebLog_Slider_Category_IsActive,
                 WebLog_Slider_Group_IsActive = x.WebLog_Slider_Group_IsActive,
                 WebLog_Slider_Blog_IsActive = x.WebLog_Slider_Blog_IsActive,
                 WebLog_Slider_Label_IsActive = x.WebLog_Slider_Label_IsActive,
                 WebLog_Slider_IsActive = x.WebLog_Slider_IsActive,
                 WebLog_Slider_IsActive_TopPage = x.WebLog_Slider_IsActive_TopPage,
                 WebLog_Slider_IsActive_MiddlePage = x.WebLog_Slider_IsActive_MiddlePage,
                 WebLog_Slider_IsActive_BottomPage = x.WebLog_Slider_IsActive_BottomPage,
                 Id = x.Id,
                 LastUpdateDate = x.LastUpdateDate,
                 CreateDate = x.CreateDate

             }).ToPagedList(currentPage, number_showproduct);
            return result;
        }

        public IPagedList<WebLog_Slider> ShowAllWebLog_Slider_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10, int groupId = 0)
        {
            var result = TableNoTracking.Where(x => x.UserId == UserId && x.WebLog_Slider_GroupId == groupId).Select(x =>
                new WebLog_Slider()
                {
                    WebLog_Slider_Image = x.WebLog_Slider_Image,
                    WebLog_Slider_Title=x.WebLog_Slider_Title,
                    WebLog_Slider_Category_IsActive=x.WebLog_Slider_Category_IsActive,
                    WebLog_Slider_Group_IsActive=x.WebLog_Slider_Group_IsActive,
                    WebLog_Slider_Blog_IsActive=x.WebLog_Slider_Blog_IsActive,
                    WebLog_Slider_Label_IsActive=x.WebLog_Slider_Label_IsActive,
                    WebLog_Slider_IsActive=x.WebLog_Slider_IsActive,
                    WebLog_Slider_IsActive_TopPage=x.WebLog_Slider_IsActive_TopPage,
                    WebLog_Slider_IsActive_MiddlePage=x.WebLog_Slider_IsActive_MiddlePage,
                    WebLog_Slider_IsActive_BottomPage=x.WebLog_Slider_IsActive_BottomPage,
                    Id = x.Id,
                    LastUpdateDate = x.LastUpdateDate,
                    CreateDate = x.CreateDate

                }).ToPagedList(currentPage, number_showproduct);
            return result;
        }
    }
}
