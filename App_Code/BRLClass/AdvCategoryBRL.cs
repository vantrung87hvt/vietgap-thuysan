/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:4/11/2009 4:52:27 PM
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
    public class AdvCategoryBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Quảng cáo-Nhóm tin Này";
		private static string EX_IADVID_INVALID="Quảng cáo ID không hợp lệ";
		private static string EX_ICATEGORYID_INVALID="Nhóm tin ID không hợp lệ";
		private static string EX_ID_INVALID="Quảng cáo-Nhóm tin không hợp lệ";
        private static string EX_EXISTED = "Bản ghi trong tblAdvCategory đã tồn tại";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get AdvCategory Theo ID
        /// </summary>
        /// <param name="iAdvCategory">Int32:AdvCategory ID</param>
        /// <returns>AdvCategoryEntity</returns>        
        public static AdvCategoryEntity GetOne(Int32 iAdvCategory)
        {
            
			if(iAdvCategory<=0)
				throw new Exception(EX_ID_INVALID);
            return AdvCategoryDAL.GetOne(iAdvCategory);
        }
        /// <summary>
        /// Lấy về List các AdvCategory
        /// </summary>
        /// <returns>List AdvCategoryEntity:List AdvCategory Cần lấy</returns>
        public static List<AdvCategoryEntity> GetAll()
        {
            return AdvCategoryDAL.GetAll();
        }
        public static AdvCategoryEntity GetByFK(Int32 iAdvID,Int32 iCategoryID)
        {
            if (iAdvID <= 0)
                throw new Exception(EX_IADVID_INVALID);
            if (iCategoryID <= 0)
                throw new Exception(EX_ICATEGORYID_INVALID);
            List<AdvCategoryEntity> lst = AdvCategoryDAL.GetByiAdvID(iAdvID);
            return lst.Find(
                delegate(AdvCategoryEntity obj)
                {
                    return obj.iCategoryID == iCategoryID;
                }
            );
        }
        public static List<AdvCategoryEntity> GetByiAdvID(Int32 iAdvID)
		{
			if(iAdvID<=0)
				throw new Exception(EX_IADVID_INVALID);
			return AdvCategoryDAL.GetByiAdvID(iAdvID);
		}public static List<AdvCategoryEntity> GetByiCategoryID(Int32 iCategoryID)
		{
			if(iCategoryID<=0)
				throw new Exception(EX_ICATEGORYID_INVALID);
			return AdvCategoryDAL.GetByiCategoryID(iCategoryID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới AdvCategory
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của AdvCategory Mới Thêm Vào</returns>
        public static Int32 Add(AdvCategoryEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return AdvCategoryDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa AdvCategory
        /// </summary>
        /// <param name="entity">AdvCategoryEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(AdvCategoryEntity entity)
        {
            checkExist(entity.iAdvCategory);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return AdvCategoryDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá AdvCategory
        /// </summary>
        /// <param name="iAdvCategory">Int32 : iAdvCategory</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 iAdvCategory)
        {
            checkExist(iAdvCategory);
            return AdvCategoryDAL.Remove(iAdvCategory);
        }
        public static bool RemoveByiCategoryID(Int32 iCategoryID)
        {
            List<AdvCategoryEntity> lstAdvCat = AdvCategoryDAL.GetByiCategoryID(iCategoryID);
            bool totalResult = true;
            foreach (AdvCategoryEntity oAdvCat in lstAdvCat)
            {
                bool result = AdvCategoryDAL.Remove(oAdvCat.iAdvCategory);
                if (!result) totalResult = false;
            }
            return totalResult;
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 iAdvCategory)
        {
            AdvCategoryEntity oAdvCategory=AdvCategoryDAL.GetOne(iAdvCategory);
            if(oAdvCategory==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">AdvCategoryEntity: entity</param>
        private static void checkLogic(AdvCategoryEntity entity)
        {   
			if (entity.iAdvID < 0)
				throw new Exception(EX_IADVID_INVALID);
			if (entity.iCategoryID < 0)
				throw new Exception(EX_ICATEGORYID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">AdvCategoryEntity: AdvCategoryEntity</param>
        private static void checkDuplicate(AdvCategoryEntity entity,bool checkPK)
        {
            List<AdvCategoryEntity> list = AdvCategoryDAL.GetAll();
            if (list.Exists(
                delegate(AdvCategoryEntity oldEntity)
                {
                    bool result = oldEntity.iAdvID == entity.iAdvID && oldEntity.iCategoryID == entity.iCategoryID;
                    if(checkPK)
                        result=result && oldEntity.iAdvCategory != entity.iAdvCategory;
                    return result;
                }
            ))
            {
                list.Clear();
                throw new Exception(EX_EXISTED);
            }
        }
        /// <summary>
        /// Kiểm tra tồn tại khóa ngoại
        /// </summary>
        /// <param name="entity">AdvCategoryEntity:entity</param>
        private static void checkFK(AdvCategoryEntity entity)
        {            
			AdvEntity oAdv = AdvDAL.GetOne(entity.iAdvID);
			if (oAdv==null)
			{
				throw new Exception("Không tìm thấy quảng cáo này");
			}
			CategoryEntity oCategory = CategoryDAL.GetOne(entity.iCategoryID);
			if (oCategory==null)
			{
				throw new Exception("Không tìm thấy nhóm tin này");
			}
        }
        #endregion
    }
}
