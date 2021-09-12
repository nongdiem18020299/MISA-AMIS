using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MISA.Core.Const;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infranstructure;
using MISA.Core.Interfaces.Service;
using MISA.Core.Interfaces.Validate;

namespace MISA.Core.Services
{
    public class BaseService<Entity>:IBaseService<Entity>
    {
        #region Field
        public ServiceResult ServiceResult;
        IBaseValidate<Entity> _baseValidate;
        IBaseRepository<Entity> _baseRepo;
        #endregion
        #region Constructor
        public BaseService(IBaseValidate<Entity> baseValidate, IBaseRepository<Entity> baseRepo)
        {
            ServiceResult = new ServiceResult();
            _baseValidate = baseValidate;
            _baseRepo = baseRepo;
        }
        #endregion
        #region Method
        #region ADD        
        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Thông tin thêm mới</param>
        /// <returns>Kết quả thêm mới</returns>
        /// CreateBy: NTDIEM (16/08/2021)
        public ServiceResult Add(Entity entity)
        {
            //Kiểm tra mã có bị trống không?
            var className = typeof(Entity).Name;
            var entityCode = entity.GetType().GetProperty($"{className}Code").GetValue(entity, null).ToString();
            //Kiểm tra các trường bắt buộc có bị trống không?
            if (!CheckNullRequired(entity).Success)
            {
                return CheckNullRequired(entity);
            }
            // Kiểm tra email
            if (!CheckEmail(entity).Success)
            {
                return CheckEmail(entity);
            }
            //Kiểm tra số điện thoại
            if (!CheckPhoneNumber(entity).Success)
            {
                return CheckPhoneNumber(entity);
            }
            //TODO: mã trả về 200? Success là true hay false
            //Kiểm tra trùng mã
            if (_baseValidate.CheckCodeDublicate(entity))
            {
                ServiceResult.Success = false;
                ServiceResult.UserMsg = Resources.ValidateError_EmployeeCodeExist;
                ServiceResult.ErrorCode = MISAConst.MISACodeGetSuccess;
                ServiceResult.Data = $"{entity}Code";
                return ServiceResult;
            }
            ServiceResult.UserMsg = Resources.Status_PostSuccess;
            ServiceResult.Data = _baseRepo.Add(entity);
            return ServiceResult;
        }
        #endregion
        #region PUT
        /// <summary>
        /// Sửa thông tin
        /// </summary>
        /// <param name="entity">Thông tin</param>
        /// <param name="id">Id entity</param>
        /// <returns>Kết quả sửa</returns>
        /// CreateBy: NTDIEM (16/08/2021)
        public ServiceResult Put(Entity entity, Guid id)
        {
            var className = typeof(Entity).Name;
            var entityCode = entity.GetType().GetProperty($"{className}Code").GetValue(entity, null).ToString();
            //Kiểm tra các trường bắt buộc có bị trống không?
            if (!CheckNullRequired(entity).Success)
            {
                return CheckNullRequired(entity);
            }
            // Kiểm tra email
            if (!CheckEmail(entity).Success)
            {
                return CheckEmail(entity);
            }
            //Kiểm tra số điện thoại
            if (!CheckPhoneNumber(entity).Success)
            {
                return CheckPhoneNumber(entity);
            }
            //Kiểm tra trùng mã nhân viên
            if (_baseValidate.CheckDublicateCodePut(entityCode, id))
            {
                ServiceResult.Success = false;
                ServiceResult.UserMsg = Resources.ValidateError_EmployeeCodeExist;
                ServiceResult.ErrorCode = MISAConst.MISACodeGetSuccess;
                ServiceResult.Data = $"{entity}Code";
                return ServiceResult;
            }
            ServiceResult.UserMsg = Resources.Status_PutSuccess;
            ServiceResult.Data = _baseRepo.Put(entity);
            return ServiceResult;

        }
        #endregion
        #region DELETE
        /// <summary>
        /// Xóa thông tin
        /// </summary>
        /// <param name="id">entityId</param>
        /// <returns>Kết quả xóa</returns>
        /// CreateBy: NTDIEM (16/08/2021)
        public ServiceResult Delete(Guid id)
        {
            var entity = _baseRepo.GetById(id);
            //Kiểm tra id cần xóa có ở trong db không
            if (entity == null)
            {
                ServiceResult.ErrorCode = MISAConst.MISACodeNoContent;
            }
            else
            {
                if (_baseValidate.CheckCodeDublicate(entity))
                {
                    ServiceResult.UserMsg = Resources.Status_DeleteSuccess;
                    ServiceResult.ErrorCode = MISAConst.MISACodeGetSuccess;
                    ServiceResult.Data = _baseRepo.Delete(id);
                }
                else
                {
                    ServiceResult.ErrorCode = MISAConst.MISACodeNoContent;
                }
            }
            return ServiceResult;
        }

