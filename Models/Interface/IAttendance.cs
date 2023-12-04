using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface IAttendance
    {
        #region TabAsync
        Task<IEnumerable<AttendanceModel>> TabAsync();
        #endregion
        Task<IEnumerable<AttendanceModel>> TabAsync(int Pupip);
        Task<IEnumerable<AttendanceModel>> TabAEnrolePupilsync(int EnroleId, int Pupip);

        #region GetByIdAsync
        Task<AttendanceModel> GetByIdAsync(int Id);
        #endregion
        #region AddAsync
        Task<AttendanceModel> AddAsync(AttendanceModel Model);
        #endregion
        #region RemoveAsync
        Task<AttendanceModel> RemoveAsync(int Id);
        #endregion
        #region UpdatAsync
        Task<AttendanceModel> UpdatAsync(AttendanceModel Model);
        #endregion
    }
}
