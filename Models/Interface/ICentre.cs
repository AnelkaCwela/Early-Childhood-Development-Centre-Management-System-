using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface ICentre
    {
        #region TabAsync
        Task<IEnumerable<CentreModel>> TabAsync();
        #endregion
        Task<IEnumerable<CentreModel>> TabSubAsync(int Id);

        #region GetByIdAsync
        Task<CentreModel> GetByIdAsync(int Id);
        #endregion
        #region AddAsync
        Task<CentreModel> AddAsync(CentreModel Model);
        #endregion
        #region RemoveAsync
        Task<CentreModel> RemoveAsync(int Id);
        #endregion
        #region UpdatAsync
        Task<CentreModel> UpdatAsync(CentreModel Model);
        //Task<IEnumerable> TabByCentreAsync(int centreId);
        #endregion
    }
}
