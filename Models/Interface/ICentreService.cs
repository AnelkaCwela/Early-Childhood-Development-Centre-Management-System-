using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface ICentreService
    {
        #region TabAsync
        Task<IEnumerable<CentreServiceModel>> TabAsync();
        #endregion

        #region GetByIdAsync
        Task<CentreServiceModel> GetByIdAsync(int Id);
        #endregion
        #region AddAsync
        Task<CentreServiceModel> AddAsync(CentreServiceModel Model);
        #endregion
        #region RemoveAsync
        Task<CentreServiceModel> RemoveAsync(int Id);
        #endregion
        #region UpdatAsync
        Task<CentreServiceModel> UpdatAsync(CentreServiceModel Model);
        #endregion
    }
}
