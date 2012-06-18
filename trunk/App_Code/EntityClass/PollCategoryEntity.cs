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
    public class PollCategoryEntity
    {
        public PollCategoryEntity()
        {
			m_ipollcategoryid=0;
			m_ipollid=0;
			m_icategoryid=0;
        }
		private Int32 m_ipollcategoryid;
		public Int32 iPollCategoryID
		{
			get { return m_ipollcategoryid ; }
			set { m_ipollcategoryid = value; }
		}
		private Int32 m_ipollid;
		public Int32 iPollID
		{
			get { return m_ipollid ; }
			set { m_ipollid = value; }
		}
		private Int32 m_icategoryid;
		public Int32 iCategoryID
		{
			get { return m_icategoryid ; }
			set { m_icategoryid = value; }
		}

        #region Comparison
        public static List<PollCategoryEntity> Sort(List<PollCategoryEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(PollCategoryEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<PollCategoryEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<PollCategoryEntity> COMPARISON_iPollCategoryID
		{
			get
			{
				return delegate(PollCategoryEntity entity,PollCategoryEntity other)
				{
					return entity.iPollCategoryID.CompareTo(other.iPollCategoryID);
				};
			}
		}
		public static Comparison<PollCategoryEntity> COMPARISON_iPollID
		{
			get
			{
				return delegate(PollCategoryEntity entity,PollCategoryEntity other)
				{
					return entity.iPollID.CompareTo(other.iPollID);
				};
			}
		}
		public static Comparison<PollCategoryEntity> COMPARISON_iCategoryID
		{
			get
			{
				return delegate(PollCategoryEntity entity,PollCategoryEntity other)
				{
					return entity.iCategoryID.CompareTo(other.iCategoryID);
				};
			}
		}
        #endregion
    }
}
