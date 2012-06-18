/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:11/24/2011 10:24:55 PM
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
    public class FaqCategoryBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại FaqCategory Này";
		private static string EX_FK_IFAQID_INVALID="FK_iFaqID không hợp lệ";
		private static string EX_ICATEFAQID_INVALID="iCateFaqID không hợp lệ";
		private static string EX_ID_INVALID="PK_iFaqCategoryID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get FaqCategory Theo ID
        /// </summary>
        /// <param name="PK_iFaqCategoryID">Int64:FaqCategory ID</param>
        /// <returns>FaqCategoryEntity</returns>        
        public static FaqCategoryEntity GetOne(Int64 PK_iFaqCategoryID)
        {
            
			if(PK_iFaqCategoryID<=0)
				throw new Exception(EX_ID_INVALID);
            return FaqCategoryDAL.GetOne(PK_iFaqCategoryID);
        }
        /// <summary>
        /// Lấy về List các FaqCategory
        /// </summary>
        /// <returns>List FaqCategoryEntity:List FaqCategory Cần lấy</returns>
        public static List<FaqCategoryEntity> GetAll()
        {
            return FaqCategoryDAL.GetAll();
        }
        public static List<FaqCategoryEntity> GetByFK_iFaqID(Int64 FK_iFaqID)
		{
			if(FK_iFaqID<=0)
				throw new Exception(EX_FK_IFAQID_INVALID);
			return FaqCategoryDAL.GetByFK_iFaqID(FK_iFaqID);
		}public static List<FaqCategoryEntity> GetByiCateFaqID(Int32 iCateFaqID)
		{
			if(iCateFaqID<=0)
				throw new Exception(EX_ICATEFAQID_INVALID);
			return FaqCategoryDAL.GetByiCateFaqID(iCateFaqID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới FaqCategory
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của FaqCategory Mới Thêm Vào</returns>
        public static Int32 Add(FaqCategoryEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return FaqCategoryDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa FaqCategory
        /// </summary>
        /// <param name="entity">FaqCategoryEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(FaqCategoryEntity entity)
        {
            checkExist(entity.PK_iFaqCategoryID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return FaqCategoryDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá FaqCategory
        /// </summary>
        /// <param name="PK_iFaqCategoryID">Int64 : PK_iFaqCategoryID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int64 PK_iFaqCategoryID)
        {
            checkExist(PK_iFaqCategoryID);
            return FaqCategoryDAL.Remove(PK_iFaqCategoryID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int64 PK_iFaqCategoryID)
        {
            FaqCategoryEntity oFaqCategory=FaqCategoryDAL.GetOne(PK_iFaqCategoryID);
            if(oFaqCategory==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">FaqCategoryEntity: entity</param>
        private static void checkLogic(FaqCategoryEntity entity)
        {   
			if (entity.FK_iFaqID < 0)
				throw new Exception(EX_FK_IFAQID_INVALID);
			if (entity.iCateFaqID < 0)
				throw new Exception(EX_ICATEFAQID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">FaqCategoryEntity: FaqCategoryEntity</param>
        private static void checkDuplicate(FaqCategoryEntity entity,bool checkPK)
        {
            /* 
            Example
            List<FaqCategoryEntity> list = FaqCategoryDAL.GetAll();
            if (list.Exists(
                delegate(FaqCategoryEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iFaqCategoryID != entity.PK_iFaqCategoryID;
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
        /// <param name="entity">FaqCategoryEntity:entity</param>
        private static void checkFK(FaqCategoryEntity entity)
        {            
			FaqEntity oFaq = FaqDAL.GetOne(entity.FK_iFaqID);
			if (oFaq==null)
			{
				throw new Exception("Không tìm thấy :FK_iFaqID");
			}
			CateFaqEntity oCateFaq = CateFaqDAL.GetOne(entity.iCateFaqID);
			if (oCateFaq==null)
			{
				throw new Exception("Không tìm thấy :iCateFaqID");
			}
        }
        #endregion
    }
}
