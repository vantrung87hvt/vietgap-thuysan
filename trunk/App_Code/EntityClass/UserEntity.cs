/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/9/2012 9:11:05 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class UserEntity
    {
        public UserEntity()
        {
			m_iuserid=0;
			m_susername="";
			m_spassword="";
			m_semail="";
			m_bactive=false;
			m_tlastvisit=DateTime.Now;
			m_sip="";
			m_igroupid=0;
        }
		private Int64 m_iuserid;
		public Int64 iUserID
		{
			get { return m_iuserid ; }
			set { m_iuserid = value; }
		}
		private String m_susername;
		public String sUsername
		{
			get { return m_susername ; }
			set { m_susername = value; }
		}
		private String m_spassword;
		public String sPassword
		{
			get { return m_spassword ; }
			set { m_spassword = value; }
		}
		private String m_semail;
		public String sEmail
		{
			get { return m_semail ; }
			set { m_semail = value; }
		}
		private Boolean m_bactive;
		public Boolean bActive
		{
			get { return m_bactive ; }
			set { m_bactive = value; }
		}
		private DateTime m_tlastvisit;
		public DateTime tLastVisit
		{
			get { return m_tlastvisit ; }
			set { m_tlastvisit = value; }
		}
		private String m_sip;
		public String sIP
		{
			get { return m_sip ; }
			set { m_sip = value; }
		}
		private Int32 m_igroupid;
		public Int32 iGroupID
		{
			get { return m_igroupid ; }
			set { m_igroupid = value; }
		}

        #region Comparison
        public static List<UserEntity> Sort(List<UserEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(UserEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<UserEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<UserEntity> COMPARISON_iUserID
		{
			get
			{
				return delegate(UserEntity entity,UserEntity other)
				{
					return entity.iUserID.CompareTo(other.iUserID);
				};
			}
		}
		public static Comparison<UserEntity> COMPARISON_sUsername
		{
			get
			{
				return delegate(UserEntity entity,UserEntity other)
				{
					return entity.sUsername.CompareTo(other.sUsername);
				};
			}
		}
		public static Comparison<UserEntity> COMPARISON_sPassword
		{
			get
			{
				return delegate(UserEntity entity,UserEntity other)
				{
					return entity.sPassword.CompareTo(other.sPassword);
				};
			}
		}
		public static Comparison<UserEntity> COMPARISON_sEmail
		{
			get
			{
				return delegate(UserEntity entity,UserEntity other)
				{
					return entity.sEmail.CompareTo(other.sEmail);
				};
			}
		}
		public static Comparison<UserEntity> COMPARISON_bActive
		{
			get
			{
				return delegate(UserEntity entity,UserEntity other)
				{
					return entity.bActive.CompareTo(other.bActive);
				};
			}
		}
		public static Comparison<UserEntity> COMPARISON_tLastVisit
		{
			get
			{
				return delegate(UserEntity entity,UserEntity other)
				{
					return entity.tLastVisit.CompareTo(other.tLastVisit);
				};
			}
		}
		public static Comparison<UserEntity> COMPARISON_sIP
		{
			get
			{
				return delegate(UserEntity entity,UserEntity other)
				{
					return entity.sIP.CompareTo(other.sIP);
				};
			}
		}
		public static Comparison<UserEntity> COMPARISON_iGroupID
		{
			get
			{
				return delegate(UserEntity entity,UserEntity other)
				{
					return entity.iGroupID.CompareTo(other.iGroupID);
				};
			}
		}
        #endregion
    }
}
