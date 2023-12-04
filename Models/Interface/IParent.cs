using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface IParent
    {
        #region TabAsync
        Task<IEnumerable<ParentModel>> TabAsync();
        #endregion
        Task<ParentModel> GetByUserNameAsync(string UserName);

        #region GetByIdAsync
        Task<ParentModel> GetByIdAsync(int Id);
        #endregion
        #region AddAsync
        Task<ParentModel> AddAsync(ParentModel Model);
        #endregion
        #region RemoveAsync
        Task<ParentModel> RemoveAsync(int Id);
        #endregion
        #region UpdatAsync
        Task<ParentModel> UpdatAsync(ParentModel Model);
        #endregion
    }
}
