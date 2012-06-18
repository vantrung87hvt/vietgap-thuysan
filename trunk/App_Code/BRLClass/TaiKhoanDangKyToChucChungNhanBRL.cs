/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:5/17/2012 4:27:31 PM
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
    public class TaiKhoanDangKyToChucChungNhanBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại TaiKhoanDangKyToChucChungNhan Này";
		private static string EX_FK_ITAIKHOANID_INVALID="FK_iTaikhoanID không hợp lệ";
		private static string EX_FK_ITOCHUCCHUNGNHANID_INVALID="FK_iTochucchungnhanID không hợp lệ";
		private static string EX_DNGAYDANGKY_INVALID="dNgaydangky không hợp lệ";
		private static string EX_ID_INVALID="PK_iTaikhoanTochucID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get TaiKhoanDangKyToChucChungNhan Theo ID
        /// </summary>
        /// <param name="PK_iTaikhoanTochucID">Int32:TaiKhoanDangKyToChucChungNhan ID</param>
        /// <returns>TaiKhoanDangKyToChucChungNhanEntity</returns>        
        public static TaiKhoanDangKyToChucChungNhanEntity GetOne(Int32 PK_iTaikhoanTochucID)
        {
            
			if(PK_iTaikhoanTochucID<=0)
				throw new Exception(EX_ID_INVALID);
            return TaiKhoanDangKyToChucChungNhanDAL.GetOne(PK_iTaikhoanTochucID);
        }
        /// <summary>
        /// Lấy về List các TaiKhoanDangKyToChucChungNhan
        /// </summary>
        /// <returns>List TaiKhoanDangKyToChucChungNhanEntity:List TaiKhoanDangKyToChucChungNhan Cần lấy</returns>
        public static List<TaiKhoanDangKyToChucChungNhanEntity> GetAll()
        {
            return TaiKhoanDangKyToChucChungNhanDAL.GetAll();
        }
        public static List<TaiKhoanDangKyToChucChungNhanEntity> GetByFK_iTaikhoanID(Int64 FK_iTaikhoanID)
		{
			if(FK_iTaikhoanID<=0)
				throw new Exception(EX_FK_ITAIKHOANID_INVALID);
			return TaiKhoanDangKyToChucChungNhanDAL.GetByFK_iTaikhoanID(FK_iTaikhoanID);
		}public static List<TaiKhoanDangKyToChucChungNhanEntity> GetByFK_iTochucchungnhanID(Int32 FK_iTochucchungnhanID)
		{
			if(FK_iTochucchungnhanID<=0)
				throw new Exception(EX_FK_ITOCHUCCHUNGNHANID_INVALID);
			return TaiKhoanDangKyToChucChungNhanDAL.GetByFK_iTochucchungnhanID(FK_iTochucchungnhanID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới TaiKhoanDangKyToChucChungNhan
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của TaiKhoanDangKyToChucChungNhan Mới Thêm Vào</returns>
        public static Int32 Add(TaiKhoanDangKyToChucChungNhanEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return TaiKhoanDangKyToChucChungNhanDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa TaiKhoanDangKyToChucChungNhan
        /// </summary>
        /// <param name="entity">TaiKhoanDangKyToChucChungNhanEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(TaiKhoanDangKyToChucChungNhanEntity entity)
        {
            checkExist(entity.PK_iTaikhoanTochucID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return TaiKhoanDangKyToChucChungNhanDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá TaiKhoanDangKyToChucChungNhan
        /// </summary>
        /// <param name="PK_iTaikhoanTochucID">Int32 : PK_iTaikhoanTochucID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iTaikhoanTochucID)
        {
            checkExist(PK_iTaikhoanTochucID);
            return TaiKhoanDangKyToChucChungNhanDAL.Remove(PK_iTaikhoanTochucID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iTaikhoanTochucID)
        {
            TaiKhoanDangKyToChucChungNhanEntity oTaiKhoanDangKyToChucChungNhan=TaiKhoanDangKyToChucChungNhanDAL.GetOne(PK_iTaikhoanTochucID);
            if(oTaiKhoanDangKyToChucChungNhan==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">TaiKhoanDangKyToChucChungNhanEntity: entity</param>
        private static void checkLogic(TaiKhoanDangKyToChucChungNhanEntity entity)
        {   
			if (entity.FK_iTaikhoanID < 0)
				throw new Exception(EX_FK_ITAIKHOANID_INVALID);
			if (entity.FK_iTochucchungnhanID < 0)
				throw new Exception(EX_FK_ITOCHUCCHUNGNHANID_INVALID);
			if (DateTime.Parse("1753-01-01")>entity.dNgaydangky)
				throw new Exception(EX_DNGAYDANGKY_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">TaiKhoanDangKyToChucChungNhanEntity: TaiKhoanDangKyToChucChungNhanEntity</param>
        private static void checkDuplicate(TaiKhoanDangKyToChucChungNhanEntity entity,bool checkPK)
        {
            /* 
            Example
            List<TaiKhoanDangKyToChucChungNhanEntity> list = TaiKhoanDangKyToChucChungNhanDAL.GetAll();
            if (list.Exists(
                delegate(TaiKhoanDangKyToChucChungNhanEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iTaikhoanTochucID != entity.PK_iTaikhoanTochucID;
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
        /// <param name="entity">TaiKhoanDangKyToChucChungNhanEntity:entity</param>
        private static void checkFK(TaiKhoanDangKyToChucChungNhanEntity entity)
        {            
			UserEntity oUser = UserDAL.GetOne(entity.FK_iTaikhoanID);
			if (oUser==null)
			{
				throw new Exception("Không tìm thấy :FK_iTaikhoanID");
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
