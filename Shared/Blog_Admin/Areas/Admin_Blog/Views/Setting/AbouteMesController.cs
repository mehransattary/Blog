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

namespace Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    [AutoValidateAntiforgeryToken]

    public class AbouteMesController : Controller
    {
        private readonly IAbouteMeService AbouteMeService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMapper mapper;


        public AbouteMesController(IAbouteMeService AbouteMeService, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            this.AbouteMeService = AbouteMeService;
            this.userManager = userManager;
            this.mapper = mapper;

        }

        public IActionResult Index(CancellationToken cancellationToken, int currentPage = 1)
        {
            ViewBag.isActive_User_Menu = "AbouteMesController";
            int number_showproduct = 12;
            ViewBag.counter = (currentPage < 1) ? 1 : (((currentPage - 1) * number_showproduct) + 1);
            var UserId = userManager.GetUserId(User);
            var result = AbouteMeService.ShowAllAbouteMe_PagingAsync(cancellationToken, UserId, currentPage, number_showproduct);

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CancellationToken cancellationToken, AbouteMeDto AbouteMeDto)
        {
            if (ModelState.IsValid)
            {
                AbouteMeDto.UserId = userManager.GetUserId(User);
                await AbouteMeService.AddAbouteMeAsync(AbouteMeDto, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            return View(AbouteMeDto);
        }

        public async Task<IActionResult> Edit(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var AbouteMe = await AbouteMeService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (AbouteMe == null)
            {
                return NotFound();
            }
            #region AbouteMe + Image
            ViewBag.AbouteMe_Image = AbouteMe.AbouteMe_Image ?? "/images/default.png";

            AbouteMeDto AbouteMeDto = mapper.Map<Entities.AbouteMe, AbouteMeDto>(AbouteMe);

            #endregion
            return View(AbouteMeDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string _AbouteMes_Image, AbouteMeDto AbouteMeDto, CancellationToken cancellationToken)
        {
            if (id != AbouteMeDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    AbouteMeDto.UserId = userManager.GetUserId(User);
                    await AbouteMeService.UpdateAbouteMeAsync(AbouteMeDto, _AbouteMes_Image, cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillExists(AbouteMeDto.Id))
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
            return View(AbouteMeDto);
        }

        public async Task<IActionResult> Delete(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }


            var AbouteMe = await AbouteMeService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (AbouteMe == null)
            {
                return NotFound();
            }

            return View(AbouteMe);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
        {
            var AbouteMe = await AbouteMeService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            await AbouteMeService.DeleteAsync(AbouteMe, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        private bool SkillExists(int id)
        {
            return AbouteMeService.TableNoTracking.Any(e => e.Id == id);
        }
    }
}
