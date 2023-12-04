using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface IEnrole
    {
        #region TabAsync
        Task<IEnumerable<EnroleModel>> TabAsync();
        #endregion
        Task<IEnumerable<EnroleModel>> TabEnrolByProgramAsync(int i);
        Task<IEnumerable<EnroleModel>> TabEnrolByPupilAsync(int i);
        Task<EnroleModel> GetByOferProgramAsync(int Id);

        #region GetByIdAsync
        Task<EnroleModel> GetByIdAsync(int Id);
        #endregion
        #region AddAsync
        Task<EnroleModel> AddAsync(EnroleModel Model);
        #endregion
        #region RemoveAsync
        Task<EnroleModel> RemoveAsync(int Id);
        #endregion
        #region UpdatAsync
        Task<EnroleModel> UpdatAsync(EnroleModel Model);
        #endregion
    }
}
