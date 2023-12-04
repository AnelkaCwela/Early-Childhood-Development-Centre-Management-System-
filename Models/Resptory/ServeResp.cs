using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    //public class ServeResp: IServe
    //{
    //    private readonly DBCONTEX context;
    //    public ServeResp(DBCONTEX _context)
    //    {
    //        context = _context;
    //    }
    //    public async Task<IEnumerable<ServeModel>> TabAsync()
    //    {
    //        return await context.ServeTbl.ToListAsync();
    //    }

    //    public async Task<ServeModel> GetByIdAsync(int Id)
    //    {
    //        return await context.ServeTbl.FirstOrDefaultAsync(x => x.ServeId == Id);
    //    }

    //    public async Task<ServeModel> AddAsync(ServeModel Model)
    //    {
    //        var DataModel = await context.ServeTbl.AddAsync(Model);
    //        await context.SaveChangesAsync();
    //        return DataModel.Entity;
    //    }

    //    public async Task<ServeModel> RemoveAsync(int Id)
    //    {
    //        var data = await context.ServeTbl.FirstOrDefaultAsync(x => x.ServeId == Id);
    //        if (data != null)
    //        {
    //            context.ServeTbl.Remove(data);
    //            await context.SaveChangesAsync();
    //        }
    //        return data;
    //    }

    //    public async Task<ServeModel> UpdatAsync(ServeModel Model)
    //    {
    //        var Data = await context.ServeTbl.FirstOrDefaultAsync(x => x.ServeId == Model.ServeId);
    //        if (Data != null)
    //        {
    //            Data.serveDate = Model.serveDate;/// All data must be binded 


    //            var save = context.ServeTbl.Attach(Data);
    //            save.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    //            await context.SaveChangesAsync();

    //        }
    //        return Model;
    //    }
    //}
}
