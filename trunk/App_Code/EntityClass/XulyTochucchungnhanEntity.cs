/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/28/2011 8:22:28 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class XulyTochucchungnhanEntity
    {
        public XulyTochucchungnhanEntity()
        {
			m_pk_ixulytochucchungnhanid=0;
			m_fk_itochucchungnhanid=0;
			m_slydo="";
			m_imucdo=0;
			m_dngaythuchien=DateTime.Now;
        }
		private Int32 m_pk_ixulytochucchungnhanid;
		public Int32 PK_iXulyTochucchungnhanID
		{
			get { return m_pk_ixulytochucchungnhanid ; }
			set { m_pk_ixulytochucchungnhanid = value; }
		}
		private Int32 m_fk_itochucchungnhanid;
		public Int32 FK_iTochucchungnhanID
		{
			get { return m_fk_itochucchungnhanid ; }
			set { m_fk_itochucchungnhanid = value; }
		}
		private String m_slydo;
		public String sLydo
		{
			get { return m_slydo ; }
			set { m_slydo = value; }
		}
		private Int16 m_imucdo;
		public Int16 iMucdo
		{
			get { return m_imucdo ; }
			set { m_imucdo = value; }
		}
		private DateTime m_dngaythuchien;
		public DateTime dNgaythuchien
		{
			get { return m_dngaythuchien ; }
			set { m_dngaythuchien = value; }
		}

        #region Comparison
        public static List<XulyTochucchungnhanEntity> Sort(List<XulyTochucchungnhanEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(XulyTochucchungnhanEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<XulyTochucchungnhanEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<XulyTochucchungnhanEntity> COMPARISON_PK_iXulyTochucchungnhanID
		{
			get
			{
				return delegate(XulyTochucchungnhanEntity entity,XulyTochucchungnhanEntity other)
				{
					return entity.PK_iXulyTochucchungnhanID.CompareTo(other.PK_iXulyTochucchungnhanID);
				};
			}
		}
		public static Comparison<XulyTochucchungnhanEntity> COMPARISON_FK_iTochucchungnhanID
		{
			get
			{
				return delegate(XulyTochucchungnhanEntity entity,XulyTochucchungnhanEntity other)
				{
					return entity.FK_iTochucchungnhanID.CompareTo(other.FK_iTochucchungnhanID);
				};
			}
		}
		public static Comparison<XulyTochucchungnhanEntity> COMPARISON_sLydo
		{
			get
			{
				return delegate(XulyTochucchungnhanEntity entity,XulyTochucchungnhanEntity other)
				{
					return entity.sLydo.CompareTo(other.sLydo);
				};
			}
		}
		public static Comparison<XulyTochucchungnhanEntity> COMPARISON_iMucdo
		{
			get
			{
				return delegate(XulyTochucchungnhanEntity entity,XulyTochucchungnhanEntity other)
				{
					return entity.iMucdo.CompareTo(other.iMucdo);
				};
			}
		}
		public static Comparison<XulyTochucchungnhanEntity> COMPARISON_dNgaythuchien
		{
			get
			{
				return delegate(XulyTochucchungnhanEntity entity,XulyTochucchungnhanEntity other)
				{
					return entity.dNgaythuchien.CompareTo(other.dNgaythuchien);
				};
			}
		}
        #endregion
    }
}
