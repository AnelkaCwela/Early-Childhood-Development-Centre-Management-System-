using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    public class RegionResp: IRegion
    {
        private readonly DBCONTEX context;
        public RegionResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<RegionModel>> TabAsync()
        {
            return await context.RegionTbl.ToListAsync();
        }
        public async Task<IEnumerable<RegionModel>> TabProvinceAsync(int Id)
        {
            return await context.RegionTbl.Where(p=>p.ProvinceId==Id).ToListAsync();
        }

        public async Task<RegionModel> GetByIdAsync(int Id)
        {
            return await context.RegionTbl.FirstOrDefaultAsync(x => x.RegionId == Id);
        }

        public async Task<RegionModel> AddAsync(RegionModel Model)
        {
            var DataModel = await context.RegionTbl.AddAsync(Model);
            await context.SaveChangesAsync();
            return DataModel.Entity;
        }

        public async Task<RegionModel> RemoveAsync(int Id)
        {
            var data = await context.RegionTbl.FirstOrDefaultAsync(x => x.RegionId == Id);
            if (data != null)
            {
                context.RegionTbl.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<RegionModel> UpdatAsync(RegionModel Model)
        {
            var Data = await context.RegionTbl.FirstOrDefaultAsync(x => x.RegionId == Model.RegionId);
            if (Data != null)
            {
                Data.RegionName = Model.RegionName;/// All data must be binded 


                var save = context.RegionTbl.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Model;
        }
    }
}
