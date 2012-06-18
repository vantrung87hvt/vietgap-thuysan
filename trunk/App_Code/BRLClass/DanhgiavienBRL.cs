/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:01/01/2012 4:22:05 CH
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
    public class DanhgiavienBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Danhgiavien Này";
		private static string EX_SHOTEN_EMPTY="sHoten không được để trống";
		private static string EX_FK_ITOCHUCCHUNGNHANID_INVALID="FK_iTochucchungnhanID không hợp lệ";
		private static string EX_STRINHDO_EMPTY="sTrinhdo không được để trống";
		private static string EX_INAMKINHNGHIEM_INVALID="iNamkinhnghiem không hợp lệ";
		private static string EX_ITRANGTHAI_INVALID="iTrangthai không hợp lệ";
		private static string EX_ID_INVALID="PK_iDanhgiavienID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Danhgiavien Theo ID
        /// </summary>
        /// <param name="PK_iDanhgiavienID">Int32:Danhgiavien ID</param>
        /// <returns>DanhgiavienEntity</returns>        
        public static DanhgiavienEntity GetOne(Int32 PK_iDanhgiavienID)
        {
            
			if(PK_iDanhgiavienID<=0)
				throw new Exception(EX_ID_INVALID);
            return DanhgiavienDAL.GetOne(PK_iDanhgiavienID);
        }
        /// <summary>
        /// Lấy về List các Danhgiavien
        /// </summary>
        /// <returns>List DanhgiavienEntity:List Danhgiavien Cần lấy</returns>
        public static List<DanhgiavienEntity> GetAll()
        {
            return DanhgiavienDAL.GetAll();
        }
        public static List<DanhgiavienEntity> GetByFK_iTochucchungnhanID(Int32 FK_iTochucchungnhanID)
		{
			if(FK_iTochucchungnhanID<=0)
				throw new Exception(EX_FK_ITOCHUCCHUNGNHANID_INVALID);
			return DanhgiavienDAL.GetByFK_iTochucchungnhanID(FK_iTochucchungnhanID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới Danhgiavien
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Danhgiavien Mới Thêm Vào</returns>
        public static Int32 Add(DanhgiavienEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return DanhgiavienDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Danhgiavien
        /// </summary>
        /// <param name="entity">DanhgiavienEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(DanhgiavienEntity entity)
        {
            checkExist(entity.PK_iDanhgiavienID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return DanhgiavienDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Danhgiavien
        /// </summary>
        /// <param name="PK_iDanhgiavienID">Int32 : PK_iDanhgiavienID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iDanhgiavienID)
        {
            checkExist(PK_iDanhgiavienID);
            return DanhgiavienDAL.Remove(PK_iDanhgiavienID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iDanhgiavienID)
        {
            DanhgiavienEntity oDanhgiavien=DanhgiavienDAL.GetOne(PK_iDanhgiavienID);
            if(oDanhgiavien==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">DanhgiavienEntity: entity</param>
        private static void checkLogic(DanhgiavienEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sHoten))
				throw new Exception(EX_SHOTEN_EMPTY);
			if (entity.FK_iTochucchungnhanID < 0)
				throw new Exception(EX_FK_ITOCHUCCHUNGNHANID_INVALID);
			if (String.IsNullOrEmpty(entity.sTrinhdo))
				throw new Exception(EX_STRINHDO_EMPTY);
			if (entity.iNamkinhnghiem < 0)
				throw new Exception(EX_INAMKINHNGHIEM_INVALID);
			if (entity.iTrangthai < 0)
				throw new Exception(EX_ITRANGTHAI_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">DanhgiavienEntity: DanhgiavienEntity</param>
        private static void checkDuplicate(DanhgiavienEntity entity,bool checkPK)
        {
            /* 
            Example
            List<DanhgiavienEntity> list = DanhgiavienDAL.GetAll();
            if (list.Exists(
                delegate(DanhgiavienEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iDanhgiavienID != entity.PK_iDanhgiavienID;
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
        /// <param name="entity">DanhgiavienEntity:entity</param>
        private static void checkFK(DanhgiavienEntity entity)
        {            
			TochucchungnhanEntity oTochucchungnhan = TochucchungnhanDAL.GetOne(entity.FK_iTochucchungnhanID);
			if (oTochucchungnhan==null)
			{
				throw new Exception("Không tìm thấy :FK_iTochucchungnhanID");
			}
        }
        #endregion
    }
}
