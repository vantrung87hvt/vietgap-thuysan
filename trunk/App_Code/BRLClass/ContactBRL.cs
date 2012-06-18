/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/2/2011 8:50:09 PM
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
    public class ContactBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Contact Này";
		private static string EX_FK_IPHONGBANID_INVALID="FK_iPhongBanID không hợp lệ";
		private static string EX_FK_ICHUCVUID_INVALID="FK_iChucVuID không hợp lệ";
		private static string EX_ID_INVALID="PK_iContactID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Contact Theo ID
        /// </summary>
        /// <param name="PK_iContactID">int:Contact ID</param>
        /// <returns>ContactEntity</returns>        
        public static ContactEntity GetOne(int PK_iContactID)
        {
            
			if(PK_iContactID<=0)
				throw new Exception(EX_ID_INVALID);
            return ContactDAL.GetOne(PK_iContactID);
        }
        /// <summary>
        /// Lấy về List các Contact
        /// </summary>
        /// <returns>List ContactEntity:List Contact Cần lấy</returns>
        public static List<ContactEntity> GetAll()
        {
            return ContactDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới Contact
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Contact Mới Thêm Vào</returns>
        public static Int32 Add(ContactEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return ContactDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Contact
        /// </summary>
        /// <param name="entity">ContactEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(ContactEntity entity)
        {
            checkExist(entity.PK_iContactID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return ContactDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Contact
        /// </summary>
        /// <param name="PK_iContactID">int : PK_iContactID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(int PK_iContactID)
        {
            checkExist(PK_iContactID);
            return ContactDAL.Remove(PK_iContactID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(int PK_iContactID)
        {
            ContactEntity oContact=ContactDAL.GetOne(PK_iContactID);
            if(oContact==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">ContactEntity: entity</param>
        private static void checkLogic(ContactEntity entity)
        {   
			if (entity.FK_iPhongBanID < 0)
				throw new Exception(EX_FK_IPHONGBANID_INVALID);
			if (entity.FK_iChucVuID < 0)
				throw new Exception(EX_FK_ICHUCVUID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">ContactEntity: ContactEntity</param>
        private static void checkDuplicate(ContactEntity entity,bool checkPK)
        {
            /* 
            Example
            List<ContactEntity> list = ContactDAL.GetAll();
            if (list.Exists(
                delegate(ContactEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iContactID != entity.PK_iContactID;
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
        /// <param name="entity">ContactEntity:entity</param>
        private static void checkFK(ContactEntity entity)
        {            
        }
        #endregion
    }
}
