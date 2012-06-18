/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/22/2011 10:41:57 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class DichvuEntity
    {
        public DichvuEntity()
        {
			m_pk_idichvuid=0;
			m_stendichvu="";
			m_snoidung="";
			m_icategoryid=0;
			m_itrangthai=0;
        }
		private Int32 m_pk_idichvuid;
		public Int32 PK_iDichvuID
		{
			get { return m_pk_idichvuid ; }
			set { m_pk_idichvuid = value; }
		}
		private String m_stendichvu;
		public String sTendichvu
		{
			get { return m_stendichvu ; }
			set { m_stendichvu = value; }
		}
		private String m_snoidung;
		public String sNoidung
		{
			get { return m_snoidung ; }
			set { m_snoidung = value; }
		}
		private Int32 m_icategoryid;
		public Int32 iCategoryID
		{
			get { return m_icategoryid ; }
			set { m_icategoryid = value; }
		}
		private Int16 m_itrangthai;
		public Int16 iTrangthai
		{
			get { return m_itrangthai ; }
			set { m_itrangthai = value; }
		}

        #region Comparison
        public static List<DichvuEntity> Sort(List<DichvuEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(DichvuEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<DichvuEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<DichvuEntity> COMPARISON_PK_iDichvuID
		{
			get
			{
				return delegate(DichvuEntity entity,DichvuEntity other)
				{
					return entity.PK_iDichvuID.CompareTo(other.PK_iDichvuID);
				};
			}
		}
		public static Comparison<DichvuEntity> COMPARISON_sTendichvu
		{
			get
			{
				return delegate(DichvuEntity entity,DichvuEntity other)
				{
					return entity.sTendichvu.CompareTo(other.sTendichvu);
				};
			}
		}
		public static Comparison<DichvuEntity> COMPARISON_sNoidung
		{
			get
			{
				return delegate(DichvuEntity entity,DichvuEntity other)
				{
					return entity.sNoidung.CompareTo(other.sNoidung);
				};
			}
		}
		public static Comparison<DichvuEntity> COMPARISON_iCategoryID
		{
			get
			{
				return delegate(DichvuEntity entity,DichvuEntity other)
				{
					return entity.iCategoryID.CompareTo(other.iCategoryID);
				};
			}
		}
		public static Comparison<DichvuEntity> COMPARISON_iTrangthai
		{
			get
			{
				return delegate(DichvuEntity entity,DichvuEntity other)
				{
					return entity.iTrangthai.CompareTo(other.iTrangthai);
				};
			}
		}
        #endregion
    }
}
