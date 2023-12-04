using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Algorithm_3rd_Year_Project.Models.DataBinding;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Algorithm_3rd_Year_Project.Controllers
{
    [AllowAnonymous]
    public class LiaisonController : Controller
    {

        private readonly ICentre _centre;
        private readonly IPrograme _programe;
        private readonly ITeacher _teacher;
        private readonly ICentreManage _centreManage;
        private readonly IQualification _qualification;
        private readonly IPupil _pupil;

        private readonly IStatus _status;
        private readonly IGander _gander;
        private readonly IParent _parent;
        private readonly ICentreProgram _centreProgram;
        private readonly IEnrole _enrole;
        private readonly ICoodinator _coodinator;
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly RoleManager<IdentityRole> _RoleManger;
        private readonly IProvince _province;
        private readonly ISuburb _suburb;
        private readonly IRegion _region;
        private readonly ILiaison _liaison;
      
        public LiaisonController(ILiaison liaison,IRegion region, ISuburb suburb, IProvince province, ICoodinator coodinator, IEnrole enrole, ICentreProgram centreProgram, ICentre centre, IPrograme programe, ICentreManage centreManage, ITeacher teacher, RoleManager<IdentityRole> RoleManger, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _region = region;
            _liaison = liaison;
            _suburb = suburb;
            _province = province;
            _coodinator = coodinator;
            _programe = programe;
            _centreManage = centreManage;
            _teacher = teacher;
            _signInManager = signInManager;
            _userManager = userManager;
            _RoleManger = RoleManger;
            _enrole = enrole;
            _centreProgram = centreProgram;
            _centre = centre;
        }
        private async Task Role(string CurrentRole , string RoleName ,string Username)
        {
            UserModel user = await _userManager.FindByEmailAsync(Username);
           await _userManager.RemoveFromRoleAsync(user, CurrentRole);
            await _userManager.AddToRoleAsync(user, RoleName);
        }
        private async Task<CoodinatorModel> Check(int Id)
        {
            var Data = await _coodinator.CheckNameAsync(true, Id);
            return Data;
        }
        [HttpGet]
        public async Task<IActionResult> DeActive(string id)
        {          
            if(id==null)
            {
                return RedirectToAction("Error", "Error");
            }
            string RoleName = "De-Coordinator";
            string CurrentRole = "Coordinator";
            var Model = await _coodinator.GetByUserNameAsync(id);
            if (Model == null)
            {
                return RedirectToAction("Error", "Error");
            }
            else
            {
                await Role(CurrentRole, RoleName, id);
                await _coodinator.UpdatStatuseAsync(Model.CoodinatorId, false);
            }
            return RedirectToAction("Ind", "Liaison");
            
        }
        [HttpGet]
        public async Task<IActionResult> Active(string id,int ip)
        {
            if (id == null|| ip<1)
            {
                return RedirectToAction("Error", "Error");
            }
            string RoleName = "Coordinator";
            string CurrentRole = "De-Coordinator";
            var Model = await _coodinator.GetByUserNameAsync(id);
            if (Model == null)
            {
                return RedirectToAction("Error", "Error");
            }
            else
            {
                var po = await Check(ip);
                if (po != null)
                {
                    return RedirectToAction("Ind", "Liaison", new { o = true });
                }
                await Role(CurrentRole, RoleName, id);
                await _coodinator.UpdatStatuseAsync(Model.CoodinatorId,true);
            }
            return RedirectToAction("Index", "Liaison");
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CoodinatorViewModel> model = new List<CoodinatorViewModel>();
            string Role = "Coordinator";
            List<UserModel> users = (List<UserModel>)await _userManager.GetUsersInRoleAsync(Role);
            IEnumerable<CoodinatorModel> cood = await _coodinator.TabAsync();
            foreach (var Data in users)
            {
                foreach (var Da in cood)
                {
                    if (Data.Email == Da.UserName)
                    {
                        CoodinatorViewModel coodinator = new CoodinatorViewModel();
                        coodinator.Lname = Data.Lname;
                        coodinator.Fname = Data.Fname;
                        coodinator.CellNo = Data.CellNo;
                        coodinator.UserName = Da.UserName;
                        coodinator.Profile = Da.Profile;
                        coodinator.RegionId = Da.RegionId;
                        coodinator.Active = Da.Active;
                        model.Add(coodinator);
                    }
                }
            }
            ViewBag.RegionId = new SelectList(await _region.TabAsync(), "RegionId", "RegionName");
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Ind(bool o)          
        {
            if(o==true)
            {
                ViewBag.Error = "Sorry the Is Active Coodinator in this Region";
            }
            List<CoodinatorViewModel> model = new List<CoodinatorViewModel>();
            string Role = "De-Coordinator";
            //De-Coordinator
            List<UserModel> users = (List<UserModel>)await _userManager.GetUsersInRoleAsync(Role);
            IEnumerable<CoodinatorModel> cood = await _coodinator.TabAsync();
            foreach (var Data in users)
            {
                foreach (var Da in cood)
                {
                    if (Data.Email == Da.UserName)
                    {
                        CoodinatorViewModel coodinator = new CoodinatorViewModel();
                        coodinator.Lname = Data.Lname;
                        coodinator.Fname = Data.Fname;
                        coodinator.CellNo = Data.CellNo;
                        coodinator.UserName = Da.UserName;
                        coodinator.Profile = Da.Profile;
                        coodinator.RegionId = Da.RegionId;
                        coodinator.Active = Da.Active;
                        model.Add(coodinator);
                    }
                }
            }
            ViewBag.RegionId = new SelectList(await _region.TabAsync(), "RegionId", "RegionName");
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Regions()
        {
            ViewBag.ProvinceId = new SelectList(await _province.TabAsync(), "ProvinceId", "ProvinceName");
            IEnumerable<SuburbModel> Sub = await _suburb.TabAsync();
            IEnumerable<RegionModel> Reg = await _region.TabAsync();
            var combineTible = from c in Sub

                               join ct1 in Reg on c.RegionId equals ct1.RegionId into tab2
                               from ct1 in tab2.DefaultIfEmpty()

                               
                               select new RegionsViewModel
                               {
                                   suburbModel = c,
                                   regionModel = ct1
                               };

            return View(combineTible);          
        }
        [HttpGet]
        public async Task<IActionResult> Centres(int Id)
        {
            if (User.Identity.Name != null)
            {
                if (Id < 1)
                {
                    return RedirectToAction("Error", "Error");
                }
                var Coodinator = await _coodinator.GetByUserNameAsync(User.Identity.Name);
                var liaison = await _liaison.GetByUserNameAsync(User.Identity.Name);
                if (Coodinator == null && liaison == null)
                {
                    return RedirectToAction("Error", "Error");
                }
                IEnumerable<CentreModel> centre = await _centre.TabSubAsync(Id);

                return View(centre);
            }

            return RedirectToAction("Error", "Error");
        }
        
        [HttpGet]
        public async Task<IActionResult> Coordinator(string Email)
        {
            if (Email == null)
            {
                return RedirectToAction("Error", "Error");
            }
            CoodinatorModel model = new CoodinatorModel();
            model.UserName = Email;
            ViewBag.RegionId = new SelectList(await _region.TabAsync(), "RegionId", "RegionName");
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Profile(string Email)
        {
            if (Email == null)
            {
                return RedirectToAction("Error", "Error");
            }
            ProfileModel model = new ProfileModel();
            var Use = await _userManager.FindByEmailAsync(Email);
            var o = await _centreManage.GetByUserAsync(Email);
            var Centre = await _centre.GetByIdAsync(o.CentreId);
            if (Use == null || o == null || Centre == null)
            {
                return RedirectToAction("Error", "Error");
            }
            model.CentraEmail = Centre.CentraEmail;
            model.CentreFaxNo = Centre.CentreFaxNo;
            model.CentreName = Centre.CentreFaxNo;
            model.CentreNo = Centre.CentreNo;
            model.Email = Email;
            model.Name = Use.Fname;
            model.Surname = Use.Lname;
            model.Profile = o.Profile;
            model.SuburbId = Centre.SuburbId;
            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> Address(int Id)
        {
            if(Id<1)
            {
                return RedirectToAction("Error", "Error");
            }
            SuburbModel suburb = await _suburb.GetByIdAsync(Id);
            if(suburb==null)
            {
                return RedirectToAction("Error", "Error");
            }
            ViewBag.RegionId = new SelectList(await _region.TabAsync(), "RegionId", "RegionName");
            return View(suburb);

        }
        public byte[] Data { get; set; }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Coordinator(CoodinatorModel model )
        {
            if(ModelState.IsValid)
            {
                var cc = await Check(model.RegionId);
                if(cc!=null)
                {
                    ViewBag.Region = "Selected region has already assign to another coodinator";
                    ViewBag.RegionId = new SelectList(await _region.TabAsync(), "RegionId", "RegionName");                  
                    return View(model);
                }
                foreach (var file in Request.Form.Files)
                {
                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);

                    try
                    {
                        var supported = new[] { "pgn", "jpg" };
                        var f = Path.GetExtension(file.FileName).Substring(1);
                        if (!supported.Contains(f) || ms.ToArray() == null)
                        {
                            ViewBag.B = "jpg and pgn file format required";
                            ViewBag.RegionId = new SelectList(await _region.TabAsync(), "RegionId", "RegionName");
                            //ViewBag.CentreId = new SelectList(await _centre.TabAsync(), "CentreId", "CentreName");
                            return View(model); 
                        }
                        else
                        {
                            Data = ms.ToArray();
                        }

                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error");
                    }
                    break;
                }

                model.Profile = Data;
                model.Active = true;
                await _coodinator.AddAsync(model);
                return RedirectToAction("EmailSendLink", "Account");
            }
            ViewBag.RegionId = new SelectList(await _region.TabAsync(), "RegionId", "RegionName");
            return View(model);
        }
        public IActionResult RegCoordinator()
        {
  
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> RegCoordinator(RegisterUserModel Model)
        {
            if (ModelState.IsValid)
            {
                string password = Password();
                var User = new UserModel { UserName = Model.Email, Email = Model.Email, Fname = Model.Name, Lname = Model.Surname, CellNo = Model.CellNo };
                var Result = await _userManager.CreateAsync(User, password);
                if (Result.Succeeded)
                {
                    string Role = "Coordinator";
                    await _userManager.AddToRoleAsync(User, Role);


                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(User);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { UserId = User.Id, token }, Request.Scheme);
                   // await Send(Model.Email, confirmationLink, password);

                    return RedirectToAction("Coordinator", "Liaison", new { Email = Model.Email });
                }
                foreach (var error in Result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewBag.USuccess = "Somthing Went wrong Try Again..";

            return View(Model);
        }
        public string Password()
        {
            const string letter = "0M0NB5V4CX9ZA1B2C3D5F4G7H8J9L6PIUYTREWQ";
            StringBuilder res = new StringBuilder();
            int z = 6;
            Random rndm = new Random();
            while (0 < z--)
            {
                res.Append(letter[rndm.Next(letter.Length)]);
            }
            return res.ToString();
        }
        public async Task<RedirectToActionResult> Send(string To, string confirmationLink, string Password)
        {

            string Subject = "EarlyEd Email Confimation";
            //string body = confirmationLink;
            MailMessage Mail = new MailMessage();
            Mail.To.Add(To);
            Mail.Subject = Subject;
            Mail.Body = "<p1>Please Confirm your email <br/> </p1>" + "<p2>Your Login Password &nbsp;</p2>" + Password + "<br/> <hr/>" + "<a href=" + confirmationLink + ">Confirm</a>";
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
        public async Task<IActionResult> Liaison(string Email)
        {
            LiaisonModel model = new LiaisonModel();
            model.UserName = Email;
            ViewBag.ProvinceId = new SelectList(await _province.TabAsync(), "ProvinceId", "ProvinceName");
            return View(model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Liaison(LiaisonModel model)
        {
           if(ModelState.IsValid)
            {
                foreach (var file in Request.Form.Files)
                {
                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);

                    try
                    {
                        var supported = new[] { "pgn", "jpg" };
                        var f = Path.GetExtension(file.FileName).Substring(1);
                        if (!supported.Contains(f) || ms.ToArray() == null)
                        {
                            ViewBag.B = "jpg and pgn file format required";
                            ViewBag.ProvinceId = new SelectList(await _province.TabAsync(), "ProvinceId", "ProvinceName");
                            return View(model); ;
                        }
                        else
                        {
                            Data = ms.ToArray();
                        }

                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error");
                    }
                    break;
                }
                await _liaison.AddAsync(model);
                return RedirectToAction("EmailSendLink", "Account");
            }
            ViewBag.ProvinceId = new SelectList(await _province.TabAsync(), "ProvinceId", "ProvinceName");
            return View(model);
        }
        [HttpGet]
        public IActionResult RegLiaison()
        {
            
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> RegLiaison(RegisterUserModel Model)
        {
            if (ModelState.IsValid)
            {
                string password = Password();
                //YH7453/YH7453
                var User = new UserModel { UserName = Model.Email, Email = Model.Email, Fname = Model.Name, Lname = Model.Surname, CellNo = Model.CellNo };
                var Result = await _userManager.CreateAsync(User, password);
                if (Result.Succeeded)
                {
                    string Role = "Liaison";
                    await _userManager.AddToRoleAsync(User, Role);


                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(User);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { UserId = User.Id, token }, Request.Scheme);
                    //await Send(Model.Email, confirmationLink, password);

                    return RedirectToAction("Liaison", "Liaison", new { Email = Model.Email });
                }
                foreach (var error in Result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewBag.USuccess = "Somthing Went wrong Try Again..";

            return View(Model);
        }
    }
}
