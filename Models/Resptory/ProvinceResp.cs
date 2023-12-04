using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    public class ProvinceResp: IProvince
    {
        private readonly DBCONTEX context;
        public ProvinceResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<ProvinceModel>> TabAsync()
        {
            return await context.ProvinceTbl.ToListAsync();
        }

        public async Task<ProvinceModel> GetByIdAsync(int Id)
        {
            return await context.ProvinceTbl.FirstOrDefaultAsync(x => x.ProvinceId == Id);
        }

        public async Task<ProvinceModel> AddAsync(ProvinceModel Model)
        {
            var DataModel = await context.ProvinceTbl.AddAsync(Model);
            await context.SaveChangesAsync();
            return DataModel.Entity;
        }

        public async Task<ProvinceModel> RemoveAsync(int Id)
        {
            var data = await context.ProvinceTbl.FirstOrDefaultAsync(x => x.ProvinceId == Id);
            if (data != null)
            {
                context.ProvinceTbl.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<ProvinceModel> UpdatAsync(ProvinceModel Model)
        {
            var Data = await context.ProvinceTbl.FirstOrDefaultAsync(x => x.ProvinceId == Model.ProvinceId);
            if (Data != null)
            {
                Data.ProvinceName = Model.ProvinceName;/// All data must be binded 


                var save = context.ProvinceTbl.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Model;
        }
    }
}
