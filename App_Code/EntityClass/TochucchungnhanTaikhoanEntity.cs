/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:5/18/2012 11:24:35 AM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class TochucchungnhanTaikhoanEntity
    {
        public TochucchungnhanTaikhoanEntity()
        {
			m_pk_itochucchungnhantaikhoanid=0;
			m_fk_itochucchungnhanid=0;
			m_fk_itaikhoanid=0;
			m_dngaythuchien=DateTime.Now;
			m_bactive=false;
        }
		private Int32 m_pk_itochucchungnhantaikhoanid;
		public Int32 PK_iTochucchungnhanTaikhoanID
		{
			get { return m_pk_itochucchungnhantaikhoanid ; }
			set { m_pk_itochucchungnhantaikhoanid = value; }
		}
		private Int32 m_fk_itochucchungnhanid;
		public Int32 FK_iTochucchungnhanID
		{
			get { return m_fk_itochucchungnhanid ; }
			set { m_fk_itochucchungnhanid = value; }
		}
		private Int64 m_fk_itaikhoanid;
		public Int64 FK_iTaikhoanID
		{
			get { return m_fk_itaikhoanid ; }
			set { m_fk_itaikhoanid = value; }
		}
		private DateTime m_dngaythuchien;
		public DateTime dNgaythuchien
		{
			get { return m_dngaythuchien ; }
			set { m_dngaythuchien = value; }
		}
		private Boolean m_bactive;
		public Boolean bActive
		{
			get { return m_bactive ; }
			set { m_bactive = value; }
		}

        #region Comparison
        public static List<TochucchungnhanTaikhoanEntity> Sort(List<TochucchungnhanTaikhoanEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(TochucchungnhanTaikhoanEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<TochucchungnhanTaikhoanEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<TochucchungnhanTaikhoanEntity> COMPARISON_PK_iTochucchungnhanTaikhoanID
		{
			get
			{
				return delegate(TochucchungnhanTaikhoanEntity entity,TochucchungnhanTaikhoanEntity other)
				{
					return entity.PK_iTochucchungnhanTaikhoanID.CompareTo(other.PK_iTochucchungnhanTaikhoanID);
				};
			}
		}
		public static Comparison<TochucchungnhanTaikhoanEntity> COMPARISON_FK_iTochucchungnhanID
		{
			get
			{
				return delegate(TochucchungnhanTaikhoanEntity entity,TochucchungnhanTaikhoanEntity other)
				{
					return entity.FK_iTochucchungnhanID.CompareTo(other.FK_iTochucchungnhanID);
				};
			}
		}
		public static Comparison<TochucchungnhanTaikhoanEntity> COMPARISON_FK_iTaikhoanID
		{
			get
			{
				return delegate(TochucchungnhanTaikhoanEntity entity,TochucchungnhanTaikhoanEntity other)
				{
					return entity.FK_iTaikhoanID.CompareTo(other.FK_iTaikhoanID);
				};
			}
		}
		public static Comparison<TochucchungnhanTaikhoanEntity> COMPARISON_dNgaythuchien
		{
			get
			{
				return delegate(TochucchungnhanTaikhoanEntity entity,TochucchungnhanTaikhoanEntity other)
				{
					return entity.dNgaythuchien.CompareTo(other.dNgaythuchien);
				};
			}
		}
		public static Comparison<TochucchungnhanTaikhoanEntity> COMPARISON_bActive
		{
			get
			{
				return delegate(TochucchungnhanTaikhoanEntity entity,TochucchungnhanTaikhoanEntity other)
				{
					return entity.bActive.CompareTo(other.bActive);
				};
			}
		}
        #endregion
    }
}
