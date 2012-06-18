/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:31/10/2011 7:41:05 CH
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
    public class DoituongnuoiBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Doituongnuoi Này";
		private static string EX_STENDOITUONG_EMPTY="sTendoituong không được để trống";
		private static string EX_SKYTU_EMPTY="sKytu không được để trống";
		private static string EX_ID_INVALID="PK_iDoituongnuoiID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Doituongnuoi Theo ID
        /// </summary>
        /// <param name="PK_iDoituongnuoiID">Int32:Doituongnuoi ID</param>
        /// <returns>DoituongnuoiEntity</returns>        
        public static DoituongnuoiEntity GetOne(Int32 PK_iDoituongnuoiID)
        {
            
			if(PK_iDoituongnuoiID<=0)
				throw new Exception(EX_ID_INVALID);
            return DoituongnuoiDAL.GetOne(PK_iDoituongnuoiID);
        }
        /// <summary>
        /// Lấy về List các Doituongnuoi
        /// </summary>
        /// <returns>List DoituongnuoiEntity:List Doituongnuoi Cần lấy</returns>
        public static List<DoituongnuoiEntity> GetAll()
        {
            return DoituongnuoiDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới Doituongnuoi
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Doituongnuoi Mới Thêm Vào</returns>
        public static Int32 Add(DoituongnuoiEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return DoituongnuoiDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Doituongnuoi
        /// </summary>
        /// <param name="entity">DoituongnuoiEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(DoituongnuoiEntity entity)
        {
            checkExist(entity.PK_iDoituongnuoiID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return DoituongnuoiDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Doituongnuoi
        /// </summary>
        /// <param name="PK_iDoituongnuoiID">Int32 : PK_iDoituongnuoiID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iDoituongnuoiID)
        {
            checkExist(PK_iDoituongnuoiID);
            return DoituongnuoiDAL.Remove(PK_iDoituongnuoiID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iDoituongnuoiID)
        {
            DoituongnuoiEntity oDoituongnuoi=DoituongnuoiDAL.GetOne(PK_iDoituongnuoiID);
            if(oDoituongnuoi==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">DoituongnuoiEntity: entity</param>
        private static void checkLogic(DoituongnuoiEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sTendoituong))
				throw new Exception(EX_STENDOITUONG_EMPTY);
			if (String.IsNullOrEmpty(entity.sKytu))
				throw new Exception(EX_SKYTU_EMPTY);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">DoituongnuoiEntity: DoituongnuoiEntity</param>
        private static void checkDuplicate(DoituongnuoiEntity entity,bool checkPK)
        {
            /* 
            Example
            List<DoituongnuoiEntity> list = DoituongnuoiDAL.GetAll();
            if (list.Exists(
                delegate(DoituongnuoiEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iDoituongnuoiID != entity.PK_iDoituongnuoiID;
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
        /// <param name="entity">DoituongnuoiEntity:entity</param>
        private static void checkFK(DoituongnuoiEntity entity)
        {            
        }
        #endregion
    }
}
