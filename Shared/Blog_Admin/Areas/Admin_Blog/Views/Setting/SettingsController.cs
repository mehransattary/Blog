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
using AutoMapper;

namespace Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    [AutoValidateAntiforgeryToken]
    public class SettingsController : Controller
    {
        private readonly ISettingsService  settingsService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMapper mapper;

        public SettingsController(ISettingsService settingsService, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            this.settingsService = settingsService;
            this.userManager = userManager;
            this.mapper = mapper;

        }

        public IActionResult Index(CancellationToken cancellationToken, int currentPage = 1)
        {
            ViewBag.isActive_User_Menu = "SettingsController";
            int number_showproduct = 12;
            ViewBag.counter = (currentPage < 1) ? 1 : (((currentPage - 1) * number_showproduct) + 1);
            var UserId = userManager.GetUserId(User);
            var result = settingsService.ShowAllSettings_PagingAsync(cancellationToken, UserId, currentPage, number_showproduct);

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SettingsDto settingsDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                settingsDto.UserId = userManager.GetUserId(User);
                await settingsService.AddSettingsAsync(settingsDto, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            return View(settingsDto);
        }

        public async Task<IActionResult> Edit(byte? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }
            var settings = await settingsService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (settings == null)
            {
                return NotFound();
            }

            #region customPageDto + Image
            ViewBag.Settings_ImageFooter = settings.Settings_ImageFooter ?? "/images/default.png";
            ViewBag.Settings_ImageTopMain = settings.Settings_ImageTopMain ?? "/images/default.png";
            SettingsDto SettingsDto1 = mapper.Map<Settings,SettingsDto>(settings);
          
            #endregion
            return View(SettingsDto1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SettingsDto settingsDto, string _Settings_ImageFooter, string _Settings_ImageTopMain, CancellationToken cancellationToken)
        {
            if (id != settingsDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    settingsDto.UserId = userManager.GetUserId(User);

                    await settingsService.UpdateSettingsAsync(settingsDto, _Settings_ImageFooter, _Settings_ImageTopMain, cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomPageExists(settingsDto.Id))
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
            return View(settingsDto);
        }

        public async Task<IActionResult> Delete(byte? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settings = await settingsService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (settings == null)
            {
                return NotFound();
            }

            return View(settings);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id, CancellationToken cancellationToken)
        {
            var settings = await settingsService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            await settingsService.DeleteAsync(settings, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        private bool CustomPageExists(int id)
        {
            return settingsService.TableNoTracking.Any(e => e.Id == id);
        }
    }
}
