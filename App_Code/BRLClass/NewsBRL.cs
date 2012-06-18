/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/7/2009 10:50:15 PM
------------------------------------------------------*/
/*
 * File name  : NewsBRL.cs
 * Descriptor : Thực hiện kiểm tra nghiệp vụ đối với News
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
    public class NewsBRL
    {
        #region Init
        private static string EX_NOT_EXIST = "Không Tồn Tại Tin tức Này";
        private static string EX_ID_INVALID = "Tin tức ID không hợp lệ";
        private static string EX_USERID_INVALID = "User ID không hợp lệ";
        private static string EX_DATE_INVALID = "Ngày đăng tin không hợp lệ";
        private static string EX_VIEW_INVALID = "Tin tức ID không hợp lệ";
        private static string EX_TITLE_EMPTY = "Tiêu đề không được để trống";
        private static string EX_CONTENT_EMPTY = "Tiêu đề không được để trống";
        private static string EX_USERID_NOTFOUND = "Không tìm thấy User này";
        private static string EX_NEWS_EXISTED = "Tin tức có nội dung này đã tồn tại";
        private static string EX_REMOVE_INVALID = "Không thể xóa tin tức,nếu không muốn hiển thị mời bạn bỏ kiểm duyệt tin";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get News Theo ID
        /// </summary>
        /// <param name="iNewsID">Int32:News ID</param>
        /// <returns>NewsEntity</returns>        
        public static NewsEntity GetOne(Int32 iNewsID)
        {
            if (iNewsID < 0)
                throw new Exception(EX_ID_INVALID);
            return NewsDAL.GetOne(iNewsID);
        }
        public static List<NewsEntity> GetAll()
        {
            return NewsDAL.GetAll();
        }
        public static List<NewsEntity> GetVerified()
        {
            return NewsDAL.GetAll().FindAll(
                delegate(NewsEntity oNews)
                {
                    return oNews.bVerified == true;
                }
            );
        }
        public static List<NewsEntity> GetByUserID(Int32 iUserID)
        {
            if (iUserID <= 0)
                throw new Exception(EX_USERID_INVALID);
            return NewsDAL.GetByiUserID(iUserID);
        }
        public static List<NewsEntity> GetMostView()
        {
            List<NewsEntity> list = NewsBRL.GetVerified();
            list.Sort(
                delegate(NewsEntity firstEntity, NewsEntity secondEntity)
                {
                    return secondEntity.iViews.CompareTo(firstEntity.iViews);
                }
            );
            return list;
        }
        public static List<NewsEntity> GetTop3MostView()
        {
            List<NewsEntity> list = NewsBRL.GetVerified();
            list.Sort(
                delegate(NewsEntity firstEntity, NewsEntity secondEntity)
                {
                    return secondEntity.iViews.CompareTo(firstEntity.iViews);
                }
            );
            if (list.Count < 3)
                return list;
            else
            {
                list.RemoveRange(3, list.Count - 3);
                return list;
            }
        }
        public static List<NewsEntity> GetRecent()
        {
            List<NewsEntity> list = NewsBRL.GetVerified();
            list.Sort(
                delegate(NewsEntity firstEntity, NewsEntity secondEntity)
                {
                    return secondEntity.tDate.CompareTo(firstEntity.tDate);
                }
            );
            return list;
        }
        public static List<NewsEntity> GetByTag(String tags)
        {
            String[] arrTag = tags.Split(',');
            List<NewsEntity> list = NewsBRL.GetVerified();
            list.FindAll(
                delegate(NewsEntity oNews)
                {
                    foreach (String strTag in arrTag)
                        return oNews.sTag.Contains(strTag);
                    return false;
                }
            );
            return list;
        }

        public static List<NewsEntity> GetMostViewByCategoryID(Int32 iCategoryID)
        {            
            List<NewsEntity> lstNews = NewsBRL.GetVerified();
            List<NewsEntity> lstNewsout = new List<NewsEntity>();
            lstNews.Sort(
                delegate(NewsEntity firstEntity, NewsEntity secondEntity)
                {
                    return secondEntity.iViews.CompareTo(firstEntity.iViews);
                }
            );           
            lstNews.ForEach(
                delegate(NewsEntity oNews)
                {
                    List<NewsCategoryEntity> nc = NewsCategoryBRL.GetByiNewsID(oNews.iNewsID);
                    if (nc.Count>0)
                    {
                        for (int i = 0; i < nc.Count; i++)
                        {
                            if (nc[0].iCategoryID == iCategoryID)
                            {
                                lstNewsout.Add(oNews);
                                return;
                            }
                        }                           
                    }
                }
            );
            return lstNewsout;
        }
        public static List<NewsEntity> GetByCategoryID(Int32 iCategoryID)
        {
            List<NewsCategoryEntity> lstNewsCat = NewsCategoryDAL.GetByiCategoryID(iCategoryID);
            List<NewsEntity> lstNews=new List<NewsEntity>();
            lstNewsCat.ForEach(
                delegate(NewsCategoryEntity oNewsCat)
                {
                    lstNews.Add(NewsDAL.GetOne(oNewsCat.iNewsID));
                }
            );
            
            return lstNews;
        }
        /// <summary>
        /// Kiểm tra và thêm mới News
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Khách Hàng Mới Thêm Vào</returns>
        public static Int32 Add(NewsEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, true);
            return NewsDAL.Add(entity);
        }
        public static Int32 Add(int iUserID,string sTitle, string sDesc, string sImage, string sTag, DateTime tNgaydang, string sContent, bool bVerified, params int[] arrCategory)
        {
            NewsEntity entity = new NewsEntity();
            entity.sTitle = sTitle;
            entity.sDesc = sDesc;
            entity.sImage = sImage;
            entity.sTag = sTag;
            entity.tDate = tNgaydang;
            entity.sContent = sContent;
            entity.bVerified = bVerified;
            entity.iViews = 0;
            entity.iUserID = iUserID;
            checkLogic(entity);
            checkDuplicate(entity, true);
            int iNewsID = NewsDAL.Add(entity);
            foreach (int iCatID in arrCategory)
            {
                NewsCategoryEntity oNewsCat = new NewsCategoryEntity();
                oNewsCat.iNewsID = iNewsID;
                oNewsCat.iCategoryID = iCatID;
                NewsCategoryDAL.Add(oNewsCat);
            }
            return iNewsID;
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa News
        /// </summary>
        /// <param name="entity">NewsEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(NewsEntity entity)
        {
            checkExist(entity);
            checkLogic(entity);
            checkDuplicate(entity, false);
            return NewsDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa News
        /// </summary>
        /// <param name="iNewsID"></param>
        /// <param name="sTitle"></param>
        /// <param name="sDesc"></param>
        /// <param name="sImage"></param>
        /// <param name="sTag"></param>
        /// <param name="tNgaydang"></param>
        /// <param name="sContent"></param>
        /// <param name="bVerified"></param>
        /// <param name="arrCategory"></param>
        /// <returns></returns>
        public static bool Edit(int iNewsID, string sTitle, string sDesc, string sImage, string sTag, DateTime tNgaydang, string sContent, bool bVerified, params int[] arrCategory)
        {
            NewsEntity entity = NewsDAL.GetOne(iNewsID);
            if (entity == null)
                throw new Exception(EX_NOT_EXIST);
            entity.sTitle = sTitle;
            entity.sDesc = sDesc;
            entity.sImage = sImage;
            entity.sTag = sTag;
            entity.tDate = tNgaydang;
            entity.sContent = sContent;
            entity.bVerified = bVerified;
            checkLogic(entity);
            checkDuplicate(entity, false);
            updateNewsCategory(iNewsID, arrCategory);
            return NewsDAL.Edit(entity);
        }
        public static bool SetVerify(int newsID,bool verify)
        {
            NewsEntity entity = NewsDAL.GetOne(newsID);
            if (entity == null)
                throw new Exception(EX_NOT_EXIST);
            entity.bVerified = verify;
            return NewsDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá News
        /// </summary>
        /// <param name="entity">NewsEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(NewsEntity entity)
        {
            if(entity.iNewsID<=0)
                throw new Exception(EX_ID_INVALID);
            List<RateEntity> lstRate = RateDAL.GetByiNewsID(entity.iNewsID);
            if (lstRate != null && lstRate.Count > 0)
            {
                foreach (RateEntity rateEntity in lstRate)
                    RateDAL.Remove(rateEntity.iRateID);
            }
            //
            List<PollEntity> lstPoll = PollDAL.GetByiNewsID(entity.iNewsID);
            if (lstPoll != null && lstPoll.Count > 0)
            {
                foreach (PollEntity poll in lstPoll)
                    PollDAL.Remove(poll.iPollID);
            }
            //
            List<FeedbackEntity> lstFeedback = FeedbackDAL.GetByiNewsID(entity.iNewsID);
            if (lstFeedback != null && lstFeedback.Count > 0)
            {
                foreach (FeedbackEntity feedBack in lstFeedback)
                    FeedbackDAL.Remove(feedBack.iFeedbackID);
            }
            //
            List<NewsCategoryEntity> lstNC = NewsCategoryDAL.GetByiNewsID(entity.iNewsID);
            if (lstNC != null && lstNC.Count > 0)
            {
                foreach (NewsCategoryEntity newCat in lstNC)
                    NewsCategoryDAL.Remove(newCat.iNewsCategoryID);
            }
            //
            return NewsDAL.Remove(entity.iNewsID);
        }
        #endregion
        #region Private Methods

        /// <summary>
        /// Update dữ liệu bảng NewsCategory
        /// </summary>
        /// <param name="newsID">int: Tin tức ID</param>
        /// <param name="arrCategory">int[]: Mảng số nguyên Nhóm tin ID</param>
        private static void updateNewsCategory(int newsID, params int[] arrCategory)
        {
            
            List<NewsCategoryEntity> lstNewsCategory = NewsCategoryDAL.GetByiNewsID(newsID);
            foreach (int iCategoryID in arrCategory)
            {
                try
                {
                    lstNewsCategory.ForEach(
                        delegate(NewsCategoryEntity oNewsCategory)
                        {
                            if (iCategoryID != oNewsCategory.iCategoryID)
                            {
                                NewsCategoryDAL.Remove(oNewsCategory.iNewsCategoryID);
                            }
                        }
                    );
                }
                catch { }
            }
            lstNewsCategory.Clear();
            foreach (int iCategoryID in arrCategory)
            {
                try
                {
                    NewsCategoryEntity newsCatEntity = new NewsCategoryEntity();
                    newsCatEntity.iNewsID = newsID;
                    newsCatEntity.iCategoryID = iCategoryID;
                    NewsCategoryDAL.Add(newsCatEntity);
                }
                catch { }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        private static void checkExist(NewsEntity entity)
        {
            NewsEntity oNews = NewsDAL.GetOne(entity.iNewsID);
            if (oNews == null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">NewsEntity: Tin tức Entity</param>
        private static void checkLogic(NewsEntity entity)
        {
            if (String.IsNullOrEmpty(entity.sTitle))
                throw new Exception(EX_TITLE_EMPTY);
            if (String.IsNullOrEmpty(entity.sContent))
                throw new Exception(EX_CONTENT_EMPTY);
            if (entity.iUserID < 0)
                throw new Exception(EX_USERID_INVALID);
            if (entity.iViews < 0)
                throw new Exception(EX_VIEW_INVALID);
            if (entity.tDate > DateTime.Now)
                throw new Exception(EX_DATE_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">NewsEntity: NewsEntity</param>
        private static void checkDuplicate(NewsEntity entity, bool CheckInsert)
        {
            List<NewsEntity> list = NewsDAL.GetAll();
            if (list.Exists(
                delegate(NewsEntity oldEntity)
                {
                    bool result= oldEntity.sContent.Equals(entity.sContent, StringComparison.OrdinalIgnoreCase);
                    if(!CheckInsert)
                        result=result && oldEntity.iNewsID!= entity.iNewsID;
                    return result;
                }
            ))
            {
                list.Clear();
                throw new Exception(EX_NEWS_EXISTED);
            }

        }
        /// <summary>
        /// Kiểm tra tồn tại khóa ngoại
        /// </summary>
        /// <param name="entity">NewsEntity:entity</param>
        private static void checkFK(NewsEntity entity)
        {
            UserEntity oUser = UserDAL.GetOne(entity.iUserID);
            if (oUser != null)
            {
                throw new Exception(EX_USERID_NOTFOUND);
            }
        }
        #endregion
    }
}
