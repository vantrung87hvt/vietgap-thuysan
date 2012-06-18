/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/6/2012 11:12:36 AM
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
    public class GiaytoBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Giayto Này";
		private static string EX_STENGIAYTO_EMPTY="sTengiayto không được để trống";
		private static string EX_ID_INVALID="PK_iGiaytoID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Giayto Theo ID
        /// </summary>
        /// <param name="PK_iGiaytoID">Int32:Giayto ID</param>
        /// <returns>GiaytoEntity</returns>        
        public static GiaytoEntity GetOne(Int32 PK_iGiaytoID)
        {
            
			if(PK_iGiaytoID<=0)
				throw new Exception(EX_ID_INVALID);
            return GiaytoDAL.GetOne(PK_iGiaytoID);
        }
        /// <summary>
        /// Lấy về List các Giayto
        /// </summary>
        /// <returns>List GiaytoEntity:List Giayto Cần lấy</returns>
        public static List<GiaytoEntity> GetAll()
        {
            return GiaytoDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới Giayto
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Giayto Mới Thêm Vào</returns>
        public static Int32 Add(GiaytoEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return GiaytoDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Giayto
        /// </summary>
        /// <param name="entity">GiaytoEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(GiaytoEntity entity)
        {
            checkExist(entity.PK_iGiaytoID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return GiaytoDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Giayto
        /// </summary>
        /// <param name="PK_iGiaytoID">Int32 : PK_iGiaytoID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iGiaytoID)
        {
            checkExist(PK_iGiaytoID);
            return GiaytoDAL.Remove(PK_iGiaytoID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iGiaytoID)
        {
            GiaytoEntity oGiayto=GiaytoDAL.GetOne(PK_iGiaytoID);
            if(oGiayto==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">GiaytoEntity: entity</param>
        private static void checkLogic(GiaytoEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sTengiayto))
				throw new Exception(EX_STENGIAYTO_EMPTY);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">GiaytoEntity: GiaytoEntity</param>
        private static void checkDuplicate(GiaytoEntity entity,bool checkPK)
        {
            /* 
            Example
            List<GiaytoEntity> list = GiaytoDAL.GetAll();
            if (list.Exists(
                delegate(GiaytoEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iGiaytoID != entity.PK_iGiaytoID;
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
        /// <param name="entity">GiaytoEntity:entity</param>
        private static void checkFK(GiaytoEntity entity)
        {            
        }
        #endregion
    }
}
