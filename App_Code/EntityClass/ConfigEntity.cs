/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:6/27/2012 10:39:05 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class ConfigEntity
    {
        public ConfigEntity()
        {
			m_iconfigid=0;
			m_sname="";
			m_svalue="";
        }
		private Int32 m_iconfigid;
		public Int32 iConfigID
		{
			get { return m_iconfigid ; }
			set { m_iconfigid = value; }
		}
		private String m_sname;
		public String sName
		{
			get { return m_sname ; }
			set { m_sname = value; }
		}
		private String m_svalue;
		public String sValue
		{
			get { return m_svalue ; }
			set { m_svalue = value; }
		}

        #region Comparison
        public static List<ConfigEntity> Sort(List<ConfigEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(ConfigEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<ConfigEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<ConfigEntity> COMPARISON_iConfigID
		{
			get
			{
				return delegate(ConfigEntity entity,ConfigEntity other)
				{
					return entity.iConfigID.CompareTo(other.iConfigID);
				};
			}
		}
		public static Comparison<ConfigEntity> COMPARISON_sName
		{
			get
			{
				return delegate(ConfigEntity entity,ConfigEntity other)
				{
					return entity.sName.CompareTo(other.sName);
				};
			}
		}
		public static Comparison<ConfigEntity> COMPARISON_sValue
		{
			get
			{
				return delegate(ConfigEntity entity,ConfigEntity other)
				{
					return entity.sValue.CompareTo(other.sValue);
				};
			}
		}
        #endregion
    }
}
