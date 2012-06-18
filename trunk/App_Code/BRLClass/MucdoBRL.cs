/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/15/2011 11:16:10 PM
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
    public class MucdoBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Mucdo Này";
		private static string EX_STENMUCDO_EMPTY="sTenmucdo không được để trống";
		private static string EX_ID_INVALID="PK_iMucdoID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Mucdo Theo ID
        /// </summary>
        /// <param name="PK_iMucdoID">Int32:Mucdo ID</param>
        /// <returns>MucdoEntity</returns>        
        public static MucdoEntity GetOne(Int32 PK_iMucdoID)
        {
            
			if(PK_iMucdoID<=0)
				throw new Exception(EX_ID_INVALID);
            return MucdoDAL.GetOne(PK_iMucdoID);
        }
        /// <summary>
        /// Lấy về List các Mucdo
        /// </summary>
        /// <returns>List MucdoEntity:List Mucdo Cần lấy</returns>
        public static List<MucdoEntity> GetAll()
        {
            return MucdoDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới Mucdo
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Mucdo Mới Thêm Vào</returns>
        public static Int32 Add(MucdoEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return MucdoDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Mucdo
        /// </summary>
        /// <param name="entity">MucdoEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(MucdoEntity entity)
        {
            checkExist(entity.PK_iMucdoID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return MucdoDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Mucdo
        /// </summary>
        /// <param name="PK_iMucdoID">Int32 : PK_iMucdoID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iMucdoID)
        {
            checkExist(PK_iMucdoID);
            return MucdoDAL.Remove(PK_iMucdoID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iMucdoID)
        {
            MucdoEntity oMucdo=MucdoDAL.GetOne(PK_iMucdoID);
            if(oMucdo==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">MucdoEntity: entity</param>
        private static void checkLogic(MucdoEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sTenmucdo))
				throw new Exception(EX_STENMUCDO_EMPTY);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">MucdoEntity: MucdoEntity</param>
        private static void checkDuplicate(MucdoEntity entity,bool checkPK)
        {
            /* 
            Example
            List<MucdoEntity> list = MucdoDAL.GetAll();
            if (list.Exists(
                delegate(MucdoEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iMucdoID != entity.PK_iMucdoID;
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
        /// <param name="entity">MucdoEntity:entity</param>
        private static void checkFK(MucdoEntity entity)
        {            
        }
        #endregion
    }
}
