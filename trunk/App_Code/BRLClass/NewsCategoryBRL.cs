/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/9/2009 10:35:00 AM
------------------------------------------------------*/
/*
 * File name  : NewsCategoryBRL.cs
 * Descriptor : Thực hiện kiểm tra nghiệp vụ đối với NewsCategory
 * Created by : XTRUNG.NET@GMAIL.COM
 * On         : 09/01/2009
*/
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
    public class NewsCategoryBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Tin-Chủ đề Này";
		private static string EX_ICATEGORYID_INVALID="Chủ đề ID không hợp lệ";
		private static string EX_INEWSID_INVALID="Tin tức ID không hợp lệ";
        private static string EX_NEWSCAT_EXISTED = "Tin này đã có trong chủ đề đã chọn";
        private static string EX_ID_INVALID = "ID Không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get NewsCategory Theo ID
        /// </summary>
        /// <param name="iNewsCategoryID">Int32:NewsCategory ID</param>
        /// <returns>NewsCategoryEntity</returns>        
        public static NewsCategoryEntity GetOne(Int32 iNewsCategoryID)
        {
            if (iNewsCategoryID <= 0)
                throw new Exception(EX_ID_INVALID);
            return NewsCategoryDAL.GetOne(iNewsCategoryID);
        }
        /// <summary>
        /// Lấy về List các NewsCategory
        /// </summary>
        /// <returns>List NewsCategoryEntity:List NewsCategory Cần lấy</returns>
        public static List<NewsCategoryEntity> GetAll()
        {
            return NewsCategoryDAL.GetAll();
        }
        /// <summary>
        /// Lấy list NewsCategoryEntity theo FK
        /// </summary>
        /// <param name="iCategoryID"></param>
        /// <param name="iNewsID"></param>
        /// <returns></returns>
        public static List<NewsCategoryEntity> GetByFK(int iCategoryID, int iNewsID)
        {
            return NewsCategoryDAL.GetByiCategoryID(iCategoryID).FindAll(
                delegate(NewsCategoryEntity entity)
                {
                    return entity.iNewsID == iNewsID;
                }
            );
        }
        public static List<NewsCategoryEntity> GetByiNewsID(int iNewsID)
        {
            if (iNewsID <= 0)
                throw new Exception(EX_INEWSID_INVALID);
            return NewsCategoryDAL.GetByiNewsID(iNewsID);
        }
        public static List<NewsCategoryEntity> GetByiCategoryID(int iCategoryID)
        {
            if (iCategoryID <= 0)
                throw new Exception(EX_ICATEGORYID_INVALID);
            return NewsCategoryDAL.GetByiCategoryID(iCategoryID);
        }
        /// <summary>
        /// Kiểm tra và thêm mới NewsCategory
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của NewsCategory Mới Thêm Vào</returns>
        public static Int32 Add(NewsCategoryEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return NewsCategoryDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa NewsCategory
        /// </summary>
        /// <param name="entity">NewsCategoryEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(NewsCategoryEntity entity)
        {
            checkExist(entity);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return NewsCategoryDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá NewsCategory
        /// </summary>
        /// <param name="entity">NewsCategoryEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(NewsCategoryEntity entity)
        {
            checkExist(entity);
            checkFK(entity);
            return NewsCategoryDAL.Remove(entity.iNewsCategoryID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(NewsCategoryEntity entity)
        {
            NewsCategoryEntity oNewsCategory=NewsCategoryDAL.GetOne(entity.iNewsCategoryID);
            if(oNewsCategory==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">NewsCategoryEntity: entity</param>
        private static void checkLogic(NewsCategoryEntity entity)
        {   
			if (entity.iCategoryID < 0)
				throw new Exception(EX_ICATEGORYID_INVALID);
			if (entity.iNewsID < 0)
				throw new Exception(EX_INEWSID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">NewsCategoryEntity: NewsCategoryEntity</param>
        private static void checkDuplicate(NewsCategoryEntity entity,bool CheckInsert)
        {
            List<NewsCategoryEntity> list = NewsCategoryDAL.GetAll();
            if (list.Exists(
                delegate(NewsCategoryEntity oldEntity)
                {
                    bool result= oldEntity.iCategoryID == entity.iCategoryID && oldEntity.iNewsID == entity.iNewsID;
                    if (!CheckInsert)
                        result = result && oldEntity.iNewsCategoryID != entity.iNewsCategoryID;
                    return result;
                }
            ))
            {
                list.Clear();
                throw new Exception(EX_NEWSCAT_EXISTED);
            }
        }
        /// <summary>
        /// Kiểm tra tồn tại khóa ngoại
        /// </summary>
        /// <param name="entity">NewsCategoryEntity:entity</param>
        private static void checkFK(NewsCategoryEntity entity)
        {            
			CategoryEntity oCategory = CategoryDAL.GetOne(entity.iCategoryID);
			if (oCategory!=null)
			{
				throw new Exception("Không tìm thấy chủ đề này");
			}
			NewsEntity oNews = NewsDAL.GetOne(entity.iNewsID);
			if (oNews!=null)
			{
				throw new Exception("Không tìm thấy tin tức này");
			}
        }
        #endregion
    }
}
