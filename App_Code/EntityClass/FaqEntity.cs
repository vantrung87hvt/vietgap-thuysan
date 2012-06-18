/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/18/2012 8:29:32 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class FaqEntity
    {
        public FaqEntity()
        {
			m_pk_ifaqid=0;
			m_fk_ifaqcateid=0;
			m_squestion="";
			m_ddate=DateTime.Now;
			m_iviews=0;
			m_fk_iuserid=0;
        }
		private Int64 m_pk_ifaqid;
		public Int64 PK_iFaqID
		{
			get { return m_pk_ifaqid ; }
			set { m_pk_ifaqid = value; }
		}
		private Int32 m_fk_ifaqcateid;
		public Int32 FK_iFaqCateID
		{
			get { return m_fk_ifaqcateid ; }
			set { m_fk_ifaqcateid = value; }
		}
		private String m_squestion;
		public String sQuestion
		{
			get { return m_squestion ; }
			set { m_squestion = value; }
		}
		private DateTime m_ddate;
		public DateTime dDate
		{
			get { return m_ddate ; }
			set { m_ddate = value; }
		}
		private Int64 m_iviews;
		public Int64 iViews
		{
			get { return m_iviews ; }
			set { m_iviews = value; }
		}
		private Int64 m_fk_iuserid;
		public Int64 FK_iUserID
		{
			get { return m_fk_iuserid ; }
			set { m_fk_iuserid = value; }
		}

        #region Comparison
        public static List<FaqEntity> Sort(List<FaqEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(FaqEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<FaqEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<FaqEntity> COMPARISON_PK_iFaqID
		{
			get
			{
				return delegate(FaqEntity entity,FaqEntity other)
				{
					return entity.PK_iFaqID.CompareTo(other.PK_iFaqID);
				};
			}
		}
		public static Comparison<FaqEntity> COMPARISON_FK_iFaqCateID
		{
			get
			{
				return delegate(FaqEntity entity,FaqEntity other)
				{
					return entity.FK_iFaqCateID.CompareTo(other.FK_iFaqCateID);
				};
			}
		}
		public static Comparison<FaqEntity> COMPARISON_sQuestion
		{
			get
			{
				return delegate(FaqEntity entity,FaqEntity other)
				{
					return entity.sQuestion.CompareTo(other.sQuestion);
				};
			}
		}
		public static Comparison<FaqEntity> COMPARISON_dDate
		{
			get
			{
				return delegate(FaqEntity entity,FaqEntity other)
				{
					return entity.dDate.CompareTo(other.dDate);
				};
			}
		}
		public static Comparison<FaqEntity> COMPARISON_iViews
		{
			get
			{
				return delegate(FaqEntity entity,FaqEntity other)
				{
					return entity.iViews.CompareTo(other.iViews);
				};
			}
		}
		public static Comparison<FaqEntity> COMPARISON_FK_iUserID
		{
			get
			{
				return delegate(FaqEntity entity,FaqEntity other)
				{
					return entity.FK_iUserID.CompareTo(other.FK_iUserID);
				};
			}
		}
        #endregion
    }
}
