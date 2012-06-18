/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:4/11/2009 4:52:29 PM
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
    public class PollCategoryBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại PollCategory Này";
		private static string EX_IPOLLID_INVALID="Bình chọn ID không hợp lệ";
		private static string EX_ICATEGORYID_INVALID="Nhóm tin ID không hợp lệ";
		private static string EX_ID_INVALID="PollCategory ID không hợp lệ";
        private static string EX_EXISTED = "Bản ghi đã tồn tại";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get PollCategory Theo ID
        /// </summary>
        /// <param name="iPollCategoryID">Int32:PollCategory ID</param>
        /// <returns>PollCategoryEntity</returns>        
        public static PollCategoryEntity GetOne(Int32 iPollCategoryID)
        {
            
			if(iPollCategoryID<=0)
				throw new Exception(EX_ID_INVALID);
            return PollCategoryDAL.GetOne(iPollCategoryID);
        }
        /// <summary>
        /// Lấy về List các PollCategory
        /// </summary>
        /// <returns>List PollCategoryEntity:List PollCategory Cần lấy</returns>
        public static List<PollCategoryEntity> GetAll()
        {
            return PollCategoryDAL.GetAll();
        }
        public static List<PollCategoryEntity> GetByFK(int iCategoryID, int iPollID)
        {
            return PollCategoryDAL.GetByiCategoryID(iCategoryID).FindAll(
                delegate(PollCategoryEntity entity)
                {
                    return entity.iPollID == iPollID;
                }
            );
        }
        public static List<PollCategoryEntity> GetByiPollID(Int32 iPollID)
		{
			if(iPollID<=0)
				throw new Exception(EX_IPOLLID_INVALID);
			return PollCategoryDAL.GetByiPollID(iPollID);
		}public static List<PollCategoryEntity> GetByiCategoryID(Int32 iCategoryID)
		{
			if(iCategoryID<=0)
				throw new Exception(EX_ICATEGORYID_INVALID);
			return PollCategoryDAL.GetByiCategoryID(iCategoryID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới PollCategory
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của PollCategory Mới Thêm Vào</returns>
        public static Int32 Add(PollCategoryEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return PollCategoryDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa PollCategory
        /// </summary>
        /// <param name="entity">PollCategoryEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(PollCategoryEntity entity)
        {
            checkExist(entity.iPollCategoryID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return PollCategoryDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá PollCategory
        /// </summary>
        /// <param name="iPollCategoryID">Int32 : iPollCategoryID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 iPollCategoryID)
        {
            checkExist(iPollCategoryID);
            return PollCategoryDAL.Remove(iPollCategoryID);
        }
        public static bool RemoveByiCategoryID(Int32 iCategoryID)
        {
            List<PollCategoryEntity> lst = PollCategoryDAL.GetByiCategoryID(iCategoryID);
            bool totalResult = true;
            foreach (PollCategoryEntity entity in lst)
            {
                bool result = PollCategoryDAL.Remove(entity.iPollCategoryID);
                if (!result) totalResult = false;
            }
            return totalResult;
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 iPollCategoryID)
        {
            PollCategoryEntity oPollCategory=PollCategoryDAL.GetOne(iPollCategoryID);
            if(oPollCategory==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">PollCategoryEntity: entity</param>
        private static void checkLogic(PollCategoryEntity entity)
        {   
			if (entity.iPollID < 0)
				throw new Exception(EX_IPOLLID_INVALID);
			if (entity.iCategoryID < 0)
				throw new Exception(EX_ICATEGORYID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">PollCategoryEntity: PollCategoryEntity</param>
        private static void checkDuplicate(PollCategoryEntity entity,bool checkPK)
        {
            List<PollCategoryEntity> list = PollCategoryDAL.GetAll();
            if (list.Exists(
                delegate(PollCategoryEntity oldEntity)
                {
                    bool result = oldEntity.iCategoryID == entity.iCategoryID && oldEntity.iPollID == entity.iPollID;
                    if(checkPK)
                        result=result && oldEntity.iPollCategoryID != entity.iPollCategoryID;
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
        /// <param name="entity">PollCategoryEntity:entity</param>
        private static void checkFK(PollCategoryEntity entity)
        {            
			PollEntity oPoll = PollDAL.GetOne(entity.iPollID);
			if (oPoll==null)
			{
				throw new Exception("Không tìm thấy bình chọn này");
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
