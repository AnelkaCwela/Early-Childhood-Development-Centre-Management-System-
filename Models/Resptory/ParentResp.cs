using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    public class ParentResp: IParent
    {
        private readonly DBCONTEX context;
        public ParentResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<ParentModel>> TabAsync()
        {
            return await context.ParentTbl.ToListAsync();
        }
        public async Task<ParentModel> GetByUserNameAsync(string UserName)
        {
            return await context.ParentTbl.FirstOrDefaultAsync(x => x.UserName == UserName);
        }

        public async Task<ParentModel> GetByIdAsync(int Id)
        {
            return await context.ParentTbl.FirstOrDefaultAsync(x => x.ParentId == Id);
        }

        public async Task<ParentModel> AddAsync(ParentModel Model)
        {
            var DataModel = await context.ParentTbl.AddAsync(Model);
            await context.SaveChangesAsync();
            return DataModel.Entity;
        }

        public async Task<ParentModel> RemoveAsync(int Id)
        {
            var data = await context.ParentTbl.FirstOrDefaultAsync(x => x.ParentId == Id);
            if (data != null)
            {
                context.ParentTbl.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<ParentModel> UpdatAsync(ParentModel Model)
        {
            var Data = await context.ParentTbl.FirstOrDefaultAsync(x => x.ParentId== Model.ParentId);
            if (Data != null)
            {
                //Data.UserName = Model.EmailAddress;/// All data must be binded 


                var save = context.ParentTbl.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Model;
        }

    }
}
