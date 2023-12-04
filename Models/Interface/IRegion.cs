using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface IRegion
    {
        #region TabAsync
        Task<IEnumerable<RegionModel>> TabAsync();
        #endregion
        Task<IEnumerable<RegionModel>> TabProvinceAsync(int Id);

        #region GetByIdAsync
        Task<RegionModel> GetByIdAsync(int Id);
        #endregion
        #region AddAsync
        Task<RegionModel> AddAsync(RegionModel Model);
        #endregion
        #region RemoveAsync
        Task<RegionModel> RemoveAsync(int Id);
        #endregion
        #region UpdatAsync
        Task<RegionModel> UpdatAsync(RegionModel Model);
        #endregion
    }
}
