/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/14/2012 10:49:45 AM
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
    public class DangkyHoatdongchungnhanBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại DangkyHoatdongchungnhan Này";
		private static string EX_FK_ITOCHUCCHUNGNHANID_INVALID="FK_iTochucchungnhanID không hợp lệ";
		private static string EX_ITRANGTHAIDANGKY_INVALID="iTrangthaidangky không hợp lệ";
		private static string EX_DNGAYDANGKY_INVALID="dNgaydangky không hợp lệ";
		private static string EX_ILANDANGKY_INVALID="iLandangky không hợp lệ";
		private static string EX_ID_INVALID="PK_iDangkyChungnhanVietGapID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get DangkyHoatdongchungnhan Theo ID
        /// </summary>
        /// <param name="PK_iDangkyChungnhanVietGapID">Int32:DangkyHoatdongchungnhan ID</param>
        /// <returns>DangkyHoatdongchungnhanEntity</returns>        
        public static DangkyHoatdongchungnhanEntity GetOne(Int32 PK_iDangkyChungnhanVietGapID)
        {
            
			if(PK_iDangkyChungnhanVietGapID<=0)
				throw new Exception(EX_ID_INVALID);
            return DangkyHoatdongchungnhanDAL.GetOne(PK_iDangkyChungnhanVietGapID);
        }
        /// <summary>
        /// Lấy về List các DangkyHoatdongchungnhan
        /// </summary>
        /// <returns>List DangkyHoatdongchungnhanEntity:List DangkyHoatdongchungnhan Cần lấy</returns>
        public static List<DangkyHoatdongchungnhanEntity> GetAll()
        {
            return DangkyHoatdongchungnhanDAL.GetAll();
        }
        public static List<DangkyHoatdongchungnhanEntity> GetByFK_iTochucchungnhanID(Int32 FK_iTochucchungnhanID)
		{
			if(FK_iTochucchungnhanID<=0)
				throw new Exception(EX_FK_ITOCHUCCHUNGNHANID_INVALID);
			return DangkyHoatdongchungnhanDAL.GetByFK_iTochucchungnhanID(FK_iTochucchungnhanID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới DangkyHoatdongchungnhan
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của DangkyHoatdongchungnhan Mới Thêm Vào</returns>
        public static Int32 Add(DangkyHoatdongchungnhanEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return DangkyHoatdongchungnhanDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa DangkyHoatdongchungnhan
        /// </summary>
        /// <param name="entity">DangkyHoatdongchungnhanEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(DangkyHoatdongchungnhanEntity entity)
        {
            checkExist(entity.PK_iDangkyChungnhanVietGapID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return DangkyHoatdongchungnhanDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá DangkyHoatdongchungnhan
        /// </summary>
        /// <param name="PK_iDangkyChungnhanVietGapID">Int32 : PK_iDangkyChungnhanVietGapID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iDangkyChungnhanVietGapID)
        {
            checkExist(PK_iDangkyChungnhanVietGapID);
            return DangkyHoatdongchungnhanDAL.Remove(PK_iDangkyChungnhanVietGapID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iDangkyChungnhanVietGapID)
        {
            DangkyHoatdongchungnhanEntity oDangkyHoatdongchungnhan=DangkyHoatdongchungnhanDAL.GetOne(PK_iDangkyChungnhanVietGapID);
            if(oDangkyHoatdongchungnhan==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">DangkyHoatdongchungnhanEntity: entity</param>
        private static void checkLogic(DangkyHoatdongchungnhanEntity entity)
        {   
			if (entity.FK_iTochucchungnhanID < 0)
				throw new Exception(EX_FK_ITOCHUCCHUNGNHANID_INVALID);
			if (entity.iTrangthaidangky < 0)
				throw new Exception(EX_ITRANGTHAIDANGKY_INVALID);
			if (DateTime.Parse("1753-01-01")>entity.dNgaydangky)
				throw new Exception(EX_DNGAYDANGKY_INVALID);
			if (entity.iLandangky < 0)
				throw new Exception(EX_ILANDANGKY_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">DangkyHoatdongchungnhanEntity: DangkyHoatdongchungnhanEntity</param>
        private static void checkDuplicate(DangkyHoatdongchungnhanEntity entity,bool checkPK)
        {
            /* 
            Example
            List<DangkyHoatdongchungnhanEntity> list = DangkyHoatdongchungnhanDAL.GetAll();
            if (list.Exists(
                delegate(DangkyHoatdongchungnhanEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iDangkyChungnhanVietGapID != entity.PK_iDangkyChungnhanVietGapID;
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
        /// <param name="entity">DangkyHoatdongchungnhanEntity:entity</param>
        private static void checkFK(DangkyHoatdongchungnhanEntity entity)
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
