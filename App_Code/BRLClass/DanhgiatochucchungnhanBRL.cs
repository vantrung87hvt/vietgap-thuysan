/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/26/2011 9:55:50 PM
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
    public class DanhgiatochucchungnhanBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Danhgiatochucchungnhan Này";
		private static string EX_SPHAMVINGHIDINH_EMPTY="sPhamvinghidinh không được để trống";
		private static string EX_TGIODANHGIA_INVALID="tGiodanhgia không hợp lệ";
		private static string EX_DNGAYDANHGIA_INVALID="dNgaydanhgia không hợp lệ";
		private static string EX_SCANCUDANHGIA_EMPTY="sCancudanhgia không được để trống";
		private static string EX_SNOIDUNGDANHGIA_EMPTY="sNoidungdanhgia không được để trống";
		private static string EX_SKETQUADANHGIA_EMPTY="sKetquadanhgia không được để trống";
		private static string EX_IKETQUADANHGIA_INVALID="iKetquadanhgia không hợp lệ";
		private static string EX_FK_ITOCHUCCHUNGNHANID_INVALID="FK_iTochucchungnhanID không hợp lệ";
		private static string EX_FK_ITRUONGDOANDANHGIAID_INVALID="FK_iTruongdoandanhgiaID không hợp lệ";
		private static string EX_ID_INVALID="PK_iDanhgiatochucchungnhanID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Danhgiatochucchungnhan Theo ID
        /// </summary>
        /// <param name="PK_iDanhgiatochucchungnhanID">Int32:Danhgiatochucchungnhan ID</param>
        /// <returns>DanhgiatochucchungnhanEntity</returns>        
        public static DanhgiatochucchungnhanEntity GetOne(Int32 PK_iDanhgiatochucchungnhanID)
        {
            
			if(PK_iDanhgiatochucchungnhanID<=0)
				throw new Exception(EX_ID_INVALID);
            return DanhgiatochucchungnhanDAL.GetOne(PK_iDanhgiatochucchungnhanID);
        }
        /// <summary>
        /// Lấy về List các Danhgiatochucchungnhan
        /// </summary>
        /// <returns>List DanhgiatochucchungnhanEntity:List Danhgiatochucchungnhan Cần lấy</returns>
        public static List<DanhgiatochucchungnhanEntity> GetAll()
        {
            return DanhgiatochucchungnhanDAL.GetAll();
        }
        public static List<DanhgiatochucchungnhanEntity> GetByFK_iTochucchungnhanID(Int32 FK_iTochucchungnhanID)
		{
			if(FK_iTochucchungnhanID<=0)
				throw new Exception(EX_FK_ITOCHUCCHUNGNHANID_INVALID);
			return DanhgiatochucchungnhanDAL.GetByFK_iTochucchungnhanID(FK_iTochucchungnhanID);
		}public static List<DanhgiatochucchungnhanEntity> GetByFK_iTruongdoandanhgiaID(Int32 FK_iTruongdoandanhgiaID)
		{
			if(FK_iTruongdoandanhgiaID<=0)
				throw new Exception(EX_FK_ITRUONGDOANDANHGIAID_INVALID);
			return DanhgiatochucchungnhanDAL.GetByFK_iTruongdoandanhgiaID(FK_iTruongdoandanhgiaID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới Danhgiatochucchungnhan
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Danhgiatochucchungnhan Mới Thêm Vào</returns>
        public static Int32 Add(DanhgiatochucchungnhanEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return DanhgiatochucchungnhanDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Danhgiatochucchungnhan
        /// </summary>
        /// <param name="entity">DanhgiatochucchungnhanEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(DanhgiatochucchungnhanEntity entity)
        {
            checkExist(entity.PK_iDanhgiatochucchungnhanID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return DanhgiatochucchungnhanDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Danhgiatochucchungnhan
        /// </summary>
        /// <param name="PK_iDanhgiatochucchungnhanID">Int32 : PK_iDanhgiatochucchungnhanID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iDanhgiatochucchungnhanID)
        {
            checkExist(PK_iDanhgiatochucchungnhanID);
            return DanhgiatochucchungnhanDAL.Remove(PK_iDanhgiatochucchungnhanID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iDanhgiatochucchungnhanID)
        {
            DanhgiatochucchungnhanEntity oDanhgiatochucchungnhan=DanhgiatochucchungnhanDAL.GetOne(PK_iDanhgiatochucchungnhanID);
            if(oDanhgiatochucchungnhan==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">DanhgiatochucchungnhanEntity: entity</param>
        private static void checkLogic(DanhgiatochucchungnhanEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sPhamvinghidinh))
				throw new Exception(EX_SPHAMVINGHIDINH_EMPTY);
			if (DateTime.Parse("1753-01-01")>entity.tGiodanhgia)
				throw new Exception(EX_TGIODANHGIA_INVALID);
			if (DateTime.Parse("1753-01-01")>entity.dNgaydanhgia)
				throw new Exception(EX_DNGAYDANHGIA_INVALID);
			if (String.IsNullOrEmpty(entity.sCancudanhgia))
				throw new Exception(EX_SCANCUDANHGIA_EMPTY);
			if (String.IsNullOrEmpty(entity.sNoidungdanhgia))
				throw new Exception(EX_SNOIDUNGDANHGIA_EMPTY);
			if (String.IsNullOrEmpty(entity.sKetquadanhgia))
				throw new Exception(EX_SKETQUADANHGIA_EMPTY);
			if (entity.iKetquadanhgia < 0)
				throw new Exception(EX_IKETQUADANHGIA_INVALID);
			if (entity.FK_iTochucchungnhanID < 0)
				throw new Exception(EX_FK_ITOCHUCCHUNGNHANID_INVALID);
			if (entity.FK_iTruongdoandanhgiaID < 0)
				throw new Exception(EX_FK_ITRUONGDOANDANHGIAID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">DanhgiatochucchungnhanEntity: DanhgiatochucchungnhanEntity</param>
        private static void checkDuplicate(DanhgiatochucchungnhanEntity entity,bool checkPK)
        {
            /* 
            Example
            List<DanhgiatochucchungnhanEntity> list = DanhgiatochucchungnhanDAL.GetAll();
            if (list.Exists(
                delegate(DanhgiatochucchungnhanEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iDanhgiatochucchungnhanID != entity.PK_iDanhgiatochucchungnhanID;
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
        /// <param name="entity">DanhgiatochucchungnhanEntity:entity</param>
        private static void checkFK(DanhgiatochucchungnhanEntity entity)
        {            
			TochucchungnhanEntity oTochucchungnhan = TochucchungnhanDAL.GetOne(entity.FK_iTochucchungnhanID);
			if (oTochucchungnhan==null)
			{
				throw new Exception("Không tìm thấy :FK_iTochucchungnhanID");
			}
            ChuyengiaEntity oDanhgiavien = ChuyengiaDAL.GetOne(entity.FK_iTruongdoandanhgiaID);
			if (oDanhgiavien==null)
			{
				throw new Exception("Không tìm thấy :FK_iTruongdoandanhgiaID");
			}
        }
        #endregion
    }
}
