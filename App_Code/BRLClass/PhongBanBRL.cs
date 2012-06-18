/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/2/2011 4:41:53 PM
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
    public class PhongBanBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại PhongBan Này";
		private static string EX_ID_INVALID="PK_iPhongBanID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get PhongBan Theo ID
        /// </summary>
        /// <param name="PK_iPhongBanID">int:PhongBan ID</param>
        /// <returns>PhongBanEntity</returns>        
        public static PhongBanEntity GetOne(int PK_iPhongBanID)
        {
            
			if(PK_iPhongBanID<=0)
				throw new Exception(EX_ID_INVALID);
            return PhongBanDAL.GetOne(PK_iPhongBanID);
        }
        /// <summary>
        /// Lấy về List các PhongBan
        /// </summary>
        /// <returns>List PhongBanEntity:List PhongBan Cần lấy</returns>
        public static List<PhongBanEntity> GetAll()
        {
            return PhongBanDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới PhongBan
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của PhongBan Mới Thêm Vào</returns>
        public static Int32 Add(PhongBanEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return PhongBanDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa PhongBan
        /// </summary>
        /// <param name="entity">PhongBanEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(PhongBanEntity entity)
        {
            checkExist(entity.PK_iPhongBanID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return PhongBanDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá PhongBan
        /// </summary>
        /// <param name="PK_iPhongBanID">int : PK_iPhongBanID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(int PK_iPhongBanID)
        {
            checkExist(PK_iPhongBanID);
            return PhongBanDAL.Remove(PK_iPhongBanID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(int PK_iPhongBanID)
        {
            PhongBanEntity oPhongBan=PhongBanDAL.GetOne(PK_iPhongBanID);
            if(oPhongBan==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">PhongBanEntity: entity</param>
        private static void checkLogic(PhongBanEntity entity)
        {   
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">PhongBanEntity: PhongBanEntity</param>
        private static void checkDuplicate(PhongBanEntity entity,bool checkPK)
        {
            /* 
            Example
            List<PhongBanEntity> list = PhongBanDAL.GetAll();
            if (list.Exists(
                delegate(PhongBanEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iPhongBanID != entity.PK_iPhongBanID;
                    return result;
                }
            ))
            {
                list.Clear();
                throw new Exception(EX_FIELD_EXISTED);
            }
            */
        }
        /// <summary>
        /// Kiểm tra tồn tại khóa ngoại
        /// </summary>
        /// <param name="entity">PhongBanEntity:entity</param>
        private static void checkFK(PhongBanEntity entity)
        {            
        }
        #endregion
    }
}
