/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/9/2012 9:10:59 PM
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
    public class GroupPermissionBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại GroupPermission Này";
		private static string EX_IGROUPID_INVALID="iGroupID không hợp lệ";
		private static string EX_IPERMISSIONID_INVALID="iPermissionID không hợp lệ";
		private static string EX_ID_INVALID="iGroupPermissionID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get GroupPermission Theo ID
        /// </summary>
        /// <param name="iGroupPermissionID">Int32:GroupPermission ID</param>
        /// <returns>GroupPermissionEntity</returns>        
        public static GroupPermissionEntity GetOne(Int32 iGroupPermissionID)
        {
            
			if(iGroupPermissionID<=0)
				throw new Exception(EX_ID_INVALID);
            return GroupPermissionDAL.GetOne(iGroupPermissionID);
        }
        /// <summary>
        /// Lấy về List các GroupPermission
        /// </summary>
        /// <returns>List GroupPermissionEntity:List GroupPermission Cần lấy</returns>
        public static List<GroupPermissionEntity> GetAll()
        {
            return GroupPermissionDAL.GetAll();
        }
        public static List<GroupPermissionEntity> GetByiGroupID(Int32 iGroupID)
		{
			if(iGroupID<=0)
				throw new Exception(EX_IGROUPID_INVALID);
			return GroupPermissionDAL.GetByiGroupID(iGroupID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới GroupPermission
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của GroupPermission Mới Thêm Vào</returns>
        public static Int32 Add(GroupPermissionEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return GroupPermissionDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa GroupPermission
        /// </summary>
        /// <param name="entity">GroupPermissionEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(GroupPermissionEntity entity)
        {
            checkExist(entity.iGroupPermissionID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return GroupPermissionDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá GroupPermission
        /// </summary>
        /// <param name="iGroupPermissionID">Int32 : iGroupPermissionID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 iGroupPermissionID)
        {
            checkExist(iGroupPermissionID);
            return GroupPermissionDAL.Remove(iGroupPermissionID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 iGroupPermissionID)
        {
            GroupPermissionEntity oGroupPermission=GroupPermissionDAL.GetOne(iGroupPermissionID);
            if(oGroupPermission==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">GroupPermissionEntity: entity</param>
        private static void checkLogic(GroupPermissionEntity entity)
        {   
			if (entity.iGroupID < 0)
				throw new Exception(EX_IGROUPID_INVALID);
			if (entity.iPermissionID < 0)
				throw new Exception(EX_IPERMISSIONID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">GroupPermissionEntity: GroupPermissionEntity</param>
        private static void checkDuplicate(GroupPermissionEntity entity,bool checkPK)
        {
            /* 
            Example
            List<GroupPermissionEntity> list = GroupPermissionDAL.GetAll();
            if (list.Exists(
                delegate(GroupPermissionEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.iGroupPermissionID != entity.iGroupPermissionID;
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
        /// <param name="entity">GroupPermissionEntity:entity</param>
        private static void checkFK(GroupPermissionEntity entity)
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
