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

namespace Algorithm_3rd_Year_Project.Controllers
{
    public class CoordinatorController : Controller
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
        public CoordinatorController(ILiaison liaison,IRegion region,ISuburb suburb,IProvince province,ICoodinator coodinator,IEnrole enrole, ICentreProgram centreProgram, ICentre centre, IPrograme programe,  ICentreManage centreManage, ITeacher teacher, RoleManager<IdentityRole> RoleManger, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
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
        private async Task Role(string CurrentRole, string RoleName, string Username)
        {
            UserModel user = await _userManager.FindByEmailAsync(Username);
            await _userManager.RemoveFromRoleAsync(user, CurrentRole);
            await _userManager.AddToRoleAsync(user, RoleName);
        }
        private async Task<CentreManageModel> Check(int Id)
        {
            var Data = await _centreManage.CheckAsync(true, Id);
            return Data;
        }
        [HttpGet]
        public async Task<IActionResult> Active(string id, int ip)
        {
            if (id == null || ip < 1)
            {
                return RedirectToAction("Error", "Error");
            }
            string RoleName = "CentreManager";
            string CurrentRole = "De-CentreManager";
            var Model = await _centreManage.GetByUserAsync(id);
            if (Model == null)
            {
                return RedirectToAction("Error", "Error");
            }
            else
            {
                var po = await Check(ip);
                if (po != null)
                {
                    return RedirectToAction("Ind", "Coordinator", new { o = true });
                }
                await Role(CurrentRole, RoleName, id);
                await _centreManage.UpAsync(Model.CentreManagerId, true);
            }
            return RedirectToAction("Index", "Coordinator");
        }
        [HttpGet]
        public async Task<IActionResult> DeActive(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Error");
            }
            string RoleName = "De-CentreManager";
            string CurrentRole = "CentreManager";
            var Model = await _centreManage.GetByUserAsync(id);
            if (Model == null)
            {
                return RedirectToAction("Error", "Error");
            }
            else
            {
                await Role(CurrentRole, RoleName, id);
                await _centreManage.UpAsync(Model.CentreId, false);
            }
            return RedirectToAction("Ind", "Coordinator");

        }

