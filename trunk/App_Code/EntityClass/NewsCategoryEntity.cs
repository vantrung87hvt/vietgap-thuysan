/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:10/26/2011 9:44:41 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class NewsCategoryEntity
    {
        public NewsCategoryEntity()
        {
			m_inewscategoryid=0;
			m_icategoryid=0;
			m_inewsid=0;
        }
		private Int32 m_inewscategoryid;
		public Int32 iNewsCategoryID
		{
			get { return m_inewscategoryid ; }
			set { m_inewscategoryid = value; }
		}
		private Int32 m_icategoryid;
		public Int32 iCategoryID
		{
			get { return m_icategoryid ; }
			set { m_icategoryid = value; }
		}
		private Int32 m_inewsid;
		public Int32 iNewsID
		{
			get { return m_inewsid ; }
			set { m_inewsid = value; }
		}

        #region Comparison
        public static List<NewsCategoryEntity> Sort(List<NewsCategoryEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(NewsCategoryEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<NewsCategoryEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<NewsCategoryEntity> COMPARISON_iNewsCategoryID
		{
			get
			{
				return delegate(NewsCategoryEntity entity,NewsCategoryEntity other)
				{
					return entity.iNewsCategoryID.CompareTo(other.iNewsCategoryID);
				};
			}
		}
		public static Comparison<NewsCategoryEntity> COMPARISON_iCategoryID
		{
			get
			{
				return delegate(NewsCategoryEntity entity,NewsCategoryEntity other)
				{
					return entity.iCategoryID.CompareTo(other.iCategoryID);
				};
			}
		}
		public static Comparison<NewsCategoryEntity> COMPARISON_iNewsID
		{
			get
			{
				return delegate(NewsCategoryEntity entity,NewsCategoryEntity other)
				{
					return entity.iNewsID.CompareTo(other.iNewsID);
				};
			}
		}
        #endregion
    }
}
