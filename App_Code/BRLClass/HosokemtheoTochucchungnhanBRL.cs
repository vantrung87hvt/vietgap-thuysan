/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/22/2011 5:52:29 PM
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
    public class HosokemtheoTochucchungnhanBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại HosokemtheoTochucchungnhan Này";
		private static string EX_FK_IGIAYTOID_INVALID="FK_iGiaytoID không hợp lệ";
		private static string EX_FK_IDANGKYCHUNGNHANVIETGAPID_INVALID="FK_iDangkyChungnhanVietGapID không hợp lệ";
		private static string EX_ID_INVALID="PK_iHosokemtheoID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get HosokemtheoTochucchungnhan Theo ID
        /// </summary>
        /// <param name="PK_iHosokemtheoID">Int64:HosokemtheoTochucchungnhan ID</param>
        /// <returns>HosokemtheoTochucchungnhanEntity</returns>        
        public static HosokemtheoTochucchungnhanEntity GetOne(Int64 PK_iHosokemtheoID)
        {
            
			if(PK_iHosokemtheoID<=0)
				throw new Exception(EX_ID_INVALID);
            return HosokemtheoTochucchungnhanDAL.GetOne(PK_iHosokemtheoID);
        }
        /// <summary>
        /// Lấy về List các HosokemtheoTochucchungnhan
        /// </summary>
        /// <returns>List HosokemtheoTochucchungnhanEntity:List HosokemtheoTochucchungnhan Cần lấy</returns>
        public static List<HosokemtheoTochucchungnhanEntity> GetAll()
        {
            return HosokemtheoTochucchungnhanDAL.GetAll();
        }
        public static List<HosokemtheoTochucchungnhanEntity> GetByFK_iGiaytoID(Int32 FK_iGiaytoID)
		{
			if(FK_iGiaytoID<=0)
				throw new Exception(EX_FK_IGIAYTOID_INVALID);
			return HosokemtheoTochucchungnhanDAL.GetByFK_iGiaytoID(FK_iGiaytoID);
		}public static List<HosokemtheoTochucchungnhanEntity> GetByFK_iDangkyChungnhanVietGapID(Int32 FK_iDangkyChungnhanVietGapID)
		{
			if(FK_iDangkyChungnhanVietGapID<=0)
				throw new Exception(EX_FK_IDANGKYCHUNGNHANVIETGAPID_INVALID);
			return HosokemtheoTochucchungnhanDAL.GetByFK_iDangkyChungnhanVietGapID(FK_iDangkyChungnhanVietGapID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới HosokemtheoTochucchungnhan
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của HosokemtheoTochucchungnhan Mới Thêm Vào</returns>
        public static Int32 Add(HosokemtheoTochucchungnhanEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return HosokemtheoTochucchungnhanDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa HosokemtheoTochucchungnhan
        /// </summary>
        /// <param name="entity">HosokemtheoTochucchungnhanEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(HosokemtheoTochucchungnhanEntity entity)
        {
            checkExist(entity.PK_iHosokemtheoID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return HosokemtheoTochucchungnhanDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá HosokemtheoTochucchungnhan
        /// </summary>
        /// <param name="PK_iHosokemtheoID">Int64 : PK_iHosokemtheoID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int64 PK_iHosokemtheoID)
        {
            checkExist(PK_iHosokemtheoID);
            return HosokemtheoTochucchungnhanDAL.Remove(PK_iHosokemtheoID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int64 PK_iHosokemtheoID)
        {
            HosokemtheoTochucchungnhanEntity oHosokemtheoTochucchungnhan=HosokemtheoTochucchungnhanDAL.GetOne(PK_iHosokemtheoID);
            if(oHosokemtheoTochucchungnhan==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">HosokemtheoTochucchungnhanEntity: entity</param>
        private static void checkLogic(HosokemtheoTochucchungnhanEntity entity)
        {   
			if (entity.FK_iGiaytoID < 0)
				throw new Exception(EX_FK_IGIAYTOID_INVALID);
			if (entity.FK_iDangkyChungnhanVietGapID < 0)
				throw new Exception(EX_FK_IDANGKYCHUNGNHANVIETGAPID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">HosokemtheoTochucchungnhanEntity: HosokemtheoTochucchungnhanEntity</param>
        private static void checkDuplicate(HosokemtheoTochucchungnhanEntity entity,bool checkPK)
        {
            /* 
            Example
            List<HosokemtheoTochucchungnhanEntity> list = HosokemtheoTochucchungnhanDAL.GetAll();
            if (list.Exists(
                delegate(HosokemtheoTochucchungnhanEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iHosokemtheoID != entity.PK_iHosokemtheoID;
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
        /// <param name="entity">HosokemtheoTochucchungnhanEntity:entity</param>
        private static void checkFK(HosokemtheoTochucchungnhanEntity entity)
        {            
			GiaytoEntity oGiayto = GiaytoDAL.GetOne(entity.FK_iGiaytoID);
			if (oGiayto==null)
			{
				throw new Exception("Không tìm thấy :FK_iGiaytoID");
			}
			DangkyHoatdongchungnhanEntity oDangkyHoatdongchungnhan = DangkyHoatdongchungnhanDAL.GetOne(entity.FK_iDangkyChungnhanVietGapID);
			if (oDangkyHoatdongchungnhan==null)
			{
				throw new Exception("Không tìm thấy :FK_iDangkyChungnhanVietGapID");
			}
        }
        #endregion
    }
}
