/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/19/2011 10:55:41 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class CosonuoiEntity
    {
        public CosonuoiEntity()
        {
			m_pk_icosonuoiid=0;
			m_stencoso="";
			m_sdiachi="";
        }
		private Int32 m_pk_icosonuoiid;
		public Int32 PK_iCosonuoiID
		{
			get { return m_pk_icosonuoiid ; }
			set { m_pk_icosonuoiid = value; }
		}
		private String m_stencoso;
		public String sTencoso
		{
			get { return m_stencoso ; }
			set { m_stencoso = value; }
		}
		private String m_sdiachi;
		public String sDiachi
		{
			get { return m_sdiachi ; }
			set { m_sdiachi = value; }
		}

        #region Comparison
        public static List<CosonuoiEntity> Sort(List<CosonuoiEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(CosonuoiEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<CosonuoiEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<CosonuoiEntity> COMPARISON_PK_iCosonuoiID
		{
			get
			{
				return delegate(CosonuoiEntity entity,CosonuoiEntity other)
				{
					return entity.PK_iCosonuoiID.CompareTo(other.PK_iCosonuoiID);
				};
			}
		}
		public static Comparison<CosonuoiEntity> COMPARISON_sTencoso
		{
			get
			{
				return delegate(CosonuoiEntity entity,CosonuoiEntity other)
				{
					return entity.sTencoso.CompareTo(other.sTencoso);
				};
			}
		}
		public static Comparison<CosonuoiEntity> COMPARISON_sDiachi
		{
			get
			{
				return delegate(CosonuoiEntity entity,CosonuoiEntity other)
				{
					return entity.sDiachi.CompareTo(other.sDiachi);
				};
			}
		}
        #endregion
    }
}
