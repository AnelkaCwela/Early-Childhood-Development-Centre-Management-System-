using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Algorithm_3rd_Year_Project.Models;
using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Algorithm_3rd_Year_Project.Models.DataBinding;

namespace Algorithm_3rd_Year_Project.Controllers
{           
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly RoleManager<IdentityRole> _RoleManger;
        private readonly IParent _parent;
        public AccountController(IParent parent,RoleManager<IdentityRole> RoleManger, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _parent = parent;
            _signInManager = signInManager;
            _userManager = userManager;
            this._RoleManger = RoleManger;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        
            [HttpGet]

        public IActionResult ChangeEmail()
        {
            //if (User.Identity.Name == null)
            //{
            //    return RedirectToAction("EmailConfimationFailed", "Account");
            //}         
            return View();
        }
        [HttpGet]

        public IActionResult ChangePassword()
        {
            //if (User.Identity.Name == null)
            //{
            //    return RedirectToAction("EmailConfimationFailed", "Account");
            //}         
            return View();
        }
        [HttpPost]

        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel mode)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.Name != null)
                {
                    var use = await _userManager.FindByEmailAsync(User.Identity.Name);
                    if (use == null)
                    {
                        return RedirectToAction("EmailConfimationFailed", "Account");
                    }
                    var res = await _userManager.ChangePasswordAsync(use, mode.CurrentPassord, mode.NewPassword);


                    if (res.Succeeded)
                    {
                        await _signInManager.SignInAsync(use, isPersistent: true);

                        await _signInManager.SignOutAsync();
                        return RedirectToAction("PasswordChanged", "Account");

                    }
                    else
                    {
                        return RedirectToAction("EmailConfimationFailed", "Account");
                    }
                }
                else
                {
                    return RedirectToAction("EmailConfimationFailed", "Account");
                }
            }

            return View();
        }

        //[AutoValidateAntiforgeryToken]
        //[HttpPost]
        //public async Task<IActionResult> Edit(UserEditViewModel model)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        if (User.Identity.Name != null)
        //        {
        //            var use = await _userManager.FindByEmailAsync(User.Identity.Name);
        //            use.Name = model.Name;
        //            use.Surname = model.Surname;

        //           var Data=  await  _userManager.UpdateAsync(use);
        //            if(Data.Succeeded)
        //            {
        //                return RedirectToAction("Profile", "Account");
        //            }
        //            else
        //            {
        //                foreach (var error in Data.Errors)
        //                {
        //                    ModelState.AddModelError("", error.Description);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            return RedirectToAction("EmailConfimationFailed", "Account");
        //        }
              

        //    }
        //    return View();
        //}
        //[HttpGet]
        //public async Task<IActionResult> Edit()
        //{
        //    UserEditViewModel Data = new UserEditViewModel();
        //    if (User.Identity.Name == null)
        //    {
        //        return RedirectToAction("EmailConfimationFailed", "Account");
        //    }
        //    else
        //    {
        //        var use = await _userManager.FindByEmailAsync(User.Identity.Name);
               
        //        Data.Name = use.Name;
        //        Data.Surname = use.Surname;
        //    }
        //    return View(Data);
        //}
       


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterModel Model)
        {           
            if (ModelState.IsValid)
            {
               // RegisterModel
                   var User = new UserModel { UserName = Model.Email, Email = Model.Email, Fname = Model.Name, Lname = Model.Surname,CellNo=Model.CellNo };
                var Result = await _userManager.CreateAsync(User, Model.Password);
                if (Result.Succeeded)
                {
                    string Role = "Parent";
                    await _userManager.AddToRoleAsync(User,Role);

                    //Liaison
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(User);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { UserId = User.Id, token }, Request.Scheme);
                   // await Send(Model.Email, confirmationLink);
                 
                    return RedirectToAction("Address", "Account", new { Email= Model.Email });
                }
                foreach (var error in Result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewBag.USuccess = "Somthing Went wrong Try Again..";

            return View(Model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Address(ParentModel model)
        {
            if(ModelState.IsValid)
            {
                ParentModel Data;
                try
                {
                   Data = await _parent.AddAsync(model);
                }
                catch
                {
                    return RedirectToAction("Error", "Error");
                }
                if(Data==null)
                {
                    ViewBag.A = "Address Were not Entred Succesfully , Please Entre Again";
                    return View(model);
                }
                else
                {
                    return RedirectToAction("EmailSendLink", "Account");
                }


            }
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Address(string Email)
        {
            ParentModel model = new ParentModel();
            if (Email==null)
            {
                return RedirectToAction("Error", "Error");
            }          
            model.UserName = Email;
            return View(model);
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> EmailIsInUsE(string email)
        {
            var userr = await _userManager.FindByEmailAsync(email);
            if (userr == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use");
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel Model)
        {
            if (ModelState.IsValid)
            {

                var Result = await _signInManager.PasswordSignInAsync(Model.Email, Model.Password, true, false);
                if (Result.Succeeded)
                {
                                  
                        return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Login Failed ... Invalid Email or Password ");

            }
            return View(Model);
        }
        [AllowAnonymous]
        public async Task<RedirectToActionResult> Send(string To, string confirmationLink)
        {

            string Subject = "EarlyEd Email Confimation";
            //string body = confirmationLink;
            MailMessage Mail = new MailMessage();
            Mail.To.Add(To);
            Mail.Subject = Subject;
            Mail.Body = "<p1>Please Confirm your email</p1>" + "<hr/>" + "<a href=" + confirmationLink + ">Confirm</a>";
            Mail.IsBodyHtml = true;
            Mail.From = new MailAddress("earlychildhooddevelopmentc@gmail.com");
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;

            smtp.Credentials = new System.Net.NetworkCredential("earlychildhooddevelopmentc@gmail.com", "Algorithms");

            await smtp.SendMailAsync(Mail);
            return RedirectToAction("EmailSendLink", "Account");


        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgortPassword()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ForgotPasswordReset(string Email, string token)
        {
            if (Email == null || token == null)
            {
                return RedirectToAction("EmailConfimationFailed", "Account");
            }
            var use = await _userManager.FindByEmailAsync(Email);
            if (use == null)
            {
                return RedirectToAction("EmailConfimationFailed", "Account");
            }
            else
            {
                ForgotPasswordResetViewModel data = new ForgotPasswordResetViewModel();
                data.Email = Email;
                data.token = token;
                return View(data);
            }

        }
        [AllowAnonymous]
        [HttpPost]
        
        public async Task<IActionResult> ForgotPasswordReset(ForgotPasswordResetViewModel data)
        {
            if (data.Email == null || data.token == null)
            {
                return RedirectToAction("EmailConfimationFailed", "Account");
            }
            var use = await _userManager.FindByEmailAsync(data.Email);
            if (use == null)
            {
                return RedirectToAction("EmailConfimationFailed", "Account");
            }
            // var res = await _userManager.ConfirmEmailAsync(use, data.token);
            var xx = await _userManager.ResetPasswordAsync(use, data.token, data.Password);

            if (xx.Succeeded)
            {
               
                //if (xx.Succeeded)
                //{
                   await _signInManager.SignInAsync(use, isPersistent: true);

                    await _signInManager.SignOutAsync();
                    return RedirectToAction("PasswordChanged", "Account");
                //}

               // return RedirectToAction("EmailConfimationFailed", "Account"); ;
            }
            else
            {
                return RedirectToAction("EmailConfimationFailed", "Account");
            }

        }
        [AllowAnonymous]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ForgortPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {

                var use = await _userManager.FindByEmailAsync(model.Email);

               if (use != null && await _userManager.IsEmailConfirmedAsync(use))
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(use);
                    var passwordRestLink = Url.Action("ForgotPasswordReset", "Account", new { email = model.Email, token }, Request.Scheme, Request.Host.ToString());

                    await Send(model.Email, passwordRestLink);
                    //await _emailService.SendAsync(model.Email, "Email Verification", $"<a href=\"{passwordRestLink}></a>", true);
                    return RedirectToAction("EmailSendLink", "Account");
                }
                return RedirectToAction("EmailConfimationFailed", "Account");
            }
            return View(model);
        }
        [AllowAnonymous]
        [AcceptVerbs("Get", "Post")]

        public async Task<IActionResult> ConfirmEmail(string UserId, string token)
        {
            if (UserId == null || token == null)
            {
                return RedirectToAction("EmailConfimationFailed", "Account");

            }
             UserModel use = await _userManager.FindByIdAsync(UserId);
            if (use == null)
            {
                return RedirectToAction("EmailConfimationFailed", "Account");
            }
            var res = await _userManager.ConfirmEmailAsync(use, token);
            if (res.Succeeded)
            {
                await _signInManager.SignInAsync(use, isPersistent: true);
               
                await _signInManager.SignOutAsync();
                return RedirectToAction("ConfirmSuccesfull", "Account");
            }
            else
            {
                return RedirectToAction("EmailConfimationFailed", "Account");
            }

        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult EmailConfimationFailed()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult PasswordChanged()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult EmailSendLink()
        {
            return View();
        }
        
              [HttpGet]
        [AllowAnonymous]
        public IActionResult ConfirmSuccesfull()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