        [HttpGet]
        public async Task<IActionResult> Ind(bool o)
        {
            if (o == true)
            {
                ViewBag.Error = "Sorry the Is Active Coodinator in this Region";
            }
            List<CoodinatorViewModel> model = new List<CoodinatorViewModel>();
            string Role = "De-CentreManager";
            //De-Coordinator
            List<UserModel> users = (List<UserModel>)await _userManager.GetUsersInRoleAsync(Role);
            IEnumerable<CentreManageModel> cood = await _centreManage.TabAsync();
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
                        coodinator.RegionId = Da.CentreId;
                        coodinator.Active = Da.Active;
                        model.Add(coodinator);
                    }
                }
            }
            ViewBag.CentreId = new SelectList(await _centre.TabAsync(), "CentreId", "CentreName");
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CoodinatorViewModel> model = new List<CoodinatorViewModel>();
            string Role = "CentreManager";
            List<UserModel> users = (List<UserModel>)await _userManager.GetUsersInRoleAsync(Role);
            IEnumerable<CentreManageModel> cood = await _centreManage.TabAsync();
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
                        coodinator.RegionId = Da.CentreId;
                        coodinator.Active = Da.Active;
                        model.Add(coodinator);
                    }
                }
            }
            ViewBag.CentreId = new SelectList(await _centre.TabAsync(), "CentreId", "CentreName");
            return View(model);
        }


        public async Task<JsonResult> GetById(int id)
        {
            SelectList Data = new SelectList(await _region.TabProvinceAsync(id), "RegionId", "RegionName");
            return Json(Data);
        }

        [HttpGet]
        public async Task<ActionResult> ListTeacher(int ip)
        {
            if (User.Identity.Name != null)
            {
               // var Centre = await _centreManage.GetByUserAsync(User.Identity.Name);
                if (ip<1)
                {
                    return RedirectToAction("Error", "Error");
                }
                var Cent = await _centre.GetByIdAsync(ip);       
                ViewBag.CentreName = Cent.CentreName;
                ViewBag.Email = Cent.CentraEmail;
                ViewBag.Cell = Cent.CentreNo;
                List<UserModel> Model = new List<UserModel>();
                IEnumerable<TeacherModel> tech = await _teacher.TabByCentreAsync(ip);
                string Role = "Teacher";
                List<UserModel> users = (List<UserModel>)await _userManager.GetUsersInRoleAsync(Role);
                foreach (var Data in users)
                {
                    foreach (var Da in tech)
                    {
                        if (Data.Email == Da.UserName)
                        {
                            Model.Add(Data);
                        }
                    }
                }
                return View(Model);
            }
            else
            {
                return RedirectToAction("Error", "Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Address()//Register/Add Centre//View Teachers In Centre //View Centers /View Centremanager
        {
            ViewBag.ProvinceId = new SelectList(await _province.TabAsync(), "ProvinceId", "ProvinceName");
            return View();
        }
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> Address(SuburbInsertModel model)
        {
            if(ModelState.IsValid)
            {
                SuburbModel suburb = new SuburbModel();
                suburb.AddressLine1 = model.AddressLine1;
                suburb.AddressLine2 = model.AddressLine2;
                suburb.CityName = model.CityName;
                suburb.PostalCode = model.PostalCode;
                suburb.RegionId = model.RegionId;
             var Sub=await _suburb.AddAsync(suburb);
                return RedirectToAction("Centre", "Coordinator",new {Id= Sub.SuburbId });
            }
            ViewBag.ProvinceId = new SelectList(await _province.TabAsync(), "ProvinceId", "ProvinceName");
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> List(int id)
        {
            if (User.Identity.Name != null)
            {
           
                CentreManageModel centreManage = await _centreManage.GetByCentreIdAsync(id);//aler if is null
                CentreModel centre = await _centre.GetByIdAsync(id);
                if(centreManage==null||centre==null)
                {
                    return RedirectToAction("Error", "Error");
                }
                ViewBag.CentreName = centre.CentreName;
                ViewBag.Email = centre.CentraEmail;
                ViewBag.Cell = centre.CentreNo;
                ViewBag.Image = centreManage.Profile;
                ViewBag.Id = centre.SuburbId;

                UserModel Data= await _userManager.FindByEmailAsync(centreManage.UserName);

                return View(Data);
            }

            return RedirectToAction("Error", "Error");
        }
        [HttpGet]
        public IActionResult Centre(int Id)
        {
            if(Id<1)
            {
                return RedirectToAction("Error", "Error");
            }
            CentreModel centre = new CentreModel();
            centre.SuburbId = Id;
            return View(centre);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Centre(CentreModel centre)
        {
            if(ModelState.IsValid)
            {
                await _centre.AddAsync(centre);
                return RedirectToAction("Centres", "Coordinator");
            }

            return View(centre);
        }
        //
        [HttpGet]
        public async Task<IActionResult> Staff()
        {
            if (User.Identity.Name != null)
            {
                string Role = "CentreManager";
                List<UserModel> users = (List<UserModel>)await _userManager.GetUsersInRoleAsync(Role);
                return View(users);
            }

            return RedirectToAction("Error", "Error");
        }
        [HttpGet]
        public async Task<IActionResult> Centres()
        {
            if (User.Identity.Name != null)
            {
                var Coodinator = await _coodinator.GetByUserNameAsync(User.Identity.Name);
                var liaison = await _liaison.GetByUserNameAsync(User.Identity.Name);
                if (Coodinator == null && liaison == null)
                {
                    return RedirectToAction("Error", "Error");
                }
                IEnumerable<CentreModel> centre = await _centre.TabAsync();

                return View(centre);
            }

            return RedirectToAction("Error", "Error");
        }
        public ActionResult Centremanager()
        {  
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        //Autozize /CentreManger
        public async Task<ActionResult> Centremanager(RegisterUserModel Model)
        {
            if (ModelState.IsValid)
            {//A2R0CU
                string password = Password();
                var User = new UserModel { UserName = Model.Email, Email = Model.Email, Fname = Model.Name, Lname = Model.Surname, CellNo = Model.CellNo };
                var Result = await _userManager.CreateAsync(User, password);
                if (Result.Succeeded)
                {
                    string Role = "CentreManager";
                    await _userManager.AddToRoleAsync(User, Role);


                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(User);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { UserId = User.Id, token }, Request.Scheme);
                    //await Send(Model.Email, confirmationLink, password);

                    return RedirectToAction("Manager", "Coordinator", new { Email = Model.Email });
                }
                foreach (var error in Result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewBag.USuccess = "Somthing Went wrong Try Again..";

            return View(Model);
        }
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Manager(string Email)
        {
            if (Email == null)
            {
                return RedirectToAction("Error", "Error");
            }
            ViewBag.CentreId = new SelectList(await _centre.TabAsync(), "CentreId", "CentreName");
            CentreManageModel model = new CentreManageModel();
            model.UserName = Email;
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> Region()
        {
            ViewBag.ProvinceId = new SelectList(await _province.TabAsync(), "ProvinceId", "ProvinceName");

            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Region(RegionModel model)
        {
            if(ModelState.IsValid)
            {
              await  _region.AddAsync(model);
            }
            ViewBag.ProvinceId = new SelectList(await _province.TabAsync(), "ProvinceId", "ProvinceName");

            return View();
        }

        public byte[] Data { get; set; }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Manager(CentreManageModel model)
        {
            if (ModelState.IsValid)
            {
                var oi = await Check(model.CentreId);
                if (oi!=null)
                {
                    ViewBag.Error = "Sorry the Is Active Coodinator in this Region";
                    ViewBag.CentreId = new SelectList(await _centre.TabAsync(), "CentreId", "CentreName");
                    return View(model);
                }
                if (User.Identity.Name != null)
                {
                    var Centre = await _coodinator.GetByUserNameAsync(User.Identity.Name);
                    if (Centre == null)
                    {
                        return RedirectToAction("Error", "Error");
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
                                ViewBag.CentreId = new SelectList(await _centre.TabAsync(), "CentreId", "CentreName");
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
                    await _centreManage.AddAsync(model);
                    return RedirectToAction("EmailSendLink", "Account");
                }
                else
                {
                    return RedirectToAction("Error", "Error");
                }
            }
            ViewBag.CentreId = new SelectList(await _centre.TabAsync(), "CentreId", "CentreName");
            return View(model);
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
    }
}
