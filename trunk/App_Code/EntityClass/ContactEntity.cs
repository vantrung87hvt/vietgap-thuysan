/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/2/2011 8:50:13 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class ContactEntity
    {
        public ContactEntity()
        {
			m_pk_icontactid=0;
			m_fk_iphongbanid=0;
			m_fk_ichucvuid=0;
			m_shoten="";
			m_sdienthoai="";
			m_semail="";
        }
		private int m_pk_icontactid;
		public int PK_iContactID
		{
			get { return m_pk_icontactid ; }
			set { m_pk_icontactid = value; }
		}
		private int m_fk_iphongbanid;
		public int FK_iPhongBanID
		{
			get { return m_fk_iphongbanid ; }
			set { m_fk_iphongbanid = value; }
		}
		private int m_fk_ichucvuid;
		public int FK_iChucVuID
		{
			get { return m_fk_ichucvuid ; }
			set { m_fk_ichucvuid = value; }
		}
		private String m_shoten;
		public String sHoTen
		{
			get { return m_shoten ; }
			set { m_shoten = value; }
		}
		private String m_sdienthoai;
		public String sDienThoai
		{
			get { return m_sdienthoai ; }
			set { m_sdienthoai = value; }
		}
		private String m_semail;
		public String sEmail
		{
			get { return m_semail ; }
			set { m_semail = value; }
		}

        #region Comparison
        public static List<ContactEntity> Sort(List<ContactEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(ContactEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<ContactEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<ContactEntity> COMPARISON_PK_iContactID
		{
			get
			{
				return delegate(ContactEntity entity,ContactEntity other)
				{
					return entity.PK_iContactID.CompareTo(other.PK_iContactID);
				};
			}
		}
		public static Comparison<ContactEntity> COMPARISON_FK_iPhongBanID
		{
			get
			{
				return delegate(ContactEntity entity,ContactEntity other)
				{
					return entity.FK_iPhongBanID.CompareTo(other.FK_iPhongBanID);
				};
			}
		}
		public static Comparison<ContactEntity> COMPARISON_FK_iChucVuID
		{
			get
			{
				return delegate(ContactEntity entity,ContactEntity other)
				{
					return entity.FK_iChucVuID.CompareTo(other.FK_iChucVuID);
				};
			}
		}
		public static Comparison<ContactEntity> COMPARISON_sHoTen
		{
			get
			{
				return delegate(ContactEntity entity,ContactEntity other)
				{
					return entity.sHoTen.CompareTo(other.sHoTen);
				};
			}
		}
		public static Comparison<ContactEntity> COMPARISON_sDienThoai
		{
			get
			{
				return delegate(ContactEntity entity,ContactEntity other)
				{
					return entity.sDienThoai.CompareTo(other.sDienThoai);
				};
			}
		}
		public static Comparison<ContactEntity> COMPARISON_sEmail
		{
			get
			{
				return delegate(ContactEntity entity,ContactEntity other)
				{
					return entity.sEmail.CompareTo(other.sEmail);
				};
			}
		}
        #endregion
    }
}
