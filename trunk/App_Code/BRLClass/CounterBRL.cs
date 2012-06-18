/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:28/10/2011 4:31:18 CH
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
using System.Globalization;
namespace INVI.Business
{
    public class CounterBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Counter Này";
		private static string EX_TDATE_INVALID="tDate không hợp lệ";
		private static string EX_ID_INVALID="PK_iCounterID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Counter Theo ID
        /// </summary>
        /// <param name="PK_iCounterID">Int64:Counter ID</param>
        /// <returns>CounterEntity</returns>        
        public static CounterEntity GetOne(int PK_iCounterID)
        {
            
			if(PK_iCounterID<=0)
				throw new Exception(EX_ID_INVALID);
            return CounterDAL.GetOne(PK_iCounterID);
        }
        /// <summary>
        /// Lấy về List các Counter
        /// </summary>
        /// <returns>List CounterEntity:List Counter Cần lấy</returns>
        public static List<CounterEntity> GetAll()
        {
            return CounterDAL.GetAll();
        }
        private static int getWeek(DateTime t)
        {
            CultureInfo myCI = new CultureInfo("en-US");
            System.Globalization.Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;

            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            int week = myCal.GetWeekOfYear(t, myCWR, myFirstDOW);
            return week;
        }
        /// <summary>
        ///Lấy số lượng truy cập ngày 
        ///
        /// </summary>
        /// <returns>Số lượng</returns>
        public static int VisitorInCurrentDay()
        {
            int i = 0;
            List<CounterEntity> lstCount = CounterDAL.GetAll();
            lstCount.ForEach(
                delegate(CounterEntity oCount)
                {
                    if (oCount.tDate.Day == DateTime.Now.Day)
                        i++;
                }
            );
            return i;
        }
        /// <summary>
        ///Lấy số lượng truy cập ngày hôm qua
        ///
        /// </summary>
        /// <returns>Số lượng</returns>
        public static int VisitorInTomorow()
        {
            int i = 0;
            List<CounterEntity> lstCount = CounterDAL.GetAll();
            lstCount.ForEach(
                delegate(CounterEntity oCount)
                {
                    if (oCount.tDate.Day == DateTime.Now.Day -1 )
                        i++;
                }
            );
            return i;
        }
        /// <summary>
        ///Lấy số lượng truy cập tuần 
        ///
        /// </summary>
        /// <returns>Số lượng</returns>
        public static int VisitorInCurrentWeek()
        {
            int i = 0;
            List<CounterEntity> lstCount = CounterDAL.GetAll();
            lstCount.ForEach(
                delegate(CounterEntity oCount)
                {                    
                   if ((oCount.tDate.Year == DateTime.Now.Year) && ( getWeek(oCount.tDate) == getWeek(DateTime.Now)))
                       i++;
                }
            );
            return i;
        }
        /// <summary>
        /// Lấy số lượng truy cập tuần trước
        /// </summary>
        /// <returns></returns>
        public static int VisitorInBeforeWeek()
        {
            int i = 0;
            List<CounterEntity> lstCount = CounterDAL.GetAll();
            lstCount.ForEach(
                delegate(CounterEntity oCount)
                {
                    if ((oCount.tDate.Year == DateTime.Now.Year) && (getWeek(oCount.tDate) == getWeek(DateTime.Now) - 1 ))
                        i++;
                }
            );
            return i;
        }
        /// <summary>
        /// Lấy số lượng truy cập trong tháng
        /// </summary>
        /// <returns></returns>
        public static int VisitorInCurrentMonth()
        {
            int i = 0;
            List<CounterEntity> lstCount = CounterDAL.GetAll();
            lstCount.ForEach(
                delegate(CounterEntity oCount)
                {
                    if (oCount.tDate.Month == DateTime.Now.Month)
                        i++;
                }
            );
            return i;
        }
        /// <summary>
        /// Lấy số lượng truy cập trong tháng trước
        /// </summary>
        /// <returns></returns>
        public static int VisitorInBeforeMonth()
        {
            int i = 0;
            List<CounterEntity> lstCount = CounterDAL.GetAll();
            lstCount.ForEach(
                delegate(CounterEntity oCount)
                {
                    if (oCount.tDate.Month == DateTime.Now.Month - 1)
                        i++;
                }
            );
            return i;
        }
        /// <summary>
        /// Kiểm tra và thêm mới Counter
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Counter Mới Thêm Vào</returns>
        public static Int32 Add(CounterEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return CounterDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Counter
        /// </summary>
        /// <param name="entity">CounterEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(CounterEntity entity)
        {
            checkExist(entity.PK_iCounterID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return CounterDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Counter
        /// </summary>
        /// <param name="PK_iCounterID">Int64 : PK_iCounterID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(int PK_iCounterID)
        {
            checkExist(PK_iCounterID);
            return CounterDAL.Remove(PK_iCounterID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(int PK_iCounterID)
        {
            CounterEntity oCounter=CounterDAL.GetOne(PK_iCounterID);
            if(oCounter==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">CounterEntity: entity</param>
        private static void checkLogic(CounterEntity entity)
        {   
			if (DateTime.Parse("1753-01-01")>entity.tDate)
				throw new Exception(EX_TDATE_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">CounterEntity: CounterEntity</param>
        private static void checkDuplicate(CounterEntity entity,bool checkPK)
        {
            /* 
            Example
            List<CounterEntity> list = CounterDAL.GetAll();
            if (list.Exists(
                delegate(CounterEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iCounterID != entity.PK_iCounterID;
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
        /// <param name="entity">CounterEntity:entity</param>
        private static void checkFK(CounterEntity entity)
        {            
        }
        #endregion
    }
}
