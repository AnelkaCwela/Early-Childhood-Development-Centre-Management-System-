using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Algorithm_3rd_Year_Project.Models.DataBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Algorithm_3rd_Year_Project.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ICentre _centre;
        private readonly IPrograme _programe;
        private readonly ITeacher _teacher;
        private readonly ICentreManage _centreManage;
        //private readonly IQualification _qualification;
        private readonly IPupil _pupil;
        private readonly ITask _task;
        private readonly IStatus _status;
        private readonly IGander _gander;
        private readonly IParent _parent;
        private readonly ICentreProgram _centreProgram;
        private readonly IEnrole _enrole;
        private readonly IMarks _marks;
        private readonly IAttendance _attendance;
       public TeacherController(ICentreManage centreManage,IAttendance attendance,IMarks marks,ITask task,ITeacher teacher,IEnrole enrole, ICentreProgram centreProgram, IPupil pupil, ICentre centre, IParent parent, IStatus status, IGander gander, IPrograme programe)
        {
            _centreManage = centreManage;
            _attendance = attendance;
            _marks = marks;
            _programe = programe;
            _teacher = teacher;
            _task = task;
        _enrole = enrole;
            _centreProgram = centreProgram;
            _pupil = pupil;
            _centre = centre;
            _parent = parent;
            _status = status;
            _gander = gander;

            _enrole = enrole;
            _centreProgram = centreProgram;

            _parent = parent;
            _status = status;
            _gander = gander;
       }
        [HttpGet]
        public async Task<IActionResult> TaskList()
        {
            if (User.Identity.Name != null)
            {
                string op = User.Identity.Name;
                var Centre = await _centreManage.GetByUserAsync(op);
                
                int CentreId=0;
                if (Centre != null)
                {
                    CentreId = Centre.CentreId;
                }               
                else
                {
                    return RedirectToAction("Error", "Error");
                }

                IEnumerable<TaskModel> pp = await _task.TabByCentreIdAsync(CentreId);
                return View(pp);
            }
            return RedirectToAction("Error", "Error");

        }
        [HttpGet]
        public async Task<IActionResult> TaskLis()
        {
            if (User.Identity.Name != null)
            {
                var teach = await _teacher.GetByUserNameAsync(User.Identity.Name);
                int CentreId = 0;
                if (teach != null)
                {
                    CentreId = teach.CentreId;
                }
                else
                {
                    return RedirectToAction("Error", "Error");
                }

                IEnumerable<TaskModel> pp = await _task.TabByCentreIdAsync(CentreId);
                return View(pp);
            }
            return RedirectToAction("Error", "Error");

        }
        [HttpGet]
        public IActionResult Task()
        {

            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Task(TaskModel taskModel)
        {
            if (User.Identity.Name != null)
            {
                var Centre = await _centreManage.GetByUserAsync(User.Identity.Name);
                //var teach = await _teacher.GetByUserNameAsync(Email);
                if (Centre == null)
                {
                    return RedirectToAction("Error", "Error");
                }
                if (ModelState.IsValid)
                {
                    taskModel.CentreId = Centre.CentreId;
                  await _task.AddAsync(taskModel);
                    return RedirectToAction("TaskList", "Teacher");
                }
                return View(taskModel);
            }
            return RedirectToAction("Error", "Error");
        }
        [HttpGet]
        public async Task<IActionResult> Program()
        {
            if (User.Identity.Name != null)
            {
                var teach = await _teacher.GetByUserNameAsync(User.Identity.Name);
                if(teach==null)
                {
                    return RedirectToAction("Error", "Error");
                }
                IEnumerable<ProgrameOfferdModel> Data = await _programe.TabAsync(teach.teacherId);
                //ViewBag.CentreId = new SelectList(await _centre.TabAsync(), "CentreId", "CentreName");
                ViewBag.CentreProgramId = new SelectList(await _centreProgram.TabByCentreAsync(teach.CentreId), "CentreProgramId", "ProgramDescr");
                return View(Data);
            }
            return RedirectToAction("Error", "Error");
        }
        [HttpGet]
        public async Task<IActionResult> AddMarks(int Id)//Add Marks/View Marks/Attendance
        {
            if(Id<1)
            {
                return RedirectToAction("Error", "Error");
            }
            List<PupilModel> pupil = new List<PupilModel>();
            IEnumerable<EnroleModel> enrol = await _enrole.TabEnrolByProgramAsync(Id);
            IEnumerable<PupilModel> Mode = await _pupil.TabAsync();
            foreach(var en in enrol)
            {
                foreach(var mo in Mode)
                {
                    if(en.PupilId== mo.PupilId)
                    {
                        mo.CentreId = en.EnroleId;//Swipe The Keys
                        pupil.Add(mo);
                    }
                }
            }
            return View(pupil);
        }
        [HttpGet]
        public async Task<IActionResult> AddMark(int Id,int i)
        {
            if(Id<1|| i<1)
            {
                return RedirectToAction("Error", "Error");
            }
            MarksModel model = new MarksModel();
            model.PupilId = Id;
            var pupil = await _pupil.GetByIdAsync(Id);
            if(pupil==null)
            {
                return RedirectToAction("Error", "Error");
            }
            model.EnroleId = i;
            ViewBag.Name = pupil.Fname;
            ViewBag.LastName = pupil.Lname;
            ViewBag.taskId = new SelectList(await _task.TabAsync(), "taskId", "taskName");
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Mark(int Id,int i)
        {
            if (Id < 1|| i<1)
            {
                return RedirectToAction("Error", "Error");
            }
            var pupil = await _pupil.GetByIdAsync(Id);
            if(pupil==null)
            {
                return RedirectToAction("Error", "Error");
            }
            ViewBag.Name = pupil.Fname;
            ViewBag.LastName = pupil.Lname;
          IEnumerable<MarksModel> dATA=  await _marks.TabPupilIdEnroleIdAsync(pupil.PupilId, i);
            ViewBag.taskId = new SelectList(await _task.TabAsync(), "taskId", "taskName");
            return View(dATA);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddMark(MarksModel marksModel)
        {
            if(ModelState.IsValid)
            {
                _marks.AddAsync(marksModel);
                
                return RedirectToAction("Mark", "Teacher",new { Id= marksModel.PupilId, i = marksModel.EnroleId });
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddAttendance(int Id)
        {
            if (Id < 1)
            {
                return RedirectToAction("Error", "Error");
            }
            List<PupilModel> pupil = new List<PupilModel>();
            IEnumerable<EnroleModel> enrol = await _enrole.TabEnrolByProgramAsync(Id);
            IEnumerable<PupilModel> Mode = await _pupil.TabAsync();
            foreach (var en in enrol)
            {
                foreach (var mo in Mode)
                {
                    if (en.PupilId == mo.PupilId)
                    {
                        mo.CentreId = en.EnroleId;//Swipe The Keys
                        pupil.Add(mo);
                    }
                }
            }
            return View(pupil);
        }
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> Attendance(AttendanceModel attendanceModel)
        {
            if(ModelState.IsValid)
            {
                await _attendance.AddAsync(attendanceModel);
              
                     return RedirectToAction("Attend", "Teacher", new { Id = attendanceModel.PupilId,i= attendanceModel.EnroleId });
            }
            return RedirectToAction("Error", "Error");
        }
        [HttpGet]
        public async Task<IActionResult> Attend(int Id,int i)
        {
            if (Id < 1|| i<1)
            {
                return RedirectToAction("Error", "Error");
            }
            var pupil = await _pupil.GetByIdAsync(Id);
            //TabAsync
           IEnumerable<AttendanceModel> attendance = await _attendance.TabAEnrolePupilsync(i,pupil.PupilId);
            ViewBag.Name = pupil.Fname;
            ViewBag.LastName = pupil.Lname;
            ViewBag.taskId = new SelectList(await _task.TabAsync(), "taskId", "taskName");
            return View(attendance);
        }
        [HttpGet]
        public async Task<IActionResult> Attendance(int Id, int i)
        {
            if (Id < 1 || i < 1)
            {
                return RedirectToAction("Error", "Error");
            }
            AttendanceModel model = new AttendanceModel();
            model.PupilId = Id;
            var pupil = await _pupil.GetByIdAsync(Id);
            model.EnroleId = i;
            ViewBag.Name = pupil.Fname;
            ViewBag.LastName = pupil.Lname;
            ViewBag.taskId = new SelectList(await _task.TabAsync(), "taskId", "taskName");
            return View(model);
        }
      
    }
}
