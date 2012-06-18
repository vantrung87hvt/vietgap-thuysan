/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:31/10/2011 7:38:21 CH
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class QuanHuyenEntity
    {
        public QuanHuyenEntity()
        {
			m_pk_iquanhuyenid=0;
			m_sten="";
			m_bquanhuyen=false;
			m_skytuviettat="";
			m_fk_itinhthanhid=0;
        }
		private int m_pk_iquanhuyenid;
		public int PK_iQuanHuyenID
		{
			get { return m_pk_iquanhuyenid ; }
			set { m_pk_iquanhuyenid = value; }
		}
		private String m_sten;
		public String sTen
		{
			get { return m_sten ; }
			set { m_sten = value; }
		}
		private Boolean m_bquanhuyen;
		public Boolean bQuanHuyen
		{
			get { return m_bquanhuyen ; }
			set { m_bquanhuyen = value; }
		}
		private String m_skytuviettat;
		public String sKytuviettat
		{
			get { return m_skytuviettat ; }
			set { m_skytuviettat = value; }
		}
		private Int16 m_fk_itinhthanhid;
		public Int16 FK_iTinhThanhID
		{
			get { return m_fk_itinhthanhid ; }
			set { m_fk_itinhthanhid = value; }
		}

        #region Comparison
        public static List<QuanHuyenEntity> Sort(List<QuanHuyenEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(QuanHuyenEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<QuanHuyenEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<QuanHuyenEntity> COMPARISON_PK_iQuanHuyenID
		{
			get
			{
				return delegate(QuanHuyenEntity entity,QuanHuyenEntity other)
				{
					return entity.PK_iQuanHuyenID.CompareTo(other.PK_iQuanHuyenID);
				};
			}
		}
		public static Comparison<QuanHuyenEntity> COMPARISON_sTen
		{
			get
			{
				return delegate(QuanHuyenEntity entity,QuanHuyenEntity other)
				{
					return entity.sTen.CompareTo(other.sTen);
				};
			}
		}
		public static Comparison<QuanHuyenEntity> COMPARISON_bQuanHuyen
		{
			get
			{
				return delegate(QuanHuyenEntity entity,QuanHuyenEntity other)
				{
					return entity.bQuanHuyen.CompareTo(other.bQuanHuyen);
				};
			}
		}
		public static Comparison<QuanHuyenEntity> COMPARISON_sKytuviettat
		{
			get
			{
				return delegate(QuanHuyenEntity entity,QuanHuyenEntity other)
				{
					return entity.sKytuviettat.CompareTo(other.sKytuviettat);
				};
			}
		}
		public static Comparison<QuanHuyenEntity> COMPARISON_FK_iTinhThanhID
		{
			get
			{
				return delegate(QuanHuyenEntity entity,QuanHuyenEntity other)
				{
					return entity.FK_iTinhThanhID.CompareTo(other.FK_iTinhThanhID);
				};
			}
		}
        #endregion
    }
}
