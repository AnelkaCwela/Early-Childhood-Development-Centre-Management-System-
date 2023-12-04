using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithm_3rd_Year_Project.Models.DataModel;
namespace Algorithm_3rd_Year_Project.Models.Interface
{
    public interface IStatus
    {
        #region TabAsync
        Task<IEnumerable<StatusModel>> TabAsync();

#endregion

//        #region GetByIdAsync
//        Task<StatusModel> GetByIdAsync(Guid OderId);
//#endregion

        #region AddAsync
        Task<StatusModel> AddAsync(StatusModel _Oder);
#endregion

//        #region RemoveAsync
//        Task<StatusModel> RemoveAsync(Guid OderId);
//#endregion

        //#region UpdaAsync
        //Task<StatusModel> UpdaAsync(StatusModel OderId);
        //#endregion
    }
}
