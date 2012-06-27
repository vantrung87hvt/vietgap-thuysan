/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:6/27/2012 8:38:16 AM
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
    public class DoandanhgiatochucchungnhanBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Doandanhgiatochucchungnhan Này";
		private static string EX_FK_IDANHGIATOCHUCCHUNGNHANID_INVALID="FK_iDanhgiatochucchungnhanID không hợp lệ";
		private static string EX_FK_ICHUYENGIAID_INVALID="FK_iChuyengiaID không hợp lệ";
		private static string EX_ID_INVALID="PK_iDoandanhgiatochucchungnhanID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Doandanhgiatochucchungnhan Theo ID
        /// </summary>
        /// <param name="PK_iDoandanhgiatochucchungnhanID">Int32:Doandanhgiatochucchungnhan ID</param>
        /// <returns>DoandanhgiatochucchungnhanEntity</returns>        
        public static DoandanhgiatochucchungnhanEntity GetOne(Int32 PK_iDoandanhgiatochucchungnhanID)
        {
            
			if(PK_iDoandanhgiatochucchungnhanID<=0)
				throw new Exception(EX_ID_INVALID);
            return DoandanhgiatochucchungnhanDAL.GetOne(PK_iDoandanhgiatochucchungnhanID);
        }
        /// <summary>
        /// Lấy về List các Doandanhgiatochucchungnhan
        /// </summary>
        /// <returns>List DoandanhgiatochucchungnhanEntity:List Doandanhgiatochucchungnhan Cần lấy</returns>
        public static List<DoandanhgiatochucchungnhanEntity> GetAll()
        {
            return DoandanhgiatochucchungnhanDAL.GetAll();
        }
        public static List<DoandanhgiatochucchungnhanEntity> GetByFK_iDanhgiatochucchungnhanID(Int32 FK_iDanhgiatochucchungnhanID)
		{
			if(FK_iDanhgiatochucchungnhanID<=0)
				throw new Exception(EX_FK_IDANHGIATOCHUCCHUNGNHANID_INVALID);
			return DoandanhgiatochucchungnhanDAL.GetByFK_iDanhgiatochucchungnhanID(FK_iDanhgiatochucchungnhanID);
		}public static List<DoandanhgiatochucchungnhanEntity> GetByFK_iChuyengiaID(Int32 FK_iChuyengiaID)
		{
			if(FK_iChuyengiaID<=0)
				throw new Exception(EX_FK_ICHUYENGIAID_INVALID);
			return DoandanhgiatochucchungnhanDAL.GetByFK_iChuyengiaID(FK_iChuyengiaID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới Doandanhgiatochucchungnhan
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Doandanhgiatochucchungnhan Mới Thêm Vào</returns>
        public static Int32 Add(DoandanhgiatochucchungnhanEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return DoandanhgiatochucchungnhanDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Doandanhgiatochucchungnhan
        /// </summary>
        /// <param name="entity">DoandanhgiatochucchungnhanEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(DoandanhgiatochucchungnhanEntity entity)
        {
            checkExist(entity.PK_iDoandanhgiatochucchungnhanID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return DoandanhgiatochucchungnhanDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Doandanhgiatochucchungnhan
        /// </summary>
        /// <param name="PK_iDoandanhgiatochucchungnhanID">Int32 : PK_iDoandanhgiatochucchungnhanID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iDoandanhgiatochucchungnhanID)
        {
            checkExist(PK_iDoandanhgiatochucchungnhanID);
            return DoandanhgiatochucchungnhanDAL.Remove(PK_iDoandanhgiatochucchungnhanID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iDoandanhgiatochucchungnhanID)
        {
            DoandanhgiatochucchungnhanEntity oDoandanhgiatochucchungnhan=DoandanhgiatochucchungnhanDAL.GetOne(PK_iDoandanhgiatochucchungnhanID);
            if(oDoandanhgiatochucchungnhan==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">DoandanhgiatochucchungnhanEntity: entity</param>
        private static void checkLogic(DoandanhgiatochucchungnhanEntity entity)
        {   
			if (entity.FK_iDanhgiatochucchungnhanID < 0)
				throw new Exception(EX_FK_IDANHGIATOCHUCCHUNGNHANID_INVALID);
			if (entity.FK_iChuyengiaID < 0)
				throw new Exception(EX_FK_ICHUYENGIAID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">DoandanhgiatochucchungnhanEntity: DoandanhgiatochucchungnhanEntity</param>
        private static void checkDuplicate(DoandanhgiatochucchungnhanEntity entity,bool checkPK)
        {
            /* 
            Example
            List<DoandanhgiatochucchungnhanEntity> list = DoandanhgiatochucchungnhanDAL.GetAll();
            if (list.Exists(
                delegate(DoandanhgiatochucchungnhanEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iDoandanhgiatochucchungnhanID != entity.PK_iDoandanhgiatochucchungnhanID;
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
        /// <param name="entity">DoandanhgiatochucchungnhanEntity:entity</param>
        private static void checkFK(DoandanhgiatochucchungnhanEntity entity)
        {            
			DanhgiatochucchungnhanEntity oDanhgiatochucchungnhan = DanhgiatochucchungnhanDAL.GetOne(entity.FK_iDanhgiatochucchungnhanID);
			if (oDanhgiatochucchungnhan==null)
			{
				throw new Exception("Không tìm thấy :FK_iDanhgiatochucchungnhanID");
			}
			ChuyengiaEntity oChuyengia = ChuyengiaDAL.GetOne(entity.FK_iChuyengiaID);
			if (oChuyengia==null)
			{
				throw new Exception("Không tìm thấy :FK_iChuyengiaID");
			}
        }
        #endregion
    }
}
