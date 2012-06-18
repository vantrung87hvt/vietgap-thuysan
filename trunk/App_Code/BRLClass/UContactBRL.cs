/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/2/2011 4:41:56 PM
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
    public class UContactBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại UContact Này";
		private static string EX_FK_ICONTACTID_INVALID="FK_iContactID không hợp lệ";
		private static string EX_TDATE_INVALID="tDate không hợp lệ";
		private static string EX_ID_INVALID="PK_iUContactID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get UContact Theo ID
        /// </summary>
        /// <param name="PK_iUContactID">int:UContact ID</param>
        /// <returns>UContactEntity</returns>        
        public static UContactEntity GetOne(int PK_iUContactID)
        {
            
			if(PK_iUContactID<=0)
				throw new Exception(EX_ID_INVALID);
            return UContactDAL.GetOne(PK_iUContactID);
        }
        /// <summary>
        /// Lấy về List các UContact
        /// </summary>
        /// <returns>List UContactEntity:List UContact Cần lấy</returns>
        public static List<UContactEntity> GetAll()
        {
            return UContactDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới UContact
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của UContact Mới Thêm Vào</returns>
        public static Int32 Add(UContactEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return UContactDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa UContact
        /// </summary>
        /// <param name="entity">UContactEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(UContactEntity entity)
        {
            checkExist(entity.PK_iUContactID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return UContactDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá UContact
        /// </summary>
        /// <param name="PK_iUContactID">int : PK_iUContactID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(int PK_iUContactID)
        {
            checkExist(PK_iUContactID);
            return UContactDAL.Remove(PK_iUContactID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(int PK_iUContactID)
        {
            UContactEntity oUContact=UContactDAL.GetOne(PK_iUContactID);
            if(oUContact==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">UContactEntity: entity</param>
        private static void checkLogic(UContactEntity entity)
        {   
			if (entity.FK_iContactID < 0)
				throw new Exception(EX_FK_ICONTACTID_INVALID);
			if (DateTime.Parse("1753-01-01")>entity.tDate)
				throw new Exception(EX_TDATE_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">UContactEntity: UContactEntity</param>
        private static void checkDuplicate(UContactEntity entity,bool checkPK)
        {
            /* 
            Example
            List<UContactEntity> list = UContactDAL.GetAll();
            if (list.Exists(
                delegate(UContactEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iUContactID != entity.PK_iUContactID;
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
        /// <param name="entity">UContactEntity:entity</param>
        private static void checkFK(UContactEntity entity)
        {            
        }
        #endregion
    }
}
