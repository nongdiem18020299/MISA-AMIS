using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Dapper;
using System.Data;
using MISA.Core.Interfaces.Infranstructure;

namespace MISA.Infractructure
{
    public class BaseRepository<MISAEntity>:IBaseRepository<MISAEntity> where MISAEntity : class
    {
        #region Field
        protected IDbConnection DbConnection;
        readonly IConfiguration _configuration;
        //private readonly string _connectionString = "Host=47.241.69.179;Port=3306;Database=MF876_NTDIEM_CukCuk;User Id=dev;Password= 12345678";
        #endregion

        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            DbConnection = new MySqlConnection(_configuration.GetConnectionString("MISA-AMISConnectionString"));
        }
        #endregion

        #region Method
        #region GET
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <returns>Dữ liệu</returns>
        /// CreateBy: NTDIEM (16/08/2021)
        public List<MISAEntity> GetAll()
        {
            var className = typeof(MISAEntity).Name;
            var entities = DbConnection.Query<MISAEntity>($"Proc_Get{className}s", commandType: CommandType.StoredProcedure).ToList();
            return entities;
        }

        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <param name="entityId">entityId</param>
        /// <returns>Dữ liệu theo Id truyền vào</returns>
        /// CreateBy: NTDIEM (16/08/2021)
        public MISAEntity GetById(Guid entityId)
        {
            var className = typeof(MISAEntity).Name;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@{className}Id", entityId);
            var entity = DbConnection.QueryFirstOrDefault<MISAEntity>($"Proc_Get{className}ById", parameters, commandType: CommandType.StoredProcedure);
            return entity;
        }
        #endregion
        #region DELETE
        /// <summary>
        /// Xóa dữ liệu theo id
        /// </summary>
        /// <param name="id">EntityId</param>
        /// <returns>Thông báo xóa thành công hay không</returns>
        /// CreateBy: NTDIEM(16/08/2021)
        public int Delete(Guid entityId)
        {
            var className = typeof(MISAEntity).Name;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@{className}Id", entityId);
            var res = DbConnection.Execute($"Proc_Delete{className}ById", parameters, commandType: CommandType.StoredProcedure);
            return (int)res;
        }
        #endregion
        #region PUT
        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="misaEntity">emtity</param>
        /// <returns>Số lượng dòng trong db bị ảnh hưởng</returns>
        /// CreateBy: NTDIEM (16/08/2021)
        public int Put(MISAEntity misaEntity)
        {
            DynamicParameters parameters = new DynamicParameters();
            var className = typeof(MISAEntity).Name;
            parameters.AddDynamicParams(misaEntity);
            var res = DbConnection.Execute($"Proc_Update{className}", parameters, commandType: CommandType.StoredProcedure);
            return (int)res;
        }
        #endregion
        #region POST
        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="misaEntity">entity</param>
        /// <returns>Số lượng dòng trong db bị ảnh hưởng</returns>
        /// CreateBy: NTDIEM (16/08/2021)
        public int Add(MISAEntity misaEntity)
        {
            DynamicParameters parameters = new DynamicParameters();
            var className = typeof(MISAEntity).Name;
            parameters.AddDynamicParams(misaEntity);
            var res = DbConnection.Execute($"Proc_Insert{className}", parameters, commandType: CommandType.StoredProcedure);
            return (int)res;
        }
        #endregion
        #endregion
    }
}
