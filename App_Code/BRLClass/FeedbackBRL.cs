/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/7/2009 10:50:15 PM
------------------------------------------------------*/
/*
 * File name  : FeedbackBRL.cs
 * Descriptor : Thực hiện kiểm tra nghiệp vụ đối với Feedback
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
    public class FeedbackBRL
    {
        #region Init
        private static string EX_NOT_EXIST = "Không Tồn Tại Phản hồi Này";
        private static string EX_ID_INVALID = "Phản hồi ID không hợp lệ";
        private static string EX_EMAIL_EMPTY = "Email không được để trống";
        private static string EX_NAME_EMPTY = "Tên không được để trống";
        private static string EX_TITLE_EMPTY = "Tiêu đề không được để trống";
        private static string EX_CONTENT_EMPTY = "Nội dung không được để trống";
        private static string EX_NEWSID_INVALID = "Tin tức ID không hợp lệ";
        private static string EX_NEWSID_NOTFOUND = "Không tìm thấy tin tức này";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Feedback Theo ID
        /// </summary>
        /// <param name="iFeedbackID">Int32:Feedback ID</param>
        /// <returns>FeedbackEntity</returns>        
        public static FeedbackEntity GetOne(Int32 iFeedbackID)
        {
            if (iFeedbackID < 0)
                throw new Exception(EX_ID_INVALID);
            return FeedbackDAL.GetOne(iFeedbackID);
        }
        public static List<FeedbackEntity> GetAll()
        {
            return FeedbackDAL.GetAll();
        }
        /// <summary>
        /// Lấy các phản hồi đã kiểm duyệt,sắp xếp theo ngày đăng giảm dần
        /// </summary>
        /// <returns>List FeedbackEntity : Các phản hồiđã kiểm duyệt</returns>
        public static List<FeedbackEntity> GetVerified()
        {
            List<FeedbackEntity> list = FeedbackDAL.GetAll();
            list=list.FindAll(
                delegate(FeedbackEntity entity)
                {
                    return entity.bVerified == true;
                }
            );
            list.Sort(FeedbackEntity.COMPARISON_tDate);
            list.Reverse();
            return list;
        }
        /// <summary>
        /// Lấy các phản hồi đã kiểm duyệt theo tin,sắp xếp theo ngày đăng giảm dần
        /// </summary>
        /// <param name="newsID">int: tin tức cần lấy phản hồi</param>
        /// <returns>List FeedbackEntity : Các phản hồi theo tin đã kiểm duyệt</returns>
        public static List<FeedbackEntity> GetVerified(int newsID)
        {
            if (newsID <= 0)
                throw new Exception(EX_NEWSID_INVALID);
            List<FeedbackEntity> list= FeedbackDAL.GetByiNewsID(newsID);
            list=list.FindAll(
                delegate(FeedbackEntity entity)
                {
                    return entity.bVerified == true;
                }
            );
            list.Sort(FeedbackEntity.COMPARISON_tDate);
            list.Reverse();
            return list;
        }
        /// <summary>
        /// Kiểm tra và thêm mới Feedback
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Feedback Mới Thêm Vào</returns>
        public static Int32 Add(FeedbackEntity entity)
        {
            checkLogic(entity);
            checkFK(entity);
            return FeedbackDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Feedback
        /// </summary>
        /// <param name="entity">FeedbackEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(FeedbackEntity entity)
        {
            checkExist(entity);
            checkFK(entity);
            checkLogic(entity);
            return FeedbackDAL.Edit(entity);
        }
        public static bool SetVerify(int feedbackID, bool verify)
        {
            FeedbackEntity entity = FeedbackDAL.GetOne(feedbackID);
            if (entity == null)
                throw new Exception(EX_NOT_EXIST);
            entity.bVerified = verify;
            return FeedbackDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Feedback
        /// </summary>
        /// <param name="entity">FeedbackEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(FeedbackEntity entity)
        {
            checkExist(entity);
            return FeedbackDAL.Remove(entity.iFeedbackID);
        }
        
        #endregion
        #region Private Methods
        /// <summary>
        /// Kiểm tra tồn tại bản ghi
        /// </summary>
        /// <param name="entity">FeedbackEntity: entity</param>
        private static void checkExist(FeedbackEntity entity)
        {
            FeedbackEntity fbEntity = FeedbackDAL.GetOne(entity.iFeedbackID);
            if (fbEntity == null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">FeedbackEntity: Tin tức Entity</param>
        private static void checkLogic(FeedbackEntity entity)
        {
            if (String.IsNullOrEmpty(entity.sContent))
                throw new Exception(EX_CONTENT_EMPTY);
            if (String.IsNullOrEmpty(entity.sEmail))
                throw new Exception(EX_EMAIL_EMPTY);
            if (String.IsNullOrEmpty(entity.sName))
                throw new Exception(EX_NAME_EMPTY);
            if (String.IsNullOrEmpty(entity.sTitle))
                throw new Exception(EX_TITLE_EMPTY);
            if (entity.iNewsID < 0)
                throw new Exception(EX_NEWSID_INVALID);
        }
        
        /// <summary>
        /// Kiểm tra tồn tại khóa ngoại
        /// </summary>
        /// <param name="entity">FeedbackEntity:entity</param>
        private static void checkFK(FeedbackEntity entity)
        {
            NewsEntity oNews = NewsDAL.GetOne(entity.iNewsID);
            if (oNews == null)
            {
                throw new Exception(EX_NEWSID_NOTFOUND);
            }
        }
        #endregion
    }
}
