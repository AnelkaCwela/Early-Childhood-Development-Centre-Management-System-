using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    public class CentreManageResp: ICentreManage
    {
        private readonly DBCONTEX context;
        public CentreManageResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<CentreManageModel>> TabAsync()
        {
            return await context.CentreManageTbl.ToListAsync();
        }
        public async Task<CentreManageModel> GetByCentreIdAsync(int Id)
        {
            return await context.CentreManageTbl.FirstOrDefaultAsync(x => x.CentreId == Id);
        }
        public async Task<CentreManageModel> GetByIdAsync(int Id)
        {
            return await context.CentreManageTbl.FirstOrDefaultAsync(x => x.CentreManagerId == Id);
        }
        public async Task<CentreManageModel> GetByUserAsync(string UserName)
        {
            return await context.CentreManageTbl.FirstOrDefaultAsync(x => x.UserName == UserName);
        }
        public async Task<CentreManageModel> CheckAsync(bool statuse ,int centreId)
        {
            return await context.CentreManageTbl.FirstOrDefaultAsync(x => x.Active == statuse&&x.CentreId== centreId);
        }

        public async Task<CentreManageModel> AddAsync(CentreManageModel Model)
        {
            var DataModel = await context.CentreManageTbl.AddAsync(Model);
            await context.SaveChangesAsync();
            return DataModel.Entity;
        }

        public async Task<CentreManageModel> RemoveAsync(int Id)
        {
            var data = await context.CentreManageTbl.FirstOrDefaultAsync(x => x.CentreId == Id);
            if (data != null)
            {
                context.CentreManageTbl.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }
        public async Task<CentreManageModel> UpAsync(int CentreId, bool status)
        {
            var Data = await context.CentreManageTbl.FirstOrDefaultAsync(x => x.CentreManagerId == CentreId);
            if (Data != null)
            {
                Data.Active = status;/// All data must be binded 


                var save = context.CentreManageTbl.Attach(Data);
                save.State = EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Data;
        }
        public async Task<CentreManageModel> UpdatAsync(CentreManageModel Model)
        {
            var Data = await context.CentreManageTbl.FirstOrDefaultAsync(x => x.CentreId == Model.CentreId);
            if (Data != null)
            {
                Data.CentreId = Model.CentreId;/// All data must be binded 


                var save = context.CentreManageTbl.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Model;
        }
    }
}
