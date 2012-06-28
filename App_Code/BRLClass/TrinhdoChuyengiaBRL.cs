/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:6/28/2012 10:02:59 PM
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
    public class TrinhdoChuyengiaBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại TrinhdoChuyengia Này";
		private static string EX_STRINHDO_EMPTY="sTrinhdo không được để trống";
		private static string EX_ID_INVALID="PK_iTrinhdoChuyengiaID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get TrinhdoChuyengia Theo ID
        /// </summary>
        /// <param name="PK_iTrinhdoChuyengiaID">Int16:TrinhdoChuyengia ID</param>
        /// <returns>TrinhdoChuyengiaEntity</returns>        
        public static TrinhdoChuyengiaEntity GetOne(Int16 PK_iTrinhdoChuyengiaID)
        {
            
			if(PK_iTrinhdoChuyengiaID<=0)
				throw new Exception(EX_ID_INVALID);
            return TrinhdoChuyengiaDAL.GetOne(PK_iTrinhdoChuyengiaID);
        }
        /// <summary>
        /// Lấy về List các TrinhdoChuyengia
        /// </summary>
        /// <returns>List TrinhdoChuyengiaEntity:List TrinhdoChuyengia Cần lấy</returns>
        public static List<TrinhdoChuyengiaEntity> GetAll()
        {
            return TrinhdoChuyengiaDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới TrinhdoChuyengia
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của TrinhdoChuyengia Mới Thêm Vào</returns>
        public static Int32 Add(TrinhdoChuyengiaEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return TrinhdoChuyengiaDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa TrinhdoChuyengia
        /// </summary>
        /// <param name="entity">TrinhdoChuyengiaEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(TrinhdoChuyengiaEntity entity)
        {
            checkExist(entity.PK_iTrinhdoChuyengiaID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return TrinhdoChuyengiaDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá TrinhdoChuyengia
        /// </summary>
        /// <param name="PK_iTrinhdoChuyengiaID">Int16 : PK_iTrinhdoChuyengiaID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int16 PK_iTrinhdoChuyengiaID)
        {
            checkExist(PK_iTrinhdoChuyengiaID);
            return TrinhdoChuyengiaDAL.Remove(PK_iTrinhdoChuyengiaID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int16 PK_iTrinhdoChuyengiaID)
        {
            TrinhdoChuyengiaEntity oTrinhdoChuyengia=TrinhdoChuyengiaDAL.GetOne(PK_iTrinhdoChuyengiaID);
            if(oTrinhdoChuyengia==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">TrinhdoChuyengiaEntity: entity</param>
        private static void checkLogic(TrinhdoChuyengiaEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sTrinhdo))
				throw new Exception(EX_STRINHDO_EMPTY);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">TrinhdoChuyengiaEntity: TrinhdoChuyengiaEntity</param>
        private static void checkDuplicate(TrinhdoChuyengiaEntity entity,bool checkPK)
        {
            /* 
            Example
            List<TrinhdoChuyengiaEntity> list = TrinhdoChuyengiaDAL.GetAll();
            if (list.Exists(
                delegate(TrinhdoChuyengiaEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iTrinhdoChuyengiaID != entity.PK_iTrinhdoChuyengiaID;
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
        /// <param name="entity">TrinhdoChuyengiaEntity:entity</param>
        private static void checkFK(TrinhdoChuyengiaEntity entity)
        {            
        }
        #endregion
    }
}
