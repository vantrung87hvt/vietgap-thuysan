/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:5/18/2012 11:24:31 AM
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
    public class TochucchungnhanTaikhoanBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại TochucchungnhanTaikhoan Này";
		private static string EX_FK_ITOCHUCCHUNGNHANID_INVALID="FK_iTochucchungnhanID không hợp lệ";
		private static string EX_FK_ITAIKHOANID_INVALID="FK_iTaikhoanID không hợp lệ";
		private static string EX_DNGAYTHUCHIEN_INVALID="dNgaythuchien không hợp lệ";
		private static string EX_ID_INVALID="PK_iTochucchungnhanTaikhoanID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get TochucchungnhanTaikhoan Theo ID
        /// </summary>
        /// <param name="PK_iTochucchungnhanTaikhoanID">Int32:TochucchungnhanTaikhoan ID</param>
        /// <returns>TochucchungnhanTaikhoanEntity</returns>        
        public static TochucchungnhanTaikhoanEntity GetOne(Int32 PK_iTochucchungnhanTaikhoanID)
        {
            
			if(PK_iTochucchungnhanTaikhoanID<=0)
				throw new Exception(EX_ID_INVALID);
            return TochucchungnhanTaikhoanDAL.GetOne(PK_iTochucchungnhanTaikhoanID);
        }
        /// <summary>
        /// Lấy về List các TochucchungnhanTaikhoan
        /// </summary>
        /// <returns>List TochucchungnhanTaikhoanEntity:List TochucchungnhanTaikhoan Cần lấy</returns>
        public static List<TochucchungnhanTaikhoanEntity> GetAll()
        {
            return TochucchungnhanTaikhoanDAL.GetAll();
        }
        public static List<TochucchungnhanTaikhoanEntity> GetByFK_iTochucchungnhanID(Int32 FK_iTochucchungnhanID)
		{
			if(FK_iTochucchungnhanID<=0)
				throw new Exception(EX_FK_ITOCHUCCHUNGNHANID_INVALID);
			return TochucchungnhanTaikhoanDAL.GetByFK_iTochucchungnhanID(FK_iTochucchungnhanID);
		}public static List<TochucchungnhanTaikhoanEntity> GetByFK_iTaikhoanID(Int64 FK_iTaikhoanID)
		{
			if(FK_iTaikhoanID<=0)
				throw new Exception(EX_FK_ITAIKHOANID_INVALID);
			return TochucchungnhanTaikhoanDAL.GetByFK_iTaikhoanID(FK_iTaikhoanID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới TochucchungnhanTaikhoan
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của TochucchungnhanTaikhoan Mới Thêm Vào</returns>
        public static Int32 Add(TochucchungnhanTaikhoanEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return TochucchungnhanTaikhoanDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa TochucchungnhanTaikhoan
        /// </summary>
        /// <param name="entity">TochucchungnhanTaikhoanEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(TochucchungnhanTaikhoanEntity entity)
        {
            checkExist(entity.PK_iTochucchungnhanTaikhoanID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return TochucchungnhanTaikhoanDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá TochucchungnhanTaikhoan
        /// </summary>
        /// <param name="PK_iTochucchungnhanTaikhoanID">Int32 : PK_iTochucchungnhanTaikhoanID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iTochucchungnhanTaikhoanID)
        {
            checkExist(PK_iTochucchungnhanTaikhoanID);
            return TochucchungnhanTaikhoanDAL.Remove(PK_iTochucchungnhanTaikhoanID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iTochucchungnhanTaikhoanID)
        {
            TochucchungnhanTaikhoanEntity oTochucchungnhanTaikhoan=TochucchungnhanTaikhoanDAL.GetOne(PK_iTochucchungnhanTaikhoanID);
            if(oTochucchungnhanTaikhoan==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">TochucchungnhanTaikhoanEntity: entity</param>
        private static void checkLogic(TochucchungnhanTaikhoanEntity entity)
        {   
			if (entity.FK_iTochucchungnhanID < 0)
				throw new Exception(EX_FK_ITOCHUCCHUNGNHANID_INVALID);
			if (entity.FK_iTaikhoanID < 0)
				throw new Exception(EX_FK_ITAIKHOANID_INVALID);
			if (DateTime.Parse("1753-01-01")>entity.dNgaythuchien)
				throw new Exception(EX_DNGAYTHUCHIEN_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">TochucchungnhanTaikhoanEntity: TochucchungnhanTaikhoanEntity</param>
        private static void checkDuplicate(TochucchungnhanTaikhoanEntity entity,bool checkPK)
        {
            /* 
            Example
            List<TochucchungnhanTaikhoanEntity> list = TochucchungnhanTaikhoanDAL.GetAll();
            if (list.Exists(
                delegate(TochucchungnhanTaikhoanEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iTochucchungnhanTaikhoanID != entity.PK_iTochucchungnhanTaikhoanID;
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
        /// <param name="entity">TochucchungnhanTaikhoanEntity:entity</param>
        private static void checkFK(TochucchungnhanTaikhoanEntity entity)
        {            
			TochucchungnhanEntity oTochucchungnhan = TochucchungnhanDAL.GetOne(entity.FK_iTochucchungnhanID);
			if (oTochucchungnhan==null)
			{
				throw new Exception("Không tìm thấy :FK_iTochucchungnhanID");
			}
			UserEntity oUser = UserDAL.GetOne(entity.FK_iTaikhoanID);
			if (oUser==null)
			{
				throw new Exception("Không tìm thấy :FK_iTaikhoanID");
			}
        }
        #endregion
    }
}
