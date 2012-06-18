/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:11/24/2011 10:24:59 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class CateFaqEntity
    {
        public CateFaqEntity()
        {
			m_pk_ifaqcateid=0;
			m_scatename="";
			m_sdesc="";
        }
		private Int32 m_pk_ifaqcateid;
		public Int32 PK_iFaqCateID
		{
			get { return m_pk_ifaqcateid ; }
			set { m_pk_ifaqcateid = value; }
		}
		private String m_scatename;
		public String sCateName
		{
			get { return m_scatename ; }
			set { m_scatename = value; }
		}
		private String m_sdesc;
		public String sDesc
		{
			get { return m_sdesc ; }
			set { m_sdesc = value; }
		}

        #region Comparison
        public static List<CateFaqEntity> Sort(List<CateFaqEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(CateFaqEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<CateFaqEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<CateFaqEntity> COMPARISON_PK_iFaqCateID
		{
			get
			{
				return delegate(CateFaqEntity entity,CateFaqEntity other)
				{
					return entity.PK_iFaqCateID.CompareTo(other.PK_iFaqCateID);
				};
			}
		}
		public static Comparison<CateFaqEntity> COMPARISON_sCateName
		{
			get
			{
				return delegate(CateFaqEntity entity,CateFaqEntity other)
				{
					return entity.sCateName.CompareTo(other.sCateName);
				};
			}
		}
		public static Comparison<CateFaqEntity> COMPARISON_sDesc
		{
			get
			{
				return delegate(CateFaqEntity entity,CateFaqEntity other)
				{
					return entity.sDesc.CompareTo(other.sDesc);
				};
			}
		}
        #endregion
    }
}
