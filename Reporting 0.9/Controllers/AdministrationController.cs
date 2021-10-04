using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reporting.Models;
using Reporting.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Net.Mail;
//using System.Net;
using MailKit.Net.Smtp;
using MimeKit;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using Protection = DocumentFormat.OpenXml.Drawing.Charts.Protection;

namespace Reporting.Controllers
{    
    [Authorize(Roles = "Administration")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        public AdministrationController(RoleManager<IdentityRole> roleManager,
                                         UserManager<AppUser> userManager,
                                           SignInManager<AppUser> signInManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(AccountRegisterViewModel model)
        {
            //string fullName = GenerateName(model.Prenom, model.Nom);
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { Prenom = model.Prenom, Nom = model.Nom, UserName = model.Email, Email = model.Email, Direction = model.Direction, Site = model.Site };
                ViewBag.id = user.Id;
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (User.IsInRole("Administration") && signInManager.IsSignedIn(User))
                    {
                        return RedirectToAction("ChooseUserRole","Administration", new { Id = user.Id ,Password = model.Password});
                    }
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);// pour ne pas saisir les infos une autre fois
        }
        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateRole(AdministrationCreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = model.RoleName
                };
                IdentityResult result = await this.roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(ListRols));
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult ListRols()
        {
            var rols = this.roleManager.Roles;
            return View(rols);
        }

        [HttpPost]


        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            try
            {
                if (!(role is null))
                {
                    var result = await roleManager.DeleteAsync(role);
                    if (!result.Succeeded)
                    {
                        foreach (IdentityError error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else
                {
                    return View("Error", $"The Role as Id {id} cannot be found !");
                }
                return View("ListRols", this.roleManager.Roles);
            }
            catch( DbUpdateException ex)
            {
                //this.logger.LogError(ex.Message);
                ViewBag.Error = "Supprimer Un Rôle";
                string errorMessage = role.Name + "le rôle est en cours d'utilisation, donc ce rôle ne peut pas être supprimé car il y a des utilisateurs dans ce rôle.  " +
                    "si vous voulez supprimer ce rôle,  " +
                    "« veuillez supprimer les utilisateurs du rôle, puis essayez de supprimer » ";

                return View("Error", errorMessage);
            }
            }
        [HttpGet]
        public ActionResult Delete()
        {

            return RedirectToAction(nameof(ListRols));
        }
        public async Task<ActionResult> Update(string id)
        {
            if (id is null)
            {
                return View("Error", "Please Add Role Id in the URL");

            }
            IdentityRole role = await this.roleManager.FindByIdAsync(id);
            if (role is null)
            {
                return View("Error", $"The Role as Id {id} cannot be found !");
            }
            EditRoleViewModel model = new EditRoleViewModel()
            {
                Id = role.Id,
                RoleName = role.Name,
                Users = new List<string>()
            };
            foreach (AppUser user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.Email);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Update(EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await this.roleManager.FindByIdAsync(model.Id);
                if (role is null)
                {
                    return View("Error", $"The Role  Id {model.Id} cannot be found !");
                }
                role.Name = model.RoleName;
                IdentityResult result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(ListRols));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);

                }
            }

