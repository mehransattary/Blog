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
    public class SettingsLogoesController : Controller
    {
        private readonly ISettingsLogoesService settingsLogoesService;
        private readonly UserManager<IdentityUser> userManager;


        public SettingsLogoesController(ISettingsLogoesService settingsLogoesService, UserManager<IdentityUser> userManager)
        {
            this.settingsLogoesService = settingsLogoesService;
            this.userManager = userManager;

        }

        public IActionResult Index(CancellationToken cancellationToken, int currentPage = 1)
        {
            ViewBag.isActive_User_Menu = "SettingsLogoesController";
            int number_showproduct = 12;
            ViewBag.counter = (currentPage < 1) ? 1 : (((currentPage - 1) * number_showproduct) + 1);
            var UserId = userManager.GetUserId(User);
            var result = settingsLogoesService.ShowAllSettingsLogo_PagingAsync(cancellationToken, UserId, currentPage, number_showproduct);

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SettingsLogoDto SettingsLogoDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                SettingsLogoDto.UserId = userManager.GetUserId(User);
                await settingsLogoesService.AddSettingsLogoAsync(SettingsLogoDto, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            return View(SettingsLogoDto);
        }

        public async Task<IActionResult> Edit(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }
            var settingsLogo = await settingsLogoesService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (settingsLogo == null)
            {
                return NotFound();
            }
            #region SettingsLogoDto + Settings_Image_Logo + Settings_Image_Logo_Footer
            ViewBag.Settings_Image_Logo = settingsLogo.Settings_Image_Logo ?? "/images/default.png";
            ViewBag.Settings_Image_Logo_Footer = settingsLogo.Settings_Image_Logo_Footer ?? "/images/default.png";
            ViewBag.Settings_Icon_Path = settingsLogo.Settings_Icon_Path ?? "/images/default.png";

            var settingsLogoDto = new SettingsLogoDto()
            {
                Id = settingsLogo.Id,
                Settings_alt_Logo = settingsLogo.Settings_alt_Logo,
                Settings_title_Logo = settingsLogo.Settings_title_Logo,
                UserId = settingsLogo.UserId,
                CreateDate = settingsLogo.CreateDate,
                LastUpdateDate = settingsLogo.LastUpdateDate
            };
            #endregion
            return View(settingsLogoDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SettingsLogoDto SettingsLogoDto, string _Settings_Image_Logo, string _Settings_Image_Logo_Footer,string _Settings_Icon_Path, CancellationToken cancellationToken)
        {
            if (id != SettingsLogoDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    SettingsLogoDto.UserId = userManager.GetUserId(User);

                    await settingsLogoesService.UpdateSettingsLogoAsync(SettingsLogoDto, _Settings_Image_Logo, _Settings_Image_Logo_Footer, _Settings_Icon_Path, cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomPageExists(SettingsLogoDto.Id))
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
            return View(SettingsLogoDto);
        }

        public async Task<IActionResult> Delete(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settingsLogo = await settingsLogoesService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (settingsLogo == null)
            {
                return NotFound();
            }

            return View(settingsLogo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
        {
            var settingsLogo = await settingsLogoesService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            await settingsLogoesService.DeleteAsync(settingsLogo, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        private bool CustomPageExists(int id)
        {
            return settingsLogoesService.TableNoTracking.Any(e => e.Id == id);
        }
    }
}
