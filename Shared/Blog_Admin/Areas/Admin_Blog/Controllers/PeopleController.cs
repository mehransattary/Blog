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

    public class PeopleController : Controller
    {
        private readonly IPersonService personService;
        private readonly UserManager<IdentityUser> userManager;
        public PeopleController(IPersonService personService, UserManager<IdentityUser> userManager)
        {
            this.personService = personService;
            this.userManager = userManager;

        }


        public IActionResult Index(CancellationToken cancellationToken, int currentPage = 1)
        {
            ViewBag.isActive_User_Menu = "PeopleController";
            int number_showproduct = 12;
            ViewBag.counter = (currentPage < 1) ? 1 : (((currentPage - 1) * number_showproduct) + 1);
            var UserId = userManager.GetUserId(User);
            var result = personService.ShowAllPeople_PagingAsync(cancellationToken, UserId, currentPage, number_showproduct);

            return View(result);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonDto personDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                personDto.UserId = userManager.GetUserId(User);
                await personService.AddPersonAsync(personDto, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            return View(personDto);
        }

        public async Task<IActionResult> Edit(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await personService.GetByIdAsync(cancellationToken, id);
            if (person == null)
            {
                return NotFound();
            }
            #region PersonDto + AvatarImage + IconImage
            ViewBag.AvatarImage = person.AvatarImage ?? "/images/default.png";
            ViewBag.IconImage = person.IconImage ?? "/images/default.png";

            var personDto = new PersonDto()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Mobile = person.Mobile,
                Description = person.Description,
                ShortDescription = person.ShortDescription,
                Address = person.Address,
                Email = person.Email,
                Instagram = person.Instagram,
                Learn = person.Learn,
                Linkdin = person.Linkdin,
                Telegram = person.Telegram,
                Tellphone = person.Tellphone,
                WhatsApp = person.WhatsApp,
                Youtube = person.Youtube,
                CreateDate = person.CreateDate,
                LastUpdateDate = person.LastUpdateDate

            };
            #endregion
            return View(personDto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PersonDto personDto, string _AvatarImage, string _IconImage, CancellationToken cancellationToken)
        {
            if (id != personDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    personDto.UserId = userManager.GetUserId(User);

                    await personService.UpdatePersonAsync(personDto, _AvatarImage, _IconImage, cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(personDto.Id))
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
            return View(personDto);
        }

        public async Task<IActionResult> Delete(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await personService.GetByIdAsync(cancellationToken, id);


            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
        {
            var person = await personService.GetByIdAsync(cancellationToken, id);
            await personService.DeleteAsync(person, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return personService.TableNoTracking.Any(e => e.Id == id);
        }
    }
}
