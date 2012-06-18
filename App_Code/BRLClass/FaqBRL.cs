/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/18/2012 8:29:28 PM
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
    public class FaqBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Faq Này";
		private static string EX_FK_IFAQCATEID_INVALID="FK_iFaqCateID không hợp lệ";
		private static string EX_SQUESTION_EMPTY="sQuestion không được để trống";
		private static string EX_DDATE_INVALID="dDate không hợp lệ";
		private static string EX_IVIEWS_INVALID="iViews không hợp lệ";
		private static string EX_FK_IUSERID_INVALID="FK_iUserID không hợp lệ";
		private static string EX_ID_INVALID="PK_iFaqID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Faq Theo ID
        /// </summary>
        /// <param name="PK_iFaqID">Int64:Faq ID</param>
        /// <returns>FaqEntity</returns>        
        public static FaqEntity GetOne(Int64 PK_iFaqID)
        {
            
			if(PK_iFaqID<=0)
				throw new Exception(EX_ID_INVALID);
            return FaqDAL.GetOne(PK_iFaqID);
        }
        /// <summary>
        /// Lấy về List các Faq
        /// </summary>
        /// <returns>List FaqEntity:List Faq Cần lấy</returns>
        public static List<FaqEntity> GetAll()
        {
            return FaqDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới Faq
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Faq Mới Thêm Vào</returns>
        public static Int32 Add(FaqEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return FaqDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Faq
        /// </summary>
        /// <param name="entity">FaqEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(FaqEntity entity)
        {
            checkExist(entity.PK_iFaqID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return FaqDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Faq
        /// </summary>
        /// <param name="PK_iFaqID">Int64 : PK_iFaqID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int64 PK_iFaqID)
        {
            checkExist(PK_iFaqID);
            return FaqDAL.Remove(PK_iFaqID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int64 PK_iFaqID)
        {
            FaqEntity oFaq=FaqDAL.GetOne(PK_iFaqID);
            if(oFaq==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">FaqEntity: entity</param>
        private static void checkLogic(FaqEntity entity)
        {   
			if (entity.FK_iFaqCateID < 0)
				throw new Exception(EX_FK_IFAQCATEID_INVALID);
			if (String.IsNullOrEmpty(entity.sQuestion))
				throw new Exception(EX_SQUESTION_EMPTY);
			if (DateTime.Parse("1753-01-01")>entity.dDate)
				throw new Exception(EX_DDATE_INVALID);
			if (entity.iViews < 0)
				throw new Exception(EX_IVIEWS_INVALID);
			if (entity.FK_iUserID < 0)
				throw new Exception(EX_FK_IUSERID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">FaqEntity: FaqEntity</param>
        private static void checkDuplicate(FaqEntity entity,bool checkPK)
        {
            /* 
            Example
            List<FaqEntity> list = FaqDAL.GetAll();
            if (list.Exists(
                delegate(FaqEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iFaqID != entity.PK_iFaqID;
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
        /// <param name="entity">FaqEntity:entity</param>
        private static void checkFK(FaqEntity entity)
        {            
        }
        #endregion
    }
}
