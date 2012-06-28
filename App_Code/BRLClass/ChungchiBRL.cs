/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:6/28/2012 3:55:44 PM
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
    public class ChungchiBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Chungchi Này";
		private static string EX_STENCHUNGCHI_EMPTY="sTenChungchi không được để trống";
		private static string EX_SMOTA_EMPTY="sMota không được để trống";
		private static string EX_ID_INVALID="PK_iChungchiID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Chungchi Theo ID
        /// </summary>
        /// <param name="PK_iChungchiID">Int32:Chungchi ID</param>
        /// <returns>ChungchiEntity</returns>        
        public static ChungchiEntity GetOne(Int32 PK_iChungchiID)
        {
            
			if(PK_iChungchiID<=0)
				throw new Exception(EX_ID_INVALID);
            return ChungchiDAL.GetOne(PK_iChungchiID);
        }
        /// <summary>
        /// Lấy về List các Chungchi
        /// </summary>
        /// <returns>List ChungchiEntity:List Chungchi Cần lấy</returns>
        public static List<ChungchiEntity> GetAll()
        {
            return ChungchiDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới Chungchi
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Chungchi Mới Thêm Vào</returns>
        public static Int32 Add(ChungchiEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return ChungchiDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Chungchi
        /// </summary>
        /// <param name="entity">ChungchiEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(ChungchiEntity entity)
        {
            checkExist(entity.PK_iChungchiID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return ChungchiDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Chungchi
        /// </summary>
        /// <param name="PK_iChungchiID">Int32 : PK_iChungchiID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iChungchiID)
        {
            checkExist(PK_iChungchiID);
            return ChungchiDAL.Remove(PK_iChungchiID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iChungchiID)
        {
            ChungchiEntity oChungchi=ChungchiDAL.GetOne(PK_iChungchiID);
            if(oChungchi==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">ChungchiEntity: entity</param>
        private static void checkLogic(ChungchiEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sTenChungchi))
				throw new Exception(EX_STENCHUNGCHI_EMPTY);
			if (String.IsNullOrEmpty(entity.sMota))
				throw new Exception(EX_SMOTA_EMPTY);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">ChungchiEntity: ChungchiEntity</param>
        private static void checkDuplicate(ChungchiEntity entity,bool checkPK)
        {
            /* 
            Example
            List<ChungchiEntity> list = ChungchiDAL.GetAll();
            if (list.Exists(
                delegate(ChungchiEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iChungchiID != entity.PK_iChungchiID;
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
        /// <param name="entity">ChungchiEntity:entity</param>
        private static void checkFK(ChungchiEntity entity)
        {            
        }
        #endregion
    }
}
