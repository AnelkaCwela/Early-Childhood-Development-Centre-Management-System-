using Algorithm_3rd_Year_Project.Models;
using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Resptory
{
    public class GanderResp : IGander
    {
        private readonly DBCONTEX context;
        public GanderResp(DBCONTEX _context)
        {
            context = _context;
        }

        public async Task<GanderModel> AddAsync(GanderModel _Imagel)
        {
             await context.GanderModelTbl.AddAsync(_Imagel);
           await context.SaveChangesAsync();
            return _Imagel;
        }


        public async Task<IEnumerable<GanderModel>> TabAsync()
        {
            return await context.GanderModelTbl.ToListAsync();
        }
    }
}
