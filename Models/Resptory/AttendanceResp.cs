using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    public class AttendanceResp: IAttendance
    {
        private readonly DBCONTEX context;
        public AttendanceResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<AttendanceModel>> TabAsync()
        {
            return await context.AttendanceTbl.ToListAsync();
        }
        public async Task<IEnumerable<AttendanceModel>> TabAsync(int Pupip)
        {
            return await context.AttendanceTbl.Where(p=>p.PupilId==Pupip).ToListAsync();
        }
        public async Task<IEnumerable<AttendanceModel>> TabAEnrolePupilsync(int EnroleId,int Pupip)
        {
            return await context.AttendanceTbl.Where(p => p.PupilId == Pupip&&p.EnroleId==EnroleId).ToListAsync();
        }

        public async Task<AttendanceModel> GetByIdAsync(int Id)
        {
            return await context.AttendanceTbl.FirstOrDefaultAsync(x => x.AttendanceId == Id);
        }

        public async Task<AttendanceModel> AddAsync(AttendanceModel Model)
        {
            var DataModel = await context.AttendanceTbl.AddAsync(Model);
            await context.SaveChangesAsync();
            return DataModel.Entity;
        }

        public async Task<AttendanceModel> RemoveAsync(int Id)
        {
            var data = await context.AttendanceTbl.FirstOrDefaultAsync(x => x.AttendanceId == Id);
            if (data != null)
            {
                context.AttendanceTbl.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<AttendanceModel> UpdatAsync(AttendanceModel Model)
        {
            var Data = await context.AttendanceTbl.FirstOrDefaultAsync(x => x.AttendanceId == Model.AttendanceId);
            if (Data != null)
            {
                Data.EnroleId = Model.EnroleId;/// All data must be binded 


                var save = context.AttendanceTbl.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Model;
        }
    }
}
