using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface ICoodinator
    {
        Task<CoodinatorModel> UpdatStatuseAsync(int CoodinatorId, bool statuse);
        Task<CoodinatorModel> CheckNameAsync(bool stause, int Rigion);
        #region TabAsync
        Task<IEnumerable<CoodinatorModel>> TabAsync();
        #endregion
        Task<CoodinatorModel> GetByUserNameAsync(string UserName);
        #region GetByIdAsync
        Task<CoodinatorModel> GetByIdAsync(int Id);
        #endregion
        #region AddAsync
        Task<CoodinatorModel> AddAsync(CoodinatorModel Model);
        #endregion
        #region RemoveAsync
        Task<CoodinatorModel> RemoveAsync(int Id);
        #endregion
        #region UpdatAsync
        Task<CoodinatorModel> UpdatAsync(CoodinatorModel Model);
        #endregion
    }
}
