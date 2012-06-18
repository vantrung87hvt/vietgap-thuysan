/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:5/17/2012 4:27:50 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class TaiKhoanDangKyToChucChungNhanEntity
    {
        public TaiKhoanDangKyToChucChungNhanEntity()
        {
			m_pk_itaikhoantochucid=0;
			m_fk_itaikhoanid=0;
			m_fk_itochucchungnhanid=0;
			m_dngaydangky=DateTime.Now;
			m_bduyet=false;
        }
		private Int32 m_pk_itaikhoantochucid;
		public Int32 PK_iTaikhoanTochucID
		{
			get { return m_pk_itaikhoantochucid ; }
			set { m_pk_itaikhoantochucid = value; }
		}
		private Int64 m_fk_itaikhoanid;
		public Int64 FK_iTaikhoanID
		{
			get { return m_fk_itaikhoanid ; }
			set { m_fk_itaikhoanid = value; }
		}
		private Int32 m_fk_itochucchungnhanid;
		public Int32 FK_iTochucchungnhanID
		{
			get { return m_fk_itochucchungnhanid ; }
			set { m_fk_itochucchungnhanid = value; }
		}
		private DateTime m_dngaydangky;
		public DateTime dNgaydangky
		{
			get { return m_dngaydangky ; }
			set { m_dngaydangky = value; }
		}
		private Boolean m_bduyet;
		public Boolean bDuyet
		{
			get { return m_bduyet ; }
			set { m_bduyet = value; }
		}

        #region Comparison
        public static List<TaiKhoanDangKyToChucChungNhanEntity> Sort(List<TaiKhoanDangKyToChucChungNhanEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(TaiKhoanDangKyToChucChungNhanEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<TaiKhoanDangKyToChucChungNhanEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<TaiKhoanDangKyToChucChungNhanEntity> COMPARISON_PK_iTaikhoanTochucID
		{
			get
			{
				return delegate(TaiKhoanDangKyToChucChungNhanEntity entity,TaiKhoanDangKyToChucChungNhanEntity other)
				{
					return entity.PK_iTaikhoanTochucID.CompareTo(other.PK_iTaikhoanTochucID);
				};
			}
		}
		public static Comparison<TaiKhoanDangKyToChucChungNhanEntity> COMPARISON_FK_iTaikhoanID
		{
			get
			{
				return delegate(TaiKhoanDangKyToChucChungNhanEntity entity,TaiKhoanDangKyToChucChungNhanEntity other)
				{
					return entity.FK_iTaikhoanID.CompareTo(other.FK_iTaikhoanID);
				};
			}
		}
		public static Comparison<TaiKhoanDangKyToChucChungNhanEntity> COMPARISON_FK_iTochucchungnhanID
		{
			get
			{
				return delegate(TaiKhoanDangKyToChucChungNhanEntity entity,TaiKhoanDangKyToChucChungNhanEntity other)
				{
					return entity.FK_iTochucchungnhanID.CompareTo(other.FK_iTochucchungnhanID);
				};
			}
		}
		public static Comparison<TaiKhoanDangKyToChucChungNhanEntity> COMPARISON_dNgaydangky
		{
			get
			{
				return delegate(TaiKhoanDangKyToChucChungNhanEntity entity,TaiKhoanDangKyToChucChungNhanEntity other)
				{
					return entity.dNgaydangky.CompareTo(other.dNgaydangky);
				};
			}
		}
		public static Comparison<TaiKhoanDangKyToChucChungNhanEntity> COMPARISON_bDuyet
		{
			get
			{
				return delegate(TaiKhoanDangKyToChucChungNhanEntity entity,TaiKhoanDangKyToChucChungNhanEntity other)
				{
					return entity.bDuyet.CompareTo(other.bDuyet);
				};
			}
		}
        #endregion
    }
}
