/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/13/2011 2:12:25 PM
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
    public class TinhBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Tinh Này";
		private static string EX_ID_INVALID="PK_iTinhID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Tinh Theo ID
        /// </summary>
        /// <param name="PK_iTinhID">Int16:Tinh ID</param>
        /// <returns>TinhEntity</returns>        
        public static TinhEntity GetOne(Int16 PK_iTinhID)
        {
            
			if(PK_iTinhID<=0)
				throw new Exception(EX_ID_INVALID);
            return TinhDAL.GetOne(PK_iTinhID);
        }
        /// <summary>
        /// Lấy về List các Tinh
        /// </summary>
        /// <returns>List TinhEntity:List Tinh Cần lấy</returns>
        public static List<TinhEntity> GetAll()
        {
            return TinhDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới Tinh
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Tinh Mới Thêm Vào</returns>
        public static Int32 Add(TinhEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return TinhDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Tinh
        /// </summary>
        /// <param name="entity">TinhEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(TinhEntity entity)
        {
            checkExist(entity.PK_iTinhID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return TinhDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Tinh
        /// </summary>
        /// <param name="PK_iTinhID">Int16 : PK_iTinhID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int16 PK_iTinhID)
        {
            checkExist(PK_iTinhID);
            return TinhDAL.Remove(PK_iTinhID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int16 PK_iTinhID)
        {
            TinhEntity oTinh=TinhDAL.GetOne(PK_iTinhID);
            if(oTinh==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">TinhEntity: entity</param>
        private static void checkLogic(TinhEntity entity)
        {   
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">TinhEntity: TinhEntity</param>
        private static void checkDuplicate(TinhEntity entity,bool checkPK)
        {
            /* 
            Example
            List<TinhEntity> list = TinhDAL.GetAll();
            if (list.Exists(
                delegate(TinhEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iTinhID != entity.PK_iTinhID;
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
        /// <param name="entity">TinhEntity:entity</param>
        private static void checkFK(TinhEntity entity)
        {            
        }
        #endregion
    }
}
