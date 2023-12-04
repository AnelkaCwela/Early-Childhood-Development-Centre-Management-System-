using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface ICentreSerViceType
    {
        #region TabAsync
        Task<IEnumerable<CentreSerViceTypeModel>> TabAsync();
        #endregion

        #region GetByIdAsync
        Task<CentreSerViceTypeModel> GetByIdAsync(int Id);
        #endregion
        #region AddAsync
        Task<CentreSerViceTypeModel> AddAsync(CentreSerViceTypeModel Model);
        #endregion
        #region RemoveAsync
        Task<CentreSerViceTypeModel> RemoveAsync(int Id);
        #endregion
        #region UpdatAsync
        Task<CentreSerViceTypeModel> UpdatAsync(CentreSerViceTypeModel Model);
        #endregion
    }
}
