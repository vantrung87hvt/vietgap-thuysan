/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/9/2009 10:35:00 AM
------------------------------------------------------*/
/*
 * File name  : PollAnswerBRL.cs
 * Descriptor : Thực hiện kiểm tra nghiệp vụ đối với PollAnswer
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
    public class PollAnswerBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại câu trả lời Này";
		private static string EX_SANSWER_EMPTY="Câu trả lời không được để trống";
		private static string EX_ICOUNT_INVALID="số lượt bình chọn không hợp lệ";
		private static string EX_IPOLLID_INVALID="Bình chọn ID không hợp lệ";
        private static string EX_ID_INVALID = "Câu trả lời ID không hợp lệ";
        private static string EX_ANSWER_EXISTED = "Câu trả lời này đã tồn tại";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get PollAnswer Theo ID
        /// </summary>
        /// <param name="iAnswerID">Int32:PollAnswer ID</param>
        /// <returns>PollAnswerEntity</returns>        
        public static PollAnswerEntity GetOne(Int32 iAnswerID)
        {
            if (iAnswerID <= 0)
                throw new Exception(EX_ID_INVALID);
            return PollAnswerDAL.GetOne(iAnswerID);
        }
        /// <summary>
        /// Lấy về List các PollAnswer
        /// </summary>
        /// <returns>List PollAnswerEntity:List PollAnswer Cần lấy</returns>
        public static List<PollAnswerEntity> GetAll()
        {
            return PollAnswerDAL.GetAll();
        }
        public static List<PollAnswerEntity> GetByPollID(int pollID)
        {
            if (pollID <= 0)
                throw new Exception(EX_IPOLLID_INVALID);
            return PollAnswerDAL.GetByiPollID(pollID);
        }
        /// <summary>
        /// Kiểm tra và thêm mới PollAnswer
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của PollAnswer Mới Thêm Vào</returns>
        public static Int32 Add(PollAnswerEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return PollAnswerDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa PollAnswer
        /// </summary>
        /// <param name="entity">PollAnswerEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(PollAnswerEntity entity)
        {
            checkExist(entity);
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return PollAnswerDAL.Edit(entity);
        }
        public static bool SetAnswer(int answerID)
        {
            if (answerID <= 0)
                throw new Exception(EX_ID_INVALID);
            PollAnswerEntity entity = PollAnswerDAL.GetOne(answerID);
            entity.iCount++;
            return PollAnswerDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá PollAnswer
        /// </summary>
        /// <param name="entity">PollAnswerEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(PollAnswerEntity entity)
        {
            checkExist(entity);
            return PollAnswerDAL.Remove(entity.iAnswerID);
        }
        public static bool RemoveByPollID(int pollID)
        {
            if (pollID <= 0)
                throw new Exception(EX_IPOLLID_INVALID);
            bool totalResult = true;
            List<PollAnswerEntity> list = PollAnswerDAL.GetByiPollID(pollID);
            foreach (PollAnswerEntity entity in list)
            {
                bool result=PollAnswerDAL.Remove(entity.iAnswerID);
                if (result == false) totalResult = false;
            }
            return totalResult;
        }
        #endregion
        #region Private Methods
        private static void checkExist(PollAnswerEntity entity)
        {
            PollAnswerEntity oPollAnswer=PollAnswerDAL.GetOne(entity.iAnswerID);
            if(oPollAnswer==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">PollAnswerEntity: entity</param>
        private static void checkLogic(PollAnswerEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sAnswer))
				throw new Exception(EX_SANSWER_EMPTY);
			if (entity.iCount < 0)
				throw new Exception(EX_ICOUNT_INVALID);
			if (entity.iPollID < 0)
				throw new Exception(EX_IPOLLID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">PollAnswerEntity: PollAnswerEntity</param>
        private static void checkDuplicate(PollAnswerEntity entity,bool CheckInsert)
        {
            List<PollAnswerEntity> list = PollAnswerDAL.GetAll();
            if (list.Exists(
                delegate(PollAnswerEntity oldEntity)
                {
                    bool result= oldEntity.sAnswer.Equals(entity.sAnswer, StringComparison.OrdinalIgnoreCase) && oldEntity.iPollID==entity.iPollID;
                    if (!CheckInsert)
                        result=result && oldEntity.iAnswerID != entity.iAnswerID;
                    return result;
                }
            ))
            {
                list.Clear();
                throw new Exception(EX_ANSWER_EXISTED);
            }
        }
        /// <summary>
        /// Kiểm tra tồn tại khóa ngoại
        /// </summary>
        /// <param name="entity">PollAnswerEntity:entity</param>
        private static void checkFK(PollAnswerEntity entity)
        {            
			PollEntity oPoll = PollDAL.GetOne(entity.iPollID);
			if (oPoll==null)
			{
				throw new Exception("Không tìm thấy bình chọn này");
			}
        }
        #endregion
    }
}
