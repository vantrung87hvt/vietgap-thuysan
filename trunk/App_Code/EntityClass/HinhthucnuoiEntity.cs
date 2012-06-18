/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/26/2011 11:53:51 AM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class HinhthucnuoiEntity
    {
        public HinhthucnuoiEntity()
        {
			m_pk_ihinhthucnuoiid=0;
			m_stenhinhthuc="";
        }
		private Int32 m_pk_ihinhthucnuoiid;
		public Int32 PK_iHinhthucnuoiID
		{
			get { return m_pk_ihinhthucnuoiid ; }
			set { m_pk_ihinhthucnuoiid = value; }
		}
		private String m_stenhinhthuc;
		public String sTenhinhthuc
		{
			get { return m_stenhinhthuc ; }
			set { m_stenhinhthuc = value; }
		}

        #region Comparison
        public static List<HinhthucnuoiEntity> Sort(List<HinhthucnuoiEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(HinhthucnuoiEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<HinhthucnuoiEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<HinhthucnuoiEntity> COMPARISON_PK_iHinhthucnuoiID
		{
			get
			{
				return delegate(HinhthucnuoiEntity entity,HinhthucnuoiEntity other)
				{
					return entity.PK_iHinhthucnuoiID.CompareTo(other.PK_iHinhthucnuoiID);
				};
			}
		}
		public static Comparison<HinhthucnuoiEntity> COMPARISON_sTenhinhthuc
		{
			get
			{
				return delegate(HinhthucnuoiEntity entity,HinhthucnuoiEntity other)
				{
					return entity.sTenhinhthuc.CompareTo(other.sTenhinhthuc);
				};
			}
		}
        #endregion
    }
}
