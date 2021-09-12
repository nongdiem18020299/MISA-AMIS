using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Infranstructure
{
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <returns>Tất cả dữ liệu</returns>
        /// CreateBy: NTDIEM (16/08/2021)
        List<MISAEntity> GetAll();

        /// <summary>
        /// Lấy dữ liệu bằng id
        /// </summary>
        /// <param name="entityId">entityID</param>
        /// <returns>Dữ liệu lấy theo Id</returns>
        /// CreateBy: NTDIEM (16/08/2021)
        MISAEntity GetById(Guid entityId);

        /// <summary>
        /// Xóa dữ liệu 
        /// </summary>
        /// <param name="entityId">entityId</param>
        /// <returns>Kết quả xóa</returns>
        /// CreateBy: NTDIEM (16/08/2021)
        int Delete(Guid entityId);

        /// <summary>
        /// Sửa thông tin
        /// </summary>
        /// <param name="misaEntity">entity</param>
        /// <returns>Kết quả sửa</returns>
        /// CreateBy: NTDIEM (16/08/2021)
        int Put(MISAEntity misaEntity);

        /// <summary>
        /// Thêm thông tin
        /// </summary>
        /// <param name="misaEntity">entity</param>
        /// <returns>Kết quả thêm mới</returns>
        /// CreateBy: NTDIEM (16/08/2021)
        int Add(MISAEntity misaEntity);
    }
}
