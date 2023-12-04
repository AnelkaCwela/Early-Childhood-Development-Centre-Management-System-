using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    public class CoodinatorResp: ICoodinator
    {
        private readonly DBCONTEX context;
        public CoodinatorResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<CoodinatorModel>> TabAsync()
        {
            return await context.CoodinatorTbl.ToListAsync();
        }

        public async Task<CoodinatorModel> GetByIdAsync(int Id)
        {
            return await context.CoodinatorTbl.FirstOrDefaultAsync(x => x.CoodinatorId == Id);
        }
        public async Task<CoodinatorModel> GetByUserNameAsync(string UserName)
        {
            return await context.CoodinatorTbl.FirstOrDefaultAsync(x => x.UserName ==UserName);
        }
        public async Task<CoodinatorModel> CheckNameAsync(bool stause,int Rigion)
        {
            return await context.CoodinatorTbl.FirstOrDefaultAsync(x => x.Active == stause && x.RegionId== Rigion);
        }

        public async Task<CoodinatorModel> AddAsync(CoodinatorModel Model)
        {
            var DataModel = await context.CoodinatorTbl.AddAsync(Model);
            await context.SaveChangesAsync();
            return DataModel.Entity;
        }

        public async Task<CoodinatorModel> RemoveAsync(int Id)
        {
            var data = await context.CoodinatorTbl.FirstOrDefaultAsync(x => x.CoodinatorId == Id);
            if (data != null)
            {
                context.CoodinatorTbl.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }
        public async Task<CoodinatorModel> UpdatStatuseAsync(int CoodinatorId,bool statuse)
        {
            var Data = await context.CoodinatorTbl.FirstOrDefaultAsync(x => x.CoodinatorId == CoodinatorId);
            if (Data != null)
            {
                Data.Active = statuse;/// All data must be binded 


                var save = context.CoodinatorTbl.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Data;
        }
        public async Task<CoodinatorModel> UpdatAsync(CoodinatorModel Model)
        {
            var Data = await context.CoodinatorTbl.FirstOrDefaultAsync(x => x.CoodinatorId == Model.CoodinatorId);
            if (Data != null)
            {
                Data.CoodinatorId = Model.CoodinatorId;/// All data must be binded 


                var save = context.CoodinatorTbl.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Model;
        }
    }
}
