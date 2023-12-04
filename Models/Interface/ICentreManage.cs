using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface ICentreManage
    {
        Task<CentreManageModel> UpAsync(int CentreId, bool status);
        Task<CentreManageModel> CheckAsync(bool statuse, int centreId);
        #region TabAsync
        Task<IEnumerable<CentreManageModel>> TabAsync();
        #endregion
        Task<CentreManageModel> GetByCentreIdAsync(int Id);
        Task<CentreManageModel> GetByUserAsync(string UserName);
        #region GetByIdAsync
        Task<CentreManageModel> GetByIdAsync(int Id);
        #endregion
        #region AddAsync
        Task<CentreManageModel> AddAsync(CentreManageModel Model);
        #endregion
        #region RemoveAsync
        Task<CentreManageModel> RemoveAsync(int Id);
        #endregion
        #region UpdatAsync
        Task<CentreManageModel> UpdatAsync(CentreManageModel Model);
        #endregion
    }
}
