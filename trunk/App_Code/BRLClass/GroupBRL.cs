/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/9/2012 9:10:58 PM
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
    public class GroupBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Group Này";
		private static string EX_SNAME_EMPTY="sName không được để trống";
		private static string EX_ID_INVALID="iGroupID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Group Theo ID
        /// </summary>
        /// <param name="iGroupID">Int32:Group ID</param>
        /// <returns>GroupEntity</returns>        
        public static GroupEntity GetOne(Int32 iGroupID)
        {
            
			if(iGroupID<=0)
				throw new Exception(EX_ID_INVALID);
            return GroupDAL.GetOne(iGroupID);
        }
        /// <summary>
        /// Lấy về List các Group
        /// </summary>
        /// <returns>List GroupEntity:List Group Cần lấy</returns>
        public static List<GroupEntity> GetAll()
        {
            return GroupDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới Group
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Group Mới Thêm Vào</returns>
        public static Int32 Add(GroupEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return GroupDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Group
        /// </summary>
        /// <param name="entity">GroupEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(GroupEntity entity)
        {
            checkExist(entity.iGroupID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return GroupDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Group
        /// </summary>
        /// <param name="iGroupID">Int32 : iGroupID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 iGroupID)
        {
            checkExist(iGroupID);
            return GroupDAL.Remove(iGroupID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 iGroupID)
        {
            GroupEntity oGroup=GroupDAL.GetOne(iGroupID);
            if(oGroup==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">GroupEntity: entity</param>
        private static void checkLogic(GroupEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sName))
				throw new Exception(EX_SNAME_EMPTY);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">GroupEntity: GroupEntity</param>
        private static void checkDuplicate(GroupEntity entity,bool checkPK)
        {
            /* 
            Example
            List<GroupEntity> list = GroupDAL.GetAll();
            if (list.Exists(
                delegate(GroupEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.iGroupID != entity.iGroupID;
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
        /// <param name="entity">GroupEntity:entity</param>
        private static void checkFK(GroupEntity entity)
        {            
        }
        #endregion
    }
}
