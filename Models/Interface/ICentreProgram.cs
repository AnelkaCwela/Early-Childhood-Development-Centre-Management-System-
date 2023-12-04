using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface ICentreProgram
    {
        #region TabAsync
        Task<IEnumerable<CentreProgramModel>> TabAsync();
        #endregion
        Task<IEnumerable<CentreProgramModel>> TabByCentreAsync(int Id);

        #region GetByIdAsync
        Task<CentreProgramModel> GetByIdAsync(int Id);
        #endregion
        #region AddAsync
        Task<CentreProgramModel> AddAsync(CentreProgramModel Model);
        #endregion
        #region RemoveAsync
        Task<CentreProgramModel> RemoveAsync(int Id);
        #endregion
        #region UpdatAsync
        Task<CentreProgramModel> UpdatAsync(CentreProgramModel Model);
        #endregion
    }
}
