using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface ITeacher
    {
        #region TabAsync
        Task<IEnumerable<TeacherModel>> TabAsync();
        #endregion
        Task<TeacherModel> GetByUserNameAsync(string UserName);
        Task<IEnumerable<TeacherModel>> TabByCentreAsync(int Id);

        #region GetByIdAsync
        Task<TeacherModel> GetByIdAsync(int Id);
        #endregion
        #region AddAsync
        Task<TeacherModel> AddAsync(TeacherModel Model);
        #endregion
        #region RemoveAsync
        Task<TeacherModel> RemoveAsync(int Id);
        #endregion
        #region UpdatAsync
        Task<TeacherModel> UpdatAsync(TeacherModel Model);
        #endregion
    }
}
