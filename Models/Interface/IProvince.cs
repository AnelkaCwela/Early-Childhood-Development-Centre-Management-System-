using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface IProvince
    {
        #region TabAsync
        Task<IEnumerable<ProvinceModel>> TabAsync();
        #endregion

        #region GetByIdAsync
        Task<ProvinceModel> GetByIdAsync(int Id);
        #endregion
        #region AddAsync
        Task<ProvinceModel> AddAsync(ProvinceModel Model);
        #endregion
        #region RemoveAsync
        Task<ProvinceModel> RemoveAsync(int Id);
        #endregion
        #region UpdatAsync
        Task<ProvinceModel> UpdatAsync(ProvinceModel Model);
        #endregion
    }
}
