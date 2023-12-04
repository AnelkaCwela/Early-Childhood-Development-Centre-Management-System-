using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface IMarks
    {
        #region TabAsync
        Task<IEnumerable<MarksModel>> TabAsync();
        #endregion
        Task<IEnumerable<MarksModel>> TabPupilIdEnroleIdAsync(int pupilId, int EnroleId);
        Task<IEnumerable<MarksModel>> TabAsync(int pupilId);

        #region GetByIdAsync
        Task<MarksModel> GetByIdAsync(int Id);
        #endregion
        #region AddAsync
        Task<MarksModel> AddAsync(MarksModel Model);
        #endregion
        #region RemoveAsync
        Task<MarksModel> RemoveAsync(int Id);
        #endregion
        #region UpdatAsync
        Task<MarksModel> UpdatAsync(MarksModel Model);
        #endregion
    }
}
