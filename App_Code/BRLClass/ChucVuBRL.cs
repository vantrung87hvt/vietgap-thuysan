/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/2/2011 4:41:55 PM
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
    public class ChucVuBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại ChucVu Này";
		private static string EX_ID_INVALID="PK_iChucVuID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get ChucVu Theo ID
        /// </summary>
        /// <param name="PK_iChucVuID">int:ChucVu ID</param>
        /// <returns>ChucVuEntity</returns>        
        public static ChucVuEntity GetOne(int PK_iChucVuID)
        {
            
			if(PK_iChucVuID<=0)
				throw new Exception(EX_ID_INVALID);
            return ChucVuDAL.GetOne(PK_iChucVuID);
        }
        /// <summary>
        /// Lấy về List các ChucVu
        /// </summary>
        /// <returns>List ChucVuEntity:List ChucVu Cần lấy</returns>
        public static List<ChucVuEntity> GetAll()
        {
            return ChucVuDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới ChucVu
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của ChucVu Mới Thêm Vào</returns>
        public static Int32 Add(ChucVuEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return ChucVuDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa ChucVu
        /// </summary>
        /// <param name="entity">ChucVuEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(ChucVuEntity entity)
        {
            checkExist(entity.PK_iChucVuID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return ChucVuDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá ChucVu
        /// </summary>
        /// <param name="PK_iChucVuID">int : PK_iChucVuID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(int PK_iChucVuID)
        {
            checkExist(PK_iChucVuID);
            return ChucVuDAL.Remove(PK_iChucVuID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(int PK_iChucVuID)
        {
            ChucVuEntity oChucVu=ChucVuDAL.GetOne(PK_iChucVuID);
            if(oChucVu==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">ChucVuEntity: entity</param>
        private static void checkLogic(ChucVuEntity entity)
        {   
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">ChucVuEntity: ChucVuEntity</param>
        private static void checkDuplicate(ChucVuEntity entity,bool checkPK)
        {
            /* 
            Example
            List<ChucVuEntity> list = ChucVuDAL.GetAll();
            if (list.Exists(
                delegate(ChucVuEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iChucVuID != entity.PK_iChucVuID;
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
        /// <param name="entity">ChucVuEntity:entity</param>
        private static void checkFK(ChucVuEntity entity)
        {            
        }
        #endregion
    }
}
