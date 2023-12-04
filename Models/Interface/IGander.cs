using System;
using System.Collections.Generic;
using Algorithm_3rd_Year_Project.Models.DataModel;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface IGander
    {
        //GanderModel
        #region TabAsync
        Task<IEnumerable<GanderModel>> TabAsync();

          #endregion

        #region AddAsync
        //GanderModel GetGander(int GanderId);
        Task<GanderModel> AddAsync(GanderModel _Gander);
        #endregion
        //GanderModel RemoveGander(int GanderId);
        //GanderModel UpdatGander(int GanderId);
    }
}
