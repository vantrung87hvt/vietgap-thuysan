/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:04/11/2011 4:04:06 CH
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
    public class ToadoBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Toado Này";
		private static string EX_ID_INVALID="PK_iToadoID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Toado Theo ID
        /// </summary>
        /// <param name="PK_iToadoID">Int32:Toado ID</param>
        /// <returns>ToadoEntity</returns>        
        public static ToadoEntity GetOne(Int32 PK_iToadoID)
        {
            
			if(PK_iToadoID<=0)
				throw new Exception(EX_ID_INVALID);
            return ToadoDAL.GetOne(PK_iToadoID);
        }
        /// <summary>
        /// Lấy về List các Toado
        /// </summary>
        /// <returns>List ToadoEntity:List Toado Cần lấy</returns>
        public static List<ToadoEntity> GetAll()
        {
            return ToadoDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới Toado
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Toado Mới Thêm Vào</returns>
        public static Int32 Add(ToadoEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return ToadoDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Toado
        /// </summary>
        /// <param name="entity">ToadoEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(ToadoEntity entity)
        {
            checkExist(entity.PK_iToadoID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return ToadoDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Toado
        /// </summary>
        /// <param name="PK_iToadoID">Int32 : PK_iToadoID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iToadoID)
        {
            checkExist(PK_iToadoID);
            return ToadoDAL.Remove(PK_iToadoID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iToadoID)
        {
            ToadoEntity oToado=ToadoDAL.GetOne(PK_iToadoID);
            if(oToado==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">ToadoEntity: entity</param>
        private static void checkLogic(ToadoEntity entity)
        {   
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">ToadoEntity: ToadoEntity</param>
        private static void checkDuplicate(ToadoEntity entity,bool checkPK)
        {
            /* 
            Example
            List<ToadoEntity> list = ToadoDAL.GetAll();
            if (list.Exists(
                delegate(ToadoEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iToadoID != entity.PK_iToadoID;
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
        /// <param name="entity">ToadoEntity:entity</param>
        private static void checkFK(ToadoEntity entity)
        {            
        }
        #endregion
    }
}
