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
    public class SettingsMetasController : Controller
    {
        private readonly ISettingsMetasService settingsMetasService;
        private readonly UserManager<IdentityUser> userManager;


        public SettingsMetasController(ISettingsMetasService settingsMetasService, UserManager<IdentityUser> userManager)
        {
            this.settingsMetasService = settingsMetasService;
            this.userManager = userManager;

        }

        public IActionResult Index(CancellationToken cancellationToken, int currentPage = 1)
        {
            ViewBag.isActive_User_Menu = "SettingsMetasController";
            int number_showproduct = 12;
            ViewBag.counter = (currentPage < 1) ? 1 : (((currentPage - 1) * number_showproduct) + 1);
            var UserId = userManager.GetUserId(User);
            var result = settingsMetasService.ShowAllSettingsMeta_PagingAsync(cancellationToken, UserId, currentPage, number_showproduct);

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SettingsMetaDto SettingsMetaDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                SettingsMetaDto.UserId = userManager.GetUserId(User);
                await settingsMetasService.AddSettingsMetaAsync(SettingsMetaDto, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            return View(SettingsMetaDto);
        }

        public async Task<IActionResult> Edit(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }
            var settingsMeta = await settingsMetasService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (settingsMeta == null)
            {
                return NotFound();
            }
            #region SettingsMetaDto + Settings_Image_Logo + Settings_Image_Logo_Footer
            ViewBag.Settings_twitter_image = settingsMeta.Settings_twitter_image ?? "/images/default.png";
            ViewBag.Settings_ogimage = settingsMeta.Settings_ogimage ?? "/images/default.png";


            var settingsMetaDto = new SettingsMetaDto()
            {
                Id = settingsMeta.Id,
                Settings_description = settingsMeta.Settings_description,
                Settings_canonical = settingsMeta.Settings_canonical,
                Settings_Google_Analytics = settingsMeta.Settings_Google_Analytics,
                Settings_author = settingsMeta.Settings_author,
                Settings_twitter_description = settingsMeta.Settings_twitter_description,
                Settings_keywords = settingsMeta.Settings_keywords,
                Settings_ogdescription = settingsMeta.Settings_ogdescription,
                Settings_ogsite_name = settingsMeta.Settings_ogsite_name,
                Settings_ogtitle = settingsMeta.Settings_ogtitle,
                Settings_Service_Adver_1 = settingsMeta.Settings_Service_Adver_1,
                Settings_Service_Adver_2 = settingsMeta.Settings_Service_Adver_2,
                Settings_Service_Adver_3 = settingsMeta.Settings_Service_Adver_3,
                Settings_Service_Adver_4 = settingsMeta.Settings_Service_Adver_4,
                Settings_ogurl = settingsMeta.Settings_ogurl,
                Settings_twitter_title = settingsMeta.Settings_twitter_title,
                Settings_Search_Console = settingsMeta.Settings_Search_Console,
                UserId = settingsMeta.UserId,
                CreateDate = settingsMeta.CreateDate,
                LastUpdateDate = settingsMeta.LastUpdateDate
            };
            #endregion
            return View(settingsMetaDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SettingsMetaDto SettingsMetaDto, string _Settings_twitter_image, string _Settings_ogimage, CancellationToken cancellationToken)
        {
            if (id != SettingsMetaDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    SettingsMetaDto.UserId = userManager.GetUserId(User);

                    await settingsMetasService.UpdateSettingsMetaAsync(SettingsMetaDto, _Settings_twitter_image, _Settings_ogimage, cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomPageExists(SettingsMetaDto.Id))
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
            return View(SettingsMetaDto);
        }

        public async Task<IActionResult> Delete(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settingsMeta = await settingsMetasService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (settingsMeta == null)
            {
                return NotFound();
            }

            return View(settingsMeta);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
        {
            var settingsMeta = await settingsMetasService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            await settingsMetasService.DeleteAsync(settingsMeta, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        private bool CustomPageExists(int id)
        {
            return settingsMetasService.TableNoTracking.Any(e => e.Id == id);
        }
    }
}
