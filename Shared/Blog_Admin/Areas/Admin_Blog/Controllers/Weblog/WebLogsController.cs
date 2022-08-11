using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Service.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using Data.Dto;

namespace ProMe_Admin.Controllers
{
    [Area("Admin_Blog")]
    [Authorize(Policy = "admin")]
    [AutoValidateAntiforgeryToken]

    public class WebLogsController : Controller
    {
        #region Ctor
        private readonly IWeblogService WebLogService;
        private readonly IWeblogGroupService weblogGroupService;

        private readonly UserManager<IdentityUser> userManager;
        public WebLogsController(IWeblogService WebLogService, IWeblogGroupService weblogGroupService, UserManager<IdentityUser> userManager)
        {
            this.WebLogService = WebLogService;
            this.weblogGroupService = weblogGroupService;
            this.userManager = userManager;
        }
        #endregion
        #region Index
        public IActionResult Index(CancellationToken cancellationToken, int currentPage = 1,int groupId=0)
        {
            ViewBag.isActive_User_Menu = "WebLogsController";
            int number_showproduct = 12;
            ViewBag.counter = (currentPage < 1) ? 1 : (((currentPage - 1) * number_showproduct) + 1);
            var UserId = userManager.GetUserId(User);
            if (groupId != 0)
            {
                var result = WebLogService.ShowAllWeblog_PagingAsync(cancellationToken, UserId, currentPage, number_showproduct,groupId);

                var isExistGroup = WebLogService.TableNoTracking.Any();
                ViewBag.isExistGroup = isExistGroup == true ? true : false;
                ViewBag.categoryId = weblogGroupService.TableNoTracking.FirstOrDefault(x=>x.Id==groupId).WebLog_Group_CategoryId;
                ViewBag.groupName = weblogGroupService.TableNoTracking.FirstOrDefault(x=>x.Id==groupId).WebLog_Group_Title_One;
                ViewBag.groupId = groupId;
                return View(result);

            }
            else
            {
                var result = WebLogService.ShowAllWeblog_PagingAsync(cancellationToken, UserId, currentPage, number_showproduct);

                var isExistCategory = WebLogService.TableNoTracking.Any();
                ViewBag.isExistGroup = isExistCategory == true ? true : false;
                return View(result);
            }




        
        }
        #endregion
        #region Add

