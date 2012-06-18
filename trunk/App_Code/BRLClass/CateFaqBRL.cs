/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:11/24/2011 10:24:52 PM
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
    public class CateFaqBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại CateFaq Này";
		private static string EX_SCATENAME_EMPTY="sCateName không được để trống";
		private static string EX_ID_INVALID="PK_iFaqCateID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get CateFaq Theo ID
        /// </summary>
        /// <param name="PK_iFaqCateID">Int32:CateFaq ID</param>
        /// <returns>CateFaqEntity</returns>        
        public static CateFaqEntity GetOne(Int32 PK_iFaqCateID)
        {
            
			if(PK_iFaqCateID<=0)
				throw new Exception(EX_ID_INVALID);
            return CateFaqDAL.GetOne(PK_iFaqCateID);
        }
        /// <summary>
        /// Lấy về List các CateFaq
        /// </summary>
        /// <returns>List CateFaqEntity:List CateFaq Cần lấy</returns>
        public static List<CateFaqEntity> GetAll()
        {
            return CateFaqDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới CateFaq
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của CateFaq Mới Thêm Vào</returns>
        public static Int32 Add(CateFaqEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return CateFaqDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa CateFaq
        /// </summary>
        /// <param name="entity">CateFaqEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(CateFaqEntity entity)
        {
            checkExist(entity.PK_iFaqCateID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return CateFaqDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá CateFaq
        /// </summary>
        /// <param name="PK_iFaqCateID">Int32 : PK_iFaqCateID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iFaqCateID)
        {
            checkExist(PK_iFaqCateID);
            return CateFaqDAL.Remove(PK_iFaqCateID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iFaqCateID)
        {
            CateFaqEntity oCateFaq=CateFaqDAL.GetOne(PK_iFaqCateID);
            if(oCateFaq==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">CateFaqEntity: entity</param>
        private static void checkLogic(CateFaqEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sCateName))
				throw new Exception(EX_SCATENAME_EMPTY);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">CateFaqEntity: CateFaqEntity</param>
        private static void checkDuplicate(CateFaqEntity entity,bool checkPK)
        {
            /* 
            Example
            List<CateFaqEntity> list = CateFaqDAL.GetAll();
            if (list.Exists(
                delegate(CateFaqEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iFaqCateID != entity.PK_iFaqCateID;
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
        /// <param name="entity">CateFaqEntity:entity</param>
        private static void checkFK(CateFaqEntity entity)
        {            
        }
        #endregion
    }
}
