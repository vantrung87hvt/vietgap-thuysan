/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/18/2012 8:05:15 PM
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
    public class FaqAnswersBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại FaqAnswers Này";
		private static string EX_FK_IFAQID_INVALID="FK_iFaqID không hợp lệ";
		private static string EX_SCONTENT_EMPTY="sContent không được để trống";
		private static string EX_ID_INVALID="PK_iFaqAnswerID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get FaqAnswers Theo ID
        /// </summary>
        /// <param name="PK_iFaqAnswerID">Int64:FaqAnswers ID</param>
        /// <returns>FaqAnswersEntity</returns>        
        public static FaqAnswersEntity GetOne(Int64 PK_iFaqAnswerID)
        {
            
			if(PK_iFaqAnswerID<=0)
				throw new Exception(EX_ID_INVALID);
            return FaqAnswersDAL.GetOne(PK_iFaqAnswerID);
        }
        /// <summary>
        /// Lấy về List các FaqAnswers
        /// </summary>
        /// <returns>List FaqAnswersEntity:List FaqAnswers Cần lấy</returns>
        public static List<FaqAnswersEntity> GetAll()
        {
            return FaqAnswersDAL.GetAll();
        }
        public static List<FaqAnswersEntity> GetByFK_iFaqID(Int64 FK_iFaqID)
		{
			if(FK_iFaqID<=0)
				throw new Exception(EX_FK_IFAQID_INVALID);
			return FaqAnswersDAL.GetByFK_iFaqID(FK_iFaqID);
		}
        /// <summary>
        /// Kiểm tra và thêm mới FaqAnswers
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của FaqAnswers Mới Thêm Vào</returns>
        public static Int32 Add(FaqAnswersEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return FaqAnswersDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa FaqAnswers
        /// </summary>
        /// <param name="entity">FaqAnswersEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(FaqAnswersEntity entity)
        {
            checkExist(entity.PK_iFaqAnswerID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return FaqAnswersDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá FaqAnswers
        /// </summary>
        /// <param name="PK_iFaqAnswerID">Int64 : PK_iFaqAnswerID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int64 PK_iFaqAnswerID)
        {
            checkExist(PK_iFaqAnswerID);
            return FaqAnswersDAL.Remove(PK_iFaqAnswerID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int64 PK_iFaqAnswerID)
        {
            FaqAnswersEntity oFaqAnswers=FaqAnswersDAL.GetOne(PK_iFaqAnswerID);
            if(oFaqAnswers==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">FaqAnswersEntity: entity</param>
        private static void checkLogic(FaqAnswersEntity entity)
        {   
			if (entity.FK_iFaqID < 0)
				throw new Exception(EX_FK_IFAQID_INVALID);
			if (String.IsNullOrEmpty(entity.sContent))
				throw new Exception(EX_SCONTENT_EMPTY);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">FaqAnswersEntity: FaqAnswersEntity</param>
        private static void checkDuplicate(FaqAnswersEntity entity,bool checkPK)
        {
            /* 
            Example
            List<FaqAnswersEntity> list = FaqAnswersDAL.GetAll();
            if (list.Exists(
                delegate(FaqAnswersEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iFaqAnswerID != entity.PK_iFaqAnswerID;
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
        /// <param name="entity">FaqAnswersEntity:entity</param>
        private static void checkFK(FaqAnswersEntity entity)
        {            
			FaqEntity oFaq = FaqDAL.GetOne(entity.FK_iFaqID);
			if (oFaq==null)
			{
				throw new Exception("Không tìm thấy :FK_iFaqID");
			}
        }
        #endregion
    }
}
