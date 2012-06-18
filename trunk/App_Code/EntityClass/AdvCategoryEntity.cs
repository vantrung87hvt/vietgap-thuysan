/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:10/26/2011 9:44:39 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class AdvCategoryEntity
    {
        public AdvCategoryEntity()
        {
			m_iadvcategory=0;
			m_iadvid=0;
			m_icategoryid=0;
        }
		private Int32 m_iadvcategory;
		public Int32 iAdvCategory
		{
			get { return m_iadvcategory ; }
			set { m_iadvcategory = value; }
		}
		private Int32 m_iadvid;
		public Int32 iAdvID
		{
			get { return m_iadvid ; }
			set { m_iadvid = value; }
		}
		private Int32 m_icategoryid;
		public Int32 iCategoryID
		{
			get { return m_icategoryid ; }
			set { m_icategoryid = value; }
		}

        #region Comparison
        public static List<AdvCategoryEntity> Sort(List<AdvCategoryEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(AdvCategoryEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<AdvCategoryEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<AdvCategoryEntity> COMPARISON_iAdvCategory
		{
			get
			{
				return delegate(AdvCategoryEntity entity,AdvCategoryEntity other)
				{
					return entity.iAdvCategory.CompareTo(other.iAdvCategory);
				};
			}
		}
		public static Comparison<AdvCategoryEntity> COMPARISON_iAdvID
		{
			get
			{
				return delegate(AdvCategoryEntity entity,AdvCategoryEntity other)
				{
					return entity.iAdvID.CompareTo(other.iAdvID);
				};
			}
		}
		public static Comparison<AdvCategoryEntity> COMPARISON_iCategoryID
		{
			get
			{
				return delegate(AdvCategoryEntity entity,AdvCategoryEntity other)
				{
					return entity.iCategoryID.CompareTo(other.iCategoryID);
				};
			}
		}
        #endregion
    }
}
