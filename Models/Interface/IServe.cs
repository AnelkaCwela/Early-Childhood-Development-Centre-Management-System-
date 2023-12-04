using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface IServe
    {
        #region TabAsync
        Task<IEnumerable<ServeModel>> TabAsync();
        #endregion

        #region GetByIdAsync
        Task<ServeModel> GetByIdAsync(int Id);
        #endregion
        #region AddAsync
        Task<ServeModel> AddAsync(ServeModel Model);
        #endregion
        #region RemoveAsync
        Task<ServeModel> RemoveAsync(int Id);
        #endregion
        #region UpdatAsync
        Task<ServeModel> UpdatAsync(ServeModel Model);
        #endregion
    }
}
