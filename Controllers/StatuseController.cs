using Algorithm_3rd_Year_Project.Models.Interface;
using Algorithm_3rd_Year_Project.Models.DataModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Algorithm_3rd_Year_Project.Controllers
{
    [AllowAnonymous]
    public class StatuseController : Controller
    {
        private readonly IStatus _status;
        private readonly IGander _gander;
        private readonly IProvince _province;
        private readonly IQualification _qualification;
        public StatuseController(IQualification qualification,IProvince province,IStatus status, IGander gander)
        {
            _qualification = qualification;
            _province = province;
            _status = status;
            _gander = gander;
        }
        [HttpGet]
        public IActionResult Createqualification()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Createqualification(QualificationModel model)
        {
            if (ModelState.IsValid)
            {
                await _qualification.AddAsync(model);
                ViewBag.A = "Added Succesfull";
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateProvince()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateProvince(ProvinceModel province)
        {
            if (ModelState.IsValid)
            {
                await _province.AddAsync(province);
                ViewBag.A = "Added Succesfull";
            }
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Createstatus(StatusModel statusModel)
        {
            if(ModelState.IsValid)            {
              await  _status.AddAsync(statusModel);
                ViewBag.A = "Added Succesfull";
            }
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Creategander(GanderModel ganderModel)
        {
            if (ModelState.IsValid)
            {
                await _gander.AddAsync(ganderModel);
                ViewBag.A = "Added Succesfull";
            }
            return View();
        }
        [HttpGet]
        public IActionResult Createstatus()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Creategander()
        {
            return View();
        }
    }
}
