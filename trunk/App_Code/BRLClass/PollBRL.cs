/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/9/2009 10:35:00 AM
------------------------------------------------------*/
/*
 * File name  : PollBRL.cs
 * Descriptor : Thực hiện kiểm tra nghiệp vụ đối với Poll
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
    public class PollBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Bình chọn Này";
		private static string EX_SQUESTION_EMPTY="Câu hỏi không được để trống";
		private static string EX_INEWSID_INVALID="Tin tức ID không hợp lệ";
        private static string EX_ID_INVALIDI="Bình chọn ID không hợp lệ";
        private static string EX_POLL_EXISTED = "Bình chọn này đã tồn tại";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Poll Theo ID
        /// </summary>
        /// <param name="iPollID">Int32:Poll ID</param>
        /// <returns>PollEntity</returns>        
        public static PollEntity GetOne(Int32 iPollID)
        {
            if(iPollID<=0)
                throw new Exception(EX_INEWSID_INVALID);
            return PollDAL.GetOne(iPollID);
        }
        /// <summary>
        /// Lấy về List các Poll
        /// </summary>
        /// <returns>List PollEntity:List Poll Cần lấy</returns>
        public static List<PollEntity> GetAll()
        {
            return PollDAL.GetAll();
        }
        public static List<PollEntity> GetByNewsID(int newsID)
        {
            if (newsID <= 0)
                throw new Exception(EX_INEWSID_INVALID);
            return PollDAL.GetByiNewsID(newsID);
        }
        public static List<PollEntity> GetByCategoryID(Int32 iCategoryID)
        {
            List<PollCategoryEntity> lstPollCat = PollCategoryDAL.GetByiCategoryID(iCategoryID);
            List<PollEntity> lstPoll = new List<PollEntity>();
            lstPollCat.ForEach(
                delegate(PollCategoryEntity oPollCat)
                {
                    lstPoll.Add(PollDAL.GetOne(oPollCat.iPollID));
                }
            );
            return lstPoll;
        }
        /// <summary>
        /// Kiểm tra và thêm mới Poll
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Poll Mới Thêm Vào</returns>
        public static Int32 Add(PollEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, true);
            //checkFK(entity);
            return PollDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Poll
        /// </summary>
        /// <param name="entity">PollEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(PollEntity entity)
        {
            checkExist(entity);
            checkLogic(entity);
            checkDuplicate(entity, false);
            //checkFK(entity);
            return PollDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Poll
        /// </summary>
        /// <param name="entity">PollEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(PollEntity entity)
        {
            checkExist(entity);
            //checkFK(entity);
            return PollDAL.Remove(entity.iPollID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(PollEntity entity)
        {
            PollEntity oPoll=PollDAL.GetOne(entity.iPollID);
            if(oPoll==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">PollEntity: entity</param>
        private static void checkLogic(PollEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sQuestion))
				throw new Exception(EX_SQUESTION_EMPTY);
			if (entity.iNewsID < 0)
				throw new Exception(EX_INEWSID_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">PollEntity: PollEntity</param>
        private static void checkDuplicate(PollEntity entity,bool CheckInsert)
        {
            List<PollEntity> list = PollDAL.GetAll();
            if (list.Exists(
                delegate(PollEntity oldEntity)
                {
                    bool result= oldEntity.sQuestion.Equals(entity.sQuestion, StringComparison.OrdinalIgnoreCase);
                    if (!CheckInsert)
                        result = result && oldEntity.iPollID != entity.iPollID;
                    return result;
                }
            ))
            {
                list.Clear();
                throw new Exception(EX_POLL_EXISTED);
            }
        }
        /// <summary>
        /// Kiểm tra tồn tại khóa ngoại
        /// </summary>
        /// <param name="entity">PollEntity:entity</param>
        private static void checkFK(PollEntity entity)
        {            
			NewsEntity oNews = NewsDAL.GetOne(entity.iNewsID);
			if (oNews==null)
			{
				throw new Exception("Không tìm thấy tin tức này");
			}
        }
        #endregion
    }
}
