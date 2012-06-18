/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/14/2012 10:49:52 AM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class DangkyHoatdongchungnhanEntity
    {
        public DangkyHoatdongchungnhanEntity()
        {
			m_pk_idangkychungnhanvietgapid=0;
			m_fk_itochucchungnhanid=0;
			m_itrangthaidangky=0;
			m_dngaydangky=DateTime.Now;
			m_ilandangky=0;
        }
		private Int32 m_pk_idangkychungnhanvietgapid;
		public Int32 PK_iDangkyChungnhanVietGapID
		{
			get { return m_pk_idangkychungnhanvietgapid ; }
			set { m_pk_idangkychungnhanvietgapid = value; }
		}
		private Int32 m_fk_itochucchungnhanid;
		public Int32 FK_iTochucchungnhanID
		{
			get { return m_fk_itochucchungnhanid ; }
			set { m_fk_itochucchungnhanid = value; }
		}
		private Int16 m_itrangthaidangky;
		public Int16 iTrangthaidangky
		{
			get { return m_itrangthaidangky ; }
			set { m_itrangthaidangky = value; }
		}
		private DateTime m_dngaydangky;
		public DateTime dNgaydangky
		{
			get { return m_dngaydangky ; }
			set { m_dngaydangky = value; }
		}
		private Int16 m_ilandangky;
		public Int16 iLandangky
		{
			get { return m_ilandangky ; }
			set { m_ilandangky = value; }
		}

        #region Comparison
        public static List<DangkyHoatdongchungnhanEntity> Sort(List<DangkyHoatdongchungnhanEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(DangkyHoatdongchungnhanEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<DangkyHoatdongchungnhanEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<DangkyHoatdongchungnhanEntity> COMPARISON_PK_iDangkyChungnhanVietGapID
		{
			get
			{
				return delegate(DangkyHoatdongchungnhanEntity entity,DangkyHoatdongchungnhanEntity other)
				{
					return entity.PK_iDangkyChungnhanVietGapID.CompareTo(other.PK_iDangkyChungnhanVietGapID);
				};
			}
		}
		public static Comparison<DangkyHoatdongchungnhanEntity> COMPARISON_FK_iTochucchungnhanID
		{
			get
			{
				return delegate(DangkyHoatdongchungnhanEntity entity,DangkyHoatdongchungnhanEntity other)
				{
					return entity.FK_iTochucchungnhanID.CompareTo(other.FK_iTochucchungnhanID);
				};
			}
		}
		public static Comparison<DangkyHoatdongchungnhanEntity> COMPARISON_iTrangthaidangky
		{
			get
			{
				return delegate(DangkyHoatdongchungnhanEntity entity,DangkyHoatdongchungnhanEntity other)
				{
					return entity.iTrangthaidangky.CompareTo(other.iTrangthaidangky);
				};
			}
		}
		public static Comparison<DangkyHoatdongchungnhanEntity> COMPARISON_dNgaydangky
		{
			get
			{
				return delegate(DangkyHoatdongchungnhanEntity entity,DangkyHoatdongchungnhanEntity other)
				{
					return entity.dNgaydangky.CompareTo(other.dNgaydangky);
				};
			}
		}
		public static Comparison<DangkyHoatdongchungnhanEntity> COMPARISON_iLandangky
		{
			get
			{
				return delegate(DangkyHoatdongchungnhanEntity entity,DangkyHoatdongchungnhanEntity other)
				{
					return entity.iLandangky.CompareTo(other.iLandangky);
				};
			}
		}
        #endregion
    }
}
