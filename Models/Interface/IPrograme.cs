using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface IPrograme
    {
        #region TabAsync
        Task<ProgrameOfferdModel> GetByCentreProgramIdAsync(int Id);
        Task<IEnumerable<ProgrameOfferdModel>> TabAsync();
        Task<ProgrameOfferdModel> CheckProgramAsync(int Id, int teacherId);
        #endregion
        Task<IEnumerable<ProgrameOfferdModel>> TabAsync(int TeacherId);
        #region GetByIdAsync
        Task<ProgrameOfferdModel> GetByIdAsync(int Id);
        #endregion
        #region AddAsync
        Task<ProgrameOfferdModel> AddAsync(ProgrameOfferdModel Model);
        #endregion
        #region RemoveAsync
        Task<ProgrameOfferdModel> RemoveAsync(int Id);
        #endregion
        #region UpdatAsync
        Task<ProgrameOfferdModel> UpdatAsync(ProgrameOfferdModel Model);
        #endregion
    }
}
