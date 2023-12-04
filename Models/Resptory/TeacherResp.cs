using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    public class TeacherResp: ITeacher
    {
        private readonly DBCONTEX context;
        public TeacherResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<TeacherModel>> TabAsync()
        {
            return await context.teacherTbl.ToListAsync();
        }
        public async Task<IEnumerable<TeacherModel>> TabByCentreAsync(int Id)
        {
            return await context.teacherTbl.Where(r=>r.CentreId==Id).ToListAsync();
        }
        public async Task<TeacherModel> GetByUserNameAsync(string UserName)
        {
            return await context.teacherTbl.FirstOrDefaultAsync(x => x.UserName == UserName);
        }

        public async Task<TeacherModel> GetByIdAsync(int Id)
        {
            return await context.teacherTbl.FirstOrDefaultAsync(x => x.teacherId == Id);
        }

        public async Task<TeacherModel> AddAsync(TeacherModel Model)
        {
            var DataModel = await context.teacherTbl.AddAsync(Model);
            await context.SaveChangesAsync();
            return DataModel.Entity;
        }

        public async Task<TeacherModel> RemoveAsync(int Id)
        {
            var data = await context.teacherTbl.FirstOrDefaultAsync(x => x.teacherId == Id);
            if (data != null)
            {
                context.teacherTbl.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<TeacherModel> UpdatAsync(TeacherModel Model)
        {
            var Data = await context.teacherTbl.FirstOrDefaultAsync(x => x.teacherId == Model.teacherId);
            if (Data != null)
            {
                //.CellNo = Model.CellNo;/// All that must be binded 
      

                var save = context.teacherTbl.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Model;
        }
    }
}
