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

    public class ContactUsController : Controller
    {
        private readonly IContactUsService ContactUsService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMapper mapper;


        public ContactUsController(IContactUsService ContactUsService, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            this.ContactUsService = ContactUsService;
            this.userManager = userManager;
            this.mapper = mapper;

        }

        public IActionResult Index(CancellationToken cancellationToken, int currentPage = 1)
        {
            ViewBag.isActive_User_Menu = "ContactUssController";
            int number_showproduct = 12;
            ViewBag.counter = (currentPage < 1) ? 1 : (((currentPage - 1) * number_showproduct) + 1);
            var UserId = userManager.GetUserId(User);
            var result = ContactUsService.ShowAllContactUs_PagingAsync(cancellationToken, UserId, currentPage, number_showproduct);

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CancellationToken cancellationToken, ContactUsDto ContactUsDto)
        {
            if (ModelState.IsValid)
            {
                ContactUsDto.UserId = userManager.GetUserId(User);
                await ContactUsService.AddContactUsAsync(ContactUsDto, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            return View(ContactUsDto);
        }

        public async Task<IActionResult> Edit(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ContactUs = await ContactUsService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (ContactUs == null)
            {
                return NotFound();
            }
            #region ContactUs + Image
            ViewBag.ContactUs_Image = ContactUs.ContactUs_Image ?? "/images/default.png";

            ContactUsDto ContactUsDto = mapper.Map<Entities.ContactUs, ContactUsDto>(ContactUs);

            #endregion
            return View(ContactUsDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string _ContactUs_Image, ContactUsDto ContactUsDto, CancellationToken cancellationToken)
        {
            if (id != ContactUsDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ContactUsDto.UserId = userManager.GetUserId(User);
                    await ContactUsService.UpdateContactUsAsync(ContactUsDto, _ContactUs_Image, cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillExists(ContactUsDto.Id))
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
            return View(ContactUsDto);
        }

        public async Task<IActionResult> Delete(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }


            var ContactUs = await ContactUsService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (ContactUs == null)
            {
                return NotFound();
            }

            return View(ContactUs);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
        {
            var ContactUs = await ContactUsService.TableNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

            await ContactUsService.DeleteAsync(ContactUs, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        private bool SkillExists(int id)
        {
            return ContactUsService.TableNoTracking.Any(e => e.Id == id);
        }
    }
}
