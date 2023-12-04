using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    public class TaskResp: ITask
    {
        private readonly DBCONTEX context;
        public TaskResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<TaskModel>> TabAsync()
        {
            return await context.taskTbl.ToListAsync();
        }
        public async Task<IEnumerable<TaskModel>> TabByCentreIdAsync(int CentreId)
        {
            return await context.taskTbl.Where(p=>p.CentreId==CentreId).ToListAsync();
        }

        public async Task<TaskModel> GetByIdAsync(int Id)
        {
            return await context.taskTbl.FirstOrDefaultAsync(x => x.taskId == Id);
        }

        public async Task<TaskModel> AddAsync(TaskModel Model)
        {
            var DataModel = await context.taskTbl.AddAsync(Model);
             context.SaveChanges();
            return DataModel.Entity;
        }

        public async Task<TaskModel> RemoveAsync(int Id)
        {
            var data = await context.taskTbl.FirstOrDefaultAsync(x => x.taskId == Id);
            if (data != null)
            {
                context.taskTbl.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<TaskModel> UpdatAsync(TaskModel Model)
        {
            var Data = await context.taskTbl.FirstOrDefaultAsync(x => x.taskId == Model.taskId);
            if (Data != null)
            {
                Data.taskName = Model.taskName;/// All data must be binded 


                var save = context.taskTbl.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Model;
        }
    }
}
