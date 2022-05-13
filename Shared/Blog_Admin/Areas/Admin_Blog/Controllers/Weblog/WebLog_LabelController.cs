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

    public class WebLog_LabelController : Controller
    {
        #region Ctor
        private readonly IWeblogLabelService WebLog_LabelService;

        private readonly UserManager<IdentityUser> userManager;
        public WebLog_LabelController(IWeblogLabelService WebLog_LabelService, UserManager<IdentityUser> userManager)
        {
            this.WebLog_LabelService = WebLog_LabelService;
            this.userManager = userManager;
        }

        #endregion
        #region Index
        public IActionResult Index(CancellationToken cancellationToken, int currentPage = 1)
        {
            ViewBag.isActive_User_Menu = "WebLogLabelController";
            int number_showproduct = 12;
            ViewBag.counter = (currentPage < 1) ? 1 : (((currentPage - 1) * number_showproduct) + 1);
            var UserId = userManager.GetUserId(User);
            var result = WebLog_LabelService.ShowAllWeblogLabel_PagingAsync(cancellationToken, UserId, currentPage, number_showproduct);

            return View(result);
        }

        #endregion
        #region Add
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WebLog_LabelDto WebLog_LabelDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                string result = await CaseChecOrderUrlkAdd(WebLog_LabelDto, cancellationToken);
                if (!string.IsNullOrEmpty(result))
                    return RedirectToAction(result);

            }
            return View(WebLog_LabelDto);
        }
        public async Task<string> CaseChecOrderUrlkAdd(WebLog_LabelDto WebLog_LabelDto, CancellationToken cancellationToken)
        {
            var isCheckRepeatUrlMeta = await WebLog_LabelService.CheckRepeatUrlMeta(WebLog_LabelDto.Url_Meta);
            var isCheckRepeatOrder = await WebLog_LabelService.CheckRepeatOrder(WebLog_LabelDto.WebLog_Label_Order.Value);
            if (isCheckRepeatOrder && isCheckRepeatUrlMeta)
            {
                if (isCheckRepeatOrder)
                    ViewBag.error_RepeatOrder = $"❌  ورودی های عمومی /  ✨ {WebLog_LabelDto.WebLog_Label_Order}  ✨ / این مرتب سازی  از قبل موجود می باشد . ";

                if (isCheckRepeatUrlMeta)
                    ViewBag.error_Url_Meta = $"❌  ورودی های سئو /  ✨ {WebLog_LabelDto.Url_Meta}  ✨ / این آدرس اینترنتی  از قبل موجود می باشد . ";

            }
            if (isCheckRepeatOrder && !isCheckRepeatUrlMeta)
            {
                if (isCheckRepeatOrder)
                    ViewBag.error_RepeatOrder = $"❌  ورودی های عمومی /  ✨ {WebLog_LabelDto.WebLog_Label_Order}  ✨ / این مرتب سازی  از قبل موجود می باشد . ";

            }
            if (!isCheckRepeatOrder && isCheckRepeatUrlMeta)
            {
                if (isCheckRepeatUrlMeta)
                    ViewBag.error_Url_Meta = $"❌  ورودی های سئو /  ✨ {WebLog_LabelDto.Url_Meta}  ✨ / این آدرس اینترنتی  از قبل موجود می باشد . ";

            }
            if (!isCheckRepeatOrder && !isCheckRepeatUrlMeta)
            {
                WebLog_LabelDto.UserId = userManager.GetUserId(User);
                await WebLog_LabelService.AddWebLog_LabelAsync(WebLog_LabelDto, cancellationToken);
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

            var WebLog_Label = await WebLog_LabelService.GetByIdAsync(cancellationToken, id);
            if (WebLog_Label == null)
            {
                return NotFound();
            }
            #region WebLog_LabelDto + AvatarImage + IconImage
            ViewBag.WebLog_Label_Image = WebLog_Label.WebLog_Label_Image ?? "/images/default.png";
            ViewBag.WebLog_Label_ImageHome = WebLog_Label.WebLog_Label_ImageHome ?? "/images/default.png";
            ViewBag.WebLog_Label_ThumbnaillImage = WebLog_Label.WebLog_Label_ThumbnaillImage ?? "/images/default.png";
            ViewBag.Image_Meta = WebLog_Label.Image_Meta ?? "/images/default.png";
          
            var WebLog_LabelDto = new WebLog_LabelDto()
            {
                Id = WebLog_Label.Id,

                WebLog_Label_IsShow = WebLog_Label.WebLog_Label_IsShow,
                WebLog_Label_ShortDescription = WebLog_Label.WebLog_Label_ShortDescription,
                WebLog_Label_ShortLink = WebLog_Label.WebLog_Label_ShortLink,
                WebLog_Label_Description = WebLog_Label.WebLog_Label_Description,
                WebLog_Label_Order = WebLog_Label.WebLog_Label_Order,
                WebLog_Label_Title_One = WebLog_Label.WebLog_Label_Title_One,
                WebLog_Label_Title_Two = WebLog_Label.WebLog_Label_Title_Two,
                //=======Meta Tags==========//
                Title_Meta = WebLog_Label.Title_Meta,
                TitleEnglish_Meta = WebLog_Label.TitleEnglish_Meta,
                Url_Meta = WebLog_Label.Url_Meta,
                Desc_Meta = WebLog_Label.Desc_Meta,
                Canonical_Meta = WebLog_Label.Canonical_Meta,
                Keyword_Meta = WebLog_Label.Keyword_Meta,
                //=======Meta Tags==========//
                CreateDate = WebLog_Label.CreateDate,
                LastUpdateDate = WebLog_Label.LastUpdateDate

            };
            #endregion
            return View(WebLog_LabelDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WebLog_LabelDto WebLog_LabelDto, string _WebLog_Label_Image, string _WebLog_Label_ImageHome, string _WebLog_Label_ThumbnaillImage, string _Image_Meta, CancellationToken cancellationToken)
        {
            if (id != WebLog_LabelDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string result = await CaseChecOrderUrlkUpdate(WebLog_LabelDto, _WebLog_Label_Image, _WebLog_Label_ImageHome, _WebLog_Label_ThumbnaillImage, _Image_Meta, cancellationToken);
                    if (!string.IsNullOrEmpty(result))
                        return RedirectToAction(result);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebLog_LabelExists(WebLog_LabelDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            return View(WebLog_LabelDto);
        }
        public async Task<string> CaseChecOrderUrlkUpdate(WebLog_LabelDto WebLog_LabelDto, string _WebLog_Category_Image, string _WebLog_Category_ImageHome, string _WebLog_Category_ThumbnaillImage, string _Image_Meta, CancellationToken cancellationToken)
        {
            var weblog_Label = await WebLog_LabelService.TableNoTracking.FirstOrDefaultAsync(x => x.Id == WebLog_LabelDto.Id);
            var url_meta_New = WebLog_LabelDto.Url_Meta;
            var url_meta_Ago = weblog_Label.Url_Meta;
            var order_New = WebLog_LabelDto.WebLog_Label_Order;
            var order_Ago = weblog_Label.WebLog_Label_Order;

            if ((url_meta_New == url_meta_Ago) && (order_New == order_Ago))
            {
                WebLog_LabelDto.UserId = userManager.GetUserId(User);
                await WebLog_LabelService.UpdateWebLog_LabelAsync(WebLog_LabelDto, _WebLog_Category_Image, _WebLog_Category_ImageHome, _WebLog_Category_ThumbnaillImage, _Image_Meta, cancellationToken);

                return "Index";
            }
            else if (!(url_meta_New == url_meta_Ago) && (order_New == order_Ago))
            {
                var isCheckRepeatUrlMeta = await WebLog_LabelService.CheckRepeatUrlMeta(WebLog_LabelDto.Url_Meta);

                if (isCheckRepeatUrlMeta)
                    ViewBag.error_Url_Meta = $"❌  ورودی های سئو /  ✨ {WebLog_LabelDto.Url_Meta}  ✨ / این آدرس اینترنتی  از قبل موجود می باشد . ";


            }
            else if ((url_meta_New == url_meta_Ago) && !(order_New == order_Ago))
            {
                var isCheckRepeatOrder = await WebLog_LabelService.CheckRepeatOrder(WebLog_LabelDto.WebLog_Label_Order.Value);

                if (isCheckRepeatOrder)
                    ViewBag.error_RepeatOrder = $"❌  ورودی های عمومی /  ✨ {WebLog_LabelDto.WebLog_Label_Order}  ✨ / این مرتب سازی  از قبل موجود می باشد . ";


            }
            else
            {
                var isCheckRepeatUrlMeta = await WebLog_LabelService.CheckRepeatUrlMeta(WebLog_LabelDto.Url_Meta);
                var isCheckRepeatOrder = await WebLog_LabelService.CheckRepeatOrder(WebLog_LabelDto.WebLog_Label_Order.Value);
                if (isCheckRepeatOrder && isCheckRepeatUrlMeta)
                {
                    if (isCheckRepeatOrder)
                        ViewBag.error_RepeatOrder = $"❌  ورودی های عمومی /  ✨ {WebLog_LabelDto.WebLog_Label_Order}  ✨ / این مرتب سازی  از قبل موجود می باشد . ";

                    if (isCheckRepeatUrlMeta)
                        ViewBag.error_Url_Meta = $"❌  ورودی های سئو /  ✨ {WebLog_LabelDto.Url_Meta}  ✨ / این آدرس اینترنتی  از قبل موجود می باشد . ";

                }
                if (isCheckRepeatOrder && !isCheckRepeatUrlMeta)
                {
                    if (isCheckRepeatOrder)
                        ViewBag.error_RepeatOrder = $"❌  ورودی های عمومی /  ✨ {WebLog_LabelDto.WebLog_Label_Order}  ✨ / این مرتب سازی  از قبل موجود می باشد . ";

                }
                if (!isCheckRepeatOrder && isCheckRepeatUrlMeta)
                {
                    if (isCheckRepeatUrlMeta)
                        ViewBag.error_Url_Meta = $"❌  ورودی های سئو /  ✨ {WebLog_LabelDto.Url_Meta}  ✨ / این آدرس اینترنتی  از قبل موجود می باشد . ";

                }
                if (!isCheckRepeatOrder && !isCheckRepeatUrlMeta)
                {
                    WebLog_LabelDto.UserId = userManager.GetUserId(User);
                    await WebLog_LabelService.AddWebLog_LabelAsync(WebLog_LabelDto, cancellationToken);
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

            var WebLog_Label = await WebLog_LabelService.GetByIdAsync(cancellationToken, id);


            if (WebLog_Label == null)
            {
                return NotFound();
            }

            return View(WebLog_Label);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
        {
            var WebLog_Label = await WebLog_LabelService.GetByIdAsync(cancellationToken, id);
            await WebLog_LabelService.DeleteAsync(WebLog_Label, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        #endregion


        private bool WebLog_LabelExists(int id)
        {
            return WebLog_LabelService.TableNoTracking.Any(e => e.Id == id);
        }
    }
}
