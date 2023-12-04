using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    public class PupilResp: IPupil
    {
        private readonly DBCONTEX context;
        public PupilResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<PupilModel>> TabAsync()
        {
            return await context.PupilTbl.ToListAsync();
        }
        //public async Task<IEnumerable<PupilModel>> TabByEnroleIdAsync(int Id)
        //{
        //    return await context.PupilTbl.Where(p => p. == Id).ToListAsync();
        //}
        public async Task<IEnumerable<PupilModel>> TabByParentIdAsync(int Id)
        {
            return await context.PupilTbl.Where(p => p.ParentId == Id).ToListAsync();
        }
        public async Task<IEnumerable<PupilModel>> TabByCentreIdAsync(int Id)
        {
            return await context.PupilTbl.Where(p => p.CentreId == Id).ToListAsync();
        }
        public async Task<IEnumerable<PupilModel>> TabByParentIdAsync(int Id,int St)
        {
           var Data= await context.PupilTbl.Where(p => p.ParentId == Id).ToListAsync();
            return Data.Where(p => p.StatusId == St);
        }

        public async Task<PupilModel> GetByIdAsync(int Id)
        {
            return await context.PupilTbl.FirstOrDefaultAsync(x => x.PupilId == Id);
        }

        public async Task<PupilModel> AddAsync(PupilModel Model)
        {
            var DataModel = await context.PupilTbl.AddAsync(Model);
            await context.SaveChangesAsync();
            return DataModel.Entity;
        }

        public async Task<PupilModel> RemoveAsync(int Id)
        {
            var data = await context.PupilTbl.FirstOrDefaultAsync(x => x.PupilId == Id);
            if (data != null)
            {
                context.PupilTbl.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }
        public async Task<PupilModel> AceptDeclineAsync(int Id)
        {
            var Data = await context.PupilTbl.FirstOrDefaultAsync(x => x.PupilId == Id);
            if (Data != null)
            {
                Data.StatusId = Id; 


                var save = context.PupilTbl.Attach(Data);
                save.State = EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Data;
        }
        public async Task<PupilModel> UpdatStatuseAsync(int Id,int StatuseId)
        {
            var Data = await context.PupilTbl.FirstOrDefaultAsync(x => x.PupilId == Id);
            if (Data != null)
            {
                Data.StatusId = StatuseId;/// All data must be binded 


                var save = context.PupilTbl.Attach(Data);
                save.State = EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Data;
        }
        public async Task<PupilModel> UpdatAsync(PupilModel Model)
        {
            var Data = await context.PupilTbl.FirstOrDefaultAsync(x => x.PupilId == Model.PupilId);
            if (Data != null)
            {
                Data.Lname = Model.Lname;/// All data must be binded 


                var save = context.PupilTbl.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Model;
        }
    }
}
