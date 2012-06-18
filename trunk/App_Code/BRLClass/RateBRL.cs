/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/9/2009 10:35:00 AM
------------------------------------------------------*/
/*
 * File name  : RateBRL.cs
 * Descriptor : Thực hiện kiểm tra nghiệp vụ đối với Rate
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
    public class RateBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Đánh giá Này";
		private static string EX_INEWSID_INVALID="Tin tức ID không hợp lệ";
		private static string EX_IRATE_INVALID="Đánh giá không hợp lệ";
		private static string EX_ICOUNT_INVALID="Số lượt đánh giá không hợp lệ";
        private static string EX_ID_INVALID = "Đánh giá ID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Rate Theo ID
        /// </summary>
        /// <param name="iRateID">Int32:Rate ID</param>
        /// <returns>RateEntity</returns>        
        public static RateEntity GetOne(Int32 iRateID)
        {
            if (iRateID <= 0)
                throw new Exception(EX_ID_INVALID);
            return RateDAL.GetOne(iRateID);
        }
        /// <summary>
        /// Lấy về List các Rate
        /// </summary>
        /// <returns>List RateEntity:List Rate Cần lấy</returns>
        public static List<RateEntity> GetAll()
        {
            return RateDAL.GetAll();
        }
        /// <summary>
        /// Kiểm tra xem đã có rate nào của news này chưa
        /// </summary>
        /// <param name="newsID"></param>
        /// <returns></returns>
        public static bool Exist(int newsID)
        {
            if (newsID <= 0)
                throw new Exception(EX_INEWSID_INVALID);
            List<RateEntity> list = RateDAL.GetByiNewsID(newsID);
            int count = list.Count;
            list.Clear();
            return count > 0;

        }
        public static List<RateEntity> GetByiNewsID(int newsID)
        {
            if (newsID <= 0)
                throw new Exception(EX_INEWSID_INVALID);
            return RateDAL.GetByiNewsID(newsID);
        }
        /// <summary>
        /// Kiểm tra và thêm mới Rate
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Rate Mới Thêm Vào</returns>
        public static Int32 Add(RateEntity entity)
        {
            checkLogic(entity);
            checkFK(entity);
            return RateDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Rate
        /// </summary>
        /// <param name="entity">RateEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(RateEntity entity)
        {
            checkExist(entity);
            checkLogic(entity);
            checkFK(entity);
            return RateDAL.Edit(entity);
        }
        public static bool Edit(int rate,int newsID)
        {
            if (rate <= 0)
                throw new Exception(EX_IRATE_INVALID);
            if (newsID <= 0)
                throw new Exception(EX_INEWSID_INVALID);
            List<RateEntity> list = RateDAL.GetByiNewsID(newsID);
            if (list.Count <= 0)
                throw new Exception(EX_NOT_EXIST);
            RateEntity oRate = list[0];
            oRate.iCount++;
            oRate.iRate += rate;
            return RateDAL.Edit(oRate);
        }
        /// <summary>
        /// Kiểm tra và xoá Rate
        /// </summary>
        /// <param name="entity">RateEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(RateEntity entity)
        {
            checkExist(entity);
            checkFK(entity);
            return RateDAL.Remove(entity.iRateID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(RateEntity entity)
        {
            RateEntity oRate=RateDAL.GetOne(entity.iRateID);
            if(oRate==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">RateEntity: entity</param>
        private static void checkLogic(RateEntity entity)
        {   
			if (entity.iNewsID < 0)
				throw new Exception(EX_INEWSID_INVALID);
			if (entity.iRate < 0)
				throw new Exception(EX_IRATE_INVALID);
			if (entity.iCount < 0)
				throw new Exception(EX_ICOUNT_INVALID);
        }
        /// <summary>
        /// Kiểm tra tồn tại khóa ngoại
        /// </summary>
        /// <param name="entity">RateEntity:entity</param>
        private static void checkFK(RateEntity entity)
        {            
			NewsEntity oNews = NewsDAL.GetOne(entity.iNewsID);
			if (oNews==null)
			{
				throw new Exception("Không tìm thấy tin tức");
			}
        }
        #endregion
    }
}
