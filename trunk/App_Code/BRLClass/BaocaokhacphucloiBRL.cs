/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/17/2011 9:33:56 PM
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
    public class BaocaokhacphucloiBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Baocaokhacphucloi Này";
		private static string EX_FK_ICOSONUOIID_INVALID="FK_iCosonuoiID không hợp lệ";
		private static string EX_DNGAYKIEMTRA_INVALID="dNgaykiemtra không hợp lệ";
		private static string EX_ID_INVALID="PK_iBaocaokhacphucloiID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Baocaokhacphucloi Theo ID
        /// </summary>
        /// <param name="PK_iBaocaokhacphucloiID">Int64:Baocaokhacphucloi ID</param>
        /// <returns>BaocaokhacphucloiEntity</returns>        
        public static BaocaokhacphucloiEntity GetOne(Int64 PK_iBaocaokhacphucloiID)
        {
            
			if(PK_iBaocaokhacphucloiID<=0)
				throw new Exception(EX_ID_INVALID);
            return BaocaokhacphucloiDAL.GetOne(PK_iBaocaokhacphucloiID);
        }
        /// <summary>
        /// Lấy về List các Baocaokhacphucloi
        /// </summary>
        /// <returns>List BaocaokhacphucloiEntity:List Baocaokhacphucloi Cần lấy</returns>
        public static List<BaocaokhacphucloiEntity> GetAll()
        {
            return BaocaokhacphucloiDAL.GetAll();
        }
        public static List<BaocaokhacphucloiEntity> GetByFK_iCosonuoiID(Int64 FK_iCosonuoiID)
		{
			if(FK_iCosonuoiID<=0)
				throw new Exception(EX_FK_ICOSONUOIID_INVALID);
			return BaocaokhacphucloiDAL.GetByFK_iCosonuoiID(FK_iCosonuoiID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới Baocaokhacphucloi
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Baocaokhacphucloi Mới Thêm Vào</returns>
        public static Int32 Add(BaocaokhacphucloiEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return BaocaokhacphucloiDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Baocaokhacphucloi
        /// </summary>
        /// <param name="entity">BaocaokhacphucloiEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(BaocaokhacphucloiEntity entity)
        {
            checkExist(entity.PK_iBaocaokhacphucloiID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return BaocaokhacphucloiDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Baocaokhacphucloi
        /// </summary>
        /// <param name="PK_iBaocaokhacphucloiID">Int64 : PK_iBaocaokhacphucloiID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int64 PK_iBaocaokhacphucloiID)
        {
            checkExist(PK_iBaocaokhacphucloiID);
            return BaocaokhacphucloiDAL.Remove(PK_iBaocaokhacphucloiID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int64 PK_iBaocaokhacphucloiID)
        {
            BaocaokhacphucloiEntity oBaocaokhacphucloi=BaocaokhacphucloiDAL.GetOne(PK_iBaocaokhacphucloiID);
            if(oBaocaokhacphucloi==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">BaocaokhacphucloiEntity: entity</param>
        private static void checkLogic(BaocaokhacphucloiEntity entity)
        {   
			if (entity.FK_iCosonuoiID < 0)
				throw new Exception(EX_FK_ICOSONUOIID_INVALID);
			if (DateTime.Parse("1753-01-01")>entity.dNgaykiemtra)
				throw new Exception(EX_DNGAYKIEMTRA_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">BaocaokhacphucloiEntity: BaocaokhacphucloiEntity</param>
        private static void checkDuplicate(BaocaokhacphucloiEntity entity,bool checkPK)
        {
            /* 
            Example
            List<BaocaokhacphucloiEntity> list = BaocaokhacphucloiDAL.GetAll();
            if (list.Exists(
                delegate(BaocaokhacphucloiEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iBaocaokhacphucloiID != entity.PK_iBaocaokhacphucloiID;
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
        /// <param name="entity">BaocaokhacphucloiEntity:entity</param>
        private static void checkFK(BaocaokhacphucloiEntity entity)
        {            
			CosonuoitrongEntity oCosonuoitrong = CosonuoitrongDAL.GetOne(entity.FK_iCosonuoiID);
			if (oCosonuoitrong==null)
			{
				throw new Exception("Không tìm thấy :FK_iCosonuoiID");
			}
        }
        #endregion
    }
}
