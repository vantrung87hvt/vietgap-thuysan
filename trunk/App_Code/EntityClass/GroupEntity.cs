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
    public class GroupEntity
    {
        public GroupEntity()
        {
			m_igroupid=0;
			m_sname="";
			m_sdesc="";
        }
		private Int32 m_igroupid;
		public Int32 iGroupID
		{
			get { return m_igroupid ; }
			set { m_igroupid = value; }
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
        public static List<GroupEntity> Sort(List<GroupEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(GroupEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<GroupEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<GroupEntity> COMPARISON_iGroupID
		{
			get
			{
				return delegate(GroupEntity entity,GroupEntity other)
				{
					return entity.iGroupID.CompareTo(other.iGroupID);
				};
			}
		}
		public static Comparison<GroupEntity> COMPARISON_sName
		{
			get
			{
				return delegate(GroupEntity entity,GroupEntity other)
				{
					return entity.sName.CompareTo(other.sName);
				};
			}
		}
		public static Comparison<GroupEntity> COMPARISON_sDesc
		{
			get
			{
				return delegate(GroupEntity entity,GroupEntity other)
				{
					return entity.sDesc.CompareTo(other.sDesc);
				};
			}
		}
        #endregion
    }
}
