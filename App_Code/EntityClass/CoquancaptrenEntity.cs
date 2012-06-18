/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/1/2012 9:47:59 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class CoquancaptrenEntity
    {
        public CoquancaptrenEntity()
        {
			m_pk_icoquancaptrenid=0;
			m_stencoquan="";
        }
		private Int32 m_pk_icoquancaptrenid;
		public Int32 PK_iCoquancaptrenID
		{
			get { return m_pk_icoquancaptrenid ; }
			set { m_pk_icoquancaptrenid = value; }
		}
		private String m_stencoquan;
		public String sTencoquan
		{
			get { return m_stencoquan ; }
			set { m_stencoquan = value; }
		}

        #region Comparison
        public static List<CoquancaptrenEntity> Sort(List<CoquancaptrenEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(CoquancaptrenEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<CoquancaptrenEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<CoquancaptrenEntity> COMPARISON_PK_iCoquancaptrenID
		{
			get
			{
				return delegate(CoquancaptrenEntity entity,CoquancaptrenEntity other)
				{
					return entity.PK_iCoquancaptrenID.CompareTo(other.PK_iCoquancaptrenID);
				};
			}
		}
		public static Comparison<CoquancaptrenEntity> COMPARISON_sTencoquan
		{
			get
			{
				return delegate(CoquancaptrenEntity entity,CoquancaptrenEntity other)
				{
					return entity.sTencoquan.CompareTo(other.sTencoquan);
				};
			}
		}
        #endregion
    }
}
