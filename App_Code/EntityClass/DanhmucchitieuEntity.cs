/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/15/2011 9:17:04 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class DanhmucchitieuEntity
    {
        public DanhmucchitieuEntity()
        {
			m_pk_idanhmucchitieuid=0;
			m_stenchuyenmuc="";
			m_ithutu=0;
        }
		private Int32 m_pk_idanhmucchitieuid;
		public Int32 PK_iDanhmucchitieuID
		{
			get { return m_pk_idanhmucchitieuid ; }
			set { m_pk_idanhmucchitieuid = value; }
		}
		private String m_stenchuyenmuc;
		public String sTenchuyenmuc
		{
			get { return m_stenchuyenmuc ; }
			set { m_stenchuyenmuc = value; }
		}
		private Int16 m_ithutu;
		public Int16 iThutu
		{
			get { return m_ithutu ; }
			set { m_ithutu = value; }
		}

        #region Comparison
        public static List<DanhmucchitieuEntity> Sort(List<DanhmucchitieuEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(DanhmucchitieuEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<DanhmucchitieuEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<DanhmucchitieuEntity> COMPARISON_PK_iDanhmucchitieuID
		{
			get
			{
				return delegate(DanhmucchitieuEntity entity,DanhmucchitieuEntity other)
				{
					return entity.PK_iDanhmucchitieuID.CompareTo(other.PK_iDanhmucchitieuID);
				};
			}
		}
		public static Comparison<DanhmucchitieuEntity> COMPARISON_sTenchuyenmuc
		{
			get
			{
				return delegate(DanhmucchitieuEntity entity,DanhmucchitieuEntity other)
				{
					return entity.sTenchuyenmuc.CompareTo(other.sTenchuyenmuc);
				};
			}
		}
		public static Comparison<DanhmucchitieuEntity> COMPARISON_iThutu
		{
			get
			{
				return delegate(DanhmucchitieuEntity entity,DanhmucchitieuEntity other)
				{
					return entity.iThutu.CompareTo(other.iThutu);
				};
			}
		}
        #endregion
    }
}
