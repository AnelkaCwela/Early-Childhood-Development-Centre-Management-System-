using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    public class LiaisonResp: ILiaison
    {
        private readonly DBCONTEX context;
        public LiaisonResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<LiaisonModel>> TabAsync()
        {
            return await context.LiaisonTbl.ToListAsync();
        }

        public async Task<LiaisonModel> GetByIdAsync(int Id)
        {
            return await context.LiaisonTbl.FirstOrDefaultAsync(x => x.LiaisonId == Id);
        }
        
        public async Task<LiaisonModel> GetByUserNameAsync(string User)
        {
            return await context.LiaisonTbl.FirstOrDefaultAsync(x => x.UserName == User);
        }
        public async Task<LiaisonModel> AddAsync(LiaisonModel Model)
        {
            var DataModel = await context.LiaisonTbl.AddAsync(Model);
            await context.SaveChangesAsync();
            return DataModel.Entity;
        }

        public async Task<LiaisonModel> RemoveAsync(int Id)
        {
            var data = await context.LiaisonTbl.FirstOrDefaultAsync(x => x.LiaisonId == Id);
            if (data != null)
            {
                context.LiaisonTbl.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<LiaisonModel> UpdatAsync(LiaisonModel Model)
        {
            var Data = await context.LiaisonTbl.FirstOrDefaultAsync(x => x.LiaisonId == Model.LiaisonId);
            if (Data != null)
            {
                Data.ProvinceId = Model.ProvinceId;/// All data must be binded 


                var save = context.LiaisonTbl.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Model;
        }
    }
}
