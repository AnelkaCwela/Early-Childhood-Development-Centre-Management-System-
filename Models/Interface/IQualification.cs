using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface IQualification
    {
        #region TabAsync
        Task<IEnumerable<QualificationModel>> TabAsync();
        #endregion

        #region GetByIdAsync
        Task<QualificationModel> GetByIdAsync(int Id);
        #endregion
        #region AddAsync
        Task<QualificationModel> AddAsync(QualificationModel Model);
        #endregion
        #region RemoveAsync
        Task<QualificationModel> RemoveAsync(int Id);
        #endregion
        #region UpdatAsync
        Task<QualificationModel> UpdatAsync(QualificationModel Model);
        #endregion
    }
}
