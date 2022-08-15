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
    public class SettingsEnemadsController : Controller
    {
        private readonly ISettingsEnemadsService settingsEnemadsService;
        private readonly UserManager<IdentityUser> userManager;


        public SettingsEnemadsController(ISettingsEnemadsService settingsEnemadsService, UserManager<IdentityUser> userManager)
        {
            this.settingsEnemadsService = settingsEnemadsService;
            this.userManager = userManager;

        }

        public IActionResult Index(CancellationToken cancellationToken, int currentPage = 1)
        {
            ViewBag.isActive_User_Menu = "SettingsEnemadsController";
            int number_showproduct = 12;
            ViewBag.counter = (currentPage < 1) ? 1 : (((currentPage - 1) * number_showproduct) + 1);
            var UserId = userManager.GetUserId(User);
            var result = settingsEnemadsService.ShowAllSettingsEnemad_PagingAsync(cancellationToken, UserId, currentPage, number_showproduct);

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SettingsEnemadDto SettingsEnemadDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                SettingsEnemadDto.UserId = userManager.GetUserId(User);
                await settingsEnemadsService.AddSettingsEnemadAsync(SettingsEnemadDto, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            return View(SettingsEnemadDto);
        }

        public async Task<IActionResult> Edit(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }
            var settingsEnemad1 = await settingsEnemadsService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (settingsEnemad1 == null)
            {
                return NotFound();
            }

            #region SettingsEnemadDto + Settings_Image_Enemad
            ViewBag.Settings_Image_Enemad = settingsEnemad1.Settings_Image_Enemad ?? "/images/default.png";

            var settingsEnemad = new SettingsEnemadDto()
            {
                Id = settingsEnemad1.Id,
                Settings_href_Enemad = settingsEnemad1.Settings_href_Enemad,
                Settings_IsExist_Enemad = settingsEnemad1.Settings_IsExist_Enemad,
                Settings_Title_Enemad = settingsEnemad1.Settings_Title_Enemad,              
                UserId = settingsEnemad1.UserId,
                CreateDate = settingsEnemad1.CreateDate,
                LastUpdateDate = settingsEnemad1.LastUpdateDate
            };
            #endregion
            return View(settingsEnemad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SettingsEnemadDto SettingsEnemadDto, string _Settings_Image_Enemad, CancellationToken cancellationToken)
        {
            if (id != SettingsEnemadDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    SettingsEnemadDto.UserId = userManager.GetUserId(User);

                    await settingsEnemadsService.UpdateSettingsEnemadAsync(SettingsEnemadDto, _Settings_Image_Enemad, cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomPageExists(SettingsEnemadDto.Id))
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
            return View(SettingsEnemadDto);
        }

        public async Task<IActionResult> Delete(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settingsEnemad1 = await settingsEnemadsService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (settingsEnemad1 == null)
            {
                return NotFound();
            }

            return View(settingsEnemad1);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
        {
            var settingsEnemad1 = await settingsEnemadsService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            await settingsEnemadsService.DeleteAsync(settingsEnemad1, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        private bool CustomPageExists(int id)
        {
            return settingsEnemadsService.TableNoTracking.Any(e => e.Id == id);
        }
    }
}