            return View(model);
        }

        [HttpGet]

        public async Task<ActionResult> EditUserRole(string idRole) {

            if (string.IsNullOrEmpty(idRole))
            {
                return View("Error", $"The Role Must be exist and not empty in the URL");
            }
            var role = await this.roleManager.FindByIdAsync(idRole);
            if (role is null)
            {
                return View("Error", $"The Role  Id {role.Id} cannot be found !");
            }
            List<EditUsersRoleViewModel> Models = new List<EditUsersRoleViewModel>();
            foreach (AppUser user in userManager.Users)
            {
                EditUsersRoleViewModel model = new EditUsersRoleViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    IsSelected = false
                };
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.IsSelected = true;
                }
                Models.Add(model);

            }
            ViewBag.RoleId = idRole;
            return View(Models);
           
        }
          
        [HttpPost]

       public async Task<ActionResult> EditUserRole(string idRole, List<EditUsersRoleViewModel> model )
        {

            if (string.IsNullOrEmpty(idRole))
            {
                return View("Error", $"The Role Must be exist and not empty in the URL");
            }
            var role = await this.roleManager.FindByIdAsync(idRole);
            if (role is null)
            {
                return View("Error", $"The Role  Id {role.Id} cannot be found !");
            }
            IdentityResult result = null;
            for (int i=0; i<model.Count; i++)
            {
                AppUser user = await userManager.FindByIdAsync(model[i].UserId);
                
                if (await userManager.IsInRoleAsync(user, role.Name)&& !model[i].IsSelected)
                {
                   result = await userManager.RemoveFromRoleAsync(user, role.Name); 
                }else if(!(await userManager.IsInRoleAsync(user, role.Name)) && model[i].IsSelected)
                {
                   result = await  userManager.AddToRoleAsync(user, role.Name);
                }
                if (result != null && !result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.TryAddModelError(string.Empty, item.Description);
                    }
                }
            }
           
            return RedirectToAction(nameof(Update), new { id = idRole });
        }

        [HttpGet]
        public async Task<ActionResult> ChooseUserRole(string Id, string Password)
        {
            ViewBag.userId = Id;
            ViewBag.Password = Password;
            var user = await userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return View("Error", $"l'utilisateur qui a l'id = {Id} est introuvable");
            }
            var model = new List<UserRolesViewModel>();
            foreach (var role in roleManager.Roles)
            {
                var userRolesViewModel = new UserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                };
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }
                model.Add(userRolesViewModel);
            }
            return View(model);

        }

        [HttpPost]
        public async Task<ActionResult> ChooseUserRole(List<UserRolesViewModel> model, string id, string Password)
        {

            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return View("Error", $"l'utilisateur qui a l'id = {id} est introvable");
            }


           
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Reporting", "Reporting@gmail.com"));
            message.To.Add(new MailboxAddress(user.UserName, user.Email));
            message.Subject = "Utlisateur Reporting";
            message.Body = new TextPart("plain")
            {
                Text = "Bonjour " + user.Prenom + " vous êtes enregestré avec succés, votre mot de passe est: " + Password,
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("reportingproje21@gmail.com","reporting2021");
                client.Send(message);
                client.Disconnect(true);
            }
            var roles = await userManager.GetRolesAsync(user);
            var result = await userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "vous ne pouvez pas supprimer le rôle de l'utilisateur");
                return View(model);
            }
            result = await userManager.AddToRolesAsync(user, model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "vous ne pouvez pas ajouter le rôle pour l'utilisateur");
                return View(model);
            }
            return RedirectToAction("ListUsers", "Administration");

        }
            [HttpGet]
        public async Task<ActionResult> ManageUserRoles(string id)
        {
            ViewBag.userId = id;
            var user = await userManager.FindByIdAsync(id);
            if(user == null)
            {
                return View("Error", $"l'utilisateur qui a l'id = {id} est introuvable");
            }
            var model = new List<UserRolesViewModel>();
            foreach(var role in roleManager.Roles)
            {
                var userRolesViewModel = new UserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                };
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }
                model.Add(userRolesViewModel);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ManageUserRoles(List<UserRolesViewModel> model, string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if(user == null)
            {
                return View("Error", $"l'utilisateur qui a l'id = {id} est introvable");
            }

            var roles = await userManager.GetRolesAsync(user);
            var result = await userManager.RemoveFromRolesAsync(user, roles);
            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "vous ne pouvez pas supprimer le rôle de l'utilisateur");
                return View(model);
            }
            result = await userManager.AddToRolesAsync(user, model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "vous ne pouvez pas ajouter le rôle pour l'utilisateur");
                return View(model);
            }
            return RedirectToAction( "EditUser","Administration", new { Id = id }); 
        }
        [HttpGet]
        public ActionResult ListUsers()
        {
            var users = userManager.Users.Where(u => u.Email != User.Identity.Name);
            return View(users);
        }

        [HttpGet]
        public async Task<ActionResult> EditUser(string Id)
        {
            AppUser user = await userManager.FindByIdAsync(Id);
            if (user is null)
            {
                return View("Error", $"l'utilisateur evec l'Id = {Id} est introvable !");
            }
            var userRoles = await userManager.GetRolesAsync(user);


            AccountEditUserViewModel model = new AccountEditUserViewModel()
            {
                Email = user.Email,
                Site = user.Site,
                Direction = user.Direction,
                Prenom = user.Prenom,
                Nom = user.Nom,
                Id = user.Id,
                Roles = userRoles,

            };
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> EditUser(AccountEditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByIdAsync(model.Id);
                if (user is null)
                {
                    return View("Error", $"l'utilisateur evec l'Id = {model.Id} est introvable !");
                }
                user.Prenom = model.Prenom;
                user.Nom = model.Nom;
                user.Email = model.Email;
                user.Site = model.Site;
                user.Direction = model.Direction;
                IdentityResult result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(ListUsers));
                }
                foreach (var erro in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, erro.Description);
                }
                await SetClaimsAndRoles(model.Id, model);
            }
            else
            {
                await SetClaimsAndRoles(model.Id, model);
            }

            return View(model);
        }

        public async Task<ActionResult> SetClaimsAndRoles(string UserId, AccountEditUserViewModel model)
        {
            AppUser user = await userManager.FindByIdAsync(model.Id);
            if (user is null)
            {
                return View("error", $"l'utilisateur evec l'Id = {model.Id} est introvable !");
            }
            var userRoles = await userManager.GetRolesAsync(user);
            var userClaims = await userManager.GetClaimsAsync(user);
            model.Roles = userRoles;
            model.Claims = userClaims.Select(c => c.Value).ToList();
            return View("EditUser", model);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteUser(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user is null)
            {
                return View("Error", $"l'utilisateur evec l'Id = {id} est introvable !");
            }
            var rols = this.roleManager.Roles;
            IdentityResult result = await userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                foreach (var erro in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, erro.Description);
                }
            }
           

            return RedirectToAction(nameof(ListUsers));
        }


    }
}


