/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:10/26/2011 9:44:41 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class PollEntity
    {
        public PollEntity()
        {
			m_ipollid=0;
			m_squestion="";
			m_iorder=0;
			m_tdate=DateTime.Now;
			m_bhomepage=false;
			m_inewsid=0;
        }
		private Int32 m_ipollid;
		public Int32 iPollID
		{
			get { return m_ipollid ; }
			set { m_ipollid = value; }
		}
		private String m_squestion;
		public String sQuestion
		{
			get { return m_squestion ; }
			set { m_squestion = value; }
		}
		private Int16 m_iorder;
		public Int16 iOrder
		{
			get { return m_iorder ; }
			set { m_iorder = value; }
		}
		private DateTime m_tdate;
		public DateTime tDate
		{
			get { return m_tdate ; }
			set { m_tdate = value; }
		}
		private Boolean m_bhomepage;
		public Boolean bHomepage
		{
			get { return m_bhomepage ; }
			set { m_bhomepage = value; }
		}
		private Int32 m_inewsid;
		public Int32 iNewsID
		{
			get { return m_inewsid ; }
			set { m_inewsid = value; }
		}

        #region Comparison
        public static List<PollEntity> Sort(List<PollEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(PollEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<PollEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<PollEntity> COMPARISON_iPollID
		{
			get
			{
				return delegate(PollEntity entity,PollEntity other)
				{
					return entity.iPollID.CompareTo(other.iPollID);
				};
			}
		}
		public static Comparison<PollEntity> COMPARISON_sQuestion
		{
			get
			{
				return delegate(PollEntity entity,PollEntity other)
				{
					return entity.sQuestion.CompareTo(other.sQuestion);
				};
			}
		}
		public static Comparison<PollEntity> COMPARISON_iOrder
		{
			get
			{
				return delegate(PollEntity entity,PollEntity other)
				{
					return entity.iOrder.CompareTo(other.iOrder);
				};
			}
		}
		public static Comparison<PollEntity> COMPARISON_tDate
		{
			get
			{
				return delegate(PollEntity entity,PollEntity other)
				{
					return entity.tDate.CompareTo(other.tDate);
				};
			}
		}
		public static Comparison<PollEntity> COMPARISON_bHomepage
		{
			get
			{
				return delegate(PollEntity entity,PollEntity other)
				{
					return entity.bHomepage.CompareTo(other.bHomepage);
				};
			}
		}
		public static Comparison<PollEntity> COMPARISON_iNewsID
		{
			get
			{
				return delegate(PollEntity entity,PollEntity other)
				{
					return entity.iNewsID.CompareTo(other.iNewsID);
				};
			}
		}
        #endregion
    }
}
