/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:10/26/2011 9:44:42 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class PositionEntity
    {
        public PositionEntity()
        {
			m_ipositionid=0;
			m_sname="";
        }
		private Int32 m_ipositionid;
		public Int32 iPositionID
		{
			get { return m_ipositionid ; }
			set { m_ipositionid = value; }
		}
		private String m_sname;
		public String sName
		{
			get { return m_sname ; }
			set { m_sname = value; }
		}

        #region Comparison
        public static List<PositionEntity> Sort(List<PositionEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(PositionEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<PositionEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<PositionEntity> COMPARISON_iPositionID
		{
			get
			{
				return delegate(PositionEntity entity,PositionEntity other)
				{
					return entity.iPositionID.CompareTo(other.iPositionID);
				};
			}
		}
		public static Comparison<PositionEntity> COMPARISON_sName
		{
			get
			{
				return delegate(PositionEntity entity,PositionEntity other)
				{
					return entity.sName.CompareTo(other.sName);
				};
			}
		}
        #endregion
    }
}
