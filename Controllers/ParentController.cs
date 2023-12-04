using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithm_3rd_Year_Project.Models;
using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Algorithm_3rd_Year_Project.Models.DataBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Identity;

namespace Algorithm_3rd_Year_Project.Controllers
{
    public class ParentController : Controller
    {
        private readonly IPupil _pupil;      
        private readonly IStatus _status;
        private readonly IGander _gander;
        private readonly ICentre _centre;
        private readonly IParent _parent;
        private readonly ICentreProgram _centreProgram;
        private readonly IEnrole _enrole;
        private readonly IPrograme _programe;
        private readonly UserManager<UserModel> _userManager;
        public ParentController(UserManager<UserModel> userManager, IPrograme programe,IEnrole enrole,ICentreProgram centreProgram,IPupil pupil, ICentre centre, IParent parent, IStatus status, IGander gander)
        {
            _programe = programe;
            _enrole = enrole;
            _centreProgram = centreProgram;
            _pupil = pupil;
            _centre = centre;
            _parent = parent;
            _userManager = userManager;
            _status = status;
            _gander = gander;
        }
        //Time Table , Progress Report
        public async Task<IActionResult> Module(int Id)
        {
            if (User.Identity.Name != null)
            {
                if (Id < 1)
                {
                    return RedirectToAction("Error", "Error");
                }
                var pupil = await _pupil.GetByIdAsync(Id);
                if (pupil == null)
                {
                    return RedirectToAction("Error", "Error");
                }
                ViewBag.Name = pupil.Fname;
                ViewBag.LastName = pupil.Lname;               
                //
                IEnumerable<EnroleModel> Enrol = await _enrole.TabEnrolByPupilAsync(Id);
                IEnumerable<ProgrameOfferdModel> prog = await _programe.TabAsync();
                ViewBag.CentrePro = await _centreProgram.TabAsync();
                var combineTible = from c in Enrol

                                   join ct1 in prog on c.ProgrameOfferdId equals ct1.ProgrameOfferdId into tab2
                                   from ct1 in tab2.DefaultIfEmpty()
                                   select new EnrolesViewModel
                                   {

                                       ProgrameOfferdModel = ct1,
                                       enroleModel = c
                                   };

                return View(combineTible);
            }
            return RedirectToAction("Error", "Error");
        }
        public async Task<IActionResult> Index()
        {
            if (User.Identity.Name != null)
            {
                var Pare = await _parent.GetByUserNameAsync(User.Identity.Name);
                if (Pare == null)
                {
                    return RedirectToAction("Error", "Error");
                }
                IEnumerable<PupilModel> pupil = await _pupil.TabByParentIdAsync(Pare.ParentId);
                
                return View(pupil);
            }
            return RedirectToAction("Error", "Error");
        }
        public byte[] Data { get; set; }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Apply(PupilModel model)//Applay
        {
            if(ModelState.IsValid)
            {
                if(User.Identity.Name!=null)
                {
                  var Pare =await _parent.GetByUserNameAsync(User.Identity.Name);
                    if(Pare==null)
                    {
                        return RedirectToAction("Error","Error");
                    }

                    foreach (var file in Request.Form.Files)
                    {                       
                        MemoryStream ms = new MemoryStream();
                        file.CopyTo(ms);
                       
                        try
                        {
                            var supported = new[] { "pdf", "PDF" };
                            var f = Path.GetExtension(file.FileName).Substring(1);
                            if (!supported.Contains(f)|| ms.ToArray()==null)
                            {
                                ViewBag.B = "Pdf file format required";
                                ViewBag.GanderId = new SelectList(await _gander.TabAsync(), "GanderId", "Gander");
                                ViewBag.CentreId = new SelectList(await _centre.TabAsync(), "CentreId", "CentreName");

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
                    model.ParentId = Pare.ParentId;
                    model.birthDocument = Data;
                    model.ApplicationDate = DateTime.Now;
                    model.StatusId = 1;//Submitted
                    try
                    {
                        await _pupil.AddAsync(model);
                    }
                    catch
                    {
                        return RedirectToAction("Error", "Error");
                    }
                    return RedirectToAction("Apply", "Parent");
                }
                else
                {
                    return RedirectToAction("Error", "Error");
                }
            }
            ViewBag.GanderId = new SelectList(await _gander.TabAsync(), "GanderId", "Gander");
            ViewBag.CentreId = new SelectList(await _centre.TabAsync(), "CentreId", "CentreName");
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Apply()//Applay
        {        
            ViewBag.GanderId = new SelectList(await _gander.TabAsync(), "GanderId", "Gander");          
            ViewBag.CentreId = new SelectList(await _centre.TabAsync(), "CentreId", "CentreName");
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Statuse()//List Of Apllication and Statuse
        {
            if (User.Identity.Name != null)
            {
                var Pare = await _parent.GetByUserNameAsync(User.Identity.Name);
                if (Pare == null)
                {
                    return RedirectToAction("Error", "Error");
                }
                IEnumerable<GanderModel> gander = await _gander.TabAsync();
                IEnumerable<CentreModel> centres = await _centre.TabAsync();
                IEnumerable<StatusModel> status = await _status.TabAsync();
                IEnumerable<PupilModel> pupils = await _pupil.TabByParentIdAsync(Pare.ParentId);
                var combineTible = from c in pupils

                                   join ct1 in gander on c.GanderId equals ct1.GanderId into tab2
                                   from ct1 in tab2.DefaultIfEmpty()

                                   join ct2 in centres on c.CentreId equals ct2.CentreId into tab3
                                   from ct2 in tab3.DefaultIfEmpty()

                                   join ct4 in status on c.StatusId equals ct4.StatusId into ct4
                                   from ct in ct4.DefaultIfEmpty()
                                   select new PupilStatuseView
                                   {
                                       StatusModel= ct,
                                       ganderModel = ct1,
                                       centreModel = ct2,
                                       pupilModel= c
                                   };

                return View(combineTible);
            }
            else
            {
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Student()//Accepted Application
        {
            if (User.Identity.Name != null)
            {
                var Pare = await _parent.GetByUserNameAsync(User.Identity.Name);
                if (Pare == null)
                {
                    return RedirectToAction("Error", "Error");
                }
                int statuse = 4;//Admited
                IEnumerable<GanderModel> gander = await _gander.TabAsync();
                IEnumerable<CentreModel> centres = await _centre.TabAsync();
                IEnumerable<StatusModel> status = await _status.TabAsync();
                IEnumerable<PupilModel> pupils = await _pupil.TabByParentIdAsync(Pare.ParentId, statuse);
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
        [HttpGet]
        public async Task<IActionResult> Cancel(int Id)//List Of Program
        {
            if (Id >0)
            {
                int Statuse =3 ;//Canceled
                var ID = await _pupil.GetByIdAsync(Id);
                if(ID!=null)
                {
                    await _pupil.UpdatStatuseAsync(Id, Statuse);
                    return RedirectToAction("Statuse", "Parent");
                }
                
            }          
             return RedirectToAction("Error", "Error");                 
        }
       
        [HttpGet]
        public async Task<IActionResult> Enrol(int Id ,int i)//List Of Program
        {
            if(Id<1||i<1)
            {
                return RedirectToAction("Error", "Error");
            }
            PupilModel pupil = await _pupil.GetByIdAsync(Id);
            if(pupil==null)
            {
                return RedirectToAction("Error", "Error");
            }
            var centre = await _centre.GetByIdAsync(pupil.CentreId);
            ViewBag.Centre = centre.CentreName;
            EnroleMode enrole = new EnroleMode();
            enrole.PupilId = pupil.PupilId;
            enrole.Fname = pupil.Fname;
            enrole.IdentityNo = pupil.IdentityNo;
            enrole.Lname = pupil.Lname;
            enrole.CentreId = pupil.CentreId;
            //enrole.ProgrameOfferdId=
            ViewBag.CentreProgramId = new SelectList(await _centreProgram.TabByCentreAsync(i), "CentreProgramId", "ProgramDescr");
            return View(enrole);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Enrol(EnroleMode enrole)//List Of Program
        {
            if(ModelState.IsValid)
            {
                EnroleModel mode = new EnroleModel();

                mode.EnroleYear = DateTime.Now.AddYears(0);
                var ProgrameOfferdId = await _programe.GetByCentreProgramIdAsync(enrole.CentreProgramId);
                if(ProgrameOfferdId==null)
                {
                    return RedirectToAction("Error", "Error");//######################################
                }
                mode.ProgrameOfferdId = ProgrameOfferdId.ProgrameOfferdId;             
                mode.Enrole = true;
                mode.PupilId = enrole.PupilId;
                 await _enrole.AddAsync(mode);
                return RedirectToAction("Enroles", "Parent",new { Id = enrole.PupilId });
            }
            var centre = await _centre.GetByIdAsync(enrole.CentreId);
            ViewBag.Centre = centre.CentreName;
            ViewBag.CentreProgramId = new SelectList(await _centreProgram.TabByCentreAsync(enrole.CentreId), "CentreProgramId", "ProgramDescr");
            return View(enrole);
        }
        [HttpGet]
        public async Task<IActionResult> Enroles(int Id)//List Of Program
        {
              if(Id<1)
              {
                return RedirectToAction("Error", "Error");
              }
               IEnumerable<EnroleModel> Enrol=  await _enrole.TabEnrolByPupilAsync(Id);
               IEnumerable <ProgrameOfferdModel> prog = await _programe.TabAsync();
                ViewBag.CentrePro = await _centreProgram.TabAsync();
              var combineTible = from c in Enrol

                                 join ct1 in prog on c.ProgrameOfferdId equals ct1.ProgrameOfferdId into tab2
                               from ct1 in tab2.DefaultIfEmpty()
                               select new EnrolesViewModel
                               {

                                   ProgrameOfferdModel = ct1,
                                   enroleModel = c
                               };

            return View(combineTible);
        }
        [HttpGet]
        public async Task<IActionResult> Pupuil()//Pupil Details And Program Enrole in
        {
            if (User.Identity.Name != null)
            {
                var Pare = await _parent.GetByUserNameAsync(User.Identity.Name);
                if (Pare == null)
                {
                    return RedirectToAction("Error", "Error");
                }
                UserModel Use = await _userManager.FindByEmailAsync(User.Identity.Name);
                if(Use==null)
                {
                    return RedirectToAction("Error", "Error");
                }
                ViewBag.Name = Use.Fname;
                ViewBag.Surnme = Use.Lname;
                ViewBag.Cell = Use.CellNo;
                ViewBag.Email = User.Identity.Name;
                ProfileViewModel model = new ProfileViewModel();
                model.ParentModel = Pare;
                model.pupilModels= await _pupil.TabByParentIdAsync(Pare.ParentId);
                return View(model);
            }
            else
            {
                return RedirectToAction("Error", "Error");
            }
        }

        public IActionResult TimeTable()
        {
            return View();
        }
        public IActionResult PrograssRepot()
        {
            return View();
        }
    }
}
