using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    public class EnroleResp: IEnrole
    {
        private readonly DBCONTEX context;
        public EnroleResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<EnroleModel>> TabAsync()
        {
            return await context.EnroleTbl.ToListAsync();
        }
        public async Task<IEnumerable<EnroleModel>> TabEnrolByPupilAsync(int i)
        {
            return await context.EnroleTbl.Where(o => o.PupilId == i).ToListAsync();
        }
        public async Task<IEnumerable<EnroleModel>> TabEnrolByProgramAsync(int i)
        {
            return await context.EnroleTbl.Where(o=>o.ProgrameOfferdId==i).ToListAsync();
        }
        public async Task<EnroleModel> GetByIdAsync(int Id)
        {
            return await context.EnroleTbl.FirstOrDefaultAsync(x => x.EnroleId == Id);
        }
        public async Task<EnroleModel> GetByOferProgramAsync(int Id)
        {
            return await context.EnroleTbl.FirstOrDefaultAsync(x => x.ProgrameOfferdId == Id);
        }

        public async Task<EnroleModel> AddAsync(EnroleModel Model)
        {
            var DataModel = await context.EnroleTbl.AddAsync(Model);
            await context.SaveChangesAsync();
            return DataModel.Entity;
        }

        public async Task<EnroleModel> RemoveAsync(int Id)
        {
            var data = await context.EnroleTbl.FirstOrDefaultAsync(x => x.EnroleId == Id);
            if (data != null)
            {
                context.EnroleTbl.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<EnroleModel> UpdatAsync(EnroleModel Model)
        {
            var Data = await context.EnroleTbl.FirstOrDefaultAsync(x => x.EnroleId == Model.EnroleId);
            if (Data != null)
            {
                Data.EnroleId = Model.EnroleId;/// All data must be binded 


                var save = context.EnroleTbl.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Model;
        }
    }
}
