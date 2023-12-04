using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface ISuburb
    {
        #region TabAsync
        Task<IEnumerable<SuburbModel>> TabAsync();
        #endregion
        Task<SuburbModel> GetByRegionIdAsync(int Id);
        #region GetByIdAsync
        Task<SuburbModel> GetByIdAsync(int Id);
        #endregion
        #region AddAsync
        Task<SuburbModel> AddAsync(SuburbModel Model);
        #endregion
        #region RemoveAsync
        Task<SuburbModel> RemoveAsync(int Id);
        #endregion
        #region UpdatAsync
        Task<SuburbModel> UpdatAsync(SuburbModel Model);
        #endregion
    }
}
