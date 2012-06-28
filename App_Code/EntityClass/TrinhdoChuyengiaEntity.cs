/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:6/28/2012 10:03:02 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class TrinhdoChuyengiaEntity
    {
        public TrinhdoChuyengiaEntity()
        {
			m_pk_itrinhdochuyengiaid=0;
			m_strinhdo="";
        }
		private Int16 m_pk_itrinhdochuyengiaid;
		public Int16 PK_iTrinhdoChuyengiaID
		{
			get { return m_pk_itrinhdochuyengiaid ; }
			set { m_pk_itrinhdochuyengiaid = value; }
		}
		private String m_strinhdo;
		public String sTrinhdo
		{
			get { return m_strinhdo ; }
			set { m_strinhdo = value; }
		}

        #region Comparison
        public static List<TrinhdoChuyengiaEntity> Sort(List<TrinhdoChuyengiaEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(TrinhdoChuyengiaEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<TrinhdoChuyengiaEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<TrinhdoChuyengiaEntity> COMPARISON_PK_iTrinhdoChuyengiaID
		{
			get
			{
				return delegate(TrinhdoChuyengiaEntity entity,TrinhdoChuyengiaEntity other)
				{
					return entity.PK_iTrinhdoChuyengiaID.CompareTo(other.PK_iTrinhdoChuyengiaID);
				};
			}
		}
		public static Comparison<TrinhdoChuyengiaEntity> COMPARISON_sTrinhdo
		{
			get
			{
				return delegate(TrinhdoChuyengiaEntity entity,TrinhdoChuyengiaEntity other)
				{
					return entity.sTrinhdo.CompareTo(other.sTrinhdo);
				};
			}
		}
        #endregion
    }
}
