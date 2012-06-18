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
    public class PermissionEntity
    {
        public PermissionEntity()
        {
			m_ipermissionid=0;
			m_sname="";
			m_sdesc="";
        }
		private Int32 m_ipermissionid;
		public Int32 iPermissionID
		{
			get { return m_ipermissionid ; }
			set { m_ipermissionid = value; }
		}
		private String m_sname;
		public String sName
		{
			get { return m_sname ; }
			set { m_sname = value; }
		}
		private String m_sdesc;
		public String sDesc
		{
			get { return m_sdesc ; }
			set { m_sdesc = value; }
		}

        #region Comparison
        public static List<PermissionEntity> Sort(List<PermissionEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(PermissionEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<PermissionEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<PermissionEntity> COMPARISON_iPermissionID
		{
			get
			{
				return delegate(PermissionEntity entity,PermissionEntity other)
				{
					return entity.iPermissionID.CompareTo(other.iPermissionID);
				};
			}
		}
		public static Comparison<PermissionEntity> COMPARISON_sName
		{
			get
			{
				return delegate(PermissionEntity entity,PermissionEntity other)
				{
					return entity.sName.CompareTo(other.sName);
				};
			}
		}
		public static Comparison<PermissionEntity> COMPARISON_sDesc
		{
			get
			{
				return delegate(PermissionEntity entity,PermissionEntity other)
				{
					return entity.sDesc.CompareTo(other.sDesc);
				};
			}
		}
        #endregion
    }
}
