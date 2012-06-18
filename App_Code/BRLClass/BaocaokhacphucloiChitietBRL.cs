/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/17/2011 9:33:54 PM
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
    public class BaocaokhacphucloiChitietBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại BaocaokhacphucloiChitiet Này";
		private static string EX_SLOISAI_EMPTY="sLoisai không được để trống";
		private static string EX_SBIENPHAPKHACPHUC_EMPTY="sBienphapkhacphuc không được để trống";
		private static string EX_IKETQUA_INVALID="iKetqua không hợp lệ";
		private static string EX_FK_IBAOCAOKHACPHUCLOIID_INVALID="FK_iBaocaokhacphucloiID không hợp lệ";
		private static string EX_ID_INVALID="PK_iBaocaokhacphucloiChitietID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get BaocaokhacphucloiChitiet Theo ID
        /// </summary>
        /// <param name="PK_iBaocaokhacphucloiChitietID">Int64:BaocaokhacphucloiChitiet ID</param>
        /// <returns>BaocaokhacphucloiChitietEntity</returns>        
        public static BaocaokhacphucloiChitietEntity GetOne(Int64 PK_iBaocaokhacphucloiChitietID)
        {
            
			if(PK_iBaocaokhacphucloiChitietID<=0)
				throw new Exception(EX_ID_INVALID);
            return BaocaokhacphucloiChitietDAL.GetOne(PK_iBaocaokhacphucloiChitietID);
        }
        /// <summary>
        /// Lấy về List các BaocaokhacphucloiChitiet
        /// </summary>
        /// <returns>List BaocaokhacphucloiChitietEntity:List BaocaokhacphucloiChitiet Cần lấy</returns>
        public static List<BaocaokhacphucloiChitietEntity> GetAll()
        {
            return BaocaokhacphucloiChitietDAL.GetAll();
        }
        public static List<BaocaokhacphucloiChitietEntity> GetByFK_iBaocaokhacphucloiID(Int64 FK_iBaocaokhacphucloiID)
		{
			if(FK_iBaocaokhacphucloiID<=0)
				throw new Exception(EX_FK_IBAOCAOKHACPHUCLOIID_INVALID);
			return BaocaokhacphucloiChitietDAL.GetByFK_iBaocaokhacphucloiID(FK_iBaocaokhacphucloiID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới BaocaokhacphucloiChitiet
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của BaocaokhacphucloiChitiet Mới Thêm Vào</returns>
        public static Int32 Add(BaocaokhacphucloiChitietEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return BaocaokhacphucloiChitietDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa BaocaokhacphucloiChitiet
        /// </summary>
        /// <param name="entity">BaocaokhacphucloiChitietEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(BaocaokhacphucloiChitietEntity entity)
        {
            checkExist(entity.PK_iBaocaokhacphucloiChitietID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return BaocaokhacphucloiChitietDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá BaocaokhacphucloiChitiet
        /// </summary>
        /// <param name="PK_iBaocaokhacphucloiChitietID">Int64 : PK_iBaocaokhacphucloiChitietID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int64 PK_iBaocaokhacphucloiChitietID)
        {
            checkExist(PK_iBaocaokhacphucloiChitietID);
            return BaocaokhacphucloiChitietDAL.Remove(PK_iBaocaokhacphucloiChitietID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int64 PK_iBaocaokhacphucloiChitietID)
        {
            BaocaokhacphucloiChitietEntity oBaocaokhacphucloiChitiet=BaocaokhacphucloiChitietDAL.GetOne(PK_iBaocaokhacphucloiChitietID);
            if(oBaocaokhacphucloiChitiet==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">BaocaokhacphucloiChitietEntity: entity</param>
        private static void checkLogic(BaocaokhacphucloiChitietEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sLoisai))
				throw new Exception(EX_SLOISAI_EMPTY);
			if (String.IsNullOrEmpty(entity.sBienphapkhacphuc))
				throw new Exception(EX_SBIENPHAPKHACPHUC_EMPTY);
			if (entity.iKetqua < 0)
				throw new Exception(EX_IKETQUA_INVALID);
			if (entity.FK_iBaocaokhacphucloiID < 0)
				throw new Exception(EX_FK_IBAOCAOKHACPHUCLOIID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">BaocaokhacphucloiChitietEntity: BaocaokhacphucloiChitietEntity</param>
        private static void checkDuplicate(BaocaokhacphucloiChitietEntity entity,bool checkPK)
        {
            /* 
            Example
            List<BaocaokhacphucloiChitietEntity> list = BaocaokhacphucloiChitietDAL.GetAll();
            if (list.Exists(
                delegate(BaocaokhacphucloiChitietEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iBaocaokhacphucloiChitietID != entity.PK_iBaocaokhacphucloiChitietID;
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
        /// <param name="entity">BaocaokhacphucloiChitietEntity:entity</param>
        private static void checkFK(BaocaokhacphucloiChitietEntity entity)
        {            
			BaocaokhacphucloiEntity oBaocaokhacphucloi = BaocaokhacphucloiDAL.GetOne(entity.FK_iBaocaokhacphucloiID);
			if (oBaocaokhacphucloi==null)
			{
				throw new Exception("Không tìm thấy :FK_iBaocaokhacphucloiID");
			}
        }
        #endregion
    }
}
