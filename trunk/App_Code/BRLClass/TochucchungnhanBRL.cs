/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/1/2012 9:47:32 PM
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
    public class TochucchungnhanBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Tochucchungnhan Này";
		private static string EX_STOCHUCCHUNGNHAN_EMPTY="sTochucchungnhan không được để trống";
		private static string EX_SKYTUVIETTAT_EMPTY="sKytuviettat không được để trống";
		private static string EX_SDIACHI_EMPTY="sDiachi không được để trống";
		private static string EX_FK_IQUANHUYENID_INVALID="FK_iQuanHuyenID không hợp lệ";
		private static string EX_FK_IUSERID_INVALID="FK_iUserID không hợp lệ";
		private static string EX_IMGLOGO_INVALID="imgLogo không hợp lệ";
		private static string EX_DNGAYCAPDANGKYKINHDOANH_INVALID="dNgaycapdangkykinhdoanh không hợp lệ";
		private static string EX_ITRANGTHAI_INVALID="iTrangthai không hợp lệ";
		private static string EX_FK_ICOQUANCAPTRENID_INVALID="FK_iCoquancaptrenID không hợp lệ";
		private static string EX_ID_INVALID="PK_iTochucchungnhanID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Tochucchungnhan Theo ID
        /// </summary>
        /// <param name="PK_iTochucchungnhanID">Int32:Tochucchungnhan ID</param>
        /// <returns>TochucchungnhanEntity</returns>        
        
        public static TochucchungnhanEntity GetOne(Int32 PK_iTochucchungnhanID)
        {
            
			if(PK_iTochucchungnhanID<=0)
				throw new Exception(EX_ID_INVALID);
            return TochucchungnhanDAL.GetOne(PK_iTochucchungnhanID);
        }
        /// <summary>
        /// Lấy về List các Tochucchungnhan
        /// </summary>
        /// <returns>List TochucchungnhanEntity:List Tochucchungnhan Cần lấy</returns>
        public static List<TochucchungnhanEntity> GetAll()
        {
            return TochucchungnhanDAL.GetAll();
        }
        public static List<TochucchungnhanEntity> GetByFK_iQuanHuyenID(Int64 FK_iQuanHuyenID)
		{
			if(FK_iQuanHuyenID<=0)
				throw new Exception(EX_FK_IQUANHUYENID_INVALID);
			return TochucchungnhanDAL.GetByFK_iQuanHuyenID(FK_iQuanHuyenID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới Tochucchungnhan
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Tochucchungnhan Mới Thêm Vào</returns>
        public static Int32 Add(TochucchungnhanEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return TochucchungnhanDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Tochucchungnhan
        /// </summary>
        /// <param name="entity">TochucchungnhanEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(TochucchungnhanEntity entity)
        {
            checkExist(entity.PK_iTochucchungnhanID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return TochucchungnhanDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Tochucchungnhan
        /// </summary>
        /// <param name="PK_iTochucchungnhanID">Int32 : PK_iTochucchungnhanID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iTochucchungnhanID)
        {
            checkExist(PK_iTochucchungnhanID);
            return TochucchungnhanDAL.Remove(PK_iTochucchungnhanID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iTochucchungnhanID)
        {
            TochucchungnhanEntity oTochucchungnhan=TochucchungnhanDAL.GetOne(PK_iTochucchungnhanID);
            if(oTochucchungnhan==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">TochucchungnhanEntity: entity</param>
        private static void checkLogic(TochucchungnhanEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sTochucchungnhan))
				throw new Exception(EX_STOCHUCCHUNGNHAN_EMPTY);
			if (String.IsNullOrEmpty(entity.sKytuviettat))
				throw new Exception(EX_SKYTUVIETTAT_EMPTY);
			if (String.IsNullOrEmpty(entity.sDiachi))
				throw new Exception(EX_SDIACHI_EMPTY);
			if (entity.FK_iQuanHuyenID < 0)
				throw new Exception(EX_FK_IQUANHUYENID_INVALID);
			if (entity.imgLogo ==null)
				throw new Exception(EX_IMGLOGO_INVALID);
			if (DateTime.Parse("1753-01-01")>entity.dNgaycapdangkykinhdoanh)
				throw new Exception(EX_DNGAYCAPDANGKYKINHDOANH_INVALID);
			if (entity.iTrangthai < 0)
				throw new Exception(EX_ITRANGTHAI_INVALID);
			if (entity.FK_iCoquancaptrenID < 0)
				throw new Exception(EX_FK_ICOQUANCAPTRENID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">TochucchungnhanEntity: TochucchungnhanEntity</param>
        private static void checkDuplicate(TochucchungnhanEntity entity,bool checkPK)
        {
            
            //List<TochucchungnhanEntity> list = TochucchungnhanDAL.GetAll();
            //if (list.Exists(
            //    delegate(TochucchungnhanEntity oldEntity)
            //    {
            //        bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
            //        if(checkPK)
            //            result=result && oldEntity.PK_iTochucchungnhanID != entity.PK_iTochucchungnhanID;
            //        return result;
            //    }
            //))
            //{
            //    list.Clear();
            //    throw new Exception(EX_FIELD_EXISTED);
            //}
            
        }
        /// <summary>
        /// Kiểm tra tồn tại khóa ngoại
        /// </summary>
        /// <param name="entity">TochucchungnhanEntity:entity</param>
        private static void checkFK(TochucchungnhanEntity entity)
        {            
			QuanHuyenEntity oQuanHuyen = QuanHuyenDAL.GetOne(entity.FK_iQuanHuyenID);
			if (oQuanHuyen==null)
			{
				throw new Exception("Không tìm thấy :FK_iQuanHuyenID");
			}
        }
        #endregion
    }
}
