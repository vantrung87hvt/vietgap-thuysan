/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/2/2011 4:42:01 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class PhongBanEntity
    {
        public PhongBanEntity()
        {
			m_pk_iphongbanid=0;
			m_stenphong="";
			m_sdienthoai="";
			m_sfax="";
        }
		private int m_pk_iphongbanid;
		public int PK_iPhongBanID
		{
			get { return m_pk_iphongbanid ; }
			set { m_pk_iphongbanid = value; }
		}
		private String m_stenphong;
		public String sTenPhong
		{
			get { return m_stenphong ; }
			set { m_stenphong = value; }
		}
		private String m_sdienthoai;
		public String sDienThoai
		{
			get { return m_sdienthoai ; }
			set { m_sdienthoai = value; }
		}
		private String m_sfax;
		public String sFax
		{
			get { return m_sfax ; }
			set { m_sfax = value; }
		}

        #region Comparison
        public static List<PhongBanEntity> Sort(List<PhongBanEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(PhongBanEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<PhongBanEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<PhongBanEntity> COMPARISON_PK_iPhongBanID
		{
			get
			{
				return delegate(PhongBanEntity entity,PhongBanEntity other)
				{
					return entity.PK_iPhongBanID.CompareTo(other.PK_iPhongBanID);
				};
			}
		}
		public static Comparison<PhongBanEntity> COMPARISON_sTenPhong
		{
			get
			{
				return delegate(PhongBanEntity entity,PhongBanEntity other)
				{
					return entity.sTenPhong.CompareTo(other.sTenPhong);
				};
			}
		}
		public static Comparison<PhongBanEntity> COMPARISON_sDienThoai
		{
			get
			{
				return delegate(PhongBanEntity entity,PhongBanEntity other)
				{
					return entity.sDienThoai.CompareTo(other.sDienThoai);
				};
			}
		}
		public static Comparison<PhongBanEntity> COMPARISON_sFax
		{
			get
			{
				return delegate(PhongBanEntity entity,PhongBanEntity other)
				{
					return entity.sFax.CompareTo(other.sFax);
				};
			}
		}
        #endregion
    }
}
