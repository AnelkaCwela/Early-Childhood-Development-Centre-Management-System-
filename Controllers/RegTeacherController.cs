using Algorithm_3rd_Year_Project.Models.DataBinding;
using Algorithm_3rd_Year_Project.Models.Del;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Algorithm_3rd_Year_Project.Controllers
{
    [AllowAnonymous]
    public class RegTeacherController : Controller
    {
        // GET: RegTeacherController
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public ActionResult RegTeach()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult RegTeach(RegTeacherModel reg)
        {
            if(ModelState.IsValid)
            {

            }
            return View(reg);
        }


        // GET: ProgramController
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public ActionResult Program()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult Program(RegProgam reg)
        {
            if (ModelState.IsValid)
            {

            }
            return View(reg);
        }
        // GET: ProgramController
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public ActionResult ProgramName()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult ProgramName(RegProgName reg)
        {
            if (ModelState.IsValid)
            {

            }
            return View(reg);
        }
        //////r/////
        ///List
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public ActionResult ProgramNameList()
        {
            return View();
        }
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public ActionResult ProgramList()
        {
            return View();
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public ActionResult RegTeachList()
        {
            return View();
        }
        ////Detail
        ///
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public ActionResult ProgramNameL()
        {
            return View();
        }
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public ActionResult ProgramL()
        {
            return View();
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public ActionResult RegTeachL()
        {
            return View();
        }
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public ActionResult ApplicationDetails()
        {
            return View();
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public ActionResult ApplicationList()
        {
            return View();
        }
    }
}
