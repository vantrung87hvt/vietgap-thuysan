/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/26/2011 9:58:17 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class DanhgiatochucchungnhanEntity
    {
        public DanhgiatochucchungnhanEntity()
        {
			m_pk_idanhgiatochucchungnhanid=0;
			m_sphamvinghidinh="";
			m_tgiodanhgia=DateTime.Now;
			m_dngaydanhgia=DateTime.Now;
			m_scancudanhgia="";
			m_snoidungdanhgia="";
			m_sketquadanhgia="";
			m_iketquadanhgia=0;
			m_skiennghi="";
			m_fk_itochucchungnhanid=0;
			m_fk_itruongdoandanhgiaid=0;
        }
		private Int32 m_pk_idanhgiatochucchungnhanid;
		public Int32 PK_iDanhgiatochucchungnhanID
		{
			get { return m_pk_idanhgiatochucchungnhanid ; }
			set { m_pk_idanhgiatochucchungnhanid = value; }
		}
		private String m_sphamvinghidinh;
		public String sPhamvinghidinh
		{
			get { return m_sphamvinghidinh ; }
			set { m_sphamvinghidinh = value; }
		}
		private DateTime m_tgiodanhgia;
		public DateTime tGiodanhgia
		{
			get { return m_tgiodanhgia ; }
			set { m_tgiodanhgia = value; }
		}
		private DateTime m_dngaydanhgia;
		public DateTime dNgaydanhgia
		{
			get { return m_dngaydanhgia ; }
			set { m_dngaydanhgia = value; }
		}
		private String m_scancudanhgia;
		public String sCancudanhgia
		{
			get { return m_scancudanhgia ; }
			set { m_scancudanhgia = value; }
		}
		private String m_snoidungdanhgia;
		public String sNoidungdanhgia
		{
			get { return m_snoidungdanhgia ; }
			set { m_snoidungdanhgia = value; }
		}
		private String m_sketquadanhgia;
		public String sKetquadanhgia
		{
			get { return m_sketquadanhgia ; }
			set { m_sketquadanhgia = value; }
		}
		private Int16 m_iketquadanhgia;
		public Int16 iKetquadanhgia
		{
			get { return m_iketquadanhgia ; }
			set { m_iketquadanhgia = value; }
		}
		private String m_skiennghi;
		public String sKiennghi
		{
			get { return m_skiennghi ; }
			set { m_skiennghi = value; }
		}
		private Int32 m_fk_itochucchungnhanid;
		public Int32 FK_iTochucchungnhanID
		{
			get { return m_fk_itochucchungnhanid ; }
			set { m_fk_itochucchungnhanid = value; }
		}
		private Int32 m_fk_itruongdoandanhgiaid;
		public Int32 FK_iTruongdoandanhgiaID
		{
			get { return m_fk_itruongdoandanhgiaid ; }
			set { m_fk_itruongdoandanhgiaid = value; }
		}

        #region Comparison
        public static List<DanhgiatochucchungnhanEntity> Sort(List<DanhgiatochucchungnhanEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(DanhgiatochucchungnhanEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<DanhgiatochucchungnhanEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<DanhgiatochucchungnhanEntity> COMPARISON_PK_iDanhgiatochucchungnhanID
		{
			get
			{
				return delegate(DanhgiatochucchungnhanEntity entity,DanhgiatochucchungnhanEntity other)
				{
					return entity.PK_iDanhgiatochucchungnhanID.CompareTo(other.PK_iDanhgiatochucchungnhanID);
				};
			}
		}
		public static Comparison<DanhgiatochucchungnhanEntity> COMPARISON_sPhamvinghidinh
		{
			get
			{
				return delegate(DanhgiatochucchungnhanEntity entity,DanhgiatochucchungnhanEntity other)
				{
					return entity.sPhamvinghidinh.CompareTo(other.sPhamvinghidinh);
				};
			}
		}
		public static Comparison<DanhgiatochucchungnhanEntity> COMPARISON_tGiodanhgia
		{
			get
			{
				return delegate(DanhgiatochucchungnhanEntity entity,DanhgiatochucchungnhanEntity other)
				{
					return entity.tGiodanhgia.CompareTo(other.tGiodanhgia);
				};
			}
		}
		public static Comparison<DanhgiatochucchungnhanEntity> COMPARISON_dNgaydanhgia
		{
			get
			{
				return delegate(DanhgiatochucchungnhanEntity entity,DanhgiatochucchungnhanEntity other)
				{
					return entity.dNgaydanhgia.CompareTo(other.dNgaydanhgia);
				};
			}
		}
		public static Comparison<DanhgiatochucchungnhanEntity> COMPARISON_sCancudanhgia
		{
			get
			{
				return delegate(DanhgiatochucchungnhanEntity entity,DanhgiatochucchungnhanEntity other)
				{
					return entity.sCancudanhgia.CompareTo(other.sCancudanhgia);
				};
			}
		}
		public static Comparison<DanhgiatochucchungnhanEntity> COMPARISON_sNoidungdanhgia
		{
			get
			{
				return delegate(DanhgiatochucchungnhanEntity entity,DanhgiatochucchungnhanEntity other)
				{
					return entity.sNoidungdanhgia.CompareTo(other.sNoidungdanhgia);
				};
			}
		}
		public static Comparison<DanhgiatochucchungnhanEntity> COMPARISON_sKetquadanhgia
		{
			get
			{
				return delegate(DanhgiatochucchungnhanEntity entity,DanhgiatochucchungnhanEntity other)
				{
					return entity.sKetquadanhgia.CompareTo(other.sKetquadanhgia);
				};
			}
		}
		public static Comparison<DanhgiatochucchungnhanEntity> COMPARISON_iKetquadanhgia
		{
			get
			{
				return delegate(DanhgiatochucchungnhanEntity entity,DanhgiatochucchungnhanEntity other)
				{
					return entity.iKetquadanhgia.CompareTo(other.iKetquadanhgia);
				};
			}
		}
		public static Comparison<DanhgiatochucchungnhanEntity> COMPARISON_sKiennghi
		{
			get
			{
				return delegate(DanhgiatochucchungnhanEntity entity,DanhgiatochucchungnhanEntity other)
				{
					return entity.sKiennghi.CompareTo(other.sKiennghi);
				};
			}
		}
		public static Comparison<DanhgiatochucchungnhanEntity> COMPARISON_FK_iTochucchungnhanID
		{
			get
			{
				return delegate(DanhgiatochucchungnhanEntity entity,DanhgiatochucchungnhanEntity other)
				{
					return entity.FK_iTochucchungnhanID.CompareTo(other.FK_iTochucchungnhanID);
				};
			}
		}
		public static Comparison<DanhgiatochucchungnhanEntity> COMPARISON_FK_iTruongdoandanhgiaID
		{
			get
			{
				return delegate(DanhgiatochucchungnhanEntity entity,DanhgiatochucchungnhanEntity other)
				{
					return entity.FK_iTruongdoandanhgiaID.CompareTo(other.FK_iTruongdoandanhgiaID);
				};
			}
		}
        #endregion
    }
}
