/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/9/2012 9:11:06 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class GroupPermissionEntity
    {
        public GroupPermissionEntity()
        {
			m_igrouppermissionid=0;
			m_igroupid=0;
			m_ipermissionid=0;
			m_svalue="";
        }
		private Int32 m_igrouppermissionid;
		public Int32 iGroupPermissionID
		{
			get { return m_igrouppermissionid ; }
			set { m_igrouppermissionid = value; }
		}
		private Int32 m_igroupid;
		public Int32 iGroupID
		{
			get { return m_igroupid ; }
			set { m_igroupid = value; }
		}
		private Int32 m_ipermissionid;
		public Int32 iPermissionID
		{
			get { return m_ipermissionid ; }
			set { m_ipermissionid = value; }
		}
		private String m_svalue;
		public String sValue
		{
			get { return m_svalue ; }
			set { m_svalue = value; }
		}

        #region Comparison
        public static List<GroupPermissionEntity> Sort(List<GroupPermissionEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(GroupPermissionEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<GroupPermissionEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<GroupPermissionEntity> COMPARISON_iGroupPermissionID
		{
			get
			{
				return delegate(GroupPermissionEntity entity,GroupPermissionEntity other)
				{
					return entity.iGroupPermissionID.CompareTo(other.iGroupPermissionID);
				};
			}
		}
		public static Comparison<GroupPermissionEntity> COMPARISON_iGroupID
		{
			get
			{
				return delegate(GroupPermissionEntity entity,GroupPermissionEntity other)
				{
					return entity.iGroupID.CompareTo(other.iGroupID);
				};
			}
		}
		public static Comparison<GroupPermissionEntity> COMPARISON_iPermissionID
		{
			get
			{
				return delegate(GroupPermissionEntity entity,GroupPermissionEntity other)
				{
					return entity.iPermissionID.CompareTo(other.iPermissionID);
				};
			}
		}
		public static Comparison<GroupPermissionEntity> COMPARISON_sValue
		{
			get
			{
				return delegate(GroupPermissionEntity entity,GroupPermissionEntity other)
				{
					return entity.sValue.CompareTo(other.sValue);
				};
			}
		}
        #endregion
    }
}
