using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    public class ProgrameResp : IPrograme
    {
        private readonly DBCONTEX context;
        public ProgrameResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<ProgrameOfferdModel>> TabAsync()
        {
            return await context.ProgrameOfferdTbl.ToListAsync();
        }
        public async Task<IEnumerable<ProgrameOfferdModel>> TabAsync(int TeacherId)
        {
            return await context.ProgrameOfferdTbl.Where(p=>p.teacherId== TeacherId).ToListAsync();
        }
        public async Task<ProgrameOfferdModel> CheckProgramAsync(int Id,int teacherId)
        {
         var program=await context.ProgrameOfferdTbl.Where(p => p.teacherId == teacherId).ToListAsync();
            return program.FirstOrDefault(x => x.CentreProgramId == Id);
        }
        public async Task<ProgrameOfferdModel> GetByIdAsync(int Id)
        {
            return await context.ProgrameOfferdTbl.FirstOrDefaultAsync(x => x.ProgrameOfferdId == Id);
        }
        public async Task<ProgrameOfferdModel> GetByCentreProgramIdAsync(int Id)
        {
            var dAR = await context.ProgrameOfferdTbl.Where(x => x.CentreProgramId == Id).ToListAsync();
            return dAR.Last();
            //return await context.ProgrameOfferdTbl.FirstOrDefaultAsync(x => x.CentreProgramId == Id);
           // return await context.ProgrameOfferdTbl.FirstOrDefaultAsync(x => x.CentreProgramId == Id);
        }

        public async Task<ProgrameOfferdModel> AddAsync(ProgrameOfferdModel Model)
        {
            var DataModel = await context.ProgrameOfferdTbl.AddAsync(Model);
            await context.SaveChangesAsync();
            return DataModel.Entity;
        }

        public async Task<ProgrameOfferdModel> RemoveAsync(int Id)
        {
            var data = await context.ProgrameOfferdTbl.FirstOrDefaultAsync(x => x.ProgrameOfferdId == Id);
            if (data != null)
            {
                context.ProgrameOfferdTbl.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<ProgrameOfferdModel> UpdatAsync(ProgrameOfferdModel Model)
        {
            var Data = await context.ProgrameOfferdTbl.FirstOrDefaultAsync(x => x.ProgrameOfferdId == Model.ProgrameOfferdId);
            if (Data != null)
            {
                Data.CentreProgramId = Model.CentreProgramId;/// All data must be binded 


                var save = context.ProgrameOfferdTbl.Attach(Data);
                save.State = EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Model;
        }
    }
}
