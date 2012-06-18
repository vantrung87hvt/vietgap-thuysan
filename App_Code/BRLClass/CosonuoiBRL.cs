/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/19/2011 10:50:49 PM
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
    public class CosonuoiBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Cosonuoi Này";
		private static string EX_STENCOSO_EMPTY="sTencoso không được để trống";
		private static string EX_SDIACHI_EMPTY="sDiachi không được để trống";
		private static string EX_ID_INVALID="PK_iCosonuoiID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Cosonuoi Theo ID
        /// </summary>
        /// <param name="PK_iCosonuoiID">Int32:Cosonuoi ID</param>
        /// <returns>CosonuoiEntity</returns>        
        public static CosonuoiEntity GetOne(Int32 PK_iCosonuoiID)
        {
            
			if(PK_iCosonuoiID<=0)
				throw new Exception(EX_ID_INVALID);
            return CosonuoiDAL.GetOne(PK_iCosonuoiID);
        }
        /// <summary>
        /// Lấy về List các Cosonuoi
        /// </summary>
        /// <returns>List CosonuoiEntity:List Cosonuoi Cần lấy</returns>
        public static List<CosonuoiEntity> GetAll()
        {
            return CosonuoiDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới Cosonuoi
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Cosonuoi Mới Thêm Vào</returns>
        public static Int32 Add(CosonuoiEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return CosonuoiDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Cosonuoi
        /// </summary>
        /// <param name="entity">CosonuoiEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(CosonuoiEntity entity)
        {
            checkExist(entity.PK_iCosonuoiID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return CosonuoiDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Cosonuoi
        /// </summary>
        /// <param name="PK_iCosonuoiID">Int32 : PK_iCosonuoiID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iCosonuoiID)
        {
            checkExist(PK_iCosonuoiID);
            return CosonuoiDAL.Remove(PK_iCosonuoiID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iCosonuoiID)
        {
            CosonuoiEntity oCosonuoi=CosonuoiDAL.GetOne(PK_iCosonuoiID);
            if(oCosonuoi==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">CosonuoiEntity: entity</param>
        private static void checkLogic(CosonuoiEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sTencoso))
				throw new Exception(EX_STENCOSO_EMPTY);
			if (String.IsNullOrEmpty(entity.sDiachi))
				throw new Exception(EX_SDIACHI_EMPTY);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">CosonuoiEntity: CosonuoiEntity</param>
        private static void checkDuplicate(CosonuoiEntity entity,bool checkPK)
        {
            /* 
            Example
            List<CosonuoiEntity> list = CosonuoiDAL.GetAll();
            if (list.Exists(
                delegate(CosonuoiEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iCosonuoiID != entity.PK_iCosonuoiID;
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
        /// <param name="entity">CosonuoiEntity:entity</param>
        private static void checkFK(CosonuoiEntity entity)
        {            
        }
        #endregion
    }
}
