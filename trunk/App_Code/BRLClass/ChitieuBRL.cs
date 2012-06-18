/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/15/2011 9:16:58 PM
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
    public class ChitieuBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Chitieu Này";
		private static string EX_SNOIDUNG_EMPTY="sNoidung không được để trống";
		private static string EX_ITHUTHU_INVALID="iThuthu không hợp lệ";
		private static string EX_FK_IMUCDOID_INVALID="FK_iMucdoID không hợp lệ";
		private static string EX_FK_IDANHMUCCHITIEUID_INVALID="FK_iDanhmucchitieuID không hợp lệ";
		private static string EX_ID_INVALID="PK_iChitieuID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Chitieu Theo ID
        /// </summary>
        /// <param name="PK_iChitieuID">Int32:Chitieu ID</param>
        /// <returns>ChitieuEntity</returns>        
        public static ChitieuEntity GetOne(Int32 PK_iChitieuID)
        {
            
			if(PK_iChitieuID<=0)
				throw new Exception(EX_ID_INVALID);
            return ChitieuDAL.GetOne(PK_iChitieuID);
        }
        /// <summary>
        /// Lấy về List các Chitieu
        /// </summary>
        /// <returns>List ChitieuEntity:List Chitieu Cần lấy</returns>
        public static List<ChitieuEntity> GetAll()
        {
            return ChitieuDAL.GetAll();
        }
        public static Int32 Count()
        {
            return ChitieuDAL.Count();
        }
        public static List<ChitieuEntity> GetByFK_iMucdoID(Int32 FK_iMucdoID)
		{
			if(FK_iMucdoID<=0)
				throw new Exception(EX_FK_IMUCDOID_INVALID);
			return ChitieuDAL.GetByFK_iMucdoID(FK_iMucdoID);
		}public static List<ChitieuEntity> GetByFK_iDanhmucchitieuID(Int32 FK_iDanhmucchitieuID)
		{
			if(FK_iDanhmucchitieuID<=0)
				throw new Exception(EX_FK_IDANHMUCCHITIEUID_INVALID);
			return ChitieuDAL.GetByFK_iDanhmucchitieuID(FK_iDanhmucchitieuID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới Chitieu
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Chitieu Mới Thêm Vào</returns>
        public static Int32 Add(ChitieuEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return ChitieuDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Chitieu
        /// </summary>
        /// <param name="entity">ChitieuEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(ChitieuEntity entity)
        {
            checkExist(entity.PK_iChitieuID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return ChitieuDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Chitieu
        /// </summary>
        /// <param name="PK_iChitieuID">Int32 : PK_iChitieuID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iChitieuID)
        {
            checkExist(PK_iChitieuID);
            return ChitieuDAL.Remove(PK_iChitieuID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iChitieuID)
        {
            ChitieuEntity oChitieu=ChitieuDAL.GetOne(PK_iChitieuID);
            if(oChitieu==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">ChitieuEntity: entity</param>
        private static void checkLogic(ChitieuEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sNoidung))
				throw new Exception(EX_SNOIDUNG_EMPTY);
			if (entity.iThuthu < 0)
				throw new Exception(EX_ITHUTHU_INVALID);
			if (entity.FK_iMucdoID < 0)
				throw new Exception(EX_FK_IMUCDOID_INVALID);
			if (entity.FK_iDanhmucchitieuID < 0)
				throw new Exception(EX_FK_IDANHMUCCHITIEUID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">ChitieuEntity: ChitieuEntity</param>
        private static void checkDuplicate(ChitieuEntity entity,bool checkPK)
        {
            /* 
            Example
            List<ChitieuEntity> list = ChitieuDAL.GetAll();
            if (list.Exists(
                delegate(ChitieuEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iChitieuID != entity.PK_iChitieuID;
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
        /// <param name="entity">ChitieuEntity:entity</param>
        private static void checkFK(ChitieuEntity entity)
        {            
			MucdoEntity oMucdo = MucdoDAL.GetOne(entity.FK_iMucdoID);
			if (oMucdo==null)
			{
				throw new Exception("Không tìm thấy :FK_iMucdoID");
			}
			DanhmucchitieuEntity oDanhmucchitieu = DanhmucchitieuDAL.GetOne(entity.FK_iDanhmucchitieuID);
			if (oDanhmucchitieu==null)
			{
				throw new Exception("Không tìm thấy :FK_iDanhmucchitieuID");
			}
        }
        #endregion
    }
}
