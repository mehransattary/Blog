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

    public class WebLog_GroupController : Controller
    {
        #region Ctor
        private readonly IWeblogGroupService WebLog_GroupService;
        private readonly IWeblogCategoryService WebLog_CategoryService;

        private readonly UserManager<IdentityUser> userManager;
        public WebLog_GroupController(IWeblogGroupService WebLog_GroupService, IWeblogCategoryService WebLog_CategoryService, UserManager<IdentityUser> userManager)
        {
            this.WebLog_GroupService = WebLog_GroupService;
            this.WebLog_CategoryService = WebLog_CategoryService;
            this.userManager = userManager;

        }

        #endregion
        #region Index
        public IActionResult Index(CancellationToken cancellationToken, int currentPage = 1)
        {
            ViewBag.isActive_User_Menu = "WebLogGroupController";
            int number_showproduct = 12;
            ViewBag.counter = (currentPage < 1) ? 1 : (((currentPage - 1) * number_showproduct) + 1);
            var UserId = userManager.GetUserId(User);
            var result = WebLog_GroupService.ShowAllWeblogGroup_PagingAsync(cancellationToken, UserId, currentPage, number_showproduct);

            var isExistCategory = WebLog_CategoryService.TableNoTracking.Any();
            ViewBag.isExistCategory = isExistCategory == true ? true : false;
            return View(result);
        }

        #endregion
        #region Add
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            var UserId = userManager.GetUserId(User);
            var selectlist = await WebLog_CategoryService.SelectListAsync(cancellationToken, UserId);
            ViewData["WebLog_Group_CategoryId"] = new SelectList(selectlist, "Id", "WebLog_Category_Title_One");


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WebLog_GroupDto WebLog_GroupDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                string result = await CaseChecOrderUrlkAdd(WebLog_GroupDto, cancellationToken);
                if (!string.IsNullOrEmpty(result))
                    return RedirectToAction(result);

            }
            var UserId = userManager.GetUserId(User);
            var selectlist = await WebLog_CategoryService.SelectListAsync(cancellationToken, UserId);
            ViewData["WebLog_Group_CategoryId"] = new SelectList(selectlist, "Id", "WebLog_Category_Title_One", WebLog_GroupDto.WebLog_Group_CategoryId);
            return View(WebLog_GroupDto);
        }
        public async Task<string> CaseChecOrderUrlkAdd(WebLog_GroupDto WebLog_GroupDto, CancellationToken cancellationToken)
        {
            var isCheckRepeatUrlMeta = await WebLog_GroupService.CheckRepeatUrlMeta(WebLog_GroupDto.Url_Meta);
            var isCheckRepeatOrder = await WebLog_GroupService.CheckRepeatOrder(WebLog_GroupDto.WebLog_Group_Order.Value);
            if (isCheckRepeatOrder && isCheckRepeatUrlMeta)
            {
                if (isCheckRepeatOrder)
                    ViewBag.error_RepeatOrder = $"❌  ورودی های عمومی /  ✨ {WebLog_GroupDto.WebLog_Group_Order}  ✨ / این مرتب سازی  از قبل موجود می باشد . ";

                if (isCheckRepeatUrlMeta)
                    ViewBag.error_Url_Meta = $"❌  ورودی های سئو /  ✨ {WebLog_GroupDto.Url_Meta}  ✨ / این آدرس اینترنتی  از قبل موجود می باشد . ";

            }
            if (isCheckRepeatOrder && !isCheckRepeatUrlMeta)
            {
                if (isCheckRepeatOrder)
                    ViewBag.error_RepeatOrder = $"❌  ورودی های عمومی /  ✨ {WebLog_GroupDto.WebLog_Group_Order}  ✨ / این مرتب سازی  از قبل موجود می باشد . ";

            }
            if (!isCheckRepeatOrder && isCheckRepeatUrlMeta)
            {
                if (isCheckRepeatUrlMeta)
                    ViewBag.error_Url_Meta = $"❌  ورودی های سئو /  ✨ {WebLog_GroupDto.Url_Meta}  ✨ / این آدرس اینترنتی  از قبل موجود می باشد . ";

            }
            if (!isCheckRepeatOrder && !isCheckRepeatUrlMeta)
            {
                WebLog_GroupDto.UserId = userManager.GetUserId(User);
                await WebLog_GroupService.AddWebLog_GroupAsync(WebLog_GroupDto, cancellationToken);
                return "Index";
            }
            return "";
        }

        #endregion
        #region Update
        public async Task<IActionResult> Edit(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var WebLog_Group = await WebLog_GroupService.GetByIdAsync(cancellationToken, id);
            if (WebLog_Group == null)
            {
                return NotFound();
            }
            #region WebLog_GroupDto + AvatarImage + IconImage
            ViewBag.WebLog_Group_Image = WebLog_Group.WebLog_Group_Image ?? "/images/default.png";
            ViewBag.WebLog_Group_ImageHome = WebLog_Group.WebLog_Group_ImageHome ?? "/images/default.png";
            ViewBag.WebLog_Group_ThumbnaillImage = WebLog_Group.WebLog_Group_ThumbnaillImage ?? "/images/default.png";
            ViewBag.Image_Meta = WebLog_Group.Image_Meta ?? "/images/default.png";
            var UserId = userManager.GetUserId(User);
            var selectlist = await WebLog_CategoryService.SelectListAsync(cancellationToken, UserId);
            ViewData["WebLog_Group_CategoryId"] = new SelectList(selectlist, "Id", "WebLog_Category_Title_One");
            var WebLog_GroupDto = new WebLog_GroupDto()
            {
                Id = WebLog_Group.Id,

                WebLog_Group_IsShow = WebLog_Group.WebLog_Group_IsShow,
                WebLog_Group_ShortDescription = WebLog_Group.WebLog_Group_ShortDescription,
                WebLog_Group_ShortLink = WebLog_Group.WebLog_Group_ShortLink,
                WebLog_Group_Description = WebLog_Group.WebLog_Group_Description,
                WebLog_Group_Order = WebLog_Group.WebLog_Group_Order,
                WebLog_Group_Title_One = WebLog_Group.WebLog_Group_Title_One,
                WebLog_Group_Title_Two = WebLog_Group.WebLog_Group_Title_Two,
                //=======Meta Tags==========//
                Title_Meta = WebLog_Group.Title_Meta,
                TitleEnglish_Meta = WebLog_Group.TitleEnglish_Meta,
                Url_Meta = WebLog_Group.Url_Meta,
                Desc_Meta = WebLog_Group.Desc_Meta,
                Canonical_Meta = WebLog_Group.Canonical_Meta,
                Keyword_Meta = WebLog_Group.Keyword_Meta,
                //=======Meta Tags==========//
                CreateDate = WebLog_Group.CreateDate,
                LastUpdateDate = WebLog_Group.LastUpdateDate

            };
            #endregion
            return View(WebLog_GroupDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WebLog_GroupDto WebLog_GroupDto, string _WebLog_Group_Image, string _WebLog_Group_ImageHome, string _WebLog_Group_ThumbnaillImage, string _Image_Meta, CancellationToken cancellationToken)
        {
            if (id != WebLog_GroupDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string result = await CaseChecOrderUrlkUpdate(WebLog_GroupDto, _WebLog_Group_Image, _WebLog_Group_ImageHome, _WebLog_Group_ThumbnaillImage, _Image_Meta, cancellationToken);
                    if (!string.IsNullOrEmpty(result))
                        return RedirectToAction(result);
                  
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebLog_GroupExists(WebLog_GroupDto.Id))
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
            var selectlist = await WebLog_CategoryService.SelectListAsync(cancellationToken, UserId);
            ViewData["WebLog_Group_CategoryId"] = new SelectList(selectlist, "Id", "WebLog_Category_Title_One", WebLog_GroupDto.WebLog_Group_CategoryId);
            return View(WebLog_GroupDto);
        }
        public async Task<string> CaseChecOrderUrlkUpdate(WebLog_GroupDto WebLog_GroupDto, string _WebLog_Category_Image, string _WebLog_Category_ImageHome, string _WebLog_Category_ThumbnaillImage, string _Image_Meta, CancellationToken cancellationToken)
        {
            var weblog_group = await WebLog_GroupService.TableNoTracking.FirstOrDefaultAsync(x => x.Id == WebLog_GroupDto.Id);
            var url_meta_New = WebLog_GroupDto.Url_Meta;
            var url_meta_Ago = weblog_group.Url_Meta;
            var order_New = WebLog_GroupDto.WebLog_Group_Order;
            var order_Ago = weblog_group.WebLog_Group_Order;

            if ((url_meta_New == url_meta_Ago) && (order_New == order_Ago))
            {
                WebLog_GroupDto.UserId = userManager.GetUserId(User);
                await WebLog_GroupService.UpdateWebLog_GroupAsync(WebLog_GroupDto, _WebLog_Category_Image, _WebLog_Category_ImageHome, _WebLog_Category_ThumbnaillImage, _Image_Meta, cancellationToken);

                return "Index";
            }
            else if (!(url_meta_New == url_meta_Ago) && (order_New == order_Ago))
            {
                var isCheckRepeatUrlMeta = await WebLog_CategoryService.CheckRepeatUrlMeta(WebLog_GroupDto.Url_Meta);

                if (isCheckRepeatUrlMeta)
                    ViewBag.error_Url_Meta = $"❌  ورودی های سئو /  ✨ {WebLog_GroupDto.Url_Meta}  ✨ / این آدرس اینترنتی  از قبل موجود می باشد . ";


            }
            else if ((url_meta_New == url_meta_Ago) && !(order_New == order_Ago))
            {
                var isCheckRepeatOrder = await WebLog_CategoryService.CheckRepeatOrder(WebLog_GroupDto.WebLog_Group_Order.Value);

                if (isCheckRepeatOrder)
                    ViewBag.error_RepeatOrder = $"❌  ورودی های عمومی /  ✨ {WebLog_GroupDto.WebLog_Group_Order}  ✨ / این مرتب سازی  از قبل موجود می باشد . ";


            }
            else
            {
                var isCheckRepeatUrlMeta = await WebLog_CategoryService.CheckRepeatUrlMeta(WebLog_GroupDto.Url_Meta);
                var isCheckRepeatOrder = await WebLog_CategoryService.CheckRepeatOrder(WebLog_GroupDto.WebLog_Group_Order.Value);
                if (isCheckRepeatOrder && isCheckRepeatUrlMeta)
                {
                    if (isCheckRepeatOrder)
                        ViewBag.error_RepeatOrder = $"❌  ورودی های عمومی /  ✨ {WebLog_GroupDto.WebLog_Group_Order}  ✨ / این مرتب سازی  از قبل موجود می باشد . ";

                    if (isCheckRepeatUrlMeta)
                        ViewBag.error_Url_Meta = $"❌  ورودی های سئو /  ✨ {WebLog_GroupDto.Url_Meta}  ✨ / این آدرس اینترنتی  از قبل موجود می باشد . ";

                }
                if (isCheckRepeatOrder && !isCheckRepeatUrlMeta)
                {
                    if (isCheckRepeatOrder)
                        ViewBag.error_RepeatOrder = $"❌  ورودی های عمومی /  ✨ {WebLog_GroupDto.WebLog_Group_Order}  ✨ / این مرتب سازی  از قبل موجود می باشد . ";

                }
                if (!isCheckRepeatOrder && isCheckRepeatUrlMeta)
                {
                    if (isCheckRepeatUrlMeta)
                        ViewBag.error_Url_Meta = $"❌  ورودی های سئو /  ✨ {WebLog_GroupDto.Url_Meta}  ✨ / این آدرس اینترنتی  از قبل موجود می باشد . ";

                }
                if (!isCheckRepeatOrder && !isCheckRepeatUrlMeta)
                {
                    WebLog_GroupDto.UserId = userManager.GetUserId(User);
                    await WebLog_GroupService.AddWebLog_GroupAsync(WebLog_GroupDto, cancellationToken);
                    return "Index";
                }


            }
            return "";
        }

        #endregion
        #region Delete

        public async Task<IActionResult> Delete(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var WebLog_Group = await WebLog_GroupService.GetByIdAsync(cancellationToken, id);


            if (WebLog_Group == null)
            {
                return NotFound();
            }

            return View(WebLog_Group);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
        {
            var WebLog_Group = await WebLog_GroupService.GetByIdAsync(cancellationToken, id);
            await WebLog_GroupService.DeleteAsync(WebLog_Group, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        #endregion


        private bool WebLog_GroupExists(int id)
        {
            return WebLog_GroupService.TableNoTracking.Any(e => e.Id == id);
        }
    }
}
