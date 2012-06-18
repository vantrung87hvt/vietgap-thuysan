/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/19/2011 10:55:45 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class ToadoCosonuoiEntity
    {
        public ToadoCosonuoiEntity()
        {
			m_pk_itoadocosonuoiid=0;
			m_fk_icosonuoiid=0;
			m_slat="";
			m_slon="";
        }
		private Int64 m_pk_itoadocosonuoiid;
		public Int64 PK_iToadocosonuoiID
		{
			get { return m_pk_itoadocosonuoiid ; }
			set { m_pk_itoadocosonuoiid = value; }
		}
		private Int32 m_fk_icosonuoiid;
		public Int32 FK_iCosonuoiID
		{
			get { return m_fk_icosonuoiid ; }
			set { m_fk_icosonuoiid = value; }
		}
		private String m_slat;
		public String sLat
		{
			get { return m_slat ; }
			set { m_slat = value; }
		}
		private String m_slon;
		public String sLon
		{
			get { return m_slon ; }
			set { m_slon = value; }
		}

        #region Comparison
        public static List<ToadoCosonuoiEntity> Sort(List<ToadoCosonuoiEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(ToadoCosonuoiEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<ToadoCosonuoiEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<ToadoCosonuoiEntity> COMPARISON_PK_iToadocosonuoiID
		{
			get
			{
				return delegate(ToadoCosonuoiEntity entity,ToadoCosonuoiEntity other)
				{
					return entity.PK_iToadocosonuoiID.CompareTo(other.PK_iToadocosonuoiID);
				};
			}
		}
		public static Comparison<ToadoCosonuoiEntity> COMPARISON_FK_iCosonuoiID
		{
			get
			{
				return delegate(ToadoCosonuoiEntity entity,ToadoCosonuoiEntity other)
				{
					return entity.FK_iCosonuoiID.CompareTo(other.FK_iCosonuoiID);
				};
			}
		}
		public static Comparison<ToadoCosonuoiEntity> COMPARISON_sLat
		{
			get
			{
				return delegate(ToadoCosonuoiEntity entity,ToadoCosonuoiEntity other)
				{
					return entity.sLat.CompareTo(other.sLat);
				};
			}
		}
		public static Comparison<ToadoCosonuoiEntity> COMPARISON_sLon
		{
			get
			{
				return delegate(ToadoCosonuoiEntity entity,ToadoCosonuoiEntity other)
				{
					return entity.sLon.CompareTo(other.sLon);
				};
			}
		}
        #endregion
    }
}
