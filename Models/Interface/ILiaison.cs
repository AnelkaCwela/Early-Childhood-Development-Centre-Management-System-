using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface ILiaison
    {
        #region TabAsync
        Task<IEnumerable<LiaisonModel>> TabAsync();
        #endregion
        Task<LiaisonModel> GetByUserNameAsync(string User);

        #region GetByIdAsync
        Task<LiaisonModel> GetByIdAsync(int Id);
        #endregion
        #region AddAsync
        Task<LiaisonModel> AddAsync(LiaisonModel Model);
        #endregion
        #region RemoveAsync
        Task<LiaisonModel> RemoveAsync(int Id);
        #endregion
        #region UpdatAsync
        Task<LiaisonModel> UpdatAsync(LiaisonModel Model);
        #endregion
    }
}
