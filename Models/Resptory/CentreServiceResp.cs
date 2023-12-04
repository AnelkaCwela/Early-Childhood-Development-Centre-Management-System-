using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    public class CentreServiceResp: ICentreService
    {
        private readonly DBCONTEX context;
        public CentreServiceResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<CentreServiceModel>> TabAsync()
        {
            return await context.CentreServiceTbl.ToListAsync();
        }

        public async Task<CentreServiceModel> GetByIdAsync(int Id)
        {
            return await context.CentreServiceTbl.FirstOrDefaultAsync(x => x.CentreServiceId == Id);
        }

        public async Task<CentreServiceModel> AddAsync(CentreServiceModel Model)
        {
            var DataModel = await context.CentreServiceTbl.AddAsync(Model);
            await context.SaveChangesAsync();
            return DataModel.Entity;
        }

        public async Task<CentreServiceModel> RemoveAsync(int Id)
        {
            var data = await context.CentreServiceTbl.FirstOrDefaultAsync(x => x.CentreServiceId == Id);
            if (data != null)
            {
                context.CentreServiceTbl.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<CentreServiceModel> UpdatAsync(CentreServiceModel Model)
        {
            var Data = await context.CentreServiceTbl.FirstOrDefaultAsync(x => x.CentreServiceId == Model.CentreServiceId);
            if (Data != null)
            {
                Data.CentreId = Model.CentreId;/// All data must be binded 


                var save = context.CentreServiceTbl.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Model;
        }
    }
}
