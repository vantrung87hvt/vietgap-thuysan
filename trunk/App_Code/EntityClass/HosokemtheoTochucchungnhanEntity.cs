/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/22/2011 5:52:36 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class HosokemtheoTochucchungnhanEntity
    {
        public HosokemtheoTochucchungnhanEntity()
        {
			m_pk_ihosokemtheoid=0;
			m_fk_igiaytoid=0;
			m_fk_idangkychungnhanvietgapid=0;
        }
		private Int64 m_pk_ihosokemtheoid;
		public Int64 PK_iHosokemtheoID
		{
			get { return m_pk_ihosokemtheoid ; }
			set { m_pk_ihosokemtheoid = value; }
		}
		private Int32 m_fk_igiaytoid;
		public Int32 FK_iGiaytoID
		{
			get { return m_fk_igiaytoid ; }
			set { m_fk_igiaytoid = value; }
		}
		private Int32 m_fk_idangkychungnhanvietgapid;
		public Int32 FK_iDangkyChungnhanVietGapID
		{
			get { return m_fk_idangkychungnhanvietgapid ; }
			set { m_fk_idangkychungnhanvietgapid = value; }
		}

        #region Comparison
        public static List<HosokemtheoTochucchungnhanEntity> Sort(List<HosokemtheoTochucchungnhanEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(HosokemtheoTochucchungnhanEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<HosokemtheoTochucchungnhanEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<HosokemtheoTochucchungnhanEntity> COMPARISON_PK_iHosokemtheoID
		{
			get
			{
				return delegate(HosokemtheoTochucchungnhanEntity entity,HosokemtheoTochucchungnhanEntity other)
				{
					return entity.PK_iHosokemtheoID.CompareTo(other.PK_iHosokemtheoID);
				};
			}
		}
		public static Comparison<HosokemtheoTochucchungnhanEntity> COMPARISON_FK_iGiaytoID
		{
			get
			{
				return delegate(HosokemtheoTochucchungnhanEntity entity,HosokemtheoTochucchungnhanEntity other)
				{
					return entity.FK_iGiaytoID.CompareTo(other.FK_iGiaytoID);
				};
			}
		}
		public static Comparison<HosokemtheoTochucchungnhanEntity> COMPARISON_FK_iDangkyChungnhanVietGapID
		{
			get
			{
				return delegate(HosokemtheoTochucchungnhanEntity entity,HosokemtheoTochucchungnhanEntity other)
				{
					return entity.FK_iDangkyChungnhanVietGapID.CompareTo(other.FK_iDangkyChungnhanVietGapID);
				};
			}
		}
        #endregion
    }
}
