/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:28/10/2011 4:31:22 CH
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class CounterEntity
    {
        public CounterEntity()
        {
			m_pk_icounterid=0;
			m_sip="";
			m_tdate=DateTime.Now;
        }
		private int m_pk_icounterid;
		public int PK_iCounterID
		{
			get { return m_pk_icounterid ; }
			set { m_pk_icounterid = value; }
		}
		private String m_sip;
		public String sIP
		{
			get { return m_sip ; }
			set { m_sip = value; }
		}
		private DateTime m_tdate;
		public DateTime tDate
		{
			get { return m_tdate ; }
			set { m_tdate = value; }
		}

        #region Comparison
        public static List<CounterEntity> Sort(List<CounterEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(CounterEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<CounterEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<CounterEntity> COMPARISON_PK_iCounterID
		{
			get
			{
				return delegate(CounterEntity entity,CounterEntity other)
				{
					return entity.PK_iCounterID.CompareTo(other.PK_iCounterID);
				};
			}
		}
		public static Comparison<CounterEntity> COMPARISON_sIP
		{
			get
			{
				return delegate(CounterEntity entity,CounterEntity other)
				{
					return entity.sIP.CompareTo(other.sIP);
				};
			}
		}
		public static Comparison<CounterEntity> COMPARISON_tDate
		{
			get
			{
				return delegate(CounterEntity entity,CounterEntity other)
				{
					return entity.tDate.CompareTo(other.tDate);
				};
			}
		}
        #endregion
    }
}
