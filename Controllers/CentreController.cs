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
    public class CentreController : Controller
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
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly RoleManager<IdentityRole> _RoleManger;
        public CentreController(IEnrole enrole, ICentreProgram centreProgram, IPupil pupil, ICentre centre, IParent parent, IStatus status, IGander gander, IPrograme programe,IQualification qualification,ICentreManage centreManage,ITeacher teacher,RoleManager<IdentityRole> RoleManger, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            // _parent = parent;
            _programe = programe;
            _qualification = qualification;
            _centreManage = centreManage;
            _teacher = teacher;
             _signInManager = signInManager;
            _userManager = userManager;
            _RoleManger = RoleManger;
            _enrole = enrole;
            _centreProgram = centreProgram;
            _pupil = pupil;
            _centre = centre;
            _parent = parent;
            _status = status;
            _gander = gander;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public ActionResult RegTeach()
        {
            return View();
        }
        [HttpGet]
        
        public async Task<ActionResult> Decline(int Id)
        {
            if (Id < 1)
            {
                return RedirectToAction("Error", "Error");
            }
            int statuse = 3;//adecline
            await _pupil.UpdatStatuseAsync(Id, statuse);
            return RedirectToAction("ApplicationList", "Centre");
        }
        [HttpGet]
        public async Task<ActionResult> Accept(int Id)
        {
            if (Id < 1)
            {
                return RedirectToAction("Error", "Error");
            }
            int statuse = 4;//Acept
            await _pupil.UpdatStatuseAsync(Id, statuse);
            return RedirectToAction("ApplicationList", "Centre");
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Teacher(string Email)
        {
            if (Email == null)
            {
                return RedirectToAction("Error", "Error");
            }
            ViewBag.QualificationId = new SelectList( await _qualification.TabAsync(), "QualificationId", "QualificationName");
            TeacherModel teacher = new TeacherModel();
            teacher.UserName = Email;
            return View(teacher);
        }
        [HttpGet]
        public async Task<ActionResult> ListTeacher()
        {
            if (User.Identity.Name != null)
            {
                var Centre = await _centreManage.GetByUserAsync(User.Identity.Name);
                if (Centre == null)
                {
                    return RedirectToAction("Error", "Error");
                }
                var Cent = await _centre.GetByIdAsync(Centre.CentreId);
                var Manager = await _userManager.FindByEmailAsync(Centre.UserName);
                ViewBag.MangerName = Manager.Fname;
                ViewBag.MangerSurname = Manager.Lname;
                ViewBag.CentreName = Cent.CentreName;
                ViewBag.Email = Cent.CentraEmail;
                ViewBag.Cell = Cent.CentreNo;
                List<UserModel> Model = new List<UserModel>();
                IEnumerable<TeacherModel> tech = await _teacher.TabByCentreAsync(Centre.CentreId);
                string Role = "Teacher";
                List<UserModel> users = (List<UserModel>)await _userManager.GetUsersInRoleAsync(Role);
                foreach( var Data in users)
                {
                    foreach (var Da in tech)
                    {
                        if(Data.Email== Da.UserName)
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
        public byte[] Data { get; set; }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Teacher(TeacherModel teacher)
        {
            if(ModelState.IsValid)
            {
                if(User.Identity.Name!=null)
                {
                   var Centre=await _centreManage.GetByUserAsync(User.Identity.Name);
                    if(Centre==null)
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
                                ViewBag.QualificationId = new SelectList(await _qualification.TabAsync(), "QualificationId", "QualificationName");
                                return View(teacher); ;
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
                    teacher.Profile = Data;
                    teacher.CentreId = Centre.CentreId;
                    await _teacher.AddAsync(teacher);
                    return RedirectToAction("EmailSendLink", "Account");
                }
                else
                {
                    return RedirectToAction("Error", "Error");
                }
            }
            ViewBag.QualificationId = new SelectList(await _qualification.TabAsync(), "QualificationId", "QualificationName");
            return View(teacher);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        //Autozize /CentreManger
        public async Task<ActionResult> RegTeach(RegisterUserModel Model)
        {
            if (ModelState.IsValid)
            {//cc
                string password = Password();
                var User = new UserModel { UserName = Model.Email, Email = Model.Email, Fname = Model.Name, Lname = Model.Surname, CellNo = Model.CellNo };
                var Result = await _userManager.CreateAsync(User, password);
                if (Result.Succeeded)
                {
                    string Role = "Teacher";
                    await _userManager.AddToRoleAsync(User,Role);


                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(User);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { UserId = User.Id, token }, Request.Scheme);
                   // await Send(Model.Email, confirmationLink, password);

                    return RedirectToAction("Teacher", "Centre", new { Email = Model.Email });
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
            Mail.Body = "<p1>Please Confirm your email <br/> </p1>"+ "<p2>Your Login Password &nbsp;</p2>"+ Password +"<br/> <hr/>" + "<a href=" + confirmationLink + ">Confirm</a>";
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
        // GET: ProgramController
        // GET: ProgramController
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public ActionResult Program()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Program(CentreProgramModel reg)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.Name != null)
                {
                    var Centre = await _centreManage.GetByUserAsync(User.Identity.Name);
                    if (Centre == null)
                    {
                        return RedirectToAction("Error", "Error");
                    }
                    reg.CentreId = Centre.CentreId;                 
                     var pro= await  _centreProgram.AddAsync(reg);
                    if(pro!=null)
                    {
                        int Id = pro.CentreProgramId;
                        return RedirectToAction("ProgramName", "Centre",new { Id = Id });
                    }
                    ViewBag.A = "Somthing went wrong Contact Owner";
                }
                else
                {
                    return RedirectToAction("Error", "Error");
                }
            }
            return View(reg);
        }
        // GET: ProgramController
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> ProgramName(int Id)
        {
            if(Id<1)
            {
                return RedirectToAction("Error", "Error");
            }
            if (User.Identity.Name != null)
            {
              var Centre = await _centreManage.GetByUserAsync(User.Identity.Name);
                //var teach = await _teacher.GetByUserNameAsync(Email);
                if (Centre == null)
                {
                    return RedirectToAction("Error", "Error");
                }
                List<UserModel> Use = (List<UserModel>)await _userManager.GetUsersInRoleAsync("Teacher");
                CentreProgramModel programe = await _centreProgram.GetByIdAsync(Id);
                List<ComboTeacher> Combo= UserTeacher(Use);
                ViewBag.Anele = new SelectList(Combo, "Email", "Fname");               
                ProgrameOfferdInsertModel model = new ProgrameOfferdInsertModel();
                model.CentreProgramId = Id;
                ViewBag.ProgrameName = programe.ProgramDescr;
                ViewBag.Year = programe.YearOferd;
                return View(model);

            }
            else
            {
                return RedirectToAction("Error", "Error");
            }
           
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> ProgramName(ProgrameOfferdInsertModel model)
        {
            if (ModelState.IsValid)
            {
             var tec =await _teacher.GetByUserNameAsync(model.UserName);
                if(tec==null)
                {
                    return RedirectToAction("Error", "Error");
                }
                //Check if Select CentrePograme dosnot exit
                // teacherId,CentreProgramId
                var value = await _programe.CheckProgramAsync(model.CentreProgramId, tec.teacherId);
                if(value!=null)
                {
                    List<UserModel> Use = (List<UserModel>)await _userManager.GetUsersInRoleAsync("Teacher");
                    CentreProgramModel rograme = await _centreProgram.GetByIdAsync(model.CentreProgramId);
                    List<ComboTeacher> Combo = UserTeacher(Use);
                    ViewBag.Anele = new SelectList(Combo, "Email", "Fname");
                    ProgrameOfferdInsertModel mode = new ProgrameOfferdInsertModel();
                    model.CentreProgramId = model.CentreProgramId;
                    ViewBag.ProgrameName = rograme.ProgramDescr;
                    ViewBag.Year = rograme.YearOferd;
                    ViewBag.already = "Selected Teacher already Assigned to this Program";
                    return View(model);
                }
                ProgrameOfferdModel programe = new ProgrameOfferdModel();
                programe.EndDate = model.EndDate;
                programe.StartDate = model.StartDate;
                programe.CentreProgramId = model.CentreProgramId;
                programe.teacherId = tec.teacherId;
                 await _programe.AddAsync(programe);
                return RedirectToAction("ProgramNameList", "Centre", new { P = tec.teacherId });
            }
            return RedirectToAction("Error", "Error");
        }
        private List<ComboTeacher> UserTeacher(List<UserModel> Use)
        {
            List<ComboTeacher> combo = new List<ComboTeacher>();
            foreach (var Data in Use)
            {
                ComboTeacher teacher = new ComboTeacher();
                teacher.Email = Data.Email;
                teacher.Fname = Data.Fname + " " + Data.Lname;
                teacher.Lname = Data.Lname;
                combo.Add(teacher);
            }
            return combo;
        }
        //////r/////
        ///List
        [HttpGet]
        public async Task<ActionResult> ProgramNameList(int P,string Email)
        {
            if(P<1&&Email==null)
            {
                return RedirectToAction("Error", "Error");
            }
            TeacherModel vv;
            if (Email == null)
            {
                vv = await _teacher.GetByIdAsync(P);
            }
            else
            {
                vv = await _teacher.GetByUserNameAsync(Email);
            }

            if(vv!=null)
            {
                var Use = await _userManager.FindByEmailAsync(vv.UserName);
                ViewBag.Name = Use.Fname;
                ViewBag.Surname = Use.Lname;
                ViewBag.inital = vv.tittleModel;
                ViewBag.Cell = Use.CellNo;
            }
            IEnumerable<ProgrameOfferdModel> Data = await _programe.TabAsync(vv.teacherId);
            
            ViewBag.CentreProgramId = new SelectList(await _centreProgram.TabByCentreAsync(vv.CentreId), "CentreProgramId", "ProgramDescr");
            return View(Data);
        }
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public ActionResult ApplicationDetails()
        {
            return View();
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> ApplicationList()
        {
            if (User.Identity.Name != null)
            {
                var Pare = await _centreManage.GetByUserAsync(User.Identity.Name);
                if (Pare == null)
                {
                    return RedirectToAction("Error", "Error");
                }
                IEnumerable<GanderModel> gander = await _gander.TabAsync();
                IEnumerable<CentreModel> centres = await _centre.TabAsync();
                IEnumerable<StatusModel> status = await _status.TabAsync();
                IEnumerable<PupilModel> pupils = await _pupil.TabByCentreIdAsync(Pare.CentreId);
                var combineTible = from c in pupils

                                   join ct1 in gander on c.GanderId equals ct1.GanderId into tab2
                                   from ct1 in tab2.DefaultIfEmpty()

                                   join ct2 in centres on c.CentreId equals ct2.CentreId into tab3
                                   from ct2 in tab3.DefaultIfEmpty()

                                   join ct4 in status on c.StatusId equals ct4.StatusId into ct4
                                   from ct in ct4.DefaultIfEmpty()
                                   select new PupilStatuseView
                                   {
                                       StatusModel = ct,
                                       ganderModel = ct1,
                                       centreModel = ct2,
                                       pupilModel = c
                                   };

                return View(combineTible);
            }
            else
            {
                return RedirectToAction("Error", "Error");
            }
        }
    }
}
