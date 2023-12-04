using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    public class QualificationResp: IQualification
    {
        private readonly DBCONTEX context;
        public QualificationResp(DBCONTEX _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<QualificationModel>> TabAsync()
        {
            return await context.QualificationTbl.ToListAsync();
        }

        public async Task<QualificationModel> GetByIdAsync(int Id)
        {
            return await context.QualificationTbl.FirstOrDefaultAsync(x => x.QualificationId == Id);
        }

        public async Task<QualificationModel> AddAsync(QualificationModel Model)
        {
            var DataModel = await context.QualificationTbl.AddAsync(Model);
            await context.SaveChangesAsync();
            return DataModel.Entity;
        }

        public async Task<QualificationModel> RemoveAsync(int Id)
        {
            var data = await context.QualificationTbl.FirstOrDefaultAsync(x => x.QualificationId == Id);
            if (data != null)
            {
                context.QualificationTbl.Remove(data);
                await context.SaveChangesAsync();
            }
            return data;
        }

        public async Task<QualificationModel> UpdatAsync(QualificationModel Model)
        {
            var Data = await context.QualificationTbl.FirstOrDefaultAsync(x => x.QualificationId == Model.QualificationId);
            if (Data != null)
            {
                Data.QualificationName = Model.QualificationName;/// All data must be binded 


                var save = context.QualificationTbl.Attach(Data);
                save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return Model;
        }
    }
}
