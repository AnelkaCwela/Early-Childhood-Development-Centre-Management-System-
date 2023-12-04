using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface ITask
    {
        #region TabAsync
        Task<IEnumerable<TaskModel>> TabAsync();
        #endregion
        Task<IEnumerable<TaskModel>> TabByCentreIdAsync(int CentreId);
        #region GetByIdAsync
        Task<TaskModel> GetByIdAsync(int Id);
        #endregion
        #region AddAsync
        Task<TaskModel> AddAsync(TaskModel Model);
        #endregion
        #region RemoveAsync
        Task<TaskModel> RemoveAsync(int Id);
        #endregion
        #region UpdatAsync
        Task<TaskModel> UpdatAsync(TaskModel Model);
        #endregion
    }
}
