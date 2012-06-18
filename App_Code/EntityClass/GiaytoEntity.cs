/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/6/2012 11:12:39 AM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class GiaytoEntity
    {
        public GiaytoEntity()
        {
			m_pk_igiaytoid=0;
			m_stengiayto="";
			m_bcsnt=false;
        }
		private Int32 m_pk_igiaytoid;
		public Int32 PK_iGiaytoID
		{
			get { return m_pk_igiaytoid ; }
			set { m_pk_igiaytoid = value; }
		}
		private String m_stengiayto;
		public String sTengiayto
		{
			get { return m_stengiayto ; }
			set { m_stengiayto = value; }
		}
		private Boolean m_bcsnt;
		public Boolean bCSNT
		{
			get { return m_bcsnt ; }
			set { m_bcsnt = value; }
		}

        #region Comparison
        public static List<GiaytoEntity> Sort(List<GiaytoEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(GiaytoEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<GiaytoEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<GiaytoEntity> COMPARISON_PK_iGiaytoID
		{
			get
			{
				return delegate(GiaytoEntity entity,GiaytoEntity other)
				{
					return entity.PK_iGiaytoID.CompareTo(other.PK_iGiaytoID);
				};
			}
		}
		public static Comparison<GiaytoEntity> COMPARISON_sTengiayto
		{
			get
			{
				return delegate(GiaytoEntity entity,GiaytoEntity other)
				{
					return entity.sTengiayto.CompareTo(other.sTengiayto);
				};
			}
		}
		public static Comparison<GiaytoEntity> COMPARISON_bCSNT
		{
			get
			{
				return delegate(GiaytoEntity entity,GiaytoEntity other)
				{
					return entity.bCSNT.CompareTo(other.bCSNT);
				};
			}
		}
        #endregion
    }
}
