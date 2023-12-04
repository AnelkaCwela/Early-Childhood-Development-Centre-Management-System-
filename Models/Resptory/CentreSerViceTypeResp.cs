using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    public class CentreSerViceTypeResp: ICentreSerViceType
    {
        private readonly DBCONTEX context;
        public CentreSerViceTypeResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<CentreSerViceTypeModel>> TabAsync()
        {
            return await context.CentreSerViceTypeTbl.ToListAsync();
        }

        public async Task<CentreSerViceTypeModel> GetByIdAsync(int Id)
        {
            return await context.CentreSerViceTypeTbl.FirstOrDefaultAsync(x => x.CentreServiceTypeId == Id);
        }

        public async Task<CentreSerViceTypeModel> AddAsync(CentreSerViceTypeModel Model)
        {
            var DataModel = await context.CentreSerViceTypeTbl.AddAsync(Model);
            await context.SaveChangesAsync();
            return DataModel.Entity;
        }

        public async Task<CentreSerViceTypeModel> RemoveAsync(int Id)
        {
            var data = await context.CentreSerViceTypeTbl.FirstOrDefaultAsync(x => x.CentreServiceTypeId == Id);
            if (data != null)
            {
                context.CentreSerViceTypeTbl.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<CentreSerViceTypeModel> UpdatAsync(CentreSerViceTypeModel Model)
        {
            var Data = await context.CentreSerViceTypeTbl.FirstOrDefaultAsync(x => x.CentreServiceTypeId == Model.CentreServiceTypeId);
            if (Data != null)
            {
                Data.ServiceType = Model.ServiceType;/// All data must be binded 


                var save = context.CentreSerViceTypeTbl.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Model;
        }
    }
}
