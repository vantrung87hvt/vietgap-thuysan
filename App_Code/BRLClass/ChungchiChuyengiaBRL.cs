/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:6/28/2012 3:45:46 PM
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
    public class ChungchiChuyengiaBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại ChungchiChuyengia Này";
		private static string EX_FK_ICHUYENGIAID_INVALID="FK_iChuyengiaID không hợp lệ";
		private static string EX_FK_ICHUNGCHIID_INVALID="FK_iChungchiID không hợp lệ";
		private static string EX_ID_INVALID="PK_iChungchiChuyengiaID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get ChungchiChuyengia Theo ID
        /// </summary>
        /// <param name="PK_iChungchiChuyengiaID">Int32:ChungchiChuyengia ID</param>
        /// <returns>ChungchiChuyengiaEntity</returns>        
        public static ChungchiChuyengiaEntity GetOne(Int32 PK_iChungchiChuyengiaID)
        {
            
			if(PK_iChungchiChuyengiaID<=0)
				throw new Exception(EX_ID_INVALID);
            return ChungchiChuyengiaDAL.GetOne(PK_iChungchiChuyengiaID);
        }
        /// <summary>
        /// Lấy về List các ChungchiChuyengia
        /// </summary>
        /// <returns>List ChungchiChuyengiaEntity:List ChungchiChuyengia Cần lấy</returns>
        public static List<ChungchiChuyengiaEntity> GetAll()
        {
            return ChungchiChuyengiaDAL.GetAll();
        }
        public static List<ChungchiChuyengiaEntity> GetByFK_iChuyengiaID(Int32 FK_iChuyengiaID)
		{
			if(FK_iChuyengiaID<=0)
				throw new Exception(EX_FK_ICHUYENGIAID_INVALID);
			return ChungchiChuyengiaDAL.GetByFK_iChuyengiaID(FK_iChuyengiaID);
		}public static List<ChungchiChuyengiaEntity> GetByFK_iChungchiID(Int32 FK_iChungchiID)
		{
			if(FK_iChungchiID<=0)
				throw new Exception(EX_FK_ICHUNGCHIID_INVALID);
			return ChungchiChuyengiaDAL.GetByFK_iChungchiID(FK_iChungchiID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới ChungchiChuyengia
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của ChungchiChuyengia Mới Thêm Vào</returns>
        public static Int32 Add(ChungchiChuyengiaEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return ChungchiChuyengiaDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa ChungchiChuyengia
        /// </summary>
        /// <param name="entity">ChungchiChuyengiaEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(ChungchiChuyengiaEntity entity)
        {
            checkExist(entity.PK_iChungchiChuyengiaID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return ChungchiChuyengiaDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá ChungchiChuyengia
        /// </summary>
        /// <param name="PK_iChungchiChuyengiaID">Int32 : PK_iChungchiChuyengiaID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iChungchiChuyengiaID)
        {
            checkExist(PK_iChungchiChuyengiaID);
            return ChungchiChuyengiaDAL.Remove(PK_iChungchiChuyengiaID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iChungchiChuyengiaID)
        {
            ChungchiChuyengiaEntity oChungchiChuyengia=ChungchiChuyengiaDAL.GetOne(PK_iChungchiChuyengiaID);
            if(oChungchiChuyengia==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">ChungchiChuyengiaEntity: entity</param>
        private static void checkLogic(ChungchiChuyengiaEntity entity)
        {   
			if (entity.FK_iChuyengiaID < 0)
				throw new Exception(EX_FK_ICHUYENGIAID_INVALID);
			if (entity.FK_iChungchiID < 0)
				throw new Exception(EX_FK_ICHUNGCHIID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">ChungchiChuyengiaEntity: ChungchiChuyengiaEntity</param>
        private static void checkDuplicate(ChungchiChuyengiaEntity entity,bool checkPK)
        {
            /* 
            Example
            List<ChungchiChuyengiaEntity> list = ChungchiChuyengiaDAL.GetAll();
            if (list.Exists(
                delegate(ChungchiChuyengiaEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iChungchiChuyengiaID != entity.PK_iChungchiChuyengiaID;
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
        /// <param name="entity">ChungchiChuyengiaEntity:entity</param>
        private static void checkFK(ChungchiChuyengiaEntity entity)
        {            
			ChuyengiaEntity oChuyengia = ChuyengiaDAL.GetOne(entity.FK_iChuyengiaID);
			if (oChuyengia==null)
			{
				throw new Exception("Không tìm thấy :FK_iChuyengiaID");
			}
			ChungchiEntity oChungchi = ChungchiDAL.GetOne(entity.FK_iChungchiID);
			if (oChungchi==null)
			{
				throw new Exception("Không tìm thấy :FK_iChungchiID");
			}
        }
        #endregion
    }
}
