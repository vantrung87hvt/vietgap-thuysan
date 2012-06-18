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
    public class NewsEntity
    {
        public NewsEntity()
        {
			m_inewsid=0;
			m_stitle="";
			m_sdesc="";
			m_scontent="";
			m_simage="";
			m_tdate=DateTime.Now;
			m_iviews=0;
			m_bverified=false;
			m_stag="";
			m_iuserid=0;
        }
		private Int32 m_inewsid;
		public Int32 iNewsID
		{
			get { return m_inewsid ; }
			set { m_inewsid = value; }
		}
		private String m_stitle;
		public String sTitle
		{
			get { return m_stitle ; }
			set { m_stitle = value; }
		}
		private String m_sdesc;
		public String sDesc
		{
			get { return m_sdesc ; }
			set { m_sdesc = value; }
		}
		private String m_scontent;
		public String sContent
		{
			get { return m_scontent ; }
			set { m_scontent = value; }
		}
		private String m_simage;
		public String sImage
		{
			get { return m_simage ; }
			set { m_simage = value; }
		}
		private DateTime m_tdate;
		public DateTime tDate
		{
			get { return m_tdate ; }
			set { m_tdate = value; }
		}
		private Int32 m_iviews;
		public Int32 iViews
		{
			get { return m_iviews ; }
			set { m_iviews = value; }
		}
		private Boolean m_bverified;
		public Boolean bVerified
		{
			get { return m_bverified ; }
			set { m_bverified = value; }
		}
		private String m_stag;
		public String sTag
		{
			get { return m_stag ; }
			set { m_stag = value; }
		}
		private Int32 m_iuserid;
		public Int32 iUserID
		{
			get { return m_iuserid ; }
			set { m_iuserid = value; }
		}

        #region Comparison
        public static List<NewsEntity> Sort(List<NewsEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(NewsEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<NewsEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<NewsEntity> COMPARISON_iNewsID
		{
			get
			{
				return delegate(NewsEntity entity,NewsEntity other)
				{
					return entity.iNewsID.CompareTo(other.iNewsID);
				};
			}
		}
		public static Comparison<NewsEntity> COMPARISON_sTitle
		{
			get
			{
				return delegate(NewsEntity entity,NewsEntity other)
				{
					return entity.sTitle.CompareTo(other.sTitle);
				};
			}
		}
		public static Comparison<NewsEntity> COMPARISON_sDesc
		{
			get
			{
				return delegate(NewsEntity entity,NewsEntity other)
				{
					return entity.sDesc.CompareTo(other.sDesc);
				};
			}
		}
		public static Comparison<NewsEntity> COMPARISON_sContent
		{
			get
			{
				return delegate(NewsEntity entity,NewsEntity other)
				{
					return entity.sContent.CompareTo(other.sContent);
				};
			}
		}
		public static Comparison<NewsEntity> COMPARISON_sImage
		{
			get
			{
				return delegate(NewsEntity entity,NewsEntity other)
				{
					return entity.sImage.CompareTo(other.sImage);
				};
			}
		}
		public static Comparison<NewsEntity> COMPARISON_tDate
		{
			get
			{
				return delegate(NewsEntity entity,NewsEntity other)
				{
					return entity.tDate.CompareTo(other.tDate);
				};
			}
		}
		public static Comparison<NewsEntity> COMPARISON_iViews
		{
			get
			{
				return delegate(NewsEntity entity,NewsEntity other)
				{
					return entity.iViews.CompareTo(other.iViews);
				};
			}
		}
		public static Comparison<NewsEntity> COMPARISON_bVerified
		{
			get
			{
				return delegate(NewsEntity entity,NewsEntity other)
				{
					return entity.bVerified.CompareTo(other.bVerified);
				};
			}
		}
		public static Comparison<NewsEntity> COMPARISON_sTag
		{
			get
			{
				return delegate(NewsEntity entity,NewsEntity other)
				{
					return entity.sTag.CompareTo(other.sTag);
				};
			}
		}
		public static Comparison<NewsEntity> COMPARISON_iUserID
		{
			get
			{
				return delegate(NewsEntity entity,NewsEntity other)
				{
					return entity.iUserID.CompareTo(other.iUserID);
				};
			}
		}
        #endregion
    }
}
