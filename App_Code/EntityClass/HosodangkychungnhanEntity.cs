/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/6/2012 10:05:51 AM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class HosodangkychungnhanEntity
    {
        public HosodangkychungnhanEntity()
        {
			m_pk_ihosodangkychungnhanid=0;
			m_dngaydangky=DateTime.Now;
			m_fk_icosonuoiid=0;
			m_blandau=false;
			m_itrangthai=0;
			m_fk_itochucchungnhanid=0;
        }
		private Int64 m_pk_ihosodangkychungnhanid;
		public Int64 PK_iHosodangkychungnhanID
		{
			get { return m_pk_ihosodangkychungnhanid ; }
			set { m_pk_ihosodangkychungnhanid = value; }
		}
		private DateTime m_dngaydangky;
		public DateTime dNgaydangky
		{
			get { return m_dngaydangky ; }
			set { m_dngaydangky = value; }
		}
		private Int64 m_fk_icosonuoiid;
		public Int64 FK_iCosonuoiID
		{
			get { return m_fk_icosonuoiid ; }
			set { m_fk_icosonuoiid = value; }
		}
		private Boolean m_blandau;
		public Boolean bLandau
		{
			get { return m_blandau ; }
			set { m_blandau = value; }
		}
		private Int16 m_itrangthai;
		public Int16 iTrangthai
		{
			get { return m_itrangthai ; }
			set { m_itrangthai = value; }
		}
		private Int32 m_fk_itochucchungnhanid;
		public Int32 FK_iTochucchungnhanID
		{
			get { return m_fk_itochucchungnhanid ; }
			set { m_fk_itochucchungnhanid = value; }
		}

        #region Comparison
        public static List<HosodangkychungnhanEntity> Sort(List<HosodangkychungnhanEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(HosodangkychungnhanEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<HosodangkychungnhanEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<HosodangkychungnhanEntity> COMPARISON_PK_iHosodangkychungnhanID
		{
			get
			{
				return delegate(HosodangkychungnhanEntity entity,HosodangkychungnhanEntity other)
				{
					return entity.PK_iHosodangkychungnhanID.CompareTo(other.PK_iHosodangkychungnhanID);
				};
			}
		}
		public static Comparison<HosodangkychungnhanEntity> COMPARISON_dNgaydangky
		{
			get
			{
				return delegate(HosodangkychungnhanEntity entity,HosodangkychungnhanEntity other)
				{
					return entity.dNgaydangky.CompareTo(other.dNgaydangky);
				};
			}
		}
		public static Comparison<HosodangkychungnhanEntity> COMPARISON_FK_iCosonuoiID
		{
			get
			{
				return delegate(HosodangkychungnhanEntity entity,HosodangkychungnhanEntity other)
				{
					return entity.FK_iCosonuoiID.CompareTo(other.FK_iCosonuoiID);
				};
			}
		}
		public static Comparison<HosodangkychungnhanEntity> COMPARISON_bLandau
		{
			get
			{
				return delegate(HosodangkychungnhanEntity entity,HosodangkychungnhanEntity other)
				{
					return entity.bLandau.CompareTo(other.bLandau);
				};
			}
		}
		public static Comparison<HosodangkychungnhanEntity> COMPARISON_iTrangthai
		{
			get
			{
				return delegate(HosodangkychungnhanEntity entity,HosodangkychungnhanEntity other)
				{
					return entity.iTrangthai.CompareTo(other.iTrangthai);
				};
			}
		}
		public static Comparison<HosodangkychungnhanEntity> COMPARISON_FK_iTochucchungnhanID
		{
			get
			{
				return delegate(HosodangkychungnhanEntity entity,HosodangkychungnhanEntity other)
				{
					return entity.FK_iTochucchungnhanID.CompareTo(other.FK_iTochucchungnhanID);
				};
			}
		}
        #endregion
    }
}
