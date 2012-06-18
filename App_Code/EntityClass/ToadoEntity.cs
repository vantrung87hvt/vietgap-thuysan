/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:04/11/2011 4:04:00 CH
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class ToadoEntity
    {
        public ToadoEntity()
        {
			m_pk_itoadoid=0;
			m_latitude="";
			m_longitude="";
        }
		private Int32 m_pk_itoadoid;
		public Int32 PK_iToadoID
		{
			get { return m_pk_itoadoid ; }
			set { m_pk_itoadoid = value; }
		}
		private String m_latitude;
		public String Latitude
		{
			get { return m_latitude ; }
			set { m_latitude = value; }
		}
		private String m_longitude;
		public String Longitude
		{
			get { return m_longitude ; }
			set { m_longitude = value; }
		}

        #region Comparison
        public static List<ToadoEntity> Sort(List<ToadoEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(ToadoEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<ToadoEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<ToadoEntity> COMPARISON_PK_iToadoID
		{
			get
			{
				return delegate(ToadoEntity entity,ToadoEntity other)
				{
					return entity.PK_iToadoID.CompareTo(other.PK_iToadoID);
				};
			}
		}
		public static Comparison<ToadoEntity> COMPARISON_Latitude
		{
			get
			{
				return delegate(ToadoEntity entity,ToadoEntity other)
				{
					return entity.Latitude.CompareTo(other.Latitude);
				};
			}
		}
		public static Comparison<ToadoEntity> COMPARISON_Longitude
		{
			get
			{
				return delegate(ToadoEntity entity,ToadoEntity other)
				{
					return entity.Longitude.CompareTo(other.Longitude);
				};
			}
		}
        #endregion
    }
}
