using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    public class CentreProgramResp:ICentreProgram
    {
        private readonly DBCONTEX context;
        public CentreProgramResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<CentreProgramModel>> TabAsync()
        {
            return await context.CentreProgramTbl.ToListAsync();
        }
        public async Task<IEnumerable<CentreProgramModel>> TabByCentreAsync(int Id)
        {
            return await context.CentreProgramTbl.Where(p=>p.CentreId==Id).ToListAsync();
        }

        public async Task<CentreProgramModel> GetByIdAsync(int Id)
        {
            return await context.CentreProgramTbl.FirstOrDefaultAsync(x => x.CentreProgramId == Id);
        }

        public async Task<CentreProgramModel> AddAsync(CentreProgramModel Model)
        {
            var DataModel = await context.CentreProgramTbl.AddAsync(Model);
            await context.SaveChangesAsync();
            return DataModel.Entity;
        }

        public async Task<CentreProgramModel> RemoveAsync(int Id)
        {
            var data = await context.CentreProgramTbl.FirstOrDefaultAsync(x => x.CentreProgramId == Id);
            if (data != null)
            {
                context.CentreProgramTbl.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<CentreProgramModel> UpdatAsync(CentreProgramModel Model)
        {
            var Data = await context.CentreProgramTbl.FirstOrDefaultAsync(x => x.CentreProgramId == Model.CentreProgramId);
            if (Data != null)
            {
                Data.ProgramDescr = Model.ProgramDescr;/// All data must be binded 


                var save = context.CentreProgramTbl.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Model;
        }
    }
}
