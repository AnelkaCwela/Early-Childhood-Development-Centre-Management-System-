using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    public class SuburbResp : ISuburb
    {
        private readonly DBCONTEX context;
        public SuburbResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<SuburbModel>> TabAsync()
        {
            return await context.SuburbTbl.ToListAsync();
        }

        public async Task<SuburbModel> GetByIdAsync(int Id)
        {
            return await context.SuburbTbl.FirstOrDefaultAsync(x => x.SuburbId == Id);
        }
        public async Task<SuburbModel> GetByRegionIdAsync(int Id)
        {
            return await context.SuburbTbl.FirstOrDefaultAsync(x => x.RegionId == Id);
        }

        public async Task<SuburbModel> AddAsync(SuburbModel Model)
        {
            var DataModel = await context.SuburbTbl.AddAsync(Model);
            await context.SaveChangesAsync();
            return DataModel.Entity;
        }

        public async Task<SuburbModel> RemoveAsync(int Id)
        {
            var data = await context.SuburbTbl.FirstOrDefaultAsync(x => x.SuburbId == Id);
            if (data != null)
            {
                context.SuburbTbl.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<SuburbModel> UpdatAsync(SuburbModel Model)
        {
            var Data = await context.SuburbTbl.FirstOrDefaultAsync(x => x.SuburbId == Model.SuburbId);
            if (Data != null)
            {
                Data.AddressLine1 = Model.AddressLine1;/// All data must be binded 


                var save = context.SuburbTbl.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Model;
        }
    }
}
