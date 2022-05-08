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

    public class SocialsController : Controller
    {
        private readonly ISocialService socialService;
        private readonly UserManager<IdentityUser> userManager;


        public SocialsController(ISocialService socialService, UserManager<IdentityUser> userManager)
        {
            this.socialService = socialService;
            this.userManager = userManager;
        }

        public IActionResult Index(CancellationToken cancellationToken, int currentPage = 1)
        {
            ViewBag.isActive_User_Menu = "SocialsController";
            int number_showproduct = 12;
            ViewBag.counter = (currentPage < 1) ? 1 : (((currentPage - 1) * number_showproduct) + 1);
            var UserId = userManager.GetUserId(User);
            var result = socialService.ShowAllSocial_PagingAsync(cancellationToken, UserId, currentPage, number_showproduct);

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CancellationToken cancellationToken, SocialDto socialDto)
        {
            if (ModelState.IsValid)
            {
                socialDto.UserId = userManager.GetUserId(User);
                await socialService.AddSocialAsync(socialDto, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            return View(socialDto);
        }

        public async Task<IActionResult> Edit(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socail = await socialService.GetByIdAsync(cancellationToken, id);
            if (socail == null)
            {
                return NotFound();
            }
            #region social + Image
            ViewBag.Image = socail.Image ?? "/images/default.png";

            var socialDto = new SocialDto()
            {
                Id = socail.Id,
                UserId = socail.UserId,
                FontAwseome = socail.FontAwseome,
                Link = socail.Link,
                Name = socail.Name,
                CreateDate = socail.CreateDate,
                LastUpdateDate = socail.LastUpdateDate

            };
            #endregion
            return View(socialDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string _Image, SocialDto socialDto, CancellationToken cancellationToken)
        {
            if (id != socialDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    socialDto.UserId = userManager.GetUserId(User);
                    await socialService.UpdateSocialAsync(socialDto, _Image, cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillExists(socialDto.Id))
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
            return View(socialDto);
        }

        public async Task<IActionResult> Delete(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }


            var slider = await socialService.GetByIdAsync(cancellationToken, id);

            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
        {
            var project = await socialService.GetByIdAsync(cancellationToken, id);
            await socialService.DeleteAsync(project, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        private bool SkillExists(int id)
        {
            return socialService.TableNoTracking.Any(e => e.Id == id);
        }
    }
}
