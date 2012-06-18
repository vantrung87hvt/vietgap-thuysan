/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/15/2011 9:16:57 PM
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
    public class PhuongphapkiemtraBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Phuongphapkiemtra Này";
		private static string EX_ID_INVALID="PK_iPhuongphapkiemtraID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Phuongphapkiemtra Theo ID
        /// </summary>
        /// <param name="PK_iPhuongphapkiemtraID">Int32:Phuongphapkiemtra ID</param>
        /// <returns>PhuongphapkiemtraEntity</returns>        
        public static PhuongphapkiemtraEntity GetOne(Int32 PK_iPhuongphapkiemtraID)
        {
            
			if(PK_iPhuongphapkiemtraID<=0)
				throw new Exception(EX_ID_INVALID);
            return PhuongphapkiemtraDAL.GetOne(PK_iPhuongphapkiemtraID);
        }
        /// <summary>
        /// Lấy về List các Phuongphapkiemtra
        /// </summary>
        /// <returns>List PhuongphapkiemtraEntity:List Phuongphapkiemtra Cần lấy</returns>
        public static List<PhuongphapkiemtraEntity> GetAll()
        {
            return PhuongphapkiemtraDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới Phuongphapkiemtra
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Phuongphapkiemtra Mới Thêm Vào</returns>
        public static Int32 Add(PhuongphapkiemtraEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return PhuongphapkiemtraDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Phuongphapkiemtra
        /// </summary>
        /// <param name="entity">PhuongphapkiemtraEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(PhuongphapkiemtraEntity entity)
        {
            checkExist(entity.PK_iPhuongphapkiemtraID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return PhuongphapkiemtraDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Phuongphapkiemtra
        /// </summary>
        /// <param name="PK_iPhuongphapkiemtraID">Int32 : PK_iPhuongphapkiemtraID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iPhuongphapkiemtraID)
        {
            checkExist(PK_iPhuongphapkiemtraID);
            return PhuongphapkiemtraDAL.Remove(PK_iPhuongphapkiemtraID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iPhuongphapkiemtraID)
        {
            PhuongphapkiemtraEntity oPhuongphapkiemtra=PhuongphapkiemtraDAL.GetOne(PK_iPhuongphapkiemtraID);
            if(oPhuongphapkiemtra==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">PhuongphapkiemtraEntity: entity</param>
        private static void checkLogic(PhuongphapkiemtraEntity entity)
        {   
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">PhuongphapkiemtraEntity: PhuongphapkiemtraEntity</param>
        private static void checkDuplicate(PhuongphapkiemtraEntity entity,bool checkPK)
        {
            /* 
            Example
            List<PhuongphapkiemtraEntity> list = PhuongphapkiemtraDAL.GetAll();
            if (list.Exists(
                delegate(PhuongphapkiemtraEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iPhuongphapkiemtraID != entity.PK_iPhuongphapkiemtraID;
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
        /// <param name="entity">PhuongphapkiemtraEntity:entity</param>
        private static void checkFK(PhuongphapkiemtraEntity entity)
        {            
        }
        #endregion
    }
}
