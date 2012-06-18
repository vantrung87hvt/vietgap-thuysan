/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/2/2011 4:42:02 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class ChucVuEntity
    {
        public ChucVuEntity()
        {
			m_pk_ichucvuid=0;
			m_stenchucvu="";
			m_scongviecphutrach="";
        }
		private int m_pk_ichucvuid;
		public int PK_iChucVuID
		{
			get { return m_pk_ichucvuid ; }
			set { m_pk_ichucvuid = value; }
		}
		private String m_stenchucvu;
		public String sTenChucVu
		{
			get { return m_stenchucvu ; }
			set { m_stenchucvu = value; }
		}
		private String m_scongviecphutrach;
		public String sCongviecphutrach
		{
			get { return m_scongviecphutrach ; }
			set { m_scongviecphutrach = value; }
		}

        #region Comparison
        public static List<ChucVuEntity> Sort(List<ChucVuEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(ChucVuEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<ChucVuEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<ChucVuEntity> COMPARISON_PK_iChucVuID
		{
			get
			{
				return delegate(ChucVuEntity entity,ChucVuEntity other)
				{
					return entity.PK_iChucVuID.CompareTo(other.PK_iChucVuID);
				};
			}
		}
		public static Comparison<ChucVuEntity> COMPARISON_sTenChucVu
		{
			get
			{
				return delegate(ChucVuEntity entity,ChucVuEntity other)
				{
					return entity.sTenChucVu.CompareTo(other.sTenChucVu);
				};
			}
		}
		public static Comparison<ChucVuEntity> COMPARISON_sCongviecphutrach
		{
			get
			{
				return delegate(ChucVuEntity entity,ChucVuEntity other)
				{
					return entity.sCongviecphutrach.CompareTo(other.sCongviecphutrach);
				};
			}
		}
        #endregion
    }
}
