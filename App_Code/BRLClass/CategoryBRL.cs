/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/7/2009 10:50:15 PM
------------------------------------------------------*/
/*
 * File name  : CategoryBRL.cs
 * Descriptor : Thực hiện kiểm tra nghiệp vụ đối với Category
 * Created by : XTRUNG.NET@GMAIL.COM
 * On         : 07/01/2009
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
    public class CategoryBRL
    {
        #region Init
        private static string EX_NOT_EXIST = "Không Tồn Tại Chủ đề Này";
        private static string EX_ID_INVALID = "ID không hợp lệ";
        private static string EX_NEWSCAT_CONSTRAINT = "Ràng buộc với bảng Tin tức,không xóa được";
        private static string EX_TITLE_EMPTY = "Tiêu đề không được rỗng";
        private static string EX_ORDER_INVALID = "Thứ tự không được <0";
        private static string EX_TOPID_INVALID = "Nhóm cấp trên không được <0";
        private static string EX_TITLE_EXISTED = "Tiêu đề này đã có trong CSDL";
        private static string EX_TOPID_NOTEXIST = "Nhóm cấp trên chưa tồn tại";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Category Theo ID
        /// </summary>
        /// <param name="iCategoryID">Int32:Category ID</param>
        /// <returns>CategoryEntity</returns>        
        public static CategoryEntity GetOne(Int32 iCategoryID)
        {
            if (iCategoryID <= 0)
                throw new Exception(EX_ID_INVALID);
            return CategoryDAL.GetOne(iCategoryID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iTopID"></param>
        /// <returns></returns>
        public static List<CategoryEntity> GetByTopID(Int32 iTopID)
        {
            if (iTopID < 0)
                throw new Exception(EX_TOPID_INVALID);
            return CategoryDAL.GetByiTopID(iTopID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<CategoryEntity> GetAll()
        {
            return CategoryDAL.GetAll();
        }
        /// <summary>
        /// Kiểm tra và thêm mới Category
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Khách Hàng Mới Thêm Vào</returns>
        public static Int32 Add(CategoryEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, true);
            return CategoryDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Category
        /// </summary>
        /// <param name="entity">CategoryEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(CategoryEntity entity)
        {
            checkExist(entity);
            checkLogic(entity);
            checkDuplicate(entity, false);
            return CategoryDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Category
        /// </summary>
        /// <param name="entity">CategoryEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(CategoryEntity entity)
        {
            checkExist(entity);
            checkConstraint(entity);
            return CategoryDAL.Remove(entity.iCategoryID);
        }
        /// <summary>
        /// Kiểm tra ràng buộc khóa ngoại khi xóa
        /// </summary>
        /// <param name="entity">CategoryEntity : entity</param>
        private static void checkConstraint(CategoryEntity entity)
        {
            List<NewsCategoryEntity> lstNewsCat = NewsCategoryDAL.GetByiCategoryID(entity.iCategoryID);
            int count = lstNewsCat.Count;
            lstNewsCat.Clear();
            if (count > 0)
                throw new Exception(EX_NEWSCAT_CONSTRAINT);
        }
        #endregion
        #region Private Methods
        private static void checkExist(CategoryEntity entity)
        {
            CategoryEntity topEntity = CategoryDAL.GetOne(entity.iCategoryID);
            if (topEntity == null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity:xâu rỗng,null,số nhỏ hơn 0,....
        /// </summary>
        /// <param name="entity">CategoryEntity: Entity</param>
        private static void checkLogic(CategoryEntity entity)
        {
            if (String.IsNullOrEmpty(entity.sTitle))
                throw new Exception(EX_TITLE_EMPTY);
            if (entity.iOrder < 0)
                throw new Exception(EX_ORDER_INVALID);
            if (entity.iTopID < 0)
                throw new Exception(EX_TOPID_INVALID);
            if (entity.iCategoryID == entity.iTopID)
                throw new Exception(EX_TOPID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">CategoryEntity: CategoryEntity</param>
        /// <param name="CheckInsert">bool:Kiểm tra xem kiểm tra trong Insert hay Update</param>
        private static void checkDuplicate(CategoryEntity entity, bool CheckInsert)
        {
            //Kiểm tra xem tiêu đề đã tồn tại trong CSDL chưa
            List<CategoryEntity> list = CategoryDAL.GetAll();
            if (list.Exists(
                delegate(CategoryEntity oldEntity)
                {
                    bool result=oldEntity.sTitle.Equals(entity.sTitle, StringComparison.OrdinalIgnoreCase);
                    //Nếu kiểm tra cho Update thì phải kiểm tra khác ID
                    if (CheckInsert == false)
                        result = result && oldEntity.iCategoryID != entity.iCategoryID;
                    return result;
                }
            ))
            {
                list.Clear();
                throw new Exception(EX_TITLE_EXISTED);
            }
        }

        /// <summary>
        /// Kiểm tra tồn tại khóa ngoại
        /// </summary>
        /// <param name="entity">CategoryEntity:entity</param>
        private static void checkFK(CategoryEntity entity)
        {
            //Kiểm tra ràng buộc TopID
            CategoryEntity topEntity = CategoryDAL.GetOne(entity.iTopID);
            if (topEntity == null)
                throw new Exception(EX_TOPID_NOTEXIST);

        }
        #endregion
    }
}
