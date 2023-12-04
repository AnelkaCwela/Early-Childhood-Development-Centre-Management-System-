using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface IPupil
    {
        #region TabAsync
        Task<IEnumerable<PupilModel>> TabAsync();
        #endregion
        Task<IEnumerable<PupilModel>> TabByCentreIdAsync(int Id);
        Task<PupilModel> AceptDeclineAsync(int Id);
        Task<IEnumerable<PupilModel>> TabByParentIdAsync(int Id, int St);
        Task<IEnumerable<PupilModel>> TabByParentIdAsync(int Id);
        Task<PupilModel> UpdatStatuseAsync(int Id, int StatuseId);

        #region GetByIdAsync
        Task<PupilModel> GetByIdAsync(int Id);
        #endregion
        #region AddAsync
        Task<PupilModel> AddAsync(PupilModel Model);
        #endregion
        #region RemoveAsync
        Task<PupilModel> RemoveAsync(int Id);
        #endregion
        #region UpdatAsync
        Task<PupilModel> UpdatAsync(PupilModel Model);
        #endregion
    }
}
