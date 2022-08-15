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
using IRepositories;
using System.Threading;
using X.PagedList;
using Data.Dto;
using Service.Repository.Interface;
using Microsoft.AspNetCore.Identity;

namespace Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    [AutoValidateAntiforgeryToken]
    public class SettingsCopyRightsController : Controller
    {
        private readonly ISettingsCopyRightsService settingsCopyRightsService;
        private readonly UserManager<IdentityUser> userManager;


        public SettingsCopyRightsController(ISettingsCopyRightsService settingsCopyRightsService, UserManager<IdentityUser> userManager)
        {
            this.settingsCopyRightsService = settingsCopyRightsService;
            this.userManager = userManager;

        }

        public IActionResult Index(CancellationToken cancellationToken, int currentPage = 1)
        {
            ViewBag.isActive_User_Menu = "SettingsCopyRightsController";
            int number_showproduct = 12;
            ViewBag.counter = (currentPage < 1) ? 1 : (((currentPage - 1) * number_showproduct) + 1);
            var UserId = userManager.GetUserId(User);
            var result = settingsCopyRightsService.ShowAllSettingsCopyRight_PagingAsync(cancellationToken, UserId, currentPage, number_showproduct);

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SettingsCopyRightDto settingsCopyRightDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                settingsCopyRightDto.UserId = userManager.GetUserId(User);
                await settingsCopyRightsService.AddSettingsCopyRightAsync(settingsCopyRightDto, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            return View(settingsCopyRightDto);
        }

        public async Task<IActionResult> Edit(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }
            var settingsCopyRight = await settingsCopyRightsService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (settingsCopyRight == null)
            {
                return NotFound();
            }

            #region customPageDto + Image
            ViewBag.Settings_Tarah_Logo_Image = settingsCopyRight.Settings_Tarah_Logo_Image ?? "/images/default.png";

            var settingsCopy = new SettingsCopyRightDto()
            {
                Id = settingsCopyRight.Id,
                Settings_Tarah_FullName = settingsCopyRight.Settings_Tarah_FullName,
                Settings_Tarah_Href = settingsCopyRight.Settings_Tarah_Href,
                Settings_Tarah_Logo_alt = settingsCopyRight.Settings_Tarah_Logo_alt,
                Settings_Tarah_Logo_Title = settingsCopyRight.Settings_Tarah_Logo_Title,
                Settings_Tarah_Title = settingsCopyRight.Settings_Tarah_Title,
                UserId = settingsCopyRight.UserId,
                CreateDate = settingsCopyRight.CreateDate,
                LastUpdateDate = settingsCopyRight.LastUpdateDate
            };
            #endregion
            return View(settingsCopy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SettingsCopyRightDto settingsCopyRightDto, string _Settings_Tarah_Logo_Image, CancellationToken cancellationToken)
        {
            if (id != settingsCopyRightDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    settingsCopyRightDto.UserId = userManager.GetUserId(User);

                    await settingsCopyRightsService.UpdateSettingsCopyRightAsync(settingsCopyRightDto, _Settings_Tarah_Logo_Image,  cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomPageExists(settingsCopyRightDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(settingsCopyRightDto);
        }

        public async Task<IActionResult> Delete(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settingsCopyRight = await settingsCopyRightsService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (settingsCopyRight == null)
            {
                return NotFound();
            }

            return View(settingsCopyRight);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
        {
            var settingsCopyRight = await settingsCopyRightsService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            await settingsCopyRightsService.DeleteAsync(settingsCopyRight, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        private bool CustomPageExists(int id)
        {
            return settingsCopyRightsService.TableNoTracking.Any(e => e.Id == id);
        }
    }
}
