/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:10/26/2011 9:44:40 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class FeedbackEntity
    {
        public FeedbackEntity()
        {
			m_ifeedbackid=0;
			m_inewsid=0;
			m_sname="";
			m_semail="";
			m_stitle="";
			m_scontent="";
			m_tdate=DateTime.Now;
			m_bverified=false;
        }
		private Int32 m_ifeedbackid;
		public Int32 iFeedbackID
		{
			get { return m_ifeedbackid ; }
			set { m_ifeedbackid = value; }
		}
		private Int32 m_inewsid;
		public Int32 iNewsID
		{
			get { return m_inewsid ; }
			set { m_inewsid = value; }
		}
		private String m_sname;
		public String sName
		{
			get { return m_sname ; }
			set { m_sname = value; }
		}
		private String m_semail;
		public String sEmail
		{
			get { return m_semail ; }
			set { m_semail = value; }
		}
		private String m_stitle;
		public String sTitle
		{
			get { return m_stitle ; }
			set { m_stitle = value; }
		}
		private String m_scontent;
		public String sContent
		{
			get { return m_scontent ; }
			set { m_scontent = value; }
		}
		private DateTime m_tdate;
		public DateTime tDate
		{
			get { return m_tdate ; }
			set { m_tdate = value; }
		}
		private Boolean m_bverified;
		public Boolean bVerified
		{
			get { return m_bverified ; }
			set { m_bverified = value; }
		}

        #region Comparison
        public static List<FeedbackEntity> Sort(List<FeedbackEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(FeedbackEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<FeedbackEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<FeedbackEntity> COMPARISON_iFeedbackID
		{
			get
			{
				return delegate(FeedbackEntity entity,FeedbackEntity other)
				{
					return entity.iFeedbackID.CompareTo(other.iFeedbackID);
				};
			}
		}
		public static Comparison<FeedbackEntity> COMPARISON_iNewsID
		{
			get
			{
				return delegate(FeedbackEntity entity,FeedbackEntity other)
				{
					return entity.iNewsID.CompareTo(other.iNewsID);
				};
			}
		}
		public static Comparison<FeedbackEntity> COMPARISON_sName
		{
			get
			{
				return delegate(FeedbackEntity entity,FeedbackEntity other)
				{
					return entity.sName.CompareTo(other.sName);
				};
			}
		}
		public static Comparison<FeedbackEntity> COMPARISON_sEmail
		{
			get
			{
				return delegate(FeedbackEntity entity,FeedbackEntity other)
				{
					return entity.sEmail.CompareTo(other.sEmail);
				};
			}
		}
		public static Comparison<FeedbackEntity> COMPARISON_sTitle
		{
			get
			{
				return delegate(FeedbackEntity entity,FeedbackEntity other)
				{
					return entity.sTitle.CompareTo(other.sTitle);
				};
			}
		}
		public static Comparison<FeedbackEntity> COMPARISON_sContent
		{
			get
			{
				return delegate(FeedbackEntity entity,FeedbackEntity other)
				{
					return entity.sContent.CompareTo(other.sContent);
				};
			}
		}
		public static Comparison<FeedbackEntity> COMPARISON_tDate
		{
			get
			{
				return delegate(FeedbackEntity entity,FeedbackEntity other)
				{
					return entity.tDate.CompareTo(other.tDate);
				};
			}
		}
		public static Comparison<FeedbackEntity> COMPARISON_bVerified
		{
			get
			{
				return delegate(FeedbackEntity entity,FeedbackEntity other)
				{
					return entity.bVerified.CompareTo(other.bVerified);
				};
			}
		}
        #endregion
    }
}
