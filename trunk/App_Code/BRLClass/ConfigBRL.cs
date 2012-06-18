/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/12/2009 11:16:02 AM
------------------------------------------------------*/
using INVI.Entity;
using INVI.DataAccess;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
namespace INVI.Business
{
    public class ConfigBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Config Này";
		private static string EX_SNAME_EMPTY="sName không được để trống";
		private static string EX_SVALUE_EMPTY="sValue không được để trống";
		private static string EX_ID_INVALID="iConfigID không hợp lệ";
        private static string EX_IDCONFIG_NOTFOUND = "Không tìm thấy config này";
        private static string EX_CONFIG_EXISTED="Config này đã tồn tại";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Config Theo ID
        /// </summary>
        /// <param name="iConfigID">Int32:Config ID</param>
        /// <returns>ConfigEntity</returns>        
        public static ConfigEntity GetOne(Int32 iConfigID)
        {
            
			if(iConfigID<=0)
				throw new Exception(EX_ID_INVALID);
            return ConfigDAL.GetOne(iConfigID);
        }
        /// <summary>
        /// Lấy về List các Config
        /// </summary>
        /// <returns>List ConfigEntity:List Config Cần lấy</returns>
        public static List<ConfigEntity> GetAll()
        {
            return ConfigDAL.GetAll();
        }
        /// <summary>
        /// Kiểm tra và thêm mới Config
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Config Mới Thêm Vào</returns>
        public static Int32 Add(ConfigEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, true);
            //checkFK(entity);
            return ConfigDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Config
        /// </summary>
        /// <param name="entity">ConfigEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(ConfigEntity entity)
        {
            checkExist(entity);
            checkLogic(entity);
            checkDuplicate(entity, false);
            //checkFK(entity);
            return ConfigDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Config
        /// </summary>
        /// <param name="entity">ConfigEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(ConfigEntity entity)
        {
            checkExist(entity);
            
            return ConfigDAL.Remove(entity.iConfigID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(ConfigEntity entity)
        {
            ConfigEntity oConfig=ConfigDAL.GetOne(entity.iConfigID);
            if(oConfig==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">ConfigEntity: entity</param>
        private static void checkLogic(ConfigEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sName))
				throw new Exception(EX_SNAME_EMPTY);
			if (String.IsNullOrEmpty(entity.sValue))
				throw new Exception(EX_SVALUE_EMPTY);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">ConfigEntity: ConfigEntity</param>
        private static void checkDuplicate(ConfigEntity entity,bool CheckInsert)
        {
             
            List<ConfigEntity> list = ConfigDAL.GetAll();
            if (list.Exists(
                delegate(ConfigEntity oldEntity)
                {
                    bool result =oldEntity.sName.Equals(entity.sName, StringComparison.OrdinalIgnoreCase);
                    if(!CheckInsert)
                        result=result && oldEntity.iConfigID != entity.iConfigID;
                    return result;
                }
            ))
            {
                list.Clear();
                throw new Exception(EX_CONFIG_EXISTED);
            }
            
        }
        /// <summary>
        /// Kiểm tra tồn tại khóa ngoại
        /// </summary>
        /// <param name="entity">ConfigEntity:entity</param>
        private static void checkFK(ConfigEntity entity)
        {
            ConfigEntity oConfig = ConfigDAL.GetOne(entity.iConfigID);
            if (oConfig == null)
            {
                throw new Exception(EX_IDCONFIG_NOTFOUND);
            }
        }
        #endregion
    }
}
