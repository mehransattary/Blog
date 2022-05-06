using Data.Dto;
using Data.ViewModel;
using Microsoft.AspNetCore.Identity;
using Service.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signIn;

        public AccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signIn)
        {
            this.userManager = userManager;
            this.signIn = signIn;
        }

     

        public async Task<IdentityResult> RegisterAsync(RegisterViewModel registerViewModel, Claim claim=null)
        {
            IdentityUser user = new IdentityUser()
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email
            };
            var result= await userManager.CreateAsync(user, registerViewModel.Password);
            if (claim!=null)        
                await userManager.AddClaimAsync(user, claim);
        
            return result;

        }
        public async Task<SignInResult> SignAsync(LoginViewModel loginViewModel)
        {

           return  await signIn.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe,false);
            
        }
        public async Task SignOutAsync()
        {
            await signIn.SignOutAsync();
        }
        public bool  IsSignin(System.Security.Claims.ClaimsPrincipal claim)
        {
           return signIn.IsSignedIn(claim);
        }

     
    }
}
