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
using AutoMapper;

namespace ProMe_Admin.Controllers
{
    [Area("Admin_Blog")]
    [Authorize(Policy = "admin")]
    [AutoValidateAntiforgeryToken]

    public class WebLogSliderController : Controller
    {
        #region Ctor
        private readonly IWeblogService WebLogService;
        private readonly IWeblogGroupService weblogGroupService;
        private readonly IWeblogCategoryService weblogCategoryService;
        private readonly IWeblogLabelService weblogLabelService;

        private readonly IWebLog_SliderService webLog_SliderService;
        private readonly IMapper mapper;

        private readonly UserManager<IdentityUser> userManager;
        public WebLogSliderController(IWeblogService WebLogService, IWeblogGroupService weblogGroupService, UserManager<IdentityUser> userManager, IWebLog_SliderService webLog_SliderService, IWeblogCategoryService weblogCategoryService, IWeblogLabelService weblogLabelService, IMapper mapper)
        {
            this.WebLogService = WebLogService;
            this.weblogGroupService = weblogGroupService;
            this.weblogCategoryService = weblogCategoryService;
            this.weblogLabelService = weblogLabelService;
            this.userManager = userManager;
            this.webLog_SliderService = webLog_SliderService;
            this.mapper = mapper;


        }
        #endregion
        #region Index
        public IActionResult Index(CancellationToken cancellationToken, int currentPage = 1,int groupId=0)
        {
            ViewBag.isActive_User_Menu = "WebLogsController";
            int number_showproduct = 12;
            ViewBag.counter = (currentPage < 1) ? 1 : (((currentPage - 1) * number_showproduct) + 1);
            var UserId = userManager.GetUserId(User);
            var result = webLog_SliderService.ShowAllWebLog_Slider_PagingAsync(cancellationToken, UserId, currentPage, number_showproduct);

         
            return View(result);

        }
        #endregion
        #region Add

        public async Task<IActionResult> Create(CancellationToken cancellationToken,int groupId=0)
        {
            var UserId = userManager.GetUserId(User);

            var selectGroups =await weblogGroupService.SelectListAsync(cancellationToken);
            var selectCategory = await weblogCategoryService.SelectListAsync(cancellationToken);
            var selectWeblog = await WebLogService.SelectListAsync(cancellationToken);
            var selectLabel = await weblogLabelService.SelectListAsync(cancellationToken);


            ViewData["WebLog_Slider_CategoryId"] = new SelectList(selectCategory, "Id", "WebLog_Category_Title_One");

            ViewData["WebLog_Slider_GroupId"] = new SelectList(selectGroups, "Id", "WebLog_Group_Title_One");

            ViewData["WebLog_Slider_BlogId"] = new SelectList(selectWeblog, "Id", "Weblog_Title_One");

            ViewData["WebLog_Slider_LabelId"] = new SelectList(selectLabel, "Id", "WebLog_Label_Title_One");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WebLog_SliderDto webLog_SliderDto, CancellationToken cancellationToken, int groupId = 0)
        {
         
            if (ModelState.IsValid)
            {
                var UserId = userManager.GetUserId(User);
                webLog_SliderDto.UserId = UserId;
                await  webLog_SliderService.AddWebLog_SliderAsync(webLog_SliderDto, cancellationToken);
                return RedirectToAction("Index");

            }
         

            var selectGroups = await weblogGroupService.SelectListAsync(cancellationToken);
            var selectCategory = await weblogCategoryService.SelectListAsync(cancellationToken);
            var selectWeblog = await WebLogService.SelectListAsync(cancellationToken);
            var selectLabel = await weblogLabelService.SelectListAsync(cancellationToken);


            ViewData["WebLog_Slider_CategoryId"] = new SelectList(selectCategory, "Id", "WebLog_Category_Title_One", webLog_SliderDto.WebLog_Slider_CategoryId);

            ViewData["WebLog_Slider_GroupId"] = new SelectList(selectGroups, "Id", "WebLog_Group_Title_One", webLog_SliderDto.WebLog_Slider_GroupId);

            ViewData["WebLog_Slider_BlogId"] = new SelectList(selectWeblog, "Id", "Weblog_Title_One", webLog_SliderDto.WebLog_Slider_BlogId);

            ViewData["WebLog_Slider_LabelId"] = new SelectList(selectLabel, "Id", "WebLog_Label_Title_One", webLog_SliderDto.WebLog_Slider_LabelId);

            return View(webLog_SliderDto);
        }

   

