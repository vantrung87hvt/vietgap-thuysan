/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/23/2011 8:17:57 PM
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
    public class MasovietgapBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Masovietgap Này";
		private static string EX_SMASO_EMPTY="sMaso không được để trống";
		private static string EX_FK_ITOCHUCCHUNGNHANID_INVALID="FK_iTochucchungnhanID không hợp lệ";
		private static string EX_FK_ICOSONUOITRONGID_INVALID="FK_iCosonuoitrongID không hợp lệ";
		private static string EX_DNGAYCAP_INVALID="dNgaycap không hợp lệ";
		private static string EX_DNGAYHETHAN_INVALID="dNgayhethan không hợp lệ";
		private static string EX_ITHOIHAN_INVALID="iThoihan không hợp lệ";
		private static string EX_ITRANGTHAI_INVALID="iTrangthai không hợp lệ";
		private static string EX_ISANLUONGDUKIENMOI_INVALID="iSanluongdukienmoi không hợp lệ";
		private static string EX_FDIENTICHMORONG_INVALID="fDientichmorong không hợp lệ";
		private static string EX_ID_INVALID="PK_iMasoVietGapID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Masovietgap Theo ID
        /// </summary>
        /// <param name="PK_iMasoVietGapID">Int64:Masovietgap ID</param>
        /// <returns>MasovietgapEntity</returns>        
        public static MasovietgapEntity GetOne(Int64 PK_iMasoVietGapID)
        {
            
			if(PK_iMasoVietGapID<=0)
				throw new Exception(EX_ID_INVALID);
            return MasovietgapDAL.GetOne(PK_iMasoVietGapID);
        }
        /// <summary>
        /// Lấy về List các Masovietgap
        /// </summary>
        /// <returns>List MasovietgapEntity:List Masovietgap Cần lấy</returns>
        public static List<MasovietgapEntity> GetAll()
        {
            return MasovietgapDAL.GetAll();
        }
        public static List<MasovietgapEntity> GetByFK_iTochucchungnhanID(Int32 FK_iTochucchungnhanID)
		{
			if(FK_iTochucchungnhanID<=0)
				throw new Exception(EX_FK_ITOCHUCCHUNGNHANID_INVALID);
			return MasovietgapDAL.GetByFK_iTochucchungnhanID(FK_iTochucchungnhanID);
		}public static List<MasovietgapEntity> GetByFK_iCosonuoitrongID(Int64 FK_iCosonuoitrongID)
		{
			if(FK_iCosonuoitrongID<=0)
				throw new Exception(EX_FK_ICOSONUOITRONGID_INVALID);
			return MasovietgapDAL.GetByFK_iCosonuoitrongID(FK_iCosonuoitrongID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới Masovietgap
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Masovietgap Mới Thêm Vào</returns>
        public static Int32 Add(MasovietgapEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return MasovietgapDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Masovietgap
        /// </summary>
        /// <param name="entity">MasovietgapEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(MasovietgapEntity entity)
        {
            checkExist(entity.PK_iMasoVietGapID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return MasovietgapDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Masovietgap
        /// </summary>
        /// <param name="PK_iMasoVietGapID">Int64 : PK_iMasoVietGapID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int64 PK_iMasoVietGapID)
        {
            checkExist(PK_iMasoVietGapID);
            return MasovietgapDAL.Remove(PK_iMasoVietGapID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int64 PK_iMasoVietGapID)
        {
            MasovietgapEntity oMasovietgap=MasovietgapDAL.GetOne(PK_iMasoVietGapID);
            if(oMasovietgap==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">MasovietgapEntity: entity</param>
        private static void checkLogic(MasovietgapEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sMaso))
				throw new Exception(EX_SMASO_EMPTY);
			if (entity.FK_iTochucchungnhanID < 0)
				throw new Exception(EX_FK_ITOCHUCCHUNGNHANID_INVALID);
			if (entity.FK_iCosonuoitrongID < 0)
				throw new Exception(EX_FK_ICOSONUOITRONGID_INVALID);
			if (DateTime.Parse("1753-01-01")>entity.dNgaycap)
				throw new Exception(EX_DNGAYCAP_INVALID);
			if (DateTime.Parse("1753-01-01")>entity.dNgayhethan)
				throw new Exception(EX_DNGAYHETHAN_INVALID);
			if (entity.iThoihan < 0)
				throw new Exception(EX_ITHOIHAN_INVALID);
			if (entity.iTrangthai < 0)
				throw new Exception(EX_ITRANGTHAI_INVALID);
			if (entity.iSanluongdukienmoi < 0)
				throw new Exception(EX_ISANLUONGDUKIENMOI_INVALID);
			if (entity.fDientichmorong < 0)
				throw new Exception(EX_FDIENTICHMORONG_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">MasovietgapEntity: MasovietgapEntity</param>
        private static void checkDuplicate(MasovietgapEntity entity,bool checkPK)
        {
            /* 
            Example
            List<MasovietgapEntity> list = MasovietgapDAL.GetAll();
            if (list.Exists(
                delegate(MasovietgapEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iMasoVietGapID != entity.PK_iMasoVietGapID;
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
        /// <param name="entity">MasovietgapEntity:entity</param>
        private static void checkFK(MasovietgapEntity entity)
        {            
			TochucchungnhanEntity oTochucchungnhan = TochucchungnhanDAL.GetOne(entity.FK_iTochucchungnhanID);
			if (oTochucchungnhan==null)
			{
				throw new Exception("Không tìm thấy :FK_iTochucchungnhanID");
			}
			CosonuoitrongEntity oCosonuoitrong = CosonuoitrongDAL.GetOne(entity.FK_iCosonuoitrongID);
			if (oCosonuoitrong==null)
			{
				throw new Exception("Không tìm thấy :FK_iCosonuoitrongID");
			}
        }
        #endregion
    }
}
