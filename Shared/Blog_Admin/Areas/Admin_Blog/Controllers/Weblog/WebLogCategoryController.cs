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

    public class WebLogCategoryController : Controller
    {
        #region Ctor
        private readonly IWeblogCategoryService WebLog_CategoryService;
        private readonly IWeblogGroupService weblogGroupService;

        private readonly UserManager<IdentityUser> userManager;
        public WebLogCategoryController(IWeblogCategoryService WebLog_CategoryService, IWeblogGroupService weblogGroupService, UserManager<IdentityUser> userManager)
        {
            this.WebLog_CategoryService = WebLog_CategoryService;
            this.weblogGroupService = weblogGroupService;

            this.userManager = userManager;

        }
        #endregion
        #region Index
        public IActionResult Index(CancellationToken cancellationToken, int currentPage = 1)
        {
            ViewBag.isActive_User_Menu = "WebLogCategoryController";
            int number_showproduct = 12;
            ViewBag.counter = (currentPage < 1) ? 1 : (((currentPage - 1) * number_showproduct) + 1);
            var UserId = userManager.GetUserId(User);
            var result = WebLog_CategoryService.ShowAllWeblogCategory_PagingAsync(cancellationToken, UserId, currentPage, number_showproduct);

            return View(result);
        }
        #endregion
        #region Add

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WebLog_CategoryDto WebLog_CategoryDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {

                string result = await CaseChecOrderUrlkAdd(WebLog_CategoryDto, cancellationToken);
                if (!string.IsNullOrEmpty(result))
                    return RedirectToAction(result);

            }
            return View(WebLog_CategoryDto);
        }

        public async Task<string> CaseChecOrderUrlkAdd(WebLog_CategoryDto WebLog_CategoryDto, CancellationToken cancellationToken)
        {
            var isCheckRepeatUrlMeta = await WebLog_CategoryService.CheckRepeatUrlMeta(WebLog_CategoryDto.Url_Meta);
            var isCheckRepeatOrder = await WebLog_CategoryService.CheckRepeatOrder(WebLog_CategoryDto.WebLog_Category_Order.Value);
            if (isCheckRepeatOrder && isCheckRepeatUrlMeta)
            {
                if (isCheckRepeatOrder)
                    ViewBag.error_RepeatOrder = $"❌  ورودی های عمومی /  ✨ {WebLog_CategoryDto.WebLog_Category_Order}  ✨ / این مرتب سازی  از قبل موجود می باشد . ";

                if (isCheckRepeatUrlMeta)
                    ViewBag.error_Url_Meta = $"❌  ورودی های سئو /  ✨ {WebLog_CategoryDto.Url_Meta}  ✨ / این آدرس اینترنتی  از قبل موجود می باشد . ";

            }
            if (isCheckRepeatOrder && !isCheckRepeatUrlMeta)
            {
                if (isCheckRepeatOrder)
                    ViewBag.error_RepeatOrder = $"❌  ورودی های عمومی /  ✨ {WebLog_CategoryDto.WebLog_Category_Order}  ✨ / این مرتب سازی  از قبل موجود می باشد . ";

            }
            if (!isCheckRepeatOrder && isCheckRepeatUrlMeta)
            {
                if (isCheckRepeatUrlMeta)
                    ViewBag.error_Url_Meta = $"❌  ورودی های سئو /  ✨ {WebLog_CategoryDto.Url_Meta}  ✨ / این آدرس اینترنتی  از قبل موجود می باشد . ";

            }
            if (!isCheckRepeatOrder && !isCheckRepeatUrlMeta)
            {
                WebLog_CategoryDto.UserId = userManager.GetUserId(User);
                await WebLog_CategoryService.AddWebLog_CategoryAsync(WebLog_CategoryDto, cancellationToken);
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

            var WebLog_Category = await WebLog_CategoryService.GetByIdAsync(cancellationToken, id);
            if (WebLog_Category == null)
            {
                return NotFound();
            }
            #region WebLog_CategoryDto + AvatarImage + IconImage
            ViewBag.WebLog_Category_Image = WebLog_Category.WebLog_Category_Image ?? "/images/default.png";
            ViewBag.WebLog_Category_ImageHome = WebLog_Category.WebLog_Category_ImageHome ?? "/images/default.png";
            ViewBag.WebLog_Category_ThumbnaillImage = WebLog_Category.WebLog_Category_ThumbnaillImage ?? "/images/default.png";
            ViewBag.Image_Meta = WebLog_Category.Image_Meta ?? "/images/default.png";

            var WebLog_CategoryDto = new WebLog_CategoryDto()
            {
                Id = WebLog_Category.Id,

                WebLog_Category_IsShow = WebLog_Category.WebLog_Category_IsShow,
                WebLog_Category_ShortDescription = WebLog_Category.WebLog_Category_ShortDescription,
                WebLog_Category_ShortLink = WebLog_Category.WebLog_Category_ShortLink,
                WebLog_Category_Description = WebLog_Category.WebLog_Category_Description,
                WebLog_Category_Order = WebLog_Category.WebLog_Category_Order,
                WebLog_Category_Title_One = WebLog_Category.WebLog_Category_Title_One,
                WebLog_Category_Title_Two = WebLog_Category.WebLog_Category_Title_Two,
                //=======Meta Tags==========//
                Title_Meta = WebLog_Category.Title_Meta,
                TitleEnglish_Meta = WebLog_Category.TitleEnglish_Meta,
                Url_Meta = WebLog_Category.Url_Meta,
                Desc_Meta = WebLog_Category.Desc_Meta,
                Canonical_Meta = WebLog_Category.Canonical_Meta,
                Keyword_Meta = WebLog_Category.Keyword_Meta,
                //=======Meta Tags==========//
                CreateDate = WebLog_Category.CreateDate,
                LastUpdateDate = WebLog_Category.LastUpdateDate

            };
            #endregion
            return View(WebLog_CategoryDto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WebLog_CategoryDto WebLog_CategoryDto, string _WebLog_Category_Image, string _WebLog_Category_ImageHome, string _WebLog_Category_ThumbnaillImage, string _Image_Meta, CancellationToken cancellationToken)
        {
            if (id != WebLog_CategoryDto.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    string result = await CaseChecOrderUrlkUpdate(WebLog_CategoryDto, _WebLog_Category_Image, _WebLog_Category_ImageHome, _WebLog_Category_ThumbnaillImage, _Image_Meta, cancellationToken);
                    if (!string.IsNullOrEmpty(result))
                        return RedirectToAction(result);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebLog_CategoryExists(WebLog_CategoryDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(WebLog_CategoryDto);
        }

        public async Task<string> CaseChecOrderUrlkUpdate(WebLog_CategoryDto WebLog_CategoryDto, string _WebLog_Category_Image, string _WebLog_Category_ImageHome, string _WebLog_Category_ThumbnaillImage, string _Image_Meta, CancellationToken cancellationToken)
        {
            var weblog_category = await WebLog_CategoryService.TableNoTracking.FirstOrDefaultAsync(x => x.Id == WebLog_CategoryDto.Id);
            var url_meta_New = WebLog_CategoryDto.Url_Meta;
            var url_meta_Ago = weblog_category.Url_Meta;
            var order_New = WebLog_CategoryDto.WebLog_Category_Order;
            var order_Ago = weblog_category.WebLog_Category_Order;

            if ((url_meta_New == url_meta_Ago) && (order_New == order_Ago))
            {
                WebLog_CategoryDto.UserId = userManager.GetUserId(User);
                await WebLog_CategoryService.UpdateWebLog_CategoryAsync(WebLog_CategoryDto, _WebLog_Category_Image, _WebLog_Category_ImageHome, _WebLog_Category_ThumbnaillImage, _Image_Meta, cancellationToken);

                return "Index";
            }
            else if (!(url_meta_New == url_meta_Ago) && (order_New == order_Ago))
            {
                var isCheckRepeatUrlMeta = await WebLog_CategoryService.CheckRepeatUrlMeta(url_meta_New);

                if (isCheckRepeatUrlMeta)
                    ViewBag.error_Url_Meta = $"❌  ورودی های سئو /  ✨ {WebLog_CategoryDto.Url_Meta}  ✨ / این آدرس اینترنتی  از قبل موجود می باشد . ";
                else
                {
                    WebLog_CategoryDto.UserId = userManager.GetUserId(User);
                    await WebLog_CategoryService.UpdateWebLog_CategoryAsync(WebLog_CategoryDto, _WebLog_Category_Image, _WebLog_Category_ImageHome, _WebLog_Category_ThumbnaillImage, _Image_Meta, cancellationToken);

                    return "Index";
                }
                       

            }
            else if ((url_meta_New == url_meta_Ago) && !(order_New == order_Ago))
            {
                var isCheckRepeatOrder = await WebLog_CategoryService.CheckRepeatOrder(WebLog_CategoryDto.WebLog_Category_Order.Value);

                if (isCheckRepeatOrder)
                    ViewBag.error_RepeatOrder = $"❌  ورودی های عمومی /  ✨ {order_New}  ✨ / این مرتب سازی  از قبل موجود می باشد . ";
                else
                {
                    WebLog_CategoryDto.UserId = userManager.GetUserId(User);
                    await WebLog_CategoryService.UpdateWebLog_CategoryAsync(WebLog_CategoryDto, _WebLog_Category_Image, _WebLog_Category_ImageHome, _WebLog_Category_ThumbnaillImage, _Image_Meta, cancellationToken);

                    return "Index";
                }
            }
            else
            {
                var isCheckRepeatUrlMeta = await WebLog_CategoryService.CheckRepeatUrlMeta(url_meta_New);
                var isCheckRepeatOrder = await WebLog_CategoryService.CheckRepeatOrder(WebLog_CategoryDto.WebLog_Category_Order.Value);

                if (isCheckRepeatOrder && isCheckRepeatUrlMeta)
                {
                    if (isCheckRepeatOrder)
                        ViewBag.error_RepeatOrder = $"❌  ورودی های عمومی /  ✨ {WebLog_CategoryDto.WebLog_Category_Order}  ✨ / این مرتب سازی  از قبل موجود می باشد . ";

                    if (isCheckRepeatUrlMeta)
                        ViewBag.error_Url_Meta = $"❌  ورودی های سئو /  ✨ {WebLog_CategoryDto.Url_Meta}  ✨ / این آدرس اینترنتی  از قبل موجود می باشد . ";

                }
                if (isCheckRepeatOrder && !isCheckRepeatUrlMeta)
                {
                    if (isCheckRepeatOrder)
                        ViewBag.error_RepeatOrder = $"❌  ورودی های عمومی /  ✨ {WebLog_CategoryDto.WebLog_Category_Order}  ✨ / این مرتب سازی  از قبل موجود می باشد . ";

                }
                if (!isCheckRepeatOrder && isCheckRepeatUrlMeta)
                {
                    if (isCheckRepeatUrlMeta)
                        ViewBag.error_Url_Meta = $"❌  ورودی های سئو /  ✨ {WebLog_CategoryDto.Url_Meta}  ✨ / این آدرس اینترنتی  از قبل موجود می باشد . ";

                }
                if (!isCheckRepeatOrder && !isCheckRepeatUrlMeta)
                {
                    WebLog_CategoryDto.UserId = userManager.GetUserId(User);
                    await WebLog_CategoryService.UpdateWebLog_CategoryAsync(WebLog_CategoryDto, _WebLog_Category_Image, _WebLog_Category_ImageHome, _WebLog_Category_ThumbnaillImage, _Image_Meta, cancellationToken);
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
            var WebLog_Category = await WebLog_CategoryService.GetByIdAsync(cancellationToken, id);

            string errors_CheckIsExistGroupInCategory = WebLog_CategoryService.CheckIsExistGroupInCategory(id.Value);
            if (!string.IsNullOrEmpty(errors_CheckIsExistGroupInCategory))
            {
                ViewBag.errormessage_ListIsExist_Groups = errors_CheckIsExistGroupInCategory;
                return View(WebLog_Category);

            }

            if (WebLog_Category == null)
            {
                return NotFound();
            }

            return View(WebLog_Category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
        {

            string errors_CheckIsExistGroupInCategory = WebLog_CategoryService.CheckIsExistGroupInCategory(id);
            if (!string.IsNullOrEmpty(errors_CheckIsExistGroupInCategory))
            {
                ViewBag.errormessage_ListIsExist_Groups = errors_CheckIsExistGroupInCategory;
                return RedirectToAction(nameof(Delete), new { id = id });

            }
            var WebLog_Category = await WebLog_CategoryService.GetByIdAsync(cancellationToken, id);
            await WebLog_CategoryService.DeleteAsync(WebLog_Category, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        #endregion


        private bool WebLog_CategoryExists(int id)
        {
            return WebLog_CategoryService.TableNoTracking.Any(e => e.Id == id);
        }
    }
}
