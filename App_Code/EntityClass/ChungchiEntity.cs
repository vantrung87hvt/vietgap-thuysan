/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:6/28/2012 3:55:47 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class ChungchiEntity
    {
        public ChungchiEntity()
        {
			m_pk_ichungchiid=0;
			m_stenchungchi="";
			m_smota="";
        }
		private Int32 m_pk_ichungchiid;
		public Int32 PK_iChungchiID
		{
			get { return m_pk_ichungchiid ; }
			set { m_pk_ichungchiid = value; }
		}
		private String m_stenchungchi;
		public String sTenChungchi
		{
			get { return m_stenchungchi ; }
			set { m_stenchungchi = value; }
		}
		private String m_smota;
		public String sMota
		{
			get { return m_smota ; }
			set { m_smota = value; }
		}

        #region Comparison
        public static List<ChungchiEntity> Sort(List<ChungchiEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(ChungchiEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<ChungchiEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<ChungchiEntity> COMPARISON_PK_iChungchiID
		{
			get
			{
				return delegate(ChungchiEntity entity,ChungchiEntity other)
				{
					return entity.PK_iChungchiID.CompareTo(other.PK_iChungchiID);
				};
			}
		}
		public static Comparison<ChungchiEntity> COMPARISON_sTenChungchi
		{
			get
			{
				return delegate(ChungchiEntity entity,ChungchiEntity other)
				{
					return entity.sTenChungchi.CompareTo(other.sTenChungchi);
				};
			}
		}
		public static Comparison<ChungchiEntity> COMPARISON_sMota
		{
			get
			{
				return delegate(ChungchiEntity entity,ChungchiEntity other)
				{
					return entity.sMota.CompareTo(other.sMota);
				};
			}
		}
        #endregion
    }
}
