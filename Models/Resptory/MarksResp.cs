using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    public class MarksResp: IMarks
    {
        private readonly DBCONTEX context;
        public MarksResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<MarksModel>> TabAsync()
        {
            return await context.MarksTbl.ToListAsync();
        }
        public async Task<IEnumerable<MarksModel>> TabAsync(int pupilId)
        {
            return await context.MarksTbl.Where(p=>p.PupilId==pupilId).ToListAsync();
        }
        public async Task<IEnumerable<MarksModel>> TabPupilIdEnroleIdAsync(int pupilId,int EnroleId)
        {
            return await context.MarksTbl.Where(p => p.PupilId == pupilId&&p.EnroleId== EnroleId).ToListAsync();
        }
        public async Task<MarksModel> GetByIdAsync(int Id)
        {
            return await context.MarksTbl.FirstOrDefaultAsync(x => x.MarksId == Id);
        }

        public async Task<MarksModel> AddAsync(MarksModel Model)
        {
            var DataModel = await context.MarksTbl.AddAsync(Model);
             context.SaveChanges();
            return DataModel.Entity;
        }

        public async Task<MarksModel> RemoveAsync(int Id)
        {
            var data = await context.MarksTbl.FirstOrDefaultAsync(x => x.MarksId == Id);
            if (data != null)
            {
                context.MarksTbl.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<MarksModel> UpdatAsync(MarksModel Model)
        {
            var Data = await context.MarksTbl.FirstOrDefaultAsync(x => x.MarksId == Model.MarksId);
            if (Data != null)
            {
                Data.Mark = Model.Mark;/// All data must be binded 


                var save = context.MarksTbl.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Model;
        }
    }
}
