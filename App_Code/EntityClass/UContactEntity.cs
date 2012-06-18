/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/2/2011 4:42:03 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class UContactEntity
    {
        public UContactEntity()
        {
			m_pk_iucontactid=0;
			m_fk_icontactid=0;
			m_semail="";
			m_stitle="";
			m_scontent="";
			m_tdate=DateTime.Now;
        }
		private int m_pk_iucontactid;
		public int PK_iUContactID
		{
			get { return m_pk_iucontactid ; }
			set { m_pk_iucontactid = value; }
		}
		private int m_fk_icontactid;
		public int FK_iContactID
		{
			get { return m_fk_icontactid ; }
			set { m_fk_icontactid = value; }
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

        #region Comparison
        public static List<UContactEntity> Sort(List<UContactEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(UContactEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<UContactEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<UContactEntity> COMPARISON_PK_iUContactID
		{
			get
			{
				return delegate(UContactEntity entity,UContactEntity other)
				{
					return entity.PK_iUContactID.CompareTo(other.PK_iUContactID);
				};
			}
		}
		public static Comparison<UContactEntity> COMPARISON_FK_iContactID
		{
			get
			{
				return delegate(UContactEntity entity,UContactEntity other)
				{
					return entity.FK_iContactID.CompareTo(other.FK_iContactID);
				};
			}
		}
		public static Comparison<UContactEntity> COMPARISON_sEmail
		{
			get
			{
				return delegate(UContactEntity entity,UContactEntity other)
				{
					return entity.sEmail.CompareTo(other.sEmail);
				};
			}
		}
		public static Comparison<UContactEntity> COMPARISON_sTitle
		{
			get
			{
				return delegate(UContactEntity entity,UContactEntity other)
				{
					return entity.sTitle.CompareTo(other.sTitle);
				};
			}
		}
		public static Comparison<UContactEntity> COMPARISON_sContent
		{
			get
			{
				return delegate(UContactEntity entity,UContactEntity other)
				{
					return entity.sContent.CompareTo(other.sContent);
				};
			}
		}
		public static Comparison<UContactEntity> COMPARISON_tDate
		{
			get
			{
				return delegate(UContactEntity entity,UContactEntity other)
				{
					return entity.tDate.CompareTo(other.tDate);
				};
			}
		}
        #endregion
    }
}
