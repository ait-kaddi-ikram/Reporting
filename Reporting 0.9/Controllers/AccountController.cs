using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Reporting.Models;
using Reporting.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Reporting.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

       
        public AccountController(UserManager<AppUser> userManager,
                                  SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        /*  [AllowAnonymous]
         [AcceptVerbs("Get","Post")]
        public async Task<IActionResult> CheckingExistingEmail(AccountRegisterViewModel model)
         {
             var user = await userManager.FindByEmailAsync(model.Email);
             if (user == null)
             {
                 return Json(true);
             }
             else { 
             return Json($"This Email{model.Email} is already in use");
         }
         }*/

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Logout()       
        {
            
              await signInManager.SignOutAsync();
              return RedirectToAction("Index", "Home");
          }

      
        /*  private string GenerateName(string Prenom, string Nom)
          {
              return Prenom.Trim().ToUpper() + "_" + Nom.ToLower();
          }*/
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login( string returnUrl)
        {
            AccountLoginViewModel model = new AccountLoginViewModel
            {
                ReturnURL = returnUrl,
                ExternalLogins =( await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            ViewBag.date = "../Images/background/image"+ DateTime.Now.ToString("MMdd")+".jpg";
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginViewModel model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
               var result = await signInManager.PasswordSignInAsync(model.Email,model.Password,model.Remember, false);
           
            if (result.Succeeded)
            {
                    //if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    //{ 
                    //    return Redirect(ReturnUrl);
                    //}
                    //else
                    //{
                        
                        return RedirectToAction("Index", "Home");
                    //}
            }     
                ModelState.AddModelError(string.Empty, "Loging Invalid Attempt");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> EditAccount(string id)
        {
            if(!string.IsNullOrEmpty(id))
            {
                AppUser user = await userManager.FindByIdAsync(id);
               if(user != null)
                {
                    EditAccountViewModel model = new EditAccountViewModel()
                    {
                        Prenom = user.Prenom,
                        Nom = user.Nom,
                        Id = user.Id,
                        Site = user.Site,
                        Direction = user.Direction,
                        Password = user.PasswordHash,
                        ConfirmPassword = user.PasswordHash,
                    };
                    return View(model);
                }
            }
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<IActionResult> EditAccount(EditAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Prenom = model.Prenom;
                    user.Nom = model.Nom;
                    user.Site = model.Site;
                    user.Direction = model.Direction;
                    var passwordHash = userManager.PasswordHasher.HashPassword(user, model.Password);                  
                    user.PasswordHash = passwordHash;
                   
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index","Home");
                    }
                    foreach(IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                  
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult AccessDenied(string ReturnUrl)
        {
            ViewBag.Message = "accès non autorisé";
            if(!string.IsNullOrEmpty(ReturnUrl)&& Url.IsLocalUrl(ReturnUrl))
            {
                ViewBag.Message += " vers URL :\n" + ReturnUrl;
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            AccountLoginViewModel loginViewModel = new AccountLoginViewModel
            {
                ReturnURL = returnUrl,
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList(),
            };
            if(remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider:{remoteError}");
                return View("Login", loginViewModel);
            }
            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
               ModelState.TryAddModelError(string.Empty, "Errorloading external login info");
                return View("Login", loginViewModel);
            }
            var signInResult = await signInManager.ExternalLoginSignInAsync(info.LoginProvider,
                        info.ProviderKey, isPersistent:false, bypassTwoFactor: true);
            if(signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                if(email != null)
                {
                    var user = await userManager.FindByEmailAsync(email);
                   if(user == null)
                    {
                        return RedirectToAction("Login");
                    //    user = new AppUser
                    //    {
                    //        UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                    //        Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                    //    };
                    //    await userManager.CreateAsync(user);
                    }
                    await userManager.AddLoginAsync(user, info);
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
                ViewBag.ErrorMessage = "Please contact support on Pragim@PragimTech.com";
                return View("Error");
            }
            
            
           
        }

        [AllowAnonymous]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl )
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback),"Account", new { ReturnURL=returnUrl });
            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider,properties);
        }
  

    }
}
