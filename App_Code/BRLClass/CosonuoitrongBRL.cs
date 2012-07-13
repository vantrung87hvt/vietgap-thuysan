/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:7/13/2012 11:25:40 AM
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
    public class CosonuoitrongBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Cosonuoitrong Này";
		private static string EX_STENCOSO_EMPTY="sTencoso không được để trống";
		private static string EX_STENCHUCOSO_EMPTY="sTenchucoso không được để trống";
		private static string EX_FK_IQUANHUYENID_INVALID="FK_iQuanHuyenID không hợp lệ";
		private static string EX_FTONGDIENTICH_INVALID="fTongdientich không hợp lệ";
		private static string EX_FTONGDIENTICHMATNUOC_INVALID="fTongdientichmatnuoc không hợp lệ";
		private static string EX_FK_ITOADOID_INVALID="FK_iToadoID không hợp lệ";
		private static string EX_FK_IDOITUONGNUOIID_INVALID="FK_iDoituongnuoiID không hợp lệ";
		private static string EX_INAMSANXUAT_INVALID="iNamsanxuat không hợp lệ";
		private static string EX_ICHUKYNUOI_INVALID="iChukynuoi không hợp lệ";
		private static string EX_DNGAYDANGKY_INVALID="dNgaydangky không hợp lệ";
		private static string EX_ISANLUONGDUKIEN_INVALID="iSanluongdukien không hợp lệ";
		private static string EX_FDIENTICHAOLANG_INVALID="fDientichAolang không hợp lệ";
		private static string EX_FK_IHINHTHUCNUOIID_INVALID="FK_iHinhthucnuoiID không hợp lệ";
		private static string EX_FK_ITOCHUCCHUNGNHANID_INVALID="FK_iTochucchungnhanID không hợp lệ";
		private static string EX_FK_IUSERID_INVALID="FK_iUserID không hợp lệ";
		private static string EX_ID_INVALID="PK_iCosonuoitrongID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Cosonuoitrong Theo ID
        /// </summary>
        /// <param name="PK_iCosonuoitrongID">Int64:Cosonuoitrong ID</param>
        /// <returns>CosonuoitrongEntity</returns>        
        public static CosonuoitrongEntity GetOne(Int64 PK_iCosonuoitrongID)
        {
            
			if(PK_iCosonuoitrongID<=0)
				throw new Exception(EX_ID_INVALID);
            return CosonuoitrongDAL.GetOne(PK_iCosonuoitrongID);
        }
        /// <summary>
        /// Lấy về List các Cosonuoitrong
        /// </summary>
        /// <returns>List CosonuoitrongEntity:List Cosonuoitrong Cần lấy</returns>
        public static List<CosonuoitrongEntity> GetAll()
        {
            return CosonuoitrongDAL.GetAll();
        }
        public static List<CosonuoitrongEntity> GetByFK_iQuanHuyenID(Int64 FK_iQuanHuyenID)
		{
			if(FK_iQuanHuyenID<=0)
				throw new Exception(EX_FK_IQUANHUYENID_INVALID);
			return CosonuoitrongDAL.GetByFK_iQuanHuyenID(FK_iQuanHuyenID);
		}public static List<CosonuoitrongEntity> GetByFK_iToadoID(Int32 FK_iToadoID)
		{
			if(FK_iToadoID<=0)
				throw new Exception(EX_FK_ITOADOID_INVALID);
			return CosonuoitrongDAL.GetByFK_iToadoID(FK_iToadoID);
		}public static List<CosonuoitrongEntity> GetByFK_iDoituongnuoiID(Int32 FK_iDoituongnuoiID)
		{
			if(FK_iDoituongnuoiID<=0)
				throw new Exception(EX_FK_IDOITUONGNUOIID_INVALID);
			return CosonuoitrongDAL.GetByFK_iDoituongnuoiID(FK_iDoituongnuoiID);
		}public static List<CosonuoitrongEntity> GetByFK_iHinhthucnuoiID(Int32 FK_iHinhthucnuoiID)
		{
			if(FK_iHinhthucnuoiID<=0)
				throw new Exception(EX_FK_IHINHTHUCNUOIID_INVALID);
			return CosonuoitrongDAL.GetByFK_iHinhthucnuoiID(FK_iHinhthucnuoiID);
		}public static List<CosonuoitrongEntity> GetByFK_iTochucchungnhanID(Int32 FK_iTochucchungnhanID)
		{
			if(FK_iTochucchungnhanID<=0)
				throw new Exception(EX_FK_ITOCHUCCHUNGNHANID_INVALID);
			return CosonuoitrongDAL.GetByFK_iTochucchungnhanID(FK_iTochucchungnhanID);
		}public static List<CosonuoitrongEntity> GetByFK_iUserID(Int64 FK_iUserID)
		{
			if(FK_iUserID<=0)
				throw new Exception(EX_FK_IUSERID_INVALID);
			return CosonuoitrongDAL.GetByFK_iUserID(FK_iUserID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới Cosonuoitrong
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Cosonuoitrong Mới Thêm Vào</returns>
        public static Int32 Add(CosonuoitrongEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return CosonuoitrongDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Cosonuoitrong
        /// </summary>
        /// <param name="entity">CosonuoitrongEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(CosonuoitrongEntity entity)
        {
            checkExist(entity.PK_iCosonuoitrongID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return CosonuoitrongDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Cosonuoitrong
        /// </summary>
        /// <param name="PK_iCosonuoitrongID">Int64 : PK_iCosonuoitrongID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int64 PK_iCosonuoitrongID)
        {
            checkExist(PK_iCosonuoitrongID);
            return CosonuoitrongDAL.Remove(PK_iCosonuoitrongID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int64 PK_iCosonuoitrongID)
        {
            CosonuoitrongEntity oCosonuoitrong=CosonuoitrongDAL.GetOne(PK_iCosonuoitrongID);
            if(oCosonuoitrong==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">CosonuoitrongEntity: entity</param>
        private static void checkLogic(CosonuoitrongEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sTencoso))
				throw new Exception(EX_STENCOSO_EMPTY);
			if (String.IsNullOrEmpty(entity.sTenchucoso))
				throw new Exception(EX_STENCHUCOSO_EMPTY);
			if (entity.FK_iQuanHuyenID < 0)
				throw new Exception(EX_FK_IQUANHUYENID_INVALID);
			if (entity.fTongdientich < 0)
				throw new Exception(EX_FTONGDIENTICH_INVALID);
			if (entity.fTongdientichmatnuoc < 0)
				throw new Exception(EX_FTONGDIENTICHMATNUOC_INVALID);
			if (entity.FK_iToadoID < 0)
				throw new Exception(EX_FK_ITOADOID_INVALID);
			if (entity.FK_iDoituongnuoiID < 0)
				throw new Exception(EX_FK_IDOITUONGNUOIID_INVALID);
			if (entity.iNamsanxuat < 0)
				throw new Exception(EX_INAMSANXUAT_INVALID);
			if (entity.iChukynuoi < 0)
				throw new Exception(EX_ICHUKYNUOI_INVALID);
			if (DateTime.Parse("1753-01-01")>entity.dNgaydangky)
				throw new Exception(EX_DNGAYDANGKY_INVALID);
			if (entity.iSanluongdukien < 0)
				throw new Exception(EX_ISANLUONGDUKIEN_INVALID);
			if (entity.fDientichAolang < 0)
				throw new Exception(EX_FDIENTICHAOLANG_INVALID);
			if (entity.FK_iHinhthucnuoiID < 0)
				throw new Exception(EX_FK_IHINHTHUCNUOIID_INVALID);
			if (entity.FK_iTochucchungnhanID < 0)
				throw new Exception(EX_FK_ITOCHUCCHUNGNHANID_INVALID);
			if (entity.FK_iUserID < 0)
				throw new Exception(EX_FK_IUSERID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">CosonuoitrongEntity: CosonuoitrongEntity</param>
        private static void checkDuplicate(CosonuoitrongEntity entity,bool checkPK)
        {
            /* 
            Example
            List<CosonuoitrongEntity> list = CosonuoitrongDAL.GetAll();
            if (list.Exists(
                delegate(CosonuoitrongEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iCosonuoitrongID != entity.PK_iCosonuoitrongID;
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
        /// <param name="entity">CosonuoitrongEntity:entity</param>
        private static void checkFK(CosonuoitrongEntity entity)
        {            
			QuanHuyenEntity oQuanHuyen = QuanHuyenDAL.GetOne(entity.FK_iQuanHuyenID);
			if (oQuanHuyen==null)
			{
				throw new Exception("Không tìm thấy :FK_iQuanHuyenID");
			}
			ToadoEntity oToado = ToadoDAL.GetOne(entity.FK_iToadoID);
			if (oToado==null)
			{
				throw new Exception("Không tìm thấy :FK_iToadoID");
			}
			DoituongnuoiEntity oDoituongnuoi = DoituongnuoiDAL.GetOne(entity.FK_iDoituongnuoiID);
			if (oDoituongnuoi==null)
			{
				throw new Exception("Không tìm thấy :FK_iDoituongnuoiID");
			}
			HinhthucnuoiEntity oHinhthucnuoi = HinhthucnuoiDAL.GetOne(entity.FK_iHinhthucnuoiID);
			if (oHinhthucnuoi==null)
			{
				throw new Exception("Không tìm thấy :FK_iHinhthucnuoiID");
			}
			TochucchungnhanEntity oTochucchungnhan = TochucchungnhanDAL.GetOne(entity.FK_iTochucchungnhanID);
			if (oTochucchungnhan==null)
			{
				throw new Exception("Không tìm thấy :FK_iTochucchungnhanID");
			}
			UserEntity oUser = UserDAL.GetOne(entity.FK_iUserID);
			if (oUser==null)
			{
				throw new Exception("Không tìm thấy :FK_iUserID");
			}
        }
        #endregion
    }
}
