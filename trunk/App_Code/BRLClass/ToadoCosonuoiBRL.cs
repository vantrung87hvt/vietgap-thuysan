/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/19/2011 10:50:51 PM
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
    public class ToadoCosonuoiBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại ToadoCosonuoi Này";
		private static string EX_FK_ICOSONUOIID_INVALID="FK_iCosonuoiID không hợp lệ";
		private static string EX_SLAT_EMPTY="sLat không được để trống";
		private static string EX_SLON_EMPTY="sLon không được để trống";
		private static string EX_ID_INVALID="PK_iToadocosonuoiID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get ToadoCosonuoi Theo ID
        /// </summary>
        /// <param name="PK_iToadocosonuoiID">Int64:ToadoCosonuoi ID</param>
        /// <returns>ToadoCosonuoiEntity</returns>        
        public static ToadoCosonuoiEntity GetOne(Int64 PK_iToadocosonuoiID)
        {
            
			if(PK_iToadocosonuoiID<=0)
				throw new Exception(EX_ID_INVALID);
            return ToadoCosonuoiDAL.GetOne(PK_iToadocosonuoiID);
        }
        /// <summary>
        /// Lấy về List các ToadoCosonuoi
        /// </summary>
        /// <returns>List ToadoCosonuoiEntity:List ToadoCosonuoi Cần lấy</returns>
        public static List<ToadoCosonuoiEntity> GetAll()
        {
            return ToadoCosonuoiDAL.GetAll();
        }
        public static List<ToadoCosonuoiEntity> GetByFK_iCosonuoiID(Int32 FK_iCosonuoiID)
		{
			if(FK_iCosonuoiID<=0)
				throw new Exception(EX_FK_ICOSONUOIID_INVALID);
			return ToadoCosonuoiDAL.GetByFK_iCosonuoiID(FK_iCosonuoiID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới ToadoCosonuoi
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của ToadoCosonuoi Mới Thêm Vào</returns>
        public static Int32 Add(ToadoCosonuoiEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return ToadoCosonuoiDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa ToadoCosonuoi
        /// </summary>
        /// <param name="entity">ToadoCosonuoiEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(ToadoCosonuoiEntity entity)
        {
            checkExist(entity.PK_iToadocosonuoiID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return ToadoCosonuoiDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá ToadoCosonuoi
        /// </summary>
        /// <param name="PK_iToadocosonuoiID">Int64 : PK_iToadocosonuoiID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int64 PK_iToadocosonuoiID)
        {
            checkExist(PK_iToadocosonuoiID);
            return ToadoCosonuoiDAL.Remove(PK_iToadocosonuoiID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int64 PK_iToadocosonuoiID)
        {
            ToadoCosonuoiEntity oToadoCosonuoi=ToadoCosonuoiDAL.GetOne(PK_iToadocosonuoiID);
            if(oToadoCosonuoi==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">ToadoCosonuoiEntity: entity</param>
        private static void checkLogic(ToadoCosonuoiEntity entity)
        {   
			if (entity.FK_iCosonuoiID < 0)
				throw new Exception(EX_FK_ICOSONUOIID_INVALID);
			if (String.IsNullOrEmpty(entity.sLat))
				throw new Exception(EX_SLAT_EMPTY);
			if (String.IsNullOrEmpty(entity.sLon))
				throw new Exception(EX_SLON_EMPTY);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">ToadoCosonuoiEntity: ToadoCosonuoiEntity</param>
        private static void checkDuplicate(ToadoCosonuoiEntity entity,bool checkPK)
        {
            /* 
            Example
            List<ToadoCosonuoiEntity> list = ToadoCosonuoiDAL.GetAll();
            if (list.Exists(
                delegate(ToadoCosonuoiEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iToadocosonuoiID != entity.PK_iToadocosonuoiID;
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
        /// <param name="entity">ToadoCosonuoiEntity:entity</param>
        private static void checkFK(ToadoCosonuoiEntity entity)
        {            
			CosonuoitrongEntity oCosonuoi = CosonuoitrongDAL.GetOne(entity.FK_iCosonuoiID);
			if (oCosonuoi==null)
			{
				throw new Exception("Không tìm thấy :FK_iCosonuoiID");
			}
        }
        #endregion
    }
}
