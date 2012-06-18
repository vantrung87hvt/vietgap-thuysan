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
    public class CategoryEntity
    {
        public CategoryEntity()
        {
			m_icategoryid=0;
			m_stitle="";
			m_sdesc="";
			m_iorder=0;
			m_itopid=0;
        }
		private Int32 m_icategoryid;
		public Int32 iCategoryID
		{
			get { return m_icategoryid ; }
			set { m_icategoryid = value; }
		}
		private String m_stitle;
		public String sTitle
		{
			get { return m_stitle ; }
			set { m_stitle = value; }
		}
		private String m_sdesc;
		public String sDesc
		{
			get { return m_sdesc ; }
			set { m_sdesc = value; }
		}
		private Byte m_iorder;
		public Byte iOrder
		{
			get { return m_iorder ; }
			set { m_iorder = value; }
		}
		private Int32 m_itopid;
		public Int32 iTopID
		{
			get { return m_itopid ; }
			set { m_itopid = value; }
		}

        #region Comparison
        public static List<CategoryEntity> Sort(List<CategoryEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(CategoryEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<CategoryEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<CategoryEntity> COMPARISON_iCategoryID
		{
			get
			{
				return delegate(CategoryEntity entity,CategoryEntity other)
				{
					return entity.iCategoryID.CompareTo(other.iCategoryID);
				};
			}
		}
		public static Comparison<CategoryEntity> COMPARISON_sTitle
		{
			get
			{
				return delegate(CategoryEntity entity,CategoryEntity other)
				{
					return entity.sTitle.CompareTo(other.sTitle);
				};
			}
		}
		public static Comparison<CategoryEntity> COMPARISON_sDesc
		{
			get
			{
				return delegate(CategoryEntity entity,CategoryEntity other)
				{
					return entity.sDesc.CompareTo(other.sDesc);
				};
			}
		}
		public static Comparison<CategoryEntity> COMPARISON_iOrder
		{
			get
			{
				return delegate(CategoryEntity entity,CategoryEntity other)
				{
					return entity.iOrder.CompareTo(other.iOrder);
				};
			}
		}
		public static Comparison<CategoryEntity> COMPARISON_iTopID
		{
			get
			{
				return delegate(CategoryEntity entity,CategoryEntity other)
				{
					return entity.iTopID.CompareTo(other.iTopID);
				};
			}
		}
        #endregion
    }
}
