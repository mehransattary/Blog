using Data.Dto;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProMe_Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy ="admin")]
    public class DefaultController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        private readonly IPersonService personService;

        public DefaultController( UserManager<IdentityUser> userManager, IPersonService personService)
        {
            this.userManager = userManager;
            this.personService = personService;


        }

        public async Task< IActionResult> Index()
        {
            ViewBag.isActive_User_Menu = "DefaultController";
            var userId = userManager.GetUserId(User);
              var person=await  personService.TableNoTracking.Where(x => x.UserId == userId).Select(x => new Person()
                {
                    FirstName=x.FirstName,
                    LastName=x.LastName,
                    Description=x.Description,
                    AvatarImage=x.AvatarImage
                }).FirstOrDefaultAsync();
            
            return View(person);
        }

       
    }
}
