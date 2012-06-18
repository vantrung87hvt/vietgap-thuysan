/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:11/24/2011 10:25:00 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class FaqCategoryEntity
    {
        public FaqCategoryEntity()
        {
			m_pk_ifaqcategoryid=0;
			m_fk_ifaqid=0;
			m_icatefaqid=0;
        }
		private Int64 m_pk_ifaqcategoryid;
		public Int64 PK_iFaqCategoryID
		{
			get { return m_pk_ifaqcategoryid ; }
			set { m_pk_ifaqcategoryid = value; }
		}
		private Int64 m_fk_ifaqid;
		public Int64 FK_iFaqID
		{
			get { return m_fk_ifaqid ; }
			set { m_fk_ifaqid = value; }
		}
		private Int32 m_icatefaqid;
		public Int32 iCateFaqID
		{
			get { return m_icatefaqid ; }
			set { m_icatefaqid = value; }
		}

        #region Comparison
        public static List<FaqCategoryEntity> Sort(List<FaqCategoryEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(FaqCategoryEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<FaqCategoryEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<FaqCategoryEntity> COMPARISON_PK_iFaqCategoryID
		{
			get
			{
				return delegate(FaqCategoryEntity entity,FaqCategoryEntity other)
				{
					return entity.PK_iFaqCategoryID.CompareTo(other.PK_iFaqCategoryID);
				};
			}
		}
		public static Comparison<FaqCategoryEntity> COMPARISON_FK_iFaqID
		{
			get
			{
				return delegate(FaqCategoryEntity entity,FaqCategoryEntity other)
				{
					return entity.FK_iFaqID.CompareTo(other.FK_iFaqID);
				};
			}
		}
		public static Comparison<FaqCategoryEntity> COMPARISON_iCateFaqID
		{
			get
			{
				return delegate(FaqCategoryEntity entity,FaqCategoryEntity other)
				{
					return entity.iCateFaqID.CompareTo(other.iCateFaqID);
				};
			}
		}
        #endregion
    }
}
