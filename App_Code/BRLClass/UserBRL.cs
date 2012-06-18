/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/9/2012 9:10:57 PM
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
    public class UserBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại User Này";
		private static string EX_SUSERNAME_EMPTY="sUsername không được để trống";
		private static string EX_SPASSWORD_EMPTY="sPassword không được để trống";
		private static string EX_SEMAIL_EMPTY="sEmail không được để trống";
		private static string EX_TLASTVISIT_INVALID="tLastVisit không hợp lệ";
		private static string EX_IGROUPID_INVALID="iGroupID không hợp lệ";
		private static string EX_ID_INVALID="iUserID không hợp lệ";
        private static string EX_SUSERNAME_EXISTED = "Username đã tồn tại, hãy chọn tên khác";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get User Theo ID
        /// </summary>
        /// <param name="iUserID">Int64:User ID</param>
        /// <returns>UserEntity</returns>        
        public static UserEntity GetOne(Int64 iUserID)
        {
            
			if(iUserID<=0)
				throw new Exception(EX_ID_INVALID);
            return UserDAL.GetOne(iUserID);
        }
        /// <summary>
        /// Lấy về List các User
        /// </summary>
        /// <returns>List UserEntity:List User Cần lấy</returns>
        public static List<UserEntity> GetAll()
        {
            return UserDAL.GetAll();
        }
        public static List<UserEntity> GetByiGroupID(Int32 iGroupID)
		{
			if(iGroupID<=0)
				throw new Exception(EX_IGROUPID_INVALID);
			return UserDAL.GetByiGroupID(iGroupID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới User
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của User Mới Thêm Vào</returns>
        public static Int32 Add(UserEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return UserDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa User
        /// </summary>
        /// <param name="entity">UserEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(UserEntity entity)
        {
            checkExist(entity.iUserID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return UserDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá User
        /// </summary>
        /// <param name="iUserID">Int64 : iUserID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int64 iUserID)
        {
            checkExist(iUserID);
            return UserDAL.Remove(iUserID);
        }
        public static UserEntity GetByUserPass(string username, string password)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
                throw new Exception("Chưa nhập đủ username / password");
            List<UserEntity> lstUser = UserDAL.GetAll();
            return lstUser.Find(
                delegate(UserEntity entity)
                {
                    return String.Compare(entity.sUsername, username, true) == 0 && entity.sPassword == password;
                }
            );
        }
        public static UserEntity getByUserName(String sUsername)
        {
            if (String.IsNullOrEmpty(sUsername))
                throw new Exception("Chưa nhập đủ username");
            List<UserEntity> lstUser = UserDAL.GetAll();
            return lstUser.Find(
                delegate(UserEntity entity)
                {
                    return String.Compare(entity.sUsername, sUsername, true) == 0;
                }
            );
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int64 iUserID)
        {
            UserEntity oUser=UserDAL.GetOne(iUserID);
            if(oUser==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">UserEntity: entity</param>
        private static void checkLogic(UserEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sUsername))
				throw new Exception(EX_SUSERNAME_EMPTY);
			if (String.IsNullOrEmpty(entity.sPassword))
				throw new Exception(EX_SPASSWORD_EMPTY);
			if (String.IsNullOrEmpty(entity.sEmail))
				throw new Exception(EX_SEMAIL_EMPTY);
			if (DateTime.Parse("1753-01-01")>entity.tLastVisit)
				throw new Exception(EX_TLASTVISIT_INVALID);
			if (entity.iGroupID < 0)
				throw new Exception(EX_IGROUPID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">UserEntity: UserEntity</param>
        private static void checkDuplicate(UserEntity entity,bool checkPK)
        {
            
            List<UserEntity> list = UserDAL.GetAll();
            if (list.Exists(
                delegate(UserEntity oldEntity)
                {
                    bool result =oldEntity.sUsername.Equals(entity.sUsername, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.iUserID != entity.iUserID;
                    return result;
                }
            ))
            {
                list.Clear();
                throw new Exception(EX_SUSERNAME_EXISTED);
            }
        }
        /// <summary>
        /// Kiểm tra tồn tại khóa ngoại
        /// </summary>
        /// <param name="entity">UserEntity:entity</param>
        private static void checkFK(UserEntity entity)
        {            
			GroupEntity oGroup = GroupDAL.GetOne(entity.iGroupID);
			if (oGroup==null)
			{
				throw new Exception("Không tìm thấy :iGroupID");
			}
        }
        #endregion
    }
}
