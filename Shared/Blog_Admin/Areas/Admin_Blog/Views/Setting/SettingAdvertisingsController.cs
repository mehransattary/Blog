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

namespace Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    [AutoValidateAntiforgeryToken]

    public class SettingAdvertisingsController : Controller
    {
        private readonly ISettingAdvertisingService  settingAdvertisingService;
        private readonly UserManager<IdentityUser> userManager;


        public SettingAdvertisingsController(ISettingAdvertisingService settingAdvertisingService, UserManager<IdentityUser> userManager)
        {
            this.settingAdvertisingService = settingAdvertisingService;
            this.userManager = userManager;
        }

        public IActionResult Index(CancellationToken cancellationToken, int currentPage = 1)
        {
            ViewBag.isActive_User_Menu = "SettingAdvertisingsController";
            int number_showproduct = 12;
            ViewBag.counter = (currentPage < 1) ? 1 : (((currentPage - 1) * number_showproduct) + 1);
            var UserId = userManager.GetUserId(User);
            var result = settingAdvertisingService.ShowAllSettingAdvertising_PagingAsync(cancellationToken, UserId, currentPage, number_showproduct);

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CancellationToken cancellationToken, SettingAdvertisingDto  settingAdvertisingDto)
        {
            if (ModelState.IsValid)
            {
                settingAdvertisingDto.UserId = userManager.GetUserId(User);
                await settingAdvertisingService.AddSettingAdvertisingAsync(settingAdvertisingDto, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            return View(settingAdvertisingDto);
        }

        public async Task<IActionResult> Edit(byte? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settingAdvertising = await settingAdvertisingService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (settingAdvertising == null)
            {
                return NotFound();
            }

            #region settingAdvertising 

            var settingAdvertisingDto = new SettingAdvertisingDto()
            {
                Id = settingAdvertising.Id,
                UserId = settingAdvertising.UserId,
               Settings_Advertising_Title= settingAdvertising.Settings_Advertising_Title,
               Settings_alt_Title= settingAdvertising.Settings_alt_Title,
               Settings_href_Title= settingAdvertising.Settings_href_Title,
               Settings_title_Title= settingAdvertising.Settings_title_Title,
                CreateDate = settingAdvertising.CreateDate,
                LastUpdateDate = settingAdvertising.LastUpdateDate

            };
            #endregion
            return View(settingAdvertisingDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, string _Image, SettingAdvertisingDto settingAdvertisingDto, CancellationToken cancellationToken)
        {
            if (id != settingAdvertisingDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    settingAdvertisingDto.UserId = userManager.GetUserId(User);
                    await settingAdvertisingService.UpdateSettingAdvertisingAsync(settingAdvertisingDto, cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillExists(settingAdvertisingDto.Id))
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
            return View(settingAdvertisingDto);
        }

        public async Task<IActionResult> Delete(byte? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }


            var settingAdvertising = await settingAdvertisingService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (settingAdvertising == null)
            {
                return NotFound();
            }

            return View(settingAdvertising);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id, CancellationToken cancellationToken)
        {
            var settingAdvertising = await settingAdvertisingService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            await settingAdvertisingService.DeleteAsync(settingAdvertising, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        private bool SkillExists(int id)
        {
            return settingAdvertisingService.TableNoTracking.Any(e => e.Id == id);
        }
    }
}
