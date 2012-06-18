/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/22/2011 10:41:52 PM
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
    public class DichvuBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Dichvu Này";
		private static string EX_STENDICHVU_EMPTY="sTendichvu không được để trống";
		private static string EX_SNOIDUNG_EMPTY="sNoidung không được để trống";
		private static string EX_ICATEGORYID_INVALID="iCategoryID không hợp lệ";
		private static string EX_ITRANGTHAI_INVALID="iTrangthai không hợp lệ";
		private static string EX_ID_INVALID="PK_iDichvuID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Dichvu Theo ID
        /// </summary>
        /// <param name="PK_iDichvuID">Int32:Dichvu ID</param>
        /// <returns>DichvuEntity</returns>        
        public static DichvuEntity GetOne(Int32 PK_iDichvuID)
        {
            
			if(PK_iDichvuID<=0)
				throw new Exception(EX_ID_INVALID);
            return DichvuDAL.GetOne(PK_iDichvuID);
        }
        /// <summary>
        /// Lấy về List các Dichvu
        /// </summary>
        /// <returns>List DichvuEntity:List Dichvu Cần lấy</returns>
        public static List<DichvuEntity> GetAll()
        {
            return DichvuDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới Dichvu
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Dichvu Mới Thêm Vào</returns>
        public static Int32 Add(DichvuEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return DichvuDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Dichvu
        /// </summary>
        /// <param name="entity">DichvuEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(DichvuEntity entity)
        {
            checkExist(entity.PK_iDichvuID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return DichvuDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Dichvu
        /// </summary>
        /// <param name="PK_iDichvuID">Int32 : PK_iDichvuID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iDichvuID)
        {
            checkExist(PK_iDichvuID);
            return DichvuDAL.Remove(PK_iDichvuID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iDichvuID)
        {
            DichvuEntity oDichvu=DichvuDAL.GetOne(PK_iDichvuID);
            if(oDichvu==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">DichvuEntity: entity</param>
        private static void checkLogic(DichvuEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sTendichvu))
				throw new Exception(EX_STENDICHVU_EMPTY);
			if (String.IsNullOrEmpty(entity.sNoidung))
				throw new Exception(EX_SNOIDUNG_EMPTY);
			if (entity.iCategoryID < 0)
				throw new Exception(EX_ICATEGORYID_INVALID);
			if (entity.iTrangthai < 0)
				throw new Exception(EX_ITRANGTHAI_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">DichvuEntity: DichvuEntity</param>
        private static void checkDuplicate(DichvuEntity entity,bool checkPK)
        {
            /* 
            Example
            List<DichvuEntity> list = DichvuDAL.GetAll();
            if (list.Exists(
                delegate(DichvuEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iDichvuID != entity.PK_iDichvuID;
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
        /// <param name="entity">DichvuEntity:entity</param>
        private static void checkFK(DichvuEntity entity)
        {            
        }
        #endregion
    }
}
