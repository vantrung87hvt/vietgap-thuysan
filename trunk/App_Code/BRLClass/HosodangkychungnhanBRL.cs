/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/6/2012 10:05:49 AM
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
    public class HosodangkychungnhanBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Hosodangkychungnhan Này";
		private static string EX_DNGAYDANGKY_INVALID="dNgaydangky không hợp lệ";
		private static string EX_FK_ICOSONUOIID_INVALID="FK_iCosonuoiID không hợp lệ";
		private static string EX_ITRANGTHAI_INVALID="iTrangthai không hợp lệ";
		private static string EX_FK_ITOCHUCCHUNGNHANID_INVALID="FK_iTochucchungnhanID không hợp lệ";
		private static string EX_ID_INVALID="PK_iHosodangkychungnhanID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Hosodangkychungnhan Theo ID
        /// </summary>
        /// <param name="PK_iHosodangkychungnhanID">Int64:Hosodangkychungnhan ID</param>
        /// <returns>HosodangkychungnhanEntity</returns>        
        public static HosodangkychungnhanEntity GetOne(Int64 PK_iHosodangkychungnhanID)
        {
            
			if(PK_iHosodangkychungnhanID<=0)
				throw new Exception(EX_ID_INVALID);
            return HosodangkychungnhanDAL.GetOne(PK_iHosodangkychungnhanID);
        }
        /// <summary>
        /// Lấy về List các Hosodangkychungnhan
        /// </summary>
        /// <returns>List HosodangkychungnhanEntity:List Hosodangkychungnhan Cần lấy</returns>
        public static List<HosodangkychungnhanEntity> GetAll()
        {
            return HosodangkychungnhanDAL.GetAll();
        }
        public static List<HosodangkychungnhanEntity> GetByFK_iCosonuoiID(Int64 FK_iCosonuoiID)
		{
			if(FK_iCosonuoiID<=0)
				throw new Exception(EX_FK_ICOSONUOIID_INVALID);
			return HosodangkychungnhanDAL.GetByFK_iCosonuoiID(FK_iCosonuoiID);
		}public static List<HosodangkychungnhanEntity> GetByFK_iTochucchungnhanID(Int32 FK_iTochucchungnhanID)
		{
			if(FK_iTochucchungnhanID<=0)
				throw new Exception(EX_FK_ITOCHUCCHUNGNHANID_INVALID);
			return HosodangkychungnhanDAL.GetByFK_iTochucchungnhanID(FK_iTochucchungnhanID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới Hosodangkychungnhan
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Hosodangkychungnhan Mới Thêm Vào</returns>
        public static Int32 Add(HosodangkychungnhanEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return HosodangkychungnhanDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Hosodangkychungnhan
        /// </summary>
        /// <param name="entity">HosodangkychungnhanEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(HosodangkychungnhanEntity entity)
        {
            checkExist(entity.PK_iHosodangkychungnhanID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return HosodangkychungnhanDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Hosodangkychungnhan
        /// </summary>
        /// <param name="PK_iHosodangkychungnhanID">Int64 : PK_iHosodangkychungnhanID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int64 PK_iHosodangkychungnhanID)
        {
            checkExist(PK_iHosodangkychungnhanID);
            return HosodangkychungnhanDAL.Remove(PK_iHosodangkychungnhanID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int64 PK_iHosodangkychungnhanID)
        {
            HosodangkychungnhanEntity oHosodangkychungnhan=HosodangkychungnhanDAL.GetOne(PK_iHosodangkychungnhanID);
            if(oHosodangkychungnhan==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">HosodangkychungnhanEntity: entity</param>
        private static void checkLogic(HosodangkychungnhanEntity entity)
        {   
			if (DateTime.Parse("1753-01-01")>entity.dNgaydangky)
				throw new Exception(EX_DNGAYDANGKY_INVALID);
			if (entity.FK_iCosonuoiID < 0)
				throw new Exception(EX_FK_ICOSONUOIID_INVALID);
			if (entity.iTrangthai < 0)
				throw new Exception(EX_ITRANGTHAI_INVALID);
			if (entity.FK_iTochucchungnhanID < 0)
				throw new Exception(EX_FK_ITOCHUCCHUNGNHANID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">HosodangkychungnhanEntity: HosodangkychungnhanEntity</param>
        private static void checkDuplicate(HosodangkychungnhanEntity entity,bool checkPK)
        {
            /* 
            Example
            List<HosodangkychungnhanEntity> list = HosodangkychungnhanDAL.GetAll();
            if (list.Exists(
                delegate(HosodangkychungnhanEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iHosodangkychungnhanID != entity.PK_iHosodangkychungnhanID;
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
        /// <param name="entity">HosodangkychungnhanEntity:entity</param>
        private static void checkFK(HosodangkychungnhanEntity entity)
        {            
			CosonuoitrongEntity oCosonuoitrong = CosonuoitrongDAL.GetOne(entity.FK_iCosonuoiID);
			if (oCosonuoitrong==null)
			{
				throw new Exception("Không tìm thấy :FK_iCosonuoiID");
			}
			TochucchungnhanEntity oTochucchungnhan = TochucchungnhanDAL.GetOne(entity.FK_iTochucchungnhanID);
			if (oTochucchungnhan==null)
			{
				throw new Exception("Không tìm thấy :FK_iTochucchungnhanID");
			}
        }
        #endregion
    }
}
