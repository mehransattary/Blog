using Data.Dto;
using Data.ViewModel;
using Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository.Interface
{
    public interface IAccountService
    {
     

        Task<IdentityResult> RegisterAsync(RegisterViewModel registerViewModel, Claim claim = null);
        Task<SignInResult> SignAsync(LoginViewModel loginViewModel);
        Task SignOutAsync();
        bool IsSignin(System.Security.Claims.ClaimsPrincipal claim);

    }
}
