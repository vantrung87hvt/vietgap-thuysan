/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/15/2011 9:17:06 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class PhuongphapkiemtraEntity
    {
        public PhuongphapkiemtraEntity()
        {
			m_pk_iphuongphapkiemtraid=0;
			m_stenphuongphapkiemtra="";
        }
		private Int32 m_pk_iphuongphapkiemtraid;
		public Int32 PK_iPhuongphapkiemtraID
		{
			get { return m_pk_iphuongphapkiemtraid ; }
			set { m_pk_iphuongphapkiemtraid = value; }
		}
		private String m_stenphuongphapkiemtra;
		public String sTenphuongphapkiemtra
		{
			get { return m_stenphuongphapkiemtra ; }
			set { m_stenphuongphapkiemtra = value; }
		}

        #region Comparison
        public static List<PhuongphapkiemtraEntity> Sort(List<PhuongphapkiemtraEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(PhuongphapkiemtraEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<PhuongphapkiemtraEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<PhuongphapkiemtraEntity> COMPARISON_PK_iPhuongphapkiemtraID
		{
			get
			{
				return delegate(PhuongphapkiemtraEntity entity,PhuongphapkiemtraEntity other)
				{
					return entity.PK_iPhuongphapkiemtraID.CompareTo(other.PK_iPhuongphapkiemtraID);
				};
			}
		}
		public static Comparison<PhuongphapkiemtraEntity> COMPARISON_sTenphuongphapkiemtra
		{
			get
			{
				return delegate(PhuongphapkiemtraEntity entity,PhuongphapkiemtraEntity other)
				{
					return entity.sTenphuongphapkiemtra.CompareTo(other.sTenphuongphapkiemtra);
				};
			}
		}
        #endregion
    }
}