        #endregion
        #region Error Exception
        /// <summary>
        /// Trả về lỗi exception
        /// </summary>
        /// <param name="e">exception</param>
        /// <returns>Lỗi trả về</returns>
        /// CreateBy: NTDIEM (16/08/2021)
        public ServiceResult ErrorException(Exception e)
        {
            ServiceResult.Success = false;
            ServiceResult.ErrorCode = MISAConst.MISACodeErrorException;
            ServiceResult.DevMsg = e.Message;
            ServiceResult.UserMsg = Resources.ValidateError_Exception;
            return ServiceResult;
        }
        #endregion

        #region Validate
        /// <summary>
        /// Kiểm tra các trường bắt buộc có bị trống không
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns>Kết quả kiểm tra bỏ trống các trường bắt buộc</returns>
        /// Create:NTDIEM (/8/08/2021)
        public ServiceResult CheckNullRequired(Entity entity)
        {
            var properties = entity.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var propRequires = prop.GetCustomAttributes(typeof(MISARequired), true);
                if (propRequires.Length > 0)
                {
                    string propValue = prop.GetValue(entity).ToString();
                    var propType = prop.PropertyType.ToString();
                    if (string.IsNullOrEmpty(propValue))
                    {
                        ServiceResult.Success = false;
                        ServiceResult.UserMsg = $"{prop.Name}" + " không được để trống";
                        ServiceResult.ErrorCode = MISAConst.MISACodeGetSuccess;
                        ServiceResult.Data = $"{prop.Name}";
                    }
                }
            }
            return ServiceResult;
        }

        /// <summary>
        /// Kiểm tra định dạng Email
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns>Kết quả kiểm tra định dạng Email</returns>
        /// Create:NTDIEM (16/08/2021)
        public ServiceResult CheckEmail(Entity entity)
        {
            var properties = entity.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var propRequires = prop.GetCustomAttributes(typeof(MISAEmail), true);
                var propValue = prop.GetValue(entity);

                if (propRequires.Length > 0)
                {
                    try
                    {
                        if (propValue != null)
                        {
                            MailAddress m = new MailAddress((string)propValue);
                        }
                    }
                    catch (FormatException)
                    {
                        ServiceResult.Success = false;
                        ServiceResult.UserMsg = Resources.ValidateError_IsNotEmail;
                        ServiceResult.ErrorCode = MISAConst.MISACodeGetSuccess;
                        ServiceResult.Data = $"{prop.Name}";
                    }

                }
            }
            return ServiceResult;
        }

        /// <summary>
        /// Kiểm tra định dạng số điện thoại
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns>Kết quả kiểrm tra định dạng số điện thoại</returns>
        /// Create:NTDIEM(16/08/2021)
        public ServiceResult CheckPhoneNumber(Entity entity)
        {
            var properties = entity.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var propRequires = prop.GetCustomAttributes(typeof(MISAPhoneNumber), true);
                var propValue = prop.GetValue(entity);

                if (propRequires.Length > 0)
                {
                    if(propValue != null)
                    {
                        var isPhoneNumber = Regex.Match((string)propValue, @"^(84|03|05|07|08|09)+([0-9]{8})$").Success;
                        if (!isPhoneNumber)
                        {
                            ServiceResult.Success = false;
                            ServiceResult.UserMsg = Resources.ValidateError_IsNotPhoneNumber;
                            ServiceResult.ErrorCode = MISAConst.MISACodeGetSuccess;
                            ServiceResult.Data = $"{prop.Name}";
                        }
                    }
                }
            }
            return ServiceResult;
        }
        #endregion
        #endregion
    }
}
