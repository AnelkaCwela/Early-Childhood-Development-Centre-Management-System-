using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    public class CentreResp: ICentre
    {
        private readonly DBCONTEX context;
        public CentreResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<CentreModel>> TabAsync()
        {
            return await context.CentreTbl.ToListAsync();
        }
        public async Task<IEnumerable<CentreModel>> TabSubAsync(int Id)
        {
            return await context.CentreTbl.Where(p => p.SuburbId == Id).ToListAsync();
        }

        public async Task<CentreModel> GetByIdAsync(int Id)
        {
            return await context.CentreTbl.FirstOrDefaultAsync(x => x.CentreId == Id);
        }

        public async Task<CentreModel> AddAsync(CentreModel Model)
        {
            var DataModel = await context.CentreTbl.AddAsync(Model);
            await context.SaveChangesAsync();
            return DataModel.Entity;
        }

        public async Task<CentreModel> RemoveAsync(int Id)
        {
            var data = await context.CentreTbl.FirstOrDefaultAsync(x => x.CentreId == Id);
            if (data != null)
            {
                context.CentreTbl.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<CentreModel> UpdatAsync(CentreModel Model)
        {
            var Data = await context.CentreTbl.FirstOrDefaultAsync(x => x.CentreId == Model.CentreId);
            if (Data != null)
            {
                Data.CentreId = Model.CentreId;/// All data must be binded 


                var save = context.CentreTbl.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Model;
        }
    }
}
