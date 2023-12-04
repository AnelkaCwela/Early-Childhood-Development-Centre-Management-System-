using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithm_3rd_Year_Project.Models.DataModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Algorithm_3rd_Year_Project.Models
{
    public class DBCONTEX : IdentityDbContext<UserModel>
    {
        public DBCONTEX(DbContextOptions<DBCONTEX> options) : base(options)
        { }
        public DbSet<GanderModel> GanderModelTbl { get; set; }
        public DbSet<StatusModel> StatusTbl { get; set; }
        public DbSet<TeacherModel> teacherTbl { get; set; }
        public DbSet<TaskModel> taskTbl { get; set; }
        public DbSet<SuburbModel> SuburbTbl { get; set; }
        public DbSet<RegionModel> RegionTbl { get; set; }
        public DbSet<QualificationModel> QualificationTbl { get; set; }
        public DbSet<PupilModel> PupilTbl { get; set; }
        public DbSet<ProvinceModel> ProvinceTbl { get; set; }
        public DbSet<ProgrameOfferdModel> ProgrameOfferdTbl { get; set; }
        /*public DbSet<ProgrameModel> ProgrameTbl { get; set; }*/
        public DbSet<ParentModel> ParentTbl { get; set; }
        public DbSet<MarksModel> MarksTbl { get; set; }
        public DbSet<LiaisonModel> LiaisonTbl { get; set; }
        public DbSet<EnroleModel> EnroleTbl { get; set; }
        public DbSet<CoodinatorModel> CoodinatorTbl { get; set; }
        public DbSet<CentreSerViceTypeModel> CentreSerViceTypeTbl { get; set; }
        public DbSet<CentreServiceModel> CentreServiceTbl { get; set; }
        public DbSet<CentreProgramModel> CentreProgramTbl { get; set; }
        public DbSet<CentreModel> CentreTbl { get; set; }
        public DbSet<CentreManageModel> CentreManageTbl { get; set; }
        public DbSet<AttendanceModel> AttendanceTbl { get; set; }
    }
}
