/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/15/2011 10:27:22 PM
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
    public class DanhgiaketquaBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Danhgiaketqua Này";
		private static string EX_FK_ICHITIEUID_INVALID="FK_iChitieuID không hợp lệ";
		private static string EX_FK_IPHUONGPHAPKIEMTRAID_INVALID="FK_iPhuongphapkiemtraID không hợp lệ";
		private static string EX_FK_ICOSONUOIID_INVALID="FK_iCosonuoiID không hợp lệ";
		private static string EX_IKETQUA_INVALID="iKetqua không hợp lệ";
		private static string EX_ID_INVALID="PK_iDanhgiaketquaID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Danhgiaketqua Theo ID
        /// </summary>
        /// <param name="PK_iDanhgiaketquaID">Int32:Danhgiaketqua ID</param>
        /// <returns>DanhgiaketquaEntity</returns>        
        public static DanhgiaketquaEntity GetOne(Int32 PK_iDanhgiaketquaID)
        {
            
			if(PK_iDanhgiaketquaID<=0)
				throw new Exception(EX_ID_INVALID);
            return DanhgiaketquaDAL.GetOne(PK_iDanhgiaketquaID);
        }
        public static DanhgiaketquaEntity GetOneByCosoAndChitieu(Int32 FK_iCosonuoitrongID, Int32 FK_iChitieuID)
        {

            if (FK_iCosonuoitrongID <= 0 || FK_iChitieuID <= 0)
                throw new Exception(EX_ID_INVALID);
            return DanhgiaketquaDAL.GetOneByCosonuoitrongAndChitieu(FK_iCosonuoitrongID, FK_iChitieuID);
        }
        /// <summary>
        /// Lấy về List các Danhgiaketqua
        /// </summary>
        /// <returns>List DanhgiaketquaEntity:List Danhgiaketqua Cần lấy</returns>
        public static List<DanhgiaketquaEntity> GetAll()
        {
            return DanhgiaketquaDAL.GetAll();
        }
        public static List<DanhgiaketquaEntity> GetByFK_iChitieuID(Int32 FK_iChitieuID)
		{
			if(FK_iChitieuID<=0)
				throw new Exception(EX_FK_ICHITIEUID_INVALID);
			return DanhgiaketquaDAL.GetByFK_iChitieuID(FK_iChitieuID);
		}public static List<DanhgiaketquaEntity> GetByFK_iPhuongphapkiemtraID(Int32 FK_iPhuongphapkiemtraID)
		{
			if(FK_iPhuongphapkiemtraID<=0)
				throw new Exception(EX_FK_IPHUONGPHAPKIEMTRAID_INVALID);
			return DanhgiaketquaDAL.GetByFK_iPhuongphapkiemtraID(FK_iPhuongphapkiemtraID);
		}public static List<DanhgiaketquaEntity> GetByFK_iCosonuoiID(Int64 FK_iCosonuoiID)
		{
			if(FK_iCosonuoiID<=0)
				throw new Exception(EX_FK_ICOSONUOIID_INVALID);
			return DanhgiaketquaDAL.GetByFK_iCosonuoiID(FK_iCosonuoiID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới Danhgiaketqua
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Danhgiaketqua Mới Thêm Vào</returns>
        public static Int32 Add(DanhgiaketquaEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return DanhgiaketquaDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Danhgiaketqua
        /// </summary>
        /// <param name="entity">DanhgiaketquaEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(DanhgiaketquaEntity entity)
        {
            checkExist(entity.PK_iDanhgiaketquaID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return DanhgiaketquaDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Danhgiaketqua
        /// </summary>
        /// <param name="PK_iDanhgiaketquaID">Int32 : PK_iDanhgiaketquaID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iDanhgiaketquaID)
        {
            checkExist(PK_iDanhgiaketquaID);
            return DanhgiaketquaDAL.Remove(PK_iDanhgiaketquaID);
        }
        public static bool RemoveByCosonuoitrong(Int32 FK_iCosonuoitrongID)
        {
            return DanhgiaketquaDAL.RemoveByCosonuoitrong(FK_iCosonuoitrongID);
        }
        #endregion
        public static bool avaiable(Int32 FK_iCosonuoitrongID)
        {
            return DanhgiaketquaDAL.avaiable(FK_iCosonuoitrongID);
        }
        public static int CountTrue(Int32 FK_iCosonuoitrongID)
        {
            return DanhgiaketquaDAL.CountTrue(FK_iCosonuoitrongID);
        }
        #region Private Methods
        private static void checkExist(Int32 PK_iDanhgiaketquaID)
        {
            DanhgiaketquaEntity oDanhgiaketqua=DanhgiaketquaDAL.GetOne(PK_iDanhgiaketquaID);
            if(oDanhgiaketqua==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">DanhgiaketquaEntity: entity</param>
        private static void checkLogic(DanhgiaketquaEntity entity)
        {   
			if (entity.FK_iChitieuID < 0)
				throw new Exception(EX_FK_ICHITIEUID_INVALID);
			if (entity.FK_iPhuongphapkiemtraID < 0)
				throw new Exception(EX_FK_IPHUONGPHAPKIEMTRAID_INVALID);
			if (entity.FK_iCosonuoiID < 0)
				throw new Exception(EX_FK_ICOSONUOIID_INVALID);
			if (entity.iKetqua < 0)
				throw new Exception(EX_IKETQUA_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">DanhgiaketquaEntity: DanhgiaketquaEntity</param>
        private static void checkDuplicate(DanhgiaketquaEntity entity,bool checkPK)
        {
            /* 
            Example
            List<DanhgiaketquaEntity> list = DanhgiaketquaDAL.GetAll();
            if (list.Exists(
                delegate(DanhgiaketquaEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iDanhgiaketquaID != entity.PK_iDanhgiaketquaID;
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
        /// <param name="entity">DanhgiaketquaEntity:entity</param>
        private static void checkFK(DanhgiaketquaEntity entity)
        {            
			ChitieuEntity oChitieu = ChitieuDAL.GetOne(entity.FK_iChitieuID);
			if (oChitieu==null)
			{
				throw new Exception("Không tìm thấy :FK_iChitieuID");
			}
			PhuongphapkiemtraEntity oPhuongphapkiemtra = PhuongphapkiemtraDAL.GetOne(entity.FK_iPhuongphapkiemtraID);
			if (oPhuongphapkiemtra==null)
			{
				throw new Exception("Không tìm thấy :FK_iPhuongphapkiemtraID");
			}
			CosonuoitrongEntity oCosonuoitrong = CosonuoitrongDAL.GetOne(entity.FK_iCosonuoiID);
			if (oCosonuoitrong==null)
			{
				throw new Exception("Không tìm thấy :FK_iCosonuoiID");
			}
        }
        #endregion
    }
}