        public async Task<IActionResult> Create(CancellationToken cancellationToken,int groupId=0)
        {
            var UserId = userManager.GetUserId(User);
            if (groupId != 0)
            {
                var selectlist = await weblogGroupService.SelectListAsync(cancellationToken, UserId, groupId);
                ViewData["Weblog_GroupId"] = new SelectList(selectlist, "Id", "WebLog_Group_Title_One");
                ViewBag.groupId = groupId;
            }
            else
            {
                var selectlist = await weblogGroupService.SelectListAsync(cancellationToken, UserId);
                ViewData["Weblog_GroupId"] = new SelectList(selectlist, "Id", "WebLog_Group_Title_One");
            
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WeblogDto WeblogDto, CancellationToken cancellationToken, int groupId = 0)
        {
            var UserId = userManager.GetUserId(User);
            if (ModelState.IsValid)
            {

                string result = await CaseChecUrlkAdd(WeblogDto, cancellationToken);
                if (!string.IsNullOrEmpty(result))
                    return RedirectToAction(result);

            }
            if (groupId != 0)
            {
                var selectlist = await weblogGroupService.SelectListAsync(cancellationToken, UserId, groupId);
                ViewData["Weblog_GroupId"] = new SelectList(selectlist, "Id", "WebLog_Group_Title_One", WeblogDto.Weblog_GroupId);
                ViewBag.groupId = groupId;
            }
            else
            {
                var selectlist = await weblogGroupService.SelectListAsync(cancellationToken, UserId);
                ViewData["Weblog_GroupId"] = new SelectList(selectlist, "Id", "WebLog_Group_Title_One", WeblogDto.Weblog_GroupId);

            }
            return View(WeblogDto);
        }

        public async Task<string> CaseChecUrlkAdd(WeblogDto WeblogDto, CancellationToken cancellationToken)
        {
            var isCheckRepeatUrlMeta = await WebLogService.CheckRepeatUrlMeta(WeblogDto.Url_Meta);
            if (isCheckRepeatUrlMeta)
            {
            
                if (isCheckRepeatUrlMeta)
                    ViewBag.error_Url_Meta = $"❌  ورودی های سئو /  ✨ {WeblogDto.Url_Meta}  ✨ / این آدرس اینترنتی  از قبل موجود می باشد . ";

            }
           
            else
            {
                WeblogDto.UserId = userManager.GetUserId(User);
                await WebLogService.AddWebLogAsync(WeblogDto, cancellationToken);
                return "Index";
            }
            return "";
        }

        #endregion
        #region Update
        public async Task<IActionResult> Edit(int? id, CancellationToken cancellationToken,int groupId = 0)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Weblog = await WebLogService.GetByIdAsync(cancellationToken, id);
            if (Weblog == null)
            {
                return NotFound();
            }
            #region WeblogDto + AvatarImage + IconImage
            ViewBag.Weblog_Image = Weblog.Weblog_Image ?? "/images/default.png";
            ViewBag.Weblog_Thumbnail_Image = Weblog.Weblog_Thumbnail_Image ?? "/images/default.png";
            ViewBag.Image_Meta = Weblog.Image_Meta ?? "/images/default.png";

            var UserId = userManager.GetUserId(User);
       

            if (groupId != 0)
            {
                var selectlist = await weblogGroupService.SelectListAsync(cancellationToken, UserId, groupId);
                ViewData["Weblog_GroupId"] = new SelectList(selectlist, "Id", "WebLog_Group_Title_One");
                ViewBag.groupId = groupId;
            }
            else
            {
                var selectlist = await weblogGroupService.SelectListAsync(cancellationToken, UserId);
                ViewData["Weblog_GroupId"] = new SelectList(selectlist, "Id", "WebLog_Group_Title_One");

            }
            var WeblogDto = new WeblogDto()
            {
                Id = Weblog.Id,

                Weblog_IsShow = Weblog.Weblog_IsShow,
                Weblog_Short_Description = Weblog.Weblog_Short_Description,
                Weblog_ShortLink = Weblog.Weblog_ShortLink,
                Weblog_Text = Weblog.Weblog_Text,
                Weblog_GroupId = Weblog.Weblog_GroupId,
                Weblog_Title_One = Weblog.Weblog_Title_One,
                Weblog_Title_Two = Weblog.Weblog_Title_Two,
                Weblog_Star= Weblog.Weblog_Star,
                Weblog_Writer= Weblog.Weblog_Writer,
                Weblog_StudyTime= Weblog.Weblog_StudyTime,          
                //=======Meta Tags==========//
                Title_Meta = Weblog.Title_Meta,
                TitleEnglish_Meta = Weblog.TitleEnglish_Meta,
                Url_Meta = Weblog.Url_Meta,
                Desc_Meta = Weblog.Desc_Meta,
                Canonical_Meta = Weblog.Canonical_Meta,
                Keyword_Meta = Weblog.Keyword_Meta,
                //=======Meta Tags==========//
                UserId= Weblog.UserId,
                CreateDate = Weblog.CreateDate,
                LastUpdateDate = Weblog.LastUpdateDate

            };
            #endregion
            return View(WeblogDto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WeblogDto WeblogDto, string _Weblog_Image, string _Weblog_Thumbnail_Image, string _Weblog_ThumbnaillImage, string _Image_Meta, CancellationToken cancellationToken,int groupId = 0)
        {
            if (id != WeblogDto.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    string result = await CaseChecUrlkUpdate(WeblogDto, _Weblog_Image, _Weblog_Thumbnail_Image, _Image_Meta, cancellationToken);
                    if (!string.IsNullOrEmpty(result))
                        return RedirectToAction(result);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeblogExists(WeblogDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            var UserId = userManager.GetUserId(User);

            if (groupId != 0)
            {
                var selectlist = await weblogGroupService.SelectListAsync(cancellationToken, UserId, groupId);
                ViewData["Weblog_GroupId"] = new SelectList(selectlist, "Id", "WebLog_Group_Title_One", WeblogDto.Weblog_GroupId);
                ViewBag.groupId = groupId;
            }
            else
            {
                var selectlist = await weblogGroupService.SelectListAsync(cancellationToken, UserId);
                ViewData["Weblog_GroupId"] = new SelectList(selectlist, "Id", "WebLog_Group_Title_One", WeblogDto.Weblog_GroupId);

            }
            return View(WeblogDto);
        }

        public async Task<string> CaseChecUrlkUpdate(WeblogDto WeblogDto, string _Weblog_Image, string _Weblog_ThumbnaillImage, string _Image_Meta, CancellationToken cancellationToken, int groupId = 0)
        {
            var Weblog = await WebLogService.TableNoTracking.FirstOrDefaultAsync(x => x.Id == WeblogDto.Id);
            var url_meta_New = WeblogDto.Url_Meta;
            var url_meta_Ago = Weblog.Url_Meta;
        

            if ((url_meta_New == url_meta_Ago))
            {
                WeblogDto.UserId = userManager.GetUserId(User);
                await WebLogService.UpdateWebLogAsync(WeblogDto, _Weblog_Image, _Weblog_ThumbnaillImage, _Image_Meta, cancellationToken);

                return "Index";
            }
           
            else
            {
                var isCheckRepeatUrlMeta = await WebLogService.CheckRepeatUrlMeta(WeblogDto.Url_Meta);
                if (isCheckRepeatUrlMeta)
                {
                   
                    if (isCheckRepeatUrlMeta)
                        ViewBag.error_Url_Meta = $"❌  ورودی های سئو /  ✨ {WeblogDto.Url_Meta}  ✨ / این آدرس اینترنتی  از قبل موجود می باشد . ";

                }
               
                else 
                {
                    WeblogDto.UserId = userManager.GetUserId(User);
                    await WebLogService.UpdateWebLogAsync(WeblogDto, _Weblog_Image, _Weblog_ThumbnaillImage, _Image_Meta, cancellationToken);
                    return "Index";
                }


            }
            return "";
        }

        #endregion
        #region Delete

        public async Task<IActionResult> Delete(int? id, CancellationToken cancellationToken,int groupId = 0)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Weblog = await WebLogService.GetByIdAsync(cancellationToken, id);
            if (groupId != 0)
            {
                ViewBag.groupId = groupId;
            }

            if (Weblog == null)
            {
                return NotFound();
            }

            return View(Weblog);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken,int groupId=0)
        {

            var Weblog = await WebLogService.GetByIdAsync(cancellationToken, id);
            await WebLogService.DeleteAsync(Weblog, cancellationToken);
            return RedirectToAction(nameof(Index),new { groupId = groupId });
        }
        #endregion


        private bool WeblogExists(int id)
        {
            return WebLogService.TableNoTracking.Any(e => e.Id == id);
        }
    }
}
