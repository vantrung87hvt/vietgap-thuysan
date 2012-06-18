/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/13/2011 2:12:32 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class TinhEntity
    {
        public TinhEntity()
        {
			m_pk_itinhid=0;
			m_stentinh="";
			m_skyhieu="";
			m_iso31662="";
        }
		private Int16 m_pk_itinhid;
		public Int16 PK_iTinhID
		{
			get { return m_pk_itinhid ; }
			set { m_pk_itinhid = value; }
		}
		private String m_stentinh;
		public String sTentinh
		{
			get { return m_stentinh ; }
			set { m_stentinh = value; }
		}
		private String m_skyhieu;
		public String sKyhieu
		{
			get { return m_skyhieu ; }
			set { m_skyhieu = value; }
		}
		private String m_iso31662;
		public String ISO31662
		{
			get { return m_iso31662 ; }
			set { m_iso31662 = value; }
		}

        #region Comparison
        public static List<TinhEntity> Sort(List<TinhEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(TinhEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<TinhEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<TinhEntity> COMPARISON_PK_iTinhID
		{
			get
			{
				return delegate(TinhEntity entity,TinhEntity other)
				{
					return entity.PK_iTinhID.CompareTo(other.PK_iTinhID);
				};
			}
		}
		public static Comparison<TinhEntity> COMPARISON_sTentinh
		{
			get
			{
				return delegate(TinhEntity entity,TinhEntity other)
				{
					return entity.sTentinh.CompareTo(other.sTentinh);
				};
			}
		}
		public static Comparison<TinhEntity> COMPARISON_sKyhieu
		{
			get
			{
				return delegate(TinhEntity entity,TinhEntity other)
				{
					return entity.sKyhieu.CompareTo(other.sKyhieu);
				};
			}
		}
		public static Comparison<TinhEntity> COMPARISON_ISO31662
		{
			get
			{
				return delegate(TinhEntity entity,TinhEntity other)
				{
					return entity.ISO31662.CompareTo(other.ISO31662);
				};
			}
		}
        #endregion
    }
}
