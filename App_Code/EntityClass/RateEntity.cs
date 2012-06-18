/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:10/26/2011 9:44:42 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class RateEntity
    {
        public RateEntity()
        {
			m_irateid=0;
			m_inewsid=0;
			m_irate=0;
			m_icount=0;
        }
		private Int32 m_irateid;
		public Int32 iRateID
		{
			get { return m_irateid ; }
			set { m_irateid = value; }
		}
		private Int32 m_inewsid;
		public Int32 iNewsID
		{
			get { return m_inewsid ; }
			set { m_inewsid = value; }
		}
		private Int32 m_irate;
		public Int32 iRate
		{
			get { return m_irate ; }
			set { m_irate = value; }
		}
		private Int32 m_icount;
		public Int32 iCount
		{
			get { return m_icount ; }
			set { m_icount = value; }
		}

        #region Comparison
        public static List<RateEntity> Sort(List<RateEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(RateEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<RateEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<RateEntity> COMPARISON_iRateID
		{
			get
			{
				return delegate(RateEntity entity,RateEntity other)
				{
					return entity.iRateID.CompareTo(other.iRateID);
				};
			}
		}
		public static Comparison<RateEntity> COMPARISON_iNewsID
		{
			get
			{
				return delegate(RateEntity entity,RateEntity other)
				{
					return entity.iNewsID.CompareTo(other.iNewsID);
				};
			}
		}
		public static Comparison<RateEntity> COMPARISON_iRate
		{
			get
			{
				return delegate(RateEntity entity,RateEntity other)
				{
					return entity.iRate.CompareTo(other.iRate);
				};
			}
		}
		public static Comparison<RateEntity> COMPARISON_iCount
		{
			get
			{
				return delegate(RateEntity entity,RateEntity other)
				{
					return entity.iCount.CompareTo(other.iCount);
				};
			}
		}
        #endregion
    }
}
