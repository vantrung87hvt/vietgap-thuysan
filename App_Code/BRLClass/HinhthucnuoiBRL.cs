/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/26/2011 11:53:37 AM
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
    public class HinhthucnuoiBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Hinhthucnuoi Này";
		private static string EX_STENHINHTHUC_EMPTY="sTenhinhthuc không được để trống";
		private static string EX_ID_INVALID="PK_iHinhthucnuoiID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Hinhthucnuoi Theo ID
        /// </summary>
        /// <param name="PK_iHinhthucnuoiID">Int32:Hinhthucnuoi ID</param>
        /// <returns>HinhthucnuoiEntity</returns>        
        public static HinhthucnuoiEntity GetOne(Int32 PK_iHinhthucnuoiID)
        {
            
			if(PK_iHinhthucnuoiID<=0)
				throw new Exception(EX_ID_INVALID);
            return HinhthucnuoiDAL.GetOne(PK_iHinhthucnuoiID);
        }
        /// <summary>
        /// Lấy về List các Hinhthucnuoi
        /// </summary>
        /// <returns>List HinhthucnuoiEntity:List Hinhthucnuoi Cần lấy</returns>
        public static List<HinhthucnuoiEntity> GetAll()
        {
            return HinhthucnuoiDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới Hinhthucnuoi
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Hinhthucnuoi Mới Thêm Vào</returns>
        public static Int32 Add(HinhthucnuoiEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return HinhthucnuoiDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Hinhthucnuoi
        /// </summary>
        /// <param name="entity">HinhthucnuoiEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(HinhthucnuoiEntity entity)
        {
            checkExist(entity.PK_iHinhthucnuoiID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return HinhthucnuoiDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Hinhthucnuoi
        /// </summary>
        /// <param name="PK_iHinhthucnuoiID">Int32 : PK_iHinhthucnuoiID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iHinhthucnuoiID)
        {
            checkExist(PK_iHinhthucnuoiID);
            return HinhthucnuoiDAL.Remove(PK_iHinhthucnuoiID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iHinhthucnuoiID)
        {
            HinhthucnuoiEntity oHinhthucnuoi=HinhthucnuoiDAL.GetOne(PK_iHinhthucnuoiID);
            if(oHinhthucnuoi==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">HinhthucnuoiEntity: entity</param>
        private static void checkLogic(HinhthucnuoiEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sTenhinhthuc))
				throw new Exception(EX_STENHINHTHUC_EMPTY);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">HinhthucnuoiEntity: HinhthucnuoiEntity</param>
        private static void checkDuplicate(HinhthucnuoiEntity entity,bool checkPK)
        {
            /* 
            Example
            List<HinhthucnuoiEntity> list = HinhthucnuoiDAL.GetAll();
            if (list.Exists(
                delegate(HinhthucnuoiEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iHinhthucnuoiID != entity.PK_iHinhthucnuoiID;
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
        /// <param name="entity">HinhthucnuoiEntity:entity</param>
        private static void checkFK(HinhthucnuoiEntity entity)
        {            
        }
        #endregion
    }
}