        #endregion
        #region Update
        public async Task<IActionResult> Edit(int? id, CancellationToken cancellationToken,int groupId = 0)
        {
            if (id == null)
            {
                return NotFound();
            }

            var WeblogSlider = await webLog_SliderService.TableNoTracking.FirstOrDefaultAsync(x=>x.Id== id);
            if (WeblogSlider == null)
            {
                return NotFound();
            }
            #region WeblogDto + AvatarImage + IconImage
            ViewBag.WebLog_Slider_Image = WeblogSlider.WebLog_Slider_Image ?? "/images/default.png";
     

            var UserId = userManager.GetUserId(User);


            var selectGroups = await weblogGroupService.SelectListAsync(cancellationToken);
            var selectCategory = await weblogCategoryService.SelectListAsync(cancellationToken);
            var selectWeblog = await WebLogService.SelectListAsync(cancellationToken);
            var selectLabel = await weblogLabelService.SelectListAsync(cancellationToken);


            ViewData["WebLog_Slider_CategoryId"] = new SelectList(selectCategory, "Id", "WebLog_Category_Title_One");

            ViewData["WebLog_Slider_GroupId"] = new SelectList(selectGroups, "Id", "WebLog_Group_Title_One");

            ViewData["WebLog_Slider_BlogId"] = new SelectList(selectWeblog, "Id", "Weblog_Title_One");

            ViewData["WebLog_Slider_LabelId"] = new SelectList(selectLabel, "Id", "WebLog_Label_Title_One");

            var webSilderDto = mapper.Map<WebLog_Slider, WebLog_SliderDto> (WeblogSlider);
            #endregion
            return View(webSilderDto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WebLog_SliderDto webLog_SliderDto, string _WebLog_Slider_Image, CancellationToken cancellationToken,int groupId = 0)
        {
            if (id != webLog_SliderDto.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var UserId = userManager.GetUserId(User);
                    webLog_SliderDto.UserId = UserId;
                    await webLog_SliderService.UpdateWebLog_SliderAsync(webLog_SliderDto, _WebLog_Slider_Image,cancellationToken);
                    return RedirectToAction("Index");

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeblogExists(webLog_SliderDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
       
            var selectGroups = await weblogGroupService.SelectListAsync(cancellationToken);
            var selectCategory = await weblogCategoryService.SelectListAsync(cancellationToken);
            var selectWeblog = await WebLogService.SelectListAsync(cancellationToken);
            var selectLabel = await weblogLabelService.SelectListAsync(cancellationToken);


            ViewData["WebLog_Slider_CategoryId"] = new SelectList(selectCategory, "Id", "WebLog_Category_Title_One");

            ViewData["WebLog_Slider_GroupId"] = new SelectList(selectGroups, "Id", "WebLog_Group_Title_One");

            ViewData["WebLog_Slider_BlogId"] = new SelectList(selectWeblog, "Id", "Weblog_Title_One");

            ViewData["WebLog_Slider_LabelId"] = new SelectList(selectLabel, "Id", "WebLog_Label_Title_One");
    
            return View(webLog_SliderDto);
        }



        #endregion
        #region Delete

        public async Task<IActionResult> Delete(int? id, CancellationToken cancellationToken,int groupId = 0)
        {
            if (id == null)
            {
                return NotFound();
            }
            var WeblogSlider = await webLog_SliderService.GetByIdAsync(cancellationToken, id);
            if (groupId != 0)
            {
                ViewBag.groupId = groupId;
            }

            if (WeblogSlider == null)
            {
                return NotFound();
            }

            return View(WeblogSlider);
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
